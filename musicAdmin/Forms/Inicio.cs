using musicAdmin.Controllers;
using musicAdmin.Forms;
using musicAdmin.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace musicAdmin
{
    public partial class Inicio : Form
    {
        MusicaController mc = new MusicaController();
        ArchivoController ac = new ArchivoController();
        MediaPlayerController mpc = new MediaPlayerController();
        List<Musica> musica = new List<Musica>();
        Inicio form = null;

        public Inicio()
        {
            form = this;
            InitializeComponent();
        }

        private void Inicio_Load(object sender, EventArgs e)
        {
            recargarCanciones();
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            form.dgvMusica.Focus();
            mpc.Play(musica[dgvMusica.CurrentCell.RowIndex].FullPath);
        }
        private void btnStop_Click(object sender, EventArgs e)
        {
            form.dgvMusica.Focus();
            mpc.Stop();
        }

        private void btnCopiar_Click(object sender, EventArgs e)
        {
            if (form.dgvMusica.CurrentCell == null)
            {
                MessageBox.Show("¡Seleccione una cancion!");
                return;
            }
            string msg = ac.GetUSB();
            if ( msg == null)
            {
                // se leyo bien un usb, copio archivo
                if (ac.Copiar(musica[form.dgvMusica.CurrentCell.RowIndex]))
                {
                    MessageBox.Show("¡Copia exitosa!");
                }
                else
                {
                    MessageBox.Show("¡Copia falló!");
                }
            }
            else
            {
                // algo fallo (ninguno o mas de uno conectado)
                MessageBox.Show(msg);
            }
            form.dgvMusica.Focus();

        }

        private void dgvMusica_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // FIXME
            // agregar logica para editar informacion de la cancion
        }

        private void btnDescargar_Click(object sender, EventArgs e)
        {
            YouTubeDownloader formYT = new YouTubeDownloader();
            formYT.Show();
            form.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            recargarCanciones();
        }
        internal void recargarCanciones()
        {
            musica = mc.GetTodasEnMyMusic();
            form.dgvMusica.DataSource = musica;
            if (musica.Count == 0)
            {
                MessageBox.Show("No se han encontrado canciones. Pulse el boton 'Recargar' para recargar canciones.");
            }
        }
    }
}
