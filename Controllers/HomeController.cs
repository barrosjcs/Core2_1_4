using Fiap01.Data;
using Fiap01.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap01.Controllers
{
    public class HomeController : Controller
    {
        PerguntasContext _context;

        public HomeController(PerguntasContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            ViewBag.Nome = "Jefferson";
            ViewData["NomeDoAluno"] = $"Outro nome na data {DateTime.Now.ToShortDateString()}";

            //var pergunta = new Pergunta()
            //{
            //    Id = 1,
            //    Autor = "Jefferson",
            //    Descricao = "Dono da porra toda"
            //};


            return View(_context.Perguntas.ToList());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Pergunta model)
        {
            if (ModelState.IsValid)
            {
                _context.Perguntas.Add(model);
                await _context.SaveChangesAsync();
                var pergunta = model;
            }

            return View();
        }

        public IActionResult Sobre()
        {
            return View();
        }

        public IActionResult Ajuda()
        {
            return View();
        }
    }
}
