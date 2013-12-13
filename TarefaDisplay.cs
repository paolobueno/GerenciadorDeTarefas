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
                    // Removemos os Handlers da anterior se a tarefa for trocada
                    // para parar de observá-la
                    if (this._tarefa != null)
                        SetTarefaEventHandlers();
                    this._tarefa = value;
                    UnsetTarefaEventHandlers();
                    this.Display();
                }
            }
        }

        /// <summary>
        /// Precisamos manter um construtor sem parâmetros para o Designer funcionar
        /// Marcamos como 'private' para prevenir acesso indevido
        /// </summary>
        private TarefaDisplay()
        {
            InitializeComponent();
        }

        // Herdamos do construtor sem parametros pois InitializeComponent é necessário
        public TarefaDisplay(Tarefa tarefa)
            : this()
        {
            this.Tarefa = tarefa;
            this.MouseDown += MDown;
            this.DragStart += TarefaDisplay_DragStart;
            this.DragEnd += TarefaDisplay_DragEnd;
            this.GiveFeedback += TarefaDisplay_GiveFeedback;
        }

        /// <summary>
        /// Exibe cor complementar, desfeito por <see cref="Display"/>
        /// </summary>
        public void DisplayComplementar()
        {
            Color cor = this.Tarefa.Cor;
            this.BackColor = Color.FromArgb(255 - cor.R, 255 - cor.G, 255 - cor.B);
        }

        /// <summary>
        /// Atualiza a interface para refletir estado da Tarefa
        /// </summary>
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
        #region Events
        public delegate void DragStartHandler(TarefaDisplay sender, MouseEventArgs e);
        public delegate void DragEndHandler(TarefaDisplay sender, MouseEventArgs e);
        public event DragStartHandler DragStart;
        public event DragEndHandler DragEnd;
        #endregion

        #region EventHandlers
        private void UnsetTarefaEventHandlers()
        {
            this._tarefa.PropertyChanged += this.TarefaPropertyChanged;
        }

        private void SetTarefaEventHandlers()
        {
            this._tarefa.PropertyChanged -= this.TarefaPropertyChanged;
        }

        private void TarefaPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            // Atualizamos a interface em qualquer alteração em Tarefa
            this.Display();
        }

        #region Drag&Drop
        private void TarefaDisplay_DragEnd(TarefaDisplay sender, MouseEventArgs e)
        {
            Display();
        }

        void TarefaDisplay_DragStart(TarefaDisplay td, MouseEventArgs e)
        {
            DisplayComplementar();
        }

        /// <summary>
        /// Handler para this.MouseDown
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MDown(object sender, MouseEventArgs e)
        {
            // Aqui invocamos nossos eventos custom para escapar da estrutura imposta pela framework
            // para checar o andamento de uma operação drag & drop
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
            // Prevenir cursores gerados pela operação Drag & Drop
            e.UseDefaultCursors = false;
        }

        #endregion

        /// <summary>
        /// Handler que troca de cor
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        #endregion
    }
}
