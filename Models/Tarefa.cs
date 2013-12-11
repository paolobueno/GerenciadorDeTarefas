using GerenciadorTarefas.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorTarefas.Models
{
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
                    if (PropertyChanged != null)
                        PropertyChanged.Invoke(this, new PropertyChangedEventArgs("Descricao"));
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
                    if (PropertyChanged != null)
                        PropertyChanged.Invoke(this, new PropertyChangedEventArgs("Inicio"));
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
                    if (PropertyChanged != null)
                        PropertyChanged.Invoke(this, new PropertyChangedEventArgs("Fim"));
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
                    if (PropertyChanged != null)
                        PropertyChanged.Invoke(this, new PropertyChangedEventArgs("Status"));
                }
                _status = value;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
