using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using dotnetmvc.Context;
using dotnetmvc.Models;
using Microsoft.EntityFrameworkCore;

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

        public IActionResult Atualizar(int Matricula)
        {
            var aluno = _context.Alunos.Find(Matricula);
            if (aluno == null)
            {
                return NotFound($"teste matricula: {Matricula}");
            }
                
            return View(aluno);
        }
        [HttpPost]
        public IActionResult Atualizar(Aluno aluno, int Matricula)
        {
            var alunoBD = _context.Alunos.Find(Matricula);

            /*
                Removendo a entidade alunoBD do rastreamento do Entity Framework.
                É necessário remover para copiar o objeto diretamente, assim como ocorre mais abaixo.
                Sem limpar o rastreador, será disparada uma Exception pois haverá duas entidades com a mesma Primary Key.
                Pode ser feito manualmente, atribuindo os novos valores para cada propriedade.
            */
            _context.Entry(alunoBD).State = EntityState.Detached;
            alunoBD = aluno;

            _context.Alunos.Update(alunoBD);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        // essas actionresult são apenas um redirecionamento para a de cima, porém é ativada em outros botões.
        // requer a matrícula de forma manual (através de um input)
        public IActionResult AtualizarAluno()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AtualizarAluno(int Matricula)
        {
            var aluno = _context.Alunos.Find(Matricula);
            return RedirectToAction(nameof(Atualizar), new {aluno = aluno, Matricula = Matricula});
        }
    }
}