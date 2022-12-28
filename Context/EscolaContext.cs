using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnetmvc.Models;
using Microsoft.EntityFrameworkCore;

namespace dotnetmvc.Context
{
    public class EscolaContext : DbContext
    {
        public EscolaContext(DbContextOptions<EscolaContext> options) : base (options)
        {

        }

        public DbSet<Aluno> Alunos { get; set; }
    }
}