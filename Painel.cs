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

namespace GerenciadorTarefas
{
    public partial class Painel : TableLayoutPanel
    {
        public Statuses Status { get; set; }
        public Painel()
        {
            InitializeComponent();
        }
    }
}
