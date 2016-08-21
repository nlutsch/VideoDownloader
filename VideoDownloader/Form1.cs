using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VideoDownloader
{
    public partial class Form1 : Form
    {
        #region Global Variables
        string RootDownloadPath = "Z:/TV Shows/";
        int FirstEpisode = 0;
        int LastEpisode = 0;
        int Current = 0;
        bool pbar1Used = false;
        bool pbar2Used = false;
        SortedDictionary<string, IShow> shows;
        IShow currentShow;
        #endregion

        public Form1()
        {
            InitializeComponent();
            shows = InitializeShows();
            cbShow.DataSource = new BindingSource(shows, null);
            cbShow.DisplayMember = "Key";
            cbShow.ValueMember = "Key";
            currentShow = shows.First().Value;
            tbEpisodef.Text = currentShow.TotalEpisodes.ToString();
            lblE0.Text = "S1E1";
            lblEf.Text = currentShow.GetSeasonEpisodeCountText(currentShow.TotalEpisodes);
        }

        SortedDictionary<string, IShow> InitializeShows()
        {
            SortedDictionary<string, IShow> dictShows = new SortedDictionary<string, IShow>();

            List<Show> listOfShows = GetInstances<Show>();
            foreach (var show in listOfShows)
            {
                dictShows.Add(show.ShowName, show);
            }

            return dictShows;
        }

        private static List<Show> GetInstances<Show>()
        {
            return (from t in Assembly.GetExecutingAssembly().GetTypes()
                    where t.GetInterfaces().Contains(typeof(IShow)) && t.GetConstructor(Type.EmptyTypes) != null && t.IsSubclassOf(typeof(Show))
                    select (Show)Activator.CreateInstance(t)).ToList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            WebRequest.DefaultWebProxy = GlobalProxySelection.GetEmptyWebProxy();
            int e0 = int.Parse(tbEpisode0.Text);
            int ef = int.Parse(tbEpisodef.Text);
            currentShow = shows[cbShow.Text];
            RootDownloadPath = tbSaveLocation.Text;

            if (e0 < 1 || ef > currentShow.TotalEpisodes)
            {
                MessageBox.Show("Invalid episode numbers");
                return;
            }
            FirstEpisode = e0;
            LastEpisode = ef;
            Current = FirstEpisode;

            Run(Current);
            Run(++Current);
        }

        void Run(int episode) {
            if (Current <= LastEpisode)
            {
                int e = 0; int s = 0; int attempt = 1; string url = ".";

                while (!string.IsNullOrEmpty(url))
                {
                    try
                    {
                        url = currentShow.Run(episode, attempt, out e, out s);
                        if (string.IsNullOrEmpty(url))
                        {
                            MessageBox.Show("Could not download episode " + Current);
                            break;
                        }
                        DownloadVideo(url, s, e);
                        break;
                    }
                    catch
                    {
                        attempt++;
                    }
                }
            }
        }

        string GetHtml(string url)
        {
            string data = "";

            using (WebClient client = new WebClient())
            {
                data = client.DownloadString(url);
            }

            return data;
        }
        
        void DownloadVideo(string url, int season, int episode)
        {
            #region Directory Check/Creation
            if (!Directory.Exists(RootDownloadPath))
            {
                Directory.CreateDirectory(RootDownloadPath);
            }
            if (!Directory.Exists(RootDownloadPath + currentShow.ShowName))
            {
                Directory.CreateDirectory(RootDownloadPath + currentShow.ShowName);
            }
            if (!Directory.Exists(RootDownloadPath + currentShow.ShowName + "/Season " + season))
            {
                Directory.CreateDirectory(RootDownloadPath + currentShow.ShowName + "/Season " + season);
            }
            #endregion

            ProgressBar pbar = null;
            Label lblProgress = null;
            Label lblPercent = null;
            if (!pbar1Used)
            {
                pbar = progressBar1;
                lblProgress = lblProgress1;
                lblPercent = lblPercent1;
                pbar1Used = true;
            }

            else if (!pbar2Used)
            {
                pbar = progressBar2;
                lblProgress = lblProgress2;
                lblPercent = lblPercent2;
                pbar2Used = true;
            }

            else
                MessageBox.Show("Two downloads already running");

            pbar.Minimum = 0;
            pbar.Maximum = 100;
            pbar.Value = 0;

            using (WebClient client = new WebClient())
            {
                client.Proxy = GlobalProxySelection.GetEmptyWebProxy();
                client.Headers.Add("User-Agent: Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/49.0.2623.110 Safari/537.36");

                lblProgress.Text ="Downloading: Season " + season + " Episode " + episode.ToString().PadLeft(3, '0');

                client.DownloadProgressChanged += (s, e) =>
                {
                    pbar.Value = e.ProgressPercentage;
                    lblPercent.Text = e.ProgressPercentage + "%";
                };

                client.DownloadFileCompleted += (s, e) =>
                {
                    lblProgress.Text = "Download Complete!";
                    if (pbar == progressBar1) 
                        pbar1Used = false;
                    else
                        pbar2Used = false;

                    Run(++Current);
                };

                string saveLocation = RootDownloadPath + currentShow.ShowName + "/Season " + season + "/" + currentShow.ShowName + " S" + season + "E" + episode + ".mp4";
                client.DownloadFileAsync(new Uri(url), saveLocation);
            }
        }

        private void cbShow_SelectionChangeCommited(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cbShow.Text) && !cbShow.Text.Contains('['))
            {
                IShow currentSelected = shows[cbShow.Text];

                tbEpisodef.Text = currentSelected.TotalEpisodes.ToString();

                if (int.Parse(tbEpisode0.Text) > currentSelected.TotalEpisodes)
                    lblE0.Text = "N/A";
                else
                    lblE0.Text = currentSelected.GetSeasonEpisodeCountText(int.Parse(tbEpisode0.Text));

                if (int.Parse(tbEpisodef.Text) > currentSelected.TotalEpisodes)
                    lblEf.Text = "N/A";
                else
                    lblEf.Text = currentSelected.GetSeasonEpisodeCountText(int.Parse(tbEpisodef.Text));
            }      
        }     
        private void tbEpisode0_Leave(object sender, EventArgs e)
        {
            IShow currentSelected = shows[cbShow.Text];

            if (int.Parse(tbEpisode0.Text) > currentSelected.TotalEpisodes)
                lblE0.Text = "N/A";
            else
                lblE0.Text = currentSelected.GetSeasonEpisodeCountText(int.Parse(tbEpisode0.Text));
        }
        private void tbEpisodef_Leave(object sender, EventArgs e)
        {
            IShow currentSelected = shows[cbShow.Text];

            if (int.Parse(tbEpisodef.Text) > currentSelected.TotalEpisodes)
                lblEf.Text = "N/A";
            else
                lblEf.Text = currentSelected.GetSeasonEpisodeCountText(int.Parse(tbEpisodef.Text));
        }
    }
}
 