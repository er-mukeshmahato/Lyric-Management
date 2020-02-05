using LyricData.Models;
using Microsoft.EntityFrameworkCore;


namespace LyricData
{
    public class LyricContext:DbContext
    {
        public LyricContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<SongLyric> Lyrics { get; set; }
        public DbSet<Result> Search { get; set; }
       
    }
}
