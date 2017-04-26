using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PictText
{
	public partial class VentanaPrincipal : Form
	{
		Visor visor = null;

		public VentanaPrincipal()
		{
			InitializeComponent();
		}

		private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
		{
			MessageBox.Show("Este programa genera una imagen PNG a partir de un texto. \r\n\r\nAutor: Cristian de León Ronquillo.", "Texto a imagen");
		}

		private void VentanaPrincipal_Load(object sender, EventArgs e)
		{
			// Cargar las fuentes del sistema
			cbFuente.Items.Clear();

			foreach (FontFamily font in System.Drawing.FontFamily.Families)
			{
				cbFuente.Items.Add(font.Name);
			}

			cbFuente.SelectedItem = "Arial";

			// Establecer color por defecto
			colorDialog1.Color = Color.FromArgb(0x1B, 0x15, 0x02);
			colorDialog2.Color = Color.FromArgb(0xF6, 0xEE, 0xD6);
		}

		private void btnColor1_Click(object sender, EventArgs e)
		{
			colorDialog1.ShowDialog();
			txtColorTexto.Text = "#" + (colorDialog1.Color.ToArgb() & 0x00FFFFFF).ToString("X6");
			EstablecerEjemplo();
        }

		private void btnColor2_Click(object sender, EventArgs e)
		{
			colorDialog2.ShowDialog();
			txtColorFondo.Text = "#" + (colorDialog2.Color.ToArgb() & 0x00FFFFFF).ToString("X6");
			EstablecerEjemplo();
        }

		private void EstablecerEjemplo()
		{
			txtEjemplo.ForeColor = colorDialog1.Color;
			txtEjemplo.BackColor = colorDialog2.Color;
		}

		private void chkColor_CheckedChanged(object sender, EventArgs e)
		{
			btnColor2.Enabled = !chkColor.Checked;
		}

		private void scrDistribucion_Scroll(object sender, ScrollEventArgs e)
		{
			lblDistribucion.Text = String.Format("Título / Texto = {0}% / {1}%", e.NewValue, 100-e.NewValue);
		}

		private void button1_Click(object sender, EventArgs e)
		{
			var conf = CargarConfig();

			var textoImg = new TextoAImagen();

			var validacion = textoImg.ValidarParametros(conf);

			if (!string.IsNullOrEmpty(validacion))
			{
				MessageBox.Show(validacion);
				return;
			}

			textoImg.DibujarImagen(conf);

			// Crear formulario de Visor
			visor = new Visor(conf.ArchivoSalida);
            visor.ShowDialog();
		}
		
		/// <summary>
		/// Cargar la configuración establecida por el usuario
		/// </summary>
		/// <returns></returns>
		private ImagenConf CargarConfig()
		{
			var conf = new ImagenConf();
			conf.ImgAncho = Convert.ToInt32(numAncho.Value);
			conf.ImgAlto = Convert.ToInt32(numAlto.Value);

			try {
				conf.Font = new Font(cbFuente.Text, Convert.ToSingle(numTexto.Value), FontStyle.Regular);
			}
			catch
			{
				// Si la fuente no es valida, usar Arial
				conf.Font = new Font("Arial", Convert.ToSingle(numTexto.Value), FontStyle.Regular);
			}

			try
			{
				conf.FontTitulo = new Font(cbFuente.Text, Convert.ToSingle(numTitulo.Value), FontStyle.Regular);
			} 
			catch
			{
				conf.FontTitulo = new Font("Arial", Convert.ToSingle(numTitulo.Value), FontStyle.Regular);
			}



			conf.Color = ColorTranslator.FromHtml(txtColorTexto.Text);

			if (chkColor.Checked)
			{
				//Generar un color aleatorio
				var color = string.Format("#{0:X6}", new Random().Next(0x1000000) & 0x7F7F7F);
				conf.ColorFondo = ColorTranslator.FromHtml(color);
			}
			else
			{
				//Utilizar el color de fondo preestablecido
				conf.ColorFondo = ColorTranslator.FromHtml(txtColorFondo.Text);
			}


			conf.AreaTitulo = Convert.ToSingle(numTitulo.Value);

			conf.AreaTexto = Convert.ToSingle(numTexto.Value);

			conf.AreaImagen = new Rectangle(0, 0, conf.ImgAncho, conf.ImgAlto);

			// Establecer la ruta al archivo de salida

			var appData = Environment.GetEnvironmentVariable("LOCALAPPDATA");

			// Datos de la ventana principal

			conf.ArchivoSalida = Path.Combine(appData, txtNombreArchivo.Text + ".PNG");
			conf.Titulo = txtTitulo.Text;
			conf.Texto = txtTexto.Text;

			return conf;
		}
	}
}
