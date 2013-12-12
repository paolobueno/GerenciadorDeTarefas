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

        private List<TarefaDisplay> tarefas = new List<TarefaDisplay>();

        public Painel()
        {
            InitializeComponent();
            this.panel.ColumnCount = 1;
        }

        public void Add(TarefaDisplay tarefa)
        {
            this.tarefas.Add(tarefa);
            this.panel.Controls.Add(tarefa);

            AtualizarLabel();
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
            this.lblDescricao.Text = String.Format("{0}({1})", desc, this.tarefas.Count);
        }
    }
}
