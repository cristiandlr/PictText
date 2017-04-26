using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace PictText
{
	public class TextoAImagen
	{
		public bool EsRutaValida(string ruta)
		{
			Uri rutaUri;
			bool isValidUri = Uri.TryCreate(ruta, UriKind.Absolute, out rutaUri);

			return isValidUri && rutaUri != null && rutaUri.IsLoopback;
		}

		public string ValidarParametros(ImagenConf conf) {
			string validacion = string.Empty;

			if (string.IsNullOrEmpty(conf.Titulo)) {
				validacion = "Por favor agregue un título a la imagen.";
			} else if (string.IsNullOrEmpty(conf.Texto))
			{
				validacion = "Por favor agregue un texto a la imagen";
			} else if (!EsRutaValida(conf.ArchivoSalida))
			{
				validacion = "El nombre de archivo de imagen no es valido.";
			}

			return validacion;
		}
		
		public void DibujarImagen(ImagenConf conf)
        {
			var bitm = new Bitmap(conf.ImgAncho, conf.ImgAlto);
			var bgRectangle = new Rectangle(0, 0, conf.ImgAncho, conf.ImgAlto);

			using (var gr = Graphics.FromImage(bitm))
			{
				var bgBrush = new SolidBrush(conf.ColorFondo);
				var bgRegion = new Region(bgRectangle);
				gr.FillRegion(bgBrush, bgRegion);

				// Definir porcentaje para Titulo y para Texto
				int h1 = (int)(conf.AreaTitulo * conf.ImgAlto / 100);
				int h2 = (int)(conf.AreaTexto * conf.ImgAlto / 100);

				StringFormat sf = new StringFormat();
				sf.LineAlignment = StringAlignment.Center;
				sf.Alignment = StringAlignment.Center;

				// Imprimir texto a imagen
				var textBrush = new SolidBrush(conf.Color);
				var rectTitulo = new Rectangle(0, 0, conf.ImgAncho, h1);
				var rectTexto = new Rectangle(0, h1, conf.ImgAncho, h2);

				gr.DrawString(conf.Titulo, conf.FontTitulo, textBrush, rectTitulo, sf);
				gr.DrawString(conf.Texto, conf.Font, textBrush, rectTexto, sf);
				
			}

			// Eliminar si ya existe
			if (File.Exists(conf.ArchivoSalida))
				File.Delete(conf.ArchivoSalida);

			bitm.Save(conf.ArchivoSalida, ImageFormat.Png);
		}
	}
}
