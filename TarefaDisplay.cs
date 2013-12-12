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
                        SetEventHandlers();
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
        }

        void TarefaDisplay_DragStart(TarefaDisplay td, EventArgs e)
        {
            // Inverter cor
            this.BackColor = CorComplementar(BackColor);
        }

        private Color CorComplementar(Color color)
        {
            return Color.FromArgb(255 - color.R, 255 - color.G, 255 - color.B);
        }

        private void UnsetEventHandlers()
        {
            this._tarefa.PropertyChanged += this.TarefaPropertyChanged;
        }

        private void SetEventHandlers()
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

        private void MDown(object sender, MouseEventArgs e)
        {
            if (DragStart != null)
            {
                DragStart.Invoke(this, null);
            }
            this.DoDragDrop(this.Tarefa, DragDropEffects.Move);
        }

        public delegate void DragStartHandler(TarefaDisplay td, EventArgs e);
        public event DragStartHandler DragStart;

        private void btnColor_Click(object sender, EventArgs e)
        {
            switch (this.colorDialog1.ShowDialog())
            {
                case DialogResult.Cancel:
                    break;
                case DialogResult.OK:
                    Tarefa.Cor = this.colorDialog1.Color;
                    break;
                default:
                    break;
            }
        }
    }
}
