using GerenciadorTarefas.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                    InvokePropertyChanged("Descricao");
                }
                _descricao = value;
            }
        }

        private DateTime _inicio;
        public DateTime Inicio
        {
            get { return _inicio; }
            set
            {
                if (_inicio != value)
                {
                    InvokePropertyChanged("Inicio");
                }
                _inicio = value;
            }
        }
        private DateTime _fim;
        public DateTime Fim
        {
            get { return _fim; }
            set
            {
                if (_fim != value)
                {
                    InvokePropertyChanged("Fim");
                }
                _fim = value;
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
                    InvokePropertyChanged("Status");
                }
                _status = value;
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
                    InvokePropertyChanged("Cor");
                }
                _cor = value;
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
