using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LyricData.Models
{
    public class SongLyric
    {
        public int Id { get; set; }

     
        public string Title { get; set; }
     
        public string Artist { get; set; }     
        public string Image { get; set; }

      
        public string Views { get; set; }

       
        public string Year { get; set; }

        public string Lyrics { get; set; }
       
       


    }
}
