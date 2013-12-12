namespace GerenciadorTarefas
{
    partial class TarefaDisplay
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblId = new System.Windows.Forms.Label();
            this.lblDescricao = new System.Windows.Forms.Label();
            this.lblInicioCaption = new System.Windows.Forms.Label();
            this.lblInicio = new System.Windows.Forms.Label();
            this.lblFim = new System.Windows.Forms.Label();
            this.lblFimCaption = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Location = new System.Drawing.Point(4, 4);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(48, 13);
            this.lblId.TabIndex = 0;
            this.lblId.Text = "Tarefa #";
            // 
            // lblDescricao
            // 
            this.lblDescricao.AutoSize = true;
            this.lblDescricao.Location = new System.Drawing.Point(4, 17);
            this.lblDescricao.Name = "lblDescricao";
            this.lblDescricao.Size = new System.Drawing.Size(67, 13);
            this.lblDescricao.TabIndex = 1;
            this.lblDescricao.Text = "Lorem Ipsum";
            // 
            // lblInicioCaption
            // 
            this.lblInicioCaption.AutoSize = true;
            this.lblInicioCaption.Location = new System.Drawing.Point(4, 45);
            this.lblInicioCaption.Name = "lblInicioCaption";
            this.lblInicioCaption.Size = new System.Drawing.Size(34, 13);
            this.lblInicioCaption.TabIndex = 2;
            this.lblInicioCaption.Text = "Início";
            // 
            // lblInicio
            // 
            this.lblInicio.AutoSize = true;
            this.lblInicio.Location = new System.Drawing.Point(4, 58);
            this.lblInicio.Name = "lblInicio";
            this.lblInicio.Size = new System.Drawing.Size(110, 13);
            this.lblInicio.TabIndex = 3;
            this.lblInicio.Text = "12/12/2013 11:11:11";
            // 
            // lblFim
            // 
            this.lblFim.AutoSize = true;
            this.lblFim.Location = new System.Drawing.Point(4, 91);
            this.lblFim.Name = "lblFim";
            this.lblFim.Size = new System.Drawing.Size(110, 13);
            this.lblFim.TabIndex = 5;
            this.lblFim.Text = "12/12/2013 11:11:11";
            // 
            // lblFimCaption
            // 
            this.lblFimCaption.AutoSize = true;
            this.lblFimCaption.Location = new System.Drawing.Point(4, 78);
            this.lblFimCaption.Name = "lblFimCaption";
            this.lblFimCaption.Size = new System.Drawing.Size(23, 13);
            this.lblFimCaption.TabIndex = 4;
            this.lblFimCaption.Text = "Fim";
            // 
            // TarefaDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.lblFim);
            this.Controls.Add(this.lblFimCaption);
            this.Controls.Add(this.lblInicio);
            this.Controls.Add(this.lblInicioCaption);
            this.Controls.Add(this.lblDescricao);
            this.Controls.Add(this.lblId);
            this.Name = "TarefaDisplay";
            this.Size = new System.Drawing.Size(148, 148);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.Label lblDescricao;
        private System.Windows.Forms.Label lblInicioCaption;
        private System.Windows.Forms.Label lblInicio;
        private System.Windows.Forms.Label lblFim;
        private System.Windows.Forms.Label lblFimCaption;
    }
}
