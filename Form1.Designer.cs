namespace GerenciadorTarefas
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.txtTarefaDescricao = new System.Windows.Forms.TextBox();
            this.btnCriar = new System.Windows.Forms.Button();
            this.pnlConcluidas = new GerenciadorTarefas.Painel();
            this.pnlEmAndamento = new GerenciadorTarefas.Painel();
            this.pnlNaoIniciadas = new GerenciadorTarefas.Painel();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Criar nova tarefa";
            // 
            // txtTarefaDescricao
            // 
            this.txtTarefaDescricao.Location = new System.Drawing.Point(117, 13);
            this.txtTarefaDescricao.Name = "txtTarefaDescricao";
            this.txtTarefaDescricao.Size = new System.Drawing.Size(156, 20);
            this.txtTarefaDescricao.TabIndex = 3;
            // 
            // btnCriar
            // 
            this.btnCriar.Location = new System.Drawing.Point(279, 11);
            this.btnCriar.Name = "btnCriar";
            this.btnCriar.Size = new System.Drawing.Size(75, 23);
            this.btnCriar.TabIndex = 4;
            this.btnCriar.Text = "Criar";
            this.btnCriar.UseVisualStyleBackColor = true;
            this.btnCriar.Click += new System.EventHandler(this.btnCriar_Click);
            // 
            // pnlConcluidas
            // 
            this.pnlConcluidas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlConcluidas.AutoScroll = true;
            this.pnlConcluidas.Location = new System.Drawing.Point(540, 40);
            this.pnlConcluidas.Name = "pnlConcluidas";
            this.pnlConcluidas.Size = new System.Drawing.Size(261, 507);
            this.pnlConcluidas.Status = GerenciadorTarefas.Models.Enums.Statuses.Concluida;
            this.pnlConcluidas.TabIndex = 2;
            // 
            // pnlEmAndamento
            // 
            this.pnlEmAndamento.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlEmAndamento.AutoScroll = true;
            this.pnlEmAndamento.Location = new System.Drawing.Point(279, 40);
            this.pnlEmAndamento.Name = "pnlEmAndamento";
            this.pnlEmAndamento.Size = new System.Drawing.Size(255, 507);
            this.pnlEmAndamento.Status = GerenciadorTarefas.Models.Enums.Statuses.EmAndamento;
            this.pnlEmAndamento.TabIndex = 1;
            // 
            // pnlNaoIniciadas
            // 
            this.pnlNaoIniciadas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlNaoIniciadas.AutoScroll = true;
            this.pnlNaoIniciadas.Location = new System.Drawing.Point(12, 40);
            this.pnlNaoIniciadas.Name = "pnlNaoIniciadas";
            this.pnlNaoIniciadas.Size = new System.Drawing.Size(261, 507);
            this.pnlNaoIniciadas.Status = GerenciadorTarefas.Models.Enums.Statuses.NaoIniciada;
            this.pnlNaoIniciadas.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(808, 559);
            this.Controls.Add(this.btnCriar);
            this.Controls.Add(this.txtTarefaDescricao);
            this.Controls.Add(this.pnlConcluidas);
            this.Controls.Add(this.pnlEmAndamento);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pnlNaoIniciadas);
            this.Name = "Form1";
            this.Text = "Minhas Tarefas";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Painel pnlNaoIniciadas;
        private System.Windows.Forms.Label label1;
        private Painel pnlEmAndamento;
        private Painel pnlConcluidas;
        private System.Windows.Forms.TextBox txtTarefaDescricao;
        private System.Windows.Forms.Button btnCriar;


    }
}

