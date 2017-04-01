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
using System.Threading;
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

        public static void ShowMessageBox(string msg)
        {
            MessageBox.Show(msg);
        }
        internal void recargarCanciones()
        {
            var th = ComunController.Loading("Cargando canciones...");
            form.Visible = false;
            form.dgvMusica.DataSource = null;
            musica = mc.GetTodas();
            form.dgvMusica.DataSource = musica;
            form.dgvMusica.DataSource = musica;
            if (musica.Count == 0)
            {
                MessageBox.Show("No se han encontrado canciones. Pulse el boton 'Recargar' para recargar canciones.");
            }
            form.Visible = true;
            ComunController.LoadingFinish(th);            
        }

        private void Inicio_Load_1(object sender, EventArgs e)
        {
           ac.GetProperties();
           recargarCanciones();
        }

        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            string filtro = txtBusqueda.Text;
            dgvMusica.DataSource = musica.Where(m => m.Nombre.IndexOf(filtro, StringComparison.OrdinalIgnoreCase) != -1 || m.Titulo.IndexOf(filtro, StringComparison.OrdinalIgnoreCase) != -1 || m.Artista.IndexOf(filtro, StringComparison.OrdinalIgnoreCase) != -1).ToList();
        }

        private void dgvMusica_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var ds = (dgvMusica.DataSource as List<Musica>);
            var cancionActual = ds[e.RowIndex];
            TagLib.File tagFile = TagLib.File.Create(cancionActual.FullPath);
            tagFile.Tag.Title = cancionActual.Titulo != null ? cancionActual.Titulo : tagFile.Tag.Title;
            tagFile.Tag.Album = cancionActual.Album != null ? cancionActual.Album : tagFile.Tag.Album;
            //tagFile.Tag.FirstAlbumArtist = cancionActual.Artista;
            if (tagFile.Tag.AlbumArtists.Count() == 0)
            {
                tagFile.Tag.AlbumArtists.ToList().Add(cancionActual.Artista);
            }
            else
            {
                //FIXME manejar artistas
                tagFile.Tag.AlbumArtists[0] = cancionActual.Artista;
            }
            tagFile.Save();
        }

    }
}
