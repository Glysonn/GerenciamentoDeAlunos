using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using dotnetmvc.Context;
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
    }
}