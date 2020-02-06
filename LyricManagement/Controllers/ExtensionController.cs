using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LyricData;
using LyricData.Extensions;
using LyricData.Models;
using Microsoft.AspNetCore.Mvc;

namespace LyricManagement.Controllers
{
    public class ExtensionController : Controller
    {
        private readonly ILyrics _cc;

        public ExtensionController(ILyrics cc)
        {
            _cc = cc;
        }
        public IActionResult Index()
        {
            var data = _cc.GetAllLyric();
            foreach (var item in data)
            {
                ViewModels ext = new ViewModels()
                {

                    Data = new List<SongLyric>()
                {
                   new SongLyric{Id=item.Id },
                }
                };
                ViewBag.total = ext.Totaldata();

            }



          


            return View();
        }
    }
}