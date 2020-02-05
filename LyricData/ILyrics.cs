using LyricData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LyricData
{
    public  interface ILyrics
    {
        IEnumerable<SongLyric> GetAllLyric();
        IQueryable<SongLyric> GetAll(string find);

        SongLyric GetById(int id);
        void Add(SongLyric newLyric);
        void delete(int id);
        void Delete(SongLyric song);

        void update(SongLyric song);


        

    }
}
