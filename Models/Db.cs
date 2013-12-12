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
        public Db()
            : base(@"Data Source=(localdb)\v11.0;Initial Catalog=GerenciadorTarefas;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False")
        {
        }
        public DbSet<Tarefa> Tarefas { get; set; }
    }
}
