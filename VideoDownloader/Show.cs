using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace VideoDownloader
{
    public class Show : IShow
    {
        public string ShowName { get; set; }
        public string RootUrl { get; set; }
        public int TotalEpisodes { get; set; }
        public int[] SeasonEpisodeStart { get; set; }

        public string Run(int episode, int attempt, out int e, out int s)
        {
            s = 0; e = 0; string url = "";

            if (episode <= TotalEpisodes)
            {
                GetSeasonEpisodeCount(episode, out s, out e);

                url = GetVideoUrl(episode, attempt);
            }

            return url;
        }

        public virtual string GetVideoUrl(int episode, int attempt) { return string.Empty; }     

        public void GetSeasonEpisodeCount(int i, out int s, out int e)
        {
            s = 0; e = 0; int j = 1;
            int totalSeasons = SeasonEpisodeStart.Length;
            if (totalSeasons < 2)
            {
                s = 1;
                e = i;
            }
            else
            {
                while (j <= totalSeasons)
                {
                    if (j == 1 && i < SeasonEpisodeStart[j])
                    {
                        s = 1;
                        e = i;
                        break;
                    }
                    else if (j == totalSeasons)
                    {
                        s = totalSeasons;
                        e = i - SeasonEpisodeStart[j - 1] + 1;
                        break;
                    }
                    else if (i >= SeasonEpisodeStart[j - 1] && i < SeasonEpisodeStart[j])
                    {
                        s = j;
                        e = i - SeasonEpisodeStart[j - 1] + 1;
                        break;
                    }
                    j++;
                }
            }            
        }

        public string GetSeasonEpisodeCountText(int i)
        {
            int s = 0; int e = 0;
            GetSeasonEpisodeCount(i, out s, out e);
            return string.Format("S" + s + "E" + e);
        }

        public string GetHtml(string url)
        {
            string data = "";

            using (WebClient client = new WebClient())
            {
                data = client.DownloadString(url);
            }

            return data;
        }
    }

    public class NarutoShippuden : Show
    {
        public NarutoShippuden()
        {
            ShowName = "Naruto Shippuden";
            RootUrl = "http://www.ryuanime.com/watch/anime/dubbed/naruto-shippuden-episode-";
            TotalEpisodes = 348;
            SeasonEpisodeStart = new[] { 1, 33, 54, 72, 89, 113, 144, 152, 176, 197, 222, 243, 276, 296, 321, 349, 362, 373, 394 };
        }

        public override string GetVideoUrl(int episode, int attempt)
        {
            switch (attempt)
            {
                case 1:
                    return GetSecondLinkNaruto(GetFirstLinkNaruto(RootUrl + episode));
                case 2:
                    return GetSecondLink2Naruto(GetFirstLink2Naruto(RootUrl + episode), episode);
            }
            return string.Empty;
        }

        string GetFirstLinkNaruto(string url)
        {
            string data = GetHtml(url);

            string regex = "</h1><iframe src=\"(.*)\" frameborder";
            Match match = Regex.Match(data, regex);

            if (match.Success) { data = match.Groups[1].Value; }

            return data;
        }

        string GetSecondLinkNaruto(string url)
        {
            string data = GetHtml(url);

            string regex = "url: \"(.*)\"";
            Match match = Regex.Matches(data, regex)[2];

            if (match.Success) { data = match.Groups[1].Value; }

            return data;
        }

        string GetFirstLink2Naruto(string url)
        {
            string data = GetHtml(url);

            string regex = "</h1><IFRAME SRC=\"(.*)\" FRAMEBORDER";
            Match match = Regex.Match(data, regex);

            if (match.Success) { data = match.Groups[1].Value; }

            return data;
        }

        string GetSecondLink2Naruto(string url, int episode)
        {
            string data = GetHtml(url);
            string newUrl = "http://";

            string regex = @"video\|\|(.*)\|flvplayer";
            Match match = Regex.Match(data, regex);

            if (match.Success)
            {
                newUrl += match.Groups[1].Value + ".myvidstream.net:";

                regex = @"\|image\|mp4\|(.*)\|(.*)\|file\|";
                match = Regex.Matches(data, regex)[0];

                if (match.Success) { newUrl += match.Groups[2].Value + "/d/" + match.Groups[1].Value + "/video.mp4"; }
            }

            else
            {

                try
                {
                    regex = @"\|Naruto\|(.*)\|\|(.*)\|file\|";
                    match = Regex.Matches(data, regex)[0];

                    if (match.Success)
                    {
                        newUrl += "fs1.mp4engine.com:";
                        newUrl += match.Groups[2].Value + "/d/" + match.Groups[1].Value + "/Naruto%20Shippuden%20Episode%20" + episode + ".mp4";
                    }
                }

                catch
                {
                    regex = @"\|Naruto\|(.*)\|(.*)\|\|file\|";
                    match = Regex.Matches(data, regex)[0];

                    if (match.Success)
                    {
                        if (episode < 336)
                        {
                            newUrl += "fs1.";
                        }
                        newUrl += "mp4engine.com:";
                        newUrl += match.Groups[2].Value + "/d/" + match.Groups[1].Value + "/Naruto%20Shippuden%20Episode%20" + episode + ".mp4";
                    }
                }
            }

            return newUrl;
        }

    }

    public class AvatarTheLastAirbender : Show
    {
        public AvatarTheLastAirbender()
        {
            ShowName = "Avatar the Last Airbender";
            RootUrl = "http://107.155.78.122/~avatarseries2/ATLA/";
            TotalEpisodes = 61;
            SeasonEpisodeStart = new[] { 1, 21, 41 };
        }

        public override string GetVideoUrl(int episode, int attempt)
        {
            switch (attempt) {
                case 1:
                    return RootUrl + episode.ToString().PadLeft(3, '0') + ".mp4";                    
            }
            return string.Empty;
        }
    }

    public class DragonBall : Show
    {
        public DragonBall()
        {
            ShowName = "Dragon Ball";
            RootUrl = "http://107.155.78.122/~saiyanwatch2/Dragon%20Ball/";
            TotalEpisodes = 153;
            SeasonEpisodeStart = new[] { 1, 29, 54, 102, 123 };
        }

        public override string GetVideoUrl(int episode, int attempt)
        {
            switch (attempt)
            {
                case 1:
                    return RootUrl + episode.ToString().PadLeft(3, '0') + ".mp4";
            }
            return string.Empty;
        }
    }

    public class SwordArtOnline : Show
    {
        public SwordArtOnline()
        {
            ShowName = "Sword Art Online";
            RootUrl = "http://www.ryuanime.io/watch/anime/dubbed/sword-art-online-episode-";
            TotalEpisodes = 25;
            SeasonEpisodeStart = new[] { 1 };
        }

        public override string GetVideoUrl(int episode, int attempt)
        {
            switch (attempt)
            {
                case 1:
                    return GetSecondLink(GetFirstLink(RootUrl + episode), episode);
            }
            return string.Empty;
        }

        string GetFirstLink(string url)
        {
            string data = GetHtml(url);

            string regex = "</h1><IFRAME SRC=\"(.*)\" FRAMEBORDER";
            Match match = Regex.Match(data, regex);

            if (match.Success) { data = match.Groups[1].Value; }

            return data;
        }

        string GetSecondLink(string url, int episode)
        {
            string data = GetHtml(url);
            string newUrl = "http://fs1.mp4engine.com:182/d/";

            string regex = @"\|\|Art\|Sword\|(.*)\|182";
            Match match = Regex.Match(data, regex);

            if (match.Success)
            {
                newUrl += match.Groups[1].Value + "/Sword%20Art%20Online%20(Dub)%20Episode%20" + episode.ToString().PadLeft(3, '0') + "-360p.mp4";
            }

            return newUrl;
        }

    }

    public class SwordArtOnline2 : Show
    {
        public SwordArtOnline2()
        {
            ShowName = "Sword Art Online II";
            RootUrl = "http://www.ryuanime.io/watch/anime/dubbed/sword-art-online-ii-episode-";
            TotalEpisodes = 24;
            SeasonEpisodeStart = new[] { 1 };
        }

        public override string GetVideoUrl(int episode, int attempt)
        {
            switch (attempt)
            {
                case 1:
                    return GetSecondLink(GetFirstLink(RootUrl + episode), episode);
            }
            return string.Empty;
        }

        string GetFirstLink(string url)
        {
            string data = GetHtml(url);

            string regex = "</h1><IFRAME SRC=\"(.*)\" FRAMEBORDER";
            Match match = Regex.Match(data, regex);

            if (match.Success) { data = match.Groups[1].Value; }

            return data;
        }

        string GetSecondLink(string url, int episode)
        {
            string data = GetHtml(url);
            string newUrl = "http://mp4engine.com:182/d/";
            
            string regex = @"mp4\|Sword_Art_Online_II_Episode_(.*)\|(.*)\|182\|file\|";
            Match match = Regex.Match(data, regex);

            if (match.Success)
            {
                newUrl += match.Groups[2].Value + "/Sword_Art_Online_II_Episode_" + episode.ToString().PadLeft(2, '0') + ".mp4";
            }

            else
            {
                regex = @"Online\|Art\|Sword\|\|(.*)\|182\|file\|";
                match = Regex.Match(data, regex);

                if (match.Success)
                {
                    newUrl += match.Groups[1].Value + "/Sword_Art_Online_II_Episode_" + episode.ToString().PadLeft(2, '0') + ".mp4";
                }

                else
                {
                    regex = @"Online\|Art\|\|Sword\|(.*)\|182\|file\|";
                    match = Regex.Match(data, regex);

                    if (match.Success)
                    {
                        newUrl = "http://fs1.mp4engine.com:182/d/" + match.Groups[1].Value + "/Sword%20Art%20Online%20II%20Episode%20" + episode.ToString().PadLeft(2, '0') + ".mp4";
                    }
                }
            }

            return newUrl;
        }

    }

    public class GameOfThrones : Show
    {
        public GameOfThrones()
        {
            ShowName = "Game of Thrones";
            RootUrl = "http://couchtuner.city/";
            SeasonEpisodeStart = new[] { 1, 11, 21, 31, 41, 51, 61 };
            TotalEpisodes = 62;
        }

        public override string GetVideoUrl(int episode, int attempt)
        {
            switch (attempt)
            {
                case 1:
                case 2:
                case 3:
                case 4:
                case 5:
                case 6:
                case 7:
                case 8:
                case 9:
                case 10:
                    int s = 0; int e = 0;
                    GetSeasonEpisodeCount(episode, out s, out e);
                    return GetSecondLink(GetFirstLink(RootUrl + attempt + "/game-of-thrones-season-" + s + "-episode-" + e));
                case 11:
                case 12:
                case 13:
                case 14:
                case 15:
                case 16:
                case 17:
                case 18:
                case 19:
                case 20:
                    GetSeasonEpisodeCount(episode, out s, out e);
                    return GetSecondLink(GetFirstLink(RootUrl + (attempt - 10) + "/" + s.ToString() + e.ToString()));
                case 21:
                case 22:
                case 23:
                case 24:
                case 25:
                case 26:
                case 27:
                case 28:
                case 29:
                case 30:
                    GetSeasonEpisodeCount(episode, out s, out e);
                    return GetSecondLink(GetFirstLink(RootUrl + (attempt - 20) + "/game-of-thrones-s" + s + "-e" + e));
            }
            return string.Empty;
        }

        string GetFirstLink(string url)
        {
            string data = GetHtml(url);
            string newUrl = "http://vidspot.net/embed-";

            string regex = @"<iframe src=""http://vidspot\.net/embed-(.*)"" frameborder=0";
            Match match = Regex.Match(data, regex);

            if (match.Success)
            {
                newUrl += match.Groups[1].Value;
            }

            return newUrl;
        }

        string GetSecondLink(string url)
        {
            string data = GetHtml(url);
            string newUrl = "";

            string regex = @"""file"" : ""(.*)"",\s*""default"" : false,\s*""label"" : ""720o""";
            Match match = Regex.Match(data, regex);

            if (match.Success)
            {
                newUrl = match.Groups[1].Value;
            }
            else
            {
                regex = @"""file"" : ""(.*)"",\s*""default"" : true,\s*""label"" : ""720o""";
                match = Regex.Match(data, regex);

                if (match.Success)
                {
                    newUrl = match.Groups[1].Value;
                }
            }

            return newUrl;
        }

    }

    public class TeenTitans : Show
    {
        public TeenTitans()
        {
            ShowName = "Teen Titans";
            RootUrl = "http://www.watchseries.ac/episode/teen_titans_s";
            TotalEpisodes = 65;
            SeasonEpisodeStart = new[] { 1 , 14, 27, 40, 53};
        }

        public override string GetVideoUrl(int episode, int attempt)
        {
            int s, e = 0;
            GetSeasonEpisodeCount(episode, out s, out e);
            string url = RootUrl + s + "_e" + e + ".html";

            switch (attempt)
            {                
                case 1:
                    return GetThirdLink(GetSecondLink(GetFirstLink(url), episode), episode);
            }
            return string.Empty;
        }

        string GetFirstLink(string url)
        {
            string data = GetHtml(url);

            string regex = "<a href=\"/link/vodlocker.com/(.*)\" class=\"buttonlink\" target=\"_blank\" title=\"vodlocker.com\"";
            Match match = Regex.Match(data, regex);

            if (match.Success) { data = match.Groups[1].Value; }

            return "http://www.watchseries.ac/link/vodlocker.com/" + data;
        }

        
            string GetSecondLink(string url, int episode)
        {
            string data = GetHtml(url);
            string newUrl = "";

            string regex = "<IFRAME style=\"max-width: 850px;\" SRC=\"(.*)\" FRAMEBORDER=0";
            Match match = Regex.Match(data, regex);

            if (match.Success)
            {
                newUrl = match.Groups[1].Value;
            }

            return newUrl;
        }
        string GetThirdLink(string url, int episode)
        {
            string data = GetHtml(url);
            string newUrl = "";

            string regex = @"file: ""http://(.*).mp4"",";
            Match match = Regex.Match(data, regex);

            if (match.Success)
            {
                newUrl = "http://" + match.Groups[1].Value + ".mp4";
            }

            return newUrl;
        }

    }
}

