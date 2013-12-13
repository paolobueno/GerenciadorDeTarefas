using GerenciadorTarefas.Models.Enums;
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
    /// <summary>
    /// Classe que serve como modelo de dados para Tarefa
    /// Ela deve ser Serializable para que possa servir como
    /// objeto de dados para DoDragAndDrop()
    /// </summary>
    [Serializable]
    public class Tarefa :
        // Essa interface é a padrão da .NET para que um objeto possa ter suas propriedades observadas
        // É utilizada internamente, por exemplo, por `GridView`s para se manterem atualizados
        INotifyPropertyChanged
    {
        public Tarefa()
        {
            // Valores default;
            this.Id = 1;

            Color defaultColor = Color.Beige;
            CopyColor(defaultColor);
        }

        /// <summary>
        /// Pequena utility para definir propriedades separadas a partir de um Color
        /// </summary>
        /// <param name="color">A cor a ser definida para a Tarefa</param>
        private void CopyColor(Color color)
        {
            this.R = color.R;
            this.G = color.G;
            this.B = color.B;
        }

        public int Id { get; set; }

        private String _descricao = "";
        public string Descricao
        {
            get { return _descricao; }
            set
            {
                // Fazemos a seguinte checagem em todos os setters para não invocar o evento desnecessariamente
                if (_descricao != value)
                {
                    _descricao = value;
                    InvokePropertyChanged("Descricao");
                }
            }
        }

        /// <summary>
        /// Tempo de início
        /// </summary>
        private DateTime _inicio = DateTime.Now; 
        // Colocamos DateTime.Now como valor padrão pois o padrão .NET de 1/1/0001 não pode ser armazenado pelo BD
        [DataType(DataType.DateTime)]
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

        /// <summary>
        /// Cor a ser exibida para a tarefa
        /// </summary>
        public Color Cor
        {
            // Esta propriedade mostra como não precisamos ter um campo
            // private do mesmo tipo para armazenar os dados da propriedade
            //
            // Ao invés de Color utilizamos 3 `byte`s e os convertemos
            // no getter e no setter
            get { return Color.FromArgb(R, G, B); }
            set
            {
                if (Cor != value)
                {
                    CopyColor(value);
                    InvokePropertyChanged("Cor");
                }
            }
        }

        // Dividimos a propriedade Cor em 3 componentes porque
        // a Entity não persiste tipos complexos automaticamente
        public byte R { get; set; }
        public byte G { get; set; }
        public byte B { get; set; }

        /// <summary>
        /// Invoca o evento PropertyChanged de maneira segura
        /// Precisamos sempre checar para `null` quando invocamos um evento pois ele é nulo caso não possua nenhum handler
        /// </summary>
        /// <param name="propertyName"></param>
        private void InvokePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Definido por INotifyPropertyChanged
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
