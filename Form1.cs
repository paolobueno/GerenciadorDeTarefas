using GerenciadorTarefas.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GerenciadorTarefas
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Tarefa t = new Tarefa
            {
                Inicio = DateTime.Now,
                Fim = DateTime.Now.AddHours(5),
                Id = 1,
                Descricao = "Hello",
                Status = Models.Enums.Statuses.NaoIniciada
            };
            TarefaDisplay td = new TarefaDisplay(t);
            TarefaDisplay td2 = new TarefaDisplay(t);
            TarefaDisplay td3 = new TarefaDisplay(t);
            this.pnlNaoIniciadas.Add(td);
            this.pnlNaoIniciadas.Add(td2);
            this.pnlNaoIniciadas.Add(td3);
        }

        private void btnCriar_Click(object sender, EventArgs e)
        {
            this.CriarTarefa();
        }

        private void CriarTarefa()
        {
            throw new NotImplementedException();
        }
    }
}
