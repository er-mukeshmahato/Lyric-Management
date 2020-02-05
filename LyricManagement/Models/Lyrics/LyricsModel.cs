using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LyricManagement.Models.Lyrics
{
    public class LyricsModel
    {
        public IEnumerable<LyricViewModel> Lyrics { get; set; }
    }
}
