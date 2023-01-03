using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using dotnetmvc.Context;
using dotnetmvc.Models;

namespace dotnetmvc.Controllers
{
    public class AlunoController : Controller
    {
        // criando uma propriedade do tipo EscolaContext (o banco de dados)
        private readonly EscolaContext _context;

        // atribuindo à propriedade _context o valor que é o próprio banco de dados
        public AlunoController (EscolaContext context)
        {
            _context = context;
        }

        // rota index
        public IActionResult Index()
        {
            var alunos = _context.Alunos.ToList();
            return View(alunos);
        }

        public IActionResult Adicionar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Adicionar(Aluno aluno)
        {
            if (ModelState.IsValid)
            {
                _context.Alunos.Add(aluno);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(aluno);
        }
    }
}