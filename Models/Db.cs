using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorTarefas.Models
{
    class Db : DbContext
    {
        public DbSet<Tarefa> Tarefas { get; set; }
    }
}
