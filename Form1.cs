using GerenciadorTarefas.Models;
using GerenciadorTarefas.Models.Enums;
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
        private Db db = new Db();
        private TarefaDisplay dragging;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Ler tarefas do banco
            foreach (var t in db.Tarefas)
            {
                this.AddTarefa(t);
            }
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
            db.Tarefas.Add(t);
            db.SaveChangesAsync();
            this.AddTarefa(t);

            txtTarefaDescricao.Text = "";
            txtTarefaDescricao.Focus();
        }

        private void AddTarefa(Tarefa t)
        {
            t.PropertyChanged += TarefaPropertyChanged;
            TarefaDisplay td = new TarefaDisplay(t);
            td.DragStart += DragStart;
            td.DragEnd += DragEnd;

            switch (t.Status)
            {
                case Statuses.NaoIniciada:
                    this.pnlNaoIniciadas.Add(td);
                    break;
                case Statuses.EmAndamento:
                    this.pnlEmAndamento.Add(td);
                    break;
                case Statuses.Concluida:
                    this.pnlConcluidas.Add(td);
                    break;
            }
        }

        void TarefaPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            Tarefa t = (Tarefa)sender;
            db.SaveChanges();
        }

        void DragStart(TarefaDisplay td, MouseEventArgs e)
        {
            this.dragging = td;
            this.Cursor = Cursors.SizeAll;
        }

        void DragEnd(TarefaDisplay td, MouseEventArgs e)
        {
            this.dragging = null;
            this.Cursor = Cursors.Default;
        }

        private void painelDropped(Painel painel, DragEventArgs e)
        {
            painel.Add(this.dragging);

            Tarefa t = this.dragging.Tarefa;
            t.Status = painel.Status;
            UpdateTempos(t);
        }

        private static void UpdateTempos(Tarefa t)
        {
            switch (t.Status)
            {
                case Statuses.EmAndamento:
                    t.Inicio = DateTime.Now;
                    break;
                case Statuses.Concluida:
                    t.Fim = DateTime.Now;
                    break;
            }
        }

    }
}
