namespace curitibatemaimagem
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.pb = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pb)).BeginInit();
            this.SuspendLayout();
            // 
            // pb
            // 
            this.pb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pb.Location = new System.Drawing.Point(0, 0);
            this.pb.Name = "pb";
            this.pb.Size = new System.Drawing.Size(800, 450);
            this.pb.TabIndex = 1;
            this.pb.TabStop = false;
            this.pb.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pb_MouseDown);
            this.pb.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pb_MouseMove);
            this.pb.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pb_MouseUp);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pb);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pb)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pb;
    }
}

