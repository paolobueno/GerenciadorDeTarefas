﻿using System;
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
                        this._tarefa.PropertyChanged -= this.TarefaPropertyChanged;
                    this._tarefa = value;
                    this._tarefa.PropertyChanged += this.TarefaPropertyChanged;
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
            this._tarefa = tarefa;
            this._tarefa.PropertyChanged += TarefaPropertyChanged;
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
        }
    }
}
