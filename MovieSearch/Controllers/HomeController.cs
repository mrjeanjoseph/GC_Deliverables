﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MovieSearch.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MovieSearch.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly MovieDAL _movieDAL = new MovieDAL();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult MovieSearch()
        {
            //Default method
            return View();
        }

        [HttpPost]
        public IActionResult MovieSearch(string title = "")
        {
            MovieModel movie = new MovieModel();
            if (title != "")
            {
                movie = _movieDAL.ConvertMovieData(title);
                return (IActionResult)movie;

            }
            else
            {
                return MovieSearch();
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
