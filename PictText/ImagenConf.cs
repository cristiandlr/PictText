using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace PictText
{
	public class ImagenConf
	{
		public int ImgAncho { get; set; }
		public int ImgAlto { get; set; }
		public Font Font { get; set; }
		public Font FontTitulo { get; set; }
		public Color Color { get; set; }
		public Color ColorFondo { get; set; }
		public float AreaTitulo { get; set; }
		public float AreaTexto { get; set; }
		public Rectangle AreaImagen { get; set; }

		public string Titulo { get; set; }
		public string Texto { get; set; }
		public string ArchivoSalida { get; set; }
	}
}
