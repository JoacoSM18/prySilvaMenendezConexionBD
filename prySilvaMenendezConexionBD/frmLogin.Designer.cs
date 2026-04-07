namespace prySilvaMenendezConexionBD
{
    partial class frmLogin
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
            this.lblGmail = new System.Windows.Forms.Label();
            this.lblContraeña = new System.Windows.Forms.Label();
            this.mskGmail = new System.Windows.Forms.MaskedTextBox();
            this.mskContrseña = new System.Windows.Forms.MaskedTextBox();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblGmail
            // 
            this.lblGmail.AutoSize = true;
            this.lblGmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGmail.Location = new System.Drawing.Point(99, 51);
            this.lblGmail.Name = "lblGmail";
            this.lblGmail.Size = new System.Drawing.Size(121, 17);
            this.lblGmail.TabIndex = 0;
            this.lblGmail.Text = "Gmail de Usuario:";
            // 
            // lblContraeña
            // 
            this.lblContraeña.AutoSize = true;
            this.lblContraeña.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContraeña.Location = new System.Drawing.Point(99, 115);
            this.lblContraeña.Name = "lblContraeña";
            this.lblContraeña.Size = new System.Drawing.Size(85, 17);
            this.lblContraeña.TabIndex = 1;
            this.lblContraeña.Text = "Contraseña:";
            // 
            // mskGmail
            // 
            this.mskGmail.Location = new System.Drawing.Point(229, 48);
            this.mskGmail.Name = "mskGmail";
            this.mskGmail.Size = new System.Drawing.Size(100, 20);
            this.mskGmail.TabIndex = 0;
            // 
            // mskContrseña
            // 
            this.mskContrseña.Location = new System.Drawing.Point(229, 112);
            this.mskContrseña.Name = "mskContrseña";
            this.mskContrseña.Size = new System.Drawing.Size(100, 20);
            this.mskContrseña.TabIndex = 3;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAceptar.Location = new System.Drawing.Point(356, 183);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(84, 29);
            this.btnAceptar.TabIndex = 7;
            this.btnAceptar.Text = "ACEPTAR";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(490, 242);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.mskContrseña);
            this.Controls.Add(this.mskGmail);
            this.Controls.Add(this.lblContraeña);
            this.Controls.Add(this.lblGmail);
            this.Name = "frmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inicio de Sesion BD";
            this.Load += new System.EventHandler(this.frmLogin_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblGmail;
        private System.Windows.Forms.Label lblContraeña;
        private System.Windows.Forms.MaskedTextBox mskGmail;
        private System.Windows.Forms.MaskedTextBox mskContrseña;
        private System.Windows.Forms.Button btnAceptar;
    }
}