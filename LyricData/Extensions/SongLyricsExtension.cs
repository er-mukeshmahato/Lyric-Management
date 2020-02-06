using LyricData.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LyricData.Extensions
{
    public static class SongLyricsExtension
    {
        public static int Totaldata(this ViewModels ext)
        {
            int total = 0;

            foreach (SongLyric d in ext.Data)
            {
                total += d.Id;

            }
            return total;
        }
    }
}
