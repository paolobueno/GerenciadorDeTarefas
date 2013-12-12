using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GerenciadorTarefas.Models;
using GerenciadorTarefas.Models.Enums;

namespace GerenciadorTarefas
{
    public partial class TarefaDisplay : UserControl
    {
        private Models.Tarefa _tarefa;
        public Tarefa Tarefa
        {
            get { return _tarefa; }
            set
            {
                if (value != null)
                {
                    if (this._tarefa != null)
                        SetTarefaEventHandlers();
                    this._tarefa = value;
                    UnsetEventHandlers();
                    this.Display();
                }
            }
        }

        public TarefaDisplay()
        {
            InitializeComponent();
        }

        public TarefaDisplay(Tarefa tarefa)
            : this()
        {
            this.Tarefa = tarefa;
            this.MouseDown += MDown;
            this.DragStart += TarefaDisplay_DragStart;
            this.DragEnd += TarefaDisplay_DragEnd;
            // Prevenir cursores de Drag&Drop
            this.GiveFeedback += TarefaDisplay_GiveFeedback;
        }

        private void DisplayComplementar()
        {
            Color cor = this.Tarefa.Cor;
            this.BackColor = Color.FromArgb(255 - cor.R, 255 - cor.G, 255 - cor.B);
        }

        private void UnsetEventHandlers()
        {
            this._tarefa.PropertyChanged += this.TarefaPropertyChanged;
        }

        private void SetTarefaEventHandlers()
        {
            this._tarefa.PropertyChanged -= this.TarefaPropertyChanged;
        }

        void TarefaPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            this.Display();
        }
        private void Display()
        {
            this.lblId.Text = string.Format("Tarefa #{0}", _tarefa.Id);
            this.lblDescricao.Text = _tarefa.Descricao;
            if (_tarefa.Status >= Statuses.EmAndamento)
            {
                this.lblInicioCaption.Visible = true;
                this.lblInicio.Visible = true;
                this.lblInicio.Text = _tarefa.Inicio.ToString();
            }
            else
            {
                this.lblInicio.Visible = false;
                this.lblInicioCaption.Visible = false;
            }

            if (_tarefa.Status >= Statuses.Concluida)
            {
                this.lblFim.Visible = true;
                this.lblFimCaption.Visible = true;
                this.lblFim.Text = _tarefa.Fim.ToString();
            }
            else
            {
                this.lblFim.Visible = false;
                this.lblFimCaption.Visible = false;
            }

            this.BackColor = Tarefa.Cor;
        }

        public delegate void DragStartHandler(TarefaDisplay sender, MouseEventArgs e);
        public delegate void DragEndHandler(TarefaDisplay sender, MouseEventArgs e);
        public event DragStartHandler DragStart;
        public event DragEndHandler DragEnd;
        private void TarefaDisplay_DragEnd(TarefaDisplay sender, MouseEventArgs e)
        {
            Display();
        }

        void TarefaDisplay_DragStart(TarefaDisplay td, MouseEventArgs e)
        {
            DisplayComplementar();
        }
        private void MDown(object sender, MouseEventArgs e)
        {
            if (DragStart != null)
            {
                DragStart.Invoke(this, e);
            }
            this.DoDragDrop(this.Tarefa, DragDropEffects.Move);
            if (DragEnd != null)
            {
                DragEnd.Invoke(this, e);
            }
        }
        void TarefaDisplay_GiveFeedback(object sender, GiveFeedbackEventArgs e)
        {
            e.UseDefaultCursors = false;
        }

        private void btnColor_Click(object sender, EventArgs e)
        {
            switch (this.colorDialog1.ShowDialog())
            {
                case DialogResult.Cancel:
                    break;
                case DialogResult.OK:
                    Tarefa.Cor = this.colorDialog1.Color;
                    this.Display();
                    break;
                default:
                    break;
            }
        }
    }
}
