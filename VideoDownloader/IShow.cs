using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoDownloader
{
    interface IShow
    {
        string ShowName { get; set; }
        string RootUrl { get; set; }
        int TotalEpisodes { get; set; }
        int[] SeasonEpisodeStart { get; set; }
        string Run(int episode, int attempt, out int ep, out int seas);
        string GetSeasonEpisodeCountText(int i);
    }
}
