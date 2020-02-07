using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using LyricData;
using LyricData.Extensions;
using LyricData.Models;
using LyricManagement.Models;
using LyricManagement.Models.Lyrics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LyricManagement.Controllers
{
    public class SongLyricsController : Controller
    {
        private readonly ILyrics _cc;
      
        public SongLyricsController(ILyrics cc)
        {
            _cc = cc;
        }
      
        public IActionResult Index()
        {
            var result = _cc.GetAllLyric().ToList();
            return View(result);
        }
        public IActionResult Home()
        {
            return View();
        }
        public IActionResult Data()
        {
            var assetModels = _cc.GetAllLyric().ToList();
            return View(assetModels);
        }

     
       
        public IActionResult Detail(int id)
        {
            var song = _cc.GetById(id);
            if (song == null)
            {

                return RedirectToAction("nofound");

            }
           


            
            return View(song);
        }
        public async Task<IActionResult> Search(string word, int? pageNumber, string sortOrder, string currentFilter)
        {

          
            var data = _cc.GetAllLyric();
            Stopwatch sw = Stopwatch.StartNew();

            ViewData["CurrentSort"] = sortOrder;
          
            if (word != null)
            {
                pageNumber = 1;
            }
            else
            {
                word = currentFilter;
            }
            ViewData["CurrentFilter"] = word;
           
            var song = _cc.GetAll(word);
           
           
            int pageSize = 10;
            ViewBag.found = song.Count();

         
            sw.Stop();
            ViewBag.time = sw.Elapsed.TotalSeconds;
            foreach (var item in data)
            {
                ViewModels ext = new ViewModels()
                {

                    Data = new List<SongLyric>()
                {
                   new SongLyric{Id=item.Id },
                }
                };
                ///////extension////method//////
                ViewBag.total = ext.Totaldata();

            }




            return View(await PaginatedList<SongLyric>.CreateAsync(song.AsNoTracking(), pageNumber ?? 1, pageSize));
          
         
        }
        public IActionResult Delete(int id)
        {

            var data = _cc.GetById(id);
            if (data == null)
            {
                return RedirectToAction("nofound");

            }
            
            return View(data);

        }
      
        public IActionResult DeleteConfirm(int id)
        {
            _cc.delete(id);
            return RedirectToAction("Search");
        }
           

        [HttpGet]
        public IActionResult Create()
        {
            return View();

        }
        [HttpPost]
        public IActionResult Create( SongLyric song)
        {
            if (ModelState.IsValid)
            {
                _cc.Add(song);
                return RedirectToAction("Search");
            }
            return View(song);

        }
        public IActionResult Edit(int id)
        {
            var data = _cc.GetById(id);
            if (data == null)
            {
                return RedirectToAction("nofound");

            }
            return View(data);
        }
        [HttpPost]
        public IActionResult Edit(int id, SongLyric song)
        {
            if (ModelState.IsValid)
            {
                _cc.update(song);
                return RedirectToAction("Data");
            }
            return View(song);

        }
        public IActionResult nofound()
        {
            return View();
        }



    }
}