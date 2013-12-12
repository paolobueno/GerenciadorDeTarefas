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
        }

        private void btnCriar_Click(object sender, EventArgs e)
        {
            this.CriarTarefa();
        }

        private void CriarTarefa()
        {
            string descricao = txtTarefaDescricao.Text.Trim();
            if (descricao == "")
            {
                MessageBox.Show("Descrição deve ser preenchida!");
                txtTarefaDescricao.Focus();
                return;
            }

            Tarefa t = new Tarefa()
            {
                Id = 1,
                Descricao = descricao,
                Status = Models.Enums.Statuses.NaoIniciada,
            };
            this.AddTarefa(t);

            txtTarefaDescricao.Text = "";
            txtTarefaDescricao.Focus();
        }

        private void AddTarefa(Tarefa t)
        {
            TarefaDisplay td = new TarefaDisplay(t);
            pnlNaoIniciadas.Add(td);
        }
    }
}
