using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LyricManagement.Models.Lyrics
{
    public class LyricViewModel
    {
        public int Id  { get; set; }
        public string Title { get; set; }
        public string image { get; set; }
        public string Artist { get; set; }
        public string Views { get; set; }
        public string Year { get; set; }
        public string Lyrics { get; set; }

    }
}
