﻿using GerenciadorTarefas.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GerenciadorTarefas.Models
{
    [Serializable]
    public class Tarefa : INotifyPropertyChanged
    {
        public int Id { get; set; }

        private String _descricao = "";
        public string Descricao
        {
            get { return _descricao; }
            set
            {
                if (_descricao != value)
                {
                    _descricao = value;
                    InvokePropertyChanged("Descricao");
                }
            }
        }

        [DataType(DataType.DateTime)]
        private DateTime _inicio = DateTime.Now;
        public DateTime Inicio
        {
            get { return _inicio; }
            set
            {
                if (_inicio != value)
                {
                    _inicio = value;
                    InvokePropertyChanged("Inicio");
                }
            }
        }
        private DateTime _fim = DateTime.Now;
        [DataType(DataType.DateTime)]
        public DateTime Fim
        {
            get { return _fim; }
            set
            {
                if (_fim != value)
                {
                    _fim = value;
                    InvokePropertyChanged("Fim");
                }
            }
        }
        private Statuses _status;
        public Statuses Status
        {
            get { return _status; }
            set
            {
                if (_status != value)
                {
                    _status = value;
                    InvokePropertyChanged("Status");
                }
            }
        }

        private Color _cor = Color.Beige;

        public Color Cor
        {
            get { return _cor; }
            set
            {
                if (_cor != value)
                {
                    _cor = value;
                    InvokePropertyChanged("Cor");
                }
            }
        }

        private void InvokePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
