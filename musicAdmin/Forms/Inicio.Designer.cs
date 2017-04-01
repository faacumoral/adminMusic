namespace musicAdmin
{
    partial class Inicio
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Inicio));
            this.btnPlay = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnCopiar = new System.Windows.Forms.Button();
            this.btnDescargar = new System.Windows.Forms.Button();
            this.btnRecargar = new System.Windows.Forms.Button();
            this.txtBusqueda = new System.Windows.Forms.TextBox();
            this.dgvMusica = new System.Windows.Forms.DataGridView();
            this.tituloDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.artistaDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.albumDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.musicaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMusica)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.musicaBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // btnPlay
            // 
            this.btnPlay.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnPlay.BackgroundImage")));
            this.btnPlay.Location = new System.Drawing.Point(24, 12);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(37, 44);
            this.btnPlay.TabIndex = 0;
            this.btnPlay.UseVisualStyleBackColor = true;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // btnStop
            // 
            this.btnStop.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnStop.BackgroundImage")));
            this.btnStop.Location = new System.Drawing.Point(82, 12);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(45, 44);
            this.btnStop.TabIndex = 0;
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnCopiar
            // 
            this.btnCopiar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCopiar.Location = new System.Drawing.Point(147, 19);
            this.btnCopiar.Name = "btnCopiar";
            this.btnCopiar.Size = new System.Drawing.Size(184, 29);
            this.btnCopiar.TabIndex = 2;
            this.btnCopiar.Text = "Copiar a Pendrive";
            this.btnCopiar.UseVisualStyleBackColor = true;
            this.btnCopiar.Click += new System.EventHandler(this.btnCopiar_Click);
            // 
            // btnDescargar
            // 
            this.btnDescargar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDescargar.Location = new System.Drawing.Point(352, 19);
            this.btnDescargar.Name = "btnDescargar";
            this.btnDescargar.Size = new System.Drawing.Size(227, 29);
            this.btnDescargar.TabIndex = 2;
            this.btnDescargar.Text = "Descargar de YouTube";
            this.btnDescargar.UseVisualStyleBackColor = true;
            this.btnDescargar.Click += new System.EventHandler(this.btnDescargar_Click);
            // 
            // btnRecargar
            // 
            this.btnRecargar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRecargar.Location = new System.Drawing.Point(596, 23);
            this.btnRecargar.Name = "btnRecargar";
            this.btnRecargar.Size = new System.Drawing.Size(134, 23);
            this.btnRecargar.TabIndex = 3;
            this.btnRecargar.Text = "Recargar";
            this.btnRecargar.UseVisualStyleBackColor = true;
            this.btnRecargar.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtBusqueda
            // 
            this.txtBusqueda.Location = new System.Drawing.Point(10, 75);
            this.txtBusqueda.Name = "txtBusqueda";
            this.txtBusqueda.Size = new System.Drawing.Size(569, 20);
            this.txtBusqueda.TabIndex = 4;
            this.txtBusqueda.TextChanged += new System.EventHandler(this.txtBusqueda_TextChanged);
            // 
            // dgvMusica
            // 
            this.dgvMusica.AllowUserToResizeRows = false;
            this.dgvMusica.AutoGenerateColumns = false;
            this.dgvMusica.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMusica.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.tituloDataGridViewTextBoxColumn1,
            this.artistaDataGridViewTextBoxColumn1,
            this.albumDataGridViewTextBoxColumn1});
            this.dgvMusica.DataSource = this.musicaBindingSource;
            this.dgvMusica.Location = new System.Drawing.Point(10, 117);
            this.dgvMusica.Name = "dgvMusica";
            this.dgvMusica.RowHeadersVisible = false;
            this.dgvMusica.Size = new System.Drawing.Size(1325, 700);
            this.dgvMusica.TabIndex = 6;
            this.dgvMusica.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMusica_CellEndEdit);
            // 
            // tituloDataGridViewTextBoxColumn1
            // 
            this.tituloDataGridViewTextBoxColumn1.DataPropertyName = "Titulo";
            this.tituloDataGridViewTextBoxColumn1.HeaderText = "Titulo";
            this.tituloDataGridViewTextBoxColumn1.Name = "tituloDataGridViewTextBoxColumn1";
            this.tituloDataGridViewTextBoxColumn1.Width = 800;
            // 
            // artistaDataGridViewTextBoxColumn1
            // 
            this.artistaDataGridViewTextBoxColumn1.DataPropertyName = "Artista";
            this.artistaDataGridViewTextBoxColumn1.HeaderText = "Artista";
            this.artistaDataGridViewTextBoxColumn1.Name = "artistaDataGridViewTextBoxColumn1";
            this.artistaDataGridViewTextBoxColumn1.Width = 300;
            // 
            // albumDataGridViewTextBoxColumn1
            // 
            this.albumDataGridViewTextBoxColumn1.DataPropertyName = "Album";
            this.albumDataGridViewTextBoxColumn1.HeaderText = "Album";
            this.albumDataGridViewTextBoxColumn1.Name = "albumDataGridViewTextBoxColumn1";
            this.albumDataGridViewTextBoxColumn1.Width = 200;
            // 
            // musicaBindingSource
            // 
            this.musicaBindingSource.DataSource = typeof(musicAdmin.Musica);
            // 
            // Inicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(959, 452);
            this.Controls.Add(this.dgvMusica);
            this.Controls.Add(this.txtBusqueda);
            this.Controls.Add(this.btnRecargar);
            this.Controls.Add(this.btnDescargar);
            this.Controls.Add(this.btnCopiar);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnPlay);
            this.Name = "Inicio";
            this.Text = "Inicio";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Inicio_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMusica)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.musicaBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.BindingSource musicaBindingSource;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnCopiar;
        private System.Windows.Forms.Button btnDescargar;
        private System.Windows.Forms.Button btnRecargar;
        private System.Windows.Forms.TextBox txtBusqueda;
        private System.Windows.Forms.DataGridView dgvMusica;
        private System.Windows.Forms.DataGridViewTextBoxColumn tituloDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn artistaDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn albumDataGridViewTextBoxColumn1;
    }
}

