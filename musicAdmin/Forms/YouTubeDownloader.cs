using musicAdmin.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace musicAdmin.Forms
{
    public partial class YouTubeDownloader : Form
    {
        private static YouTubeDownloader form = null;
        private string video ;
        public static void SetPBAValue(int value)
        {
            if (value < 0) 
            {
                // no deberir ocurrir pero mejor contemplarlo
                return;
            }
            if ((value + form.pbaDescarga.Value) > form.pbaDescarga.Maximum )
            {
                // si el nuevo value va a darme overflow, seteo maximo
                form.pbaDescarga.Value = form.pbaDescarga.Maximum;
            }
            else
            {
                // si no seteo ese valor
                form.pbaDescarga.Value = value;
            }
            
        }

        public YouTubeDownloader()
        {
            InitializeComponent();
            form = this;
        }

        private void btnDescargar_Click(object sender, EventArgs e)
        {
            // FIXME seteado en Download por dev, despues se pasara a DataController.defaultPath
            lblEstado.Text = "Descargando... por favor espere";
            form.Enabled = false;
            video = YoutubeController.GetAudioFromVideo(txtLink.Text, @"C:\Users\FacundoMoral\Downloads");
            form.Enabled = true;
            
            if (video == null)
            {
                lblEstado.Text = "Descarga fallida.";
                MessageBox.Show("¡La descarga ha fallado!");
            }
            else
            {
                lblEstado.Text = "Descarga finalizada.";
                if (MessageBox.Show("¡La descarga ha finalizado! ¿Desea pasar el audio al pendrive contectado?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    ArchivoController ac = new ArchivoController();
                    var msg = ac.GetUSB();
                    if (msg == null)
                    {
                        if (ac.Copiar(ArchivoController.GetFromPath(video)))
                        {
                            MessageBox.Show("¡Copiado correctamente!");
                            Inicio inicio = new Inicio();
                            inicio.Show();
                            form.Close();
                        }
                        else
                        {
                            MessageBox.Show("¡Copia falló!");
                        }
                    }
                    else 
                    {
                        MessageBox.Show(msg);
                        btnCopiarAgain.Visible = true;
                    }
                }
                
            }
            
        }
        public void SetPBA(int newValue)
        {
            pbaDescarga.Value = newValue;
        }

        private void btnCopiarAgain_Click(object sender, EventArgs e)
        {
            ArchivoController ac = new ArchivoController();
            var msg = ac.GetUSB();
            if (msg == null)
            {
                if (ac.Copiar(ArchivoController.GetFromPath(video)))
                {
                    MessageBox.Show("¡Copiado correctamente!");
                    Inicio inicio = new Inicio();
                    inicio.Show();
                    form.Close();
                }
                else
                {
                    MessageBox.Show("¡Copia falló!");
                }
            }
            else
            {
                MessageBox.Show(msg);
                btnCopiarAgain.Visible = true;
            }
        }

    }
}
