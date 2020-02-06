using LyricData;
using LyricData.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LyricServices
{
    public class SongLyricServices : ILyrics
    {
        private readonly LyricContext _context;
       
        public SongLyricServices(LyricContext context)
        {
             _context = context;
        }
        public void Add(SongLyric newLyric)
        {
            _context.Add(newLyric);
            _context.SaveChanges();
        }

       

        public void delete(int id)
        {
            SongLyric song = GetById(id);
            _context.Remove(song);
            _context.SaveChanges();



        }

      

        public IQueryable<SongLyric> GetAll(string find)
        {
            return _context.Lyrics.Where(p => p.Title.ToLower().Contains(find)
            || p.Lyrics.ToLower().Contains(find) || p.Artist.ToLower().Contains(find));
        }

        public IEnumerable<SongLyric> GetAllLyric()
        {
            return _context.Lyrics.ToList();
                 

        }

        public SongLyric GetById(int id)
        {
            return _context.Lyrics.Where(lyrics => lyrics.Id == id).FirstOrDefault();
               
        }

        public void update(SongLyric song)
        {
            _context.Update(song);
            _context.SaveChanges();

        }
    }
}
