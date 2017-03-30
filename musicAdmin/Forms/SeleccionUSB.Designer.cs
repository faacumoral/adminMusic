namespace musicAdmin.Forms
{
    partial class SeleccionUSB
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
            this.btnSiguiente = new System.Windows.Forms.Button();
            this.cboUSB = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btnSiguiente
            // 
            this.btnSiguiente.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSiguiente.Location = new System.Drawing.Point(60, 83);
            this.btnSiguiente.Name = "btnSiguiente";
            this.btnSiguiente.Size = new System.Drawing.Size(109, 32);
            this.btnSiguiente.TabIndex = 1;
            this.btnSiguiente.Text = "Siguiente!";
            this.btnSiguiente.UseVisualStyleBackColor = true;
            this.btnSiguiente.Click += new System.EventHandler(this.btnSiguiente_Click);
            // 
            // cboUSB
            // 
            this.cboUSB.DisplayMember = "Ruta";
            this.cboUSB.FormattingEnabled = true;
            this.cboUSB.Location = new System.Drawing.Point(35, 22);
            this.cboUSB.Name = "cboUSB";
            this.cboUSB.Size = new System.Drawing.Size(156, 21);
            this.cboUSB.TabIndex = 2;
            this.cboUSB.Text = "friendlyName";
            // 
            // SeleccionUSB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(232, 147);
            this.Controls.Add(this.cboUSB);
            this.Controls.Add(this.btnSiguiente);
            this.Name = "SeleccionUSB";
            this.Text = "SeleccionUSB";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSiguiente;
        private System.Windows.Forms.ComboBox cboUSB;
    }
}