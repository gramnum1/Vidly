﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;



namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        
        
        // GET: Movies/Random
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Shrek!" };
            //CGH View Models Customer List
            var customers = new List<Customer>
            {
                new Customer { Name = "Customer 1"},
                new Customer { Name = "Customer 2"}
            };

            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };

            return View(viewModel);
            //CGH View Data
            //ViewData["Movie"] = movie;
            //CGH ViewBag
            //ViewBag.Movie = movie;
            //return View(movie);


            //return Content("Hello World");
            //return HttpNotFound();
            //return new EmptyResult();
            //return RedirectToAction("Index", "Home", new { page = 1, sortBy = "name");
        }

        public ActionResult Edit(int id)
        {
            return Content("id=" + id);

        }

        public ActionResult Index(int? pageIndex, string sortBy)
        {
            if (!pageIndex.HasValue)
                pageIndex = 1;

            if (String.IsNullOrWhiteSpace(sortBy))
                sortBy = "Name";

            return Content(String.Format("pageIndex = {0}&sortBy={1}", pageIndex, sortBy));
        }

        //CGH Attribute Routing
        [Route("movies/released/{year:regex(\\d{4}):range(1900,3000)}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);

        }


    }
}