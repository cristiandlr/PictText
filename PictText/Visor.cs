using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PictText
{
	public partial class Visor : Form
	{
		private string _rutaImagen;

		public Visor(string ruta)
		{
			_rutaImagen = ruta;
			InitializeComponent();
		}

		private void Visor_Load(object sender, EventArgs e)
		{
			pictureBox1.ImageLocation = _rutaImagen;
			lnkImagen.Text = _rutaImagen;
		}

		private void lnkImagen_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			var dir = Path.GetDirectoryName(_rutaImagen);
			Process.Start("explorer.exe", dir);
		}
	}
}
