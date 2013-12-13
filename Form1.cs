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
        /// <summary>
        /// Tracking de qual elemento está sendo arrastado
        /// </summary>
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
                Descricao = descricao,
                Status = Models.Enums.Statuses.NaoIniciada,
            };
            db.Tarefas.Add(t);
            db.SaveChanges();
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

        #region EventHandlers
        /// <summary>
        /// Ouve por mudanças em todas as tarefas, persistindo-as imediatamente no banco de dados
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void TarefaPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            Tarefa t = (Tarefa)sender;
            db.SaveChanges();
        }
        /// <summary>
        /// Configura o cursor corrento quando o drag começa
        /// </summary>
        /// <param name="td"></param>
        /// <param name="e"></param>
        void DragStart(TarefaDisplay td, MouseEventArgs e)
        {
            this.dragging = td;

            ShowBalloonTip(td);

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
        #endregion

        private void ShowBalloonTip(TarefaDisplay td)
        {
            string message = "";
            switch (td.Tarefa.Status)
            {
                case Statuses.NaoIniciada:
                    message = "Em Andamento";
                    break;
                case Statuses.EmAndamento:
                    message = "Concluída";
                    break;
            }

            this.notifyIcon1.BalloonTipText = String.Format("Esta tarefa pode se tornar '{0}'", message);
            this.notifyIcon1.ShowBalloonTip(1000);
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
