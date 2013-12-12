namespace GerenciadorTarefas
{
    partial class Painel
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
            this.panel = new System.Windows.Forms.TableLayoutPanel();
            this.lblDescricao = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // panel
            // 
            this.panel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel.AutoScroll = true;
            this.panel.ColumnCount = 1;
            this.panel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.panel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.panel.Location = new System.Drawing.Point(4, 30);
            this.panel.Name = "panel";
            this.panel.RowCount = 1;
            this.panel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.panel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.panel.Size = new System.Drawing.Size(200, 161);
            this.panel.TabIndex = 0;
            // 
            // lblDescricao
            // 
            this.lblDescricao.AutoSize = true;
            this.lblDescricao.Location = new System.Drawing.Point(4, 4);
            this.lblDescricao.Name = "lblDescricao";
            this.lblDescricao.Size = new System.Drawing.Size(78, 13);
            this.lblDescricao.TabIndex = 1;
            this.lblDescricao.Text = "Não Iniciadas()";
            // 
            // Painel
            // 
            this.AllowDrop = true;
            this.Controls.Add(this.lblDescricao);
            this.Controls.Add(this.panel);
            this.Name = "Painel";
            this.Size = new System.Drawing.Size(207, 194);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel panel;
        private System.Windows.Forms.Label lblDescricao;
    }
}
