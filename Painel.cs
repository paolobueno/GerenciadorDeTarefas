using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GerenciadorTarefas.Models.Enums;
using GerenciadorTarefas.Models;

namespace GerenciadorTarefas
{
    public partial class Painel : UserControl
    {
        private Statuses _status = Statuses.NaoIniciada;
        public Statuses Status
        {
            get { return _status; }
            set
            {
                this._status = value;
                AtualizarLabel();
            }
        }
        public Painel()
        {
            InitializeComponent();
            this.panel.ControlAdded += QteControlesMudada;
            this.panel.ControlRemoved += QteControlesMudada;
        }

        public void Add(TarefaDisplay tarefa)
        {
            // Este método é um dos que parece trivial, mas auxilia bastante no encapsulamento
            // Poderíamos trocar o tipo de panel ou a maneira que as TarefaDisplay são exibidas sem mais problemas
            this.panel.Controls.Add(tarefa);
        }

        private void AtualizarLabel()
        {
            // Atualizar descricao
            string desc = "";
            switch (this.Status)
            {
                case Statuses.NaoIniciada:
                    desc = "Não Iniciadas";
                    break;
                case Statuses.EmAndamento:
                    desc = "Em Andamento";
                    break;
                case Statuses.Concluida:
                    desc = "Concluídas";
                    break;
                default:
                    break;
            }
            this.lblDescricao.Text = String.Format("{0}({1})", desc, this.panel.Controls.Count);
        }
        #region EventHandlers

        /// <summary>
        /// Mantem a quantidade de rows do TableLayoutPanel atualizada
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void QteControlesMudada(object sender, ControlEventArgs e)
        {
            AtualizarLabel();
            // TableLayoutPanel já cria 1 row por controle adicionado
            // mas não as remove conforme os filhos vao embora
            this.panel.RowCount = this.panel.Controls.Count;
        }

        private void Painel_DragEnter(object sender, DragEventArgs e)
        {
            this.BackColor = Color.Red;
            if (e.Data.GetDataPresent(typeof(Tarefa)))
            {
                Tarefa data = (Tarefa)e.Data.GetData(typeof(Tarefa));
                if (CanDrop(data))
                {
                    this.BackColor = Color.Green;
                    e.Effect = DragDropEffects.Move;
                }
            }
        }

        private void Painel_DragLeave(object sender, EventArgs e)
        {
            ResetColor();
        }

        public delegate void DroppedHandler(Painel painel, DragEventArgs e);
        public event DroppedHandler Dropped;
        private void Painel_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(Tarefa)))
            {
                Tarefa data = (Tarefa)e.Data.GetData(typeof(Tarefa));
                if (CanDrop(data))
                {
                    ResetColor();
                    if (Dropped != null)
                    {
                        Dropped.Invoke(this, e);
                    }
                }
            }
        }

        #endregion

        /// <summary>
        /// Método auxiliar para definir regra de permissão de drop
        /// Reduz duplicação e isola a regra caso ela tenha que ser modificada
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        private bool CanDrop(Tarefa t)
        {
            // Deixar tarefa andar 1 status
            // Isso se apoia no fato de status sequenciais terem numeros sequenciais
            return t.Status + 1 == this.Status;
        }
        private void ResetColor()
        {
            this.BackColor = SystemColors.Control;
        }
    }
}
