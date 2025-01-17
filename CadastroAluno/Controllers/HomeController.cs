﻿using CadastroAluno.Data;
using CadastroAluno.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroAluno.Controllers
{
    public class HomeController : Controller
    {
        private CadastroAlunoContext _context;

        public HomeController(CadastroAlunoContext context)
        {
            _context = context;
        }

        public IActionResult Index(int id)
        {
            return View(_context.Aluno);
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
