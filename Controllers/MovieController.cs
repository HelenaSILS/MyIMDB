using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyIMDB.Controllers;
using MyIMDB.Models;
using MyIMDB.ViewModels;

namespace MyIMDB.Controllers
{
    public class MovieController : Controller
    {
        public IActionResult Index(string msg = null)
        {
            var movies = Movie.SelectAll().ConvertAll(m=> new MovieListViewModel()
            {
                Rank = m.Rank,
                Title = m.Title,
                Year = m.Year
            });
            ViewBag.Message = msg;
            return View(movies);
        }

        public IActionResult MovieOfTheMonth()
        {
            var max = Movie.SelectAll().Max(m => m.Rank);
            var movie = Movie.SelectAll().Find(m => m.Rank == max);
            return View(movie);
        }

        //TODO: pesquisar a diferença entre ActionResult e IActionResult
        // IActionResult é uma interface e ActionResult é uma Classe abstrata

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(MovieCreateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // a função RedirectToAction recebe como parâmetro uma string com o nome da Action para qual queremos redirecionar
            // por que se utiliza o "nameof(Index)" em vez de apenas "Index"?
            return RedirectToAction(nameof(Index), new { msg = "Movie created with success" });
        }
    }
}
