using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;

namespace Imagem.Core
{
	public class Ferramentas
	{
		private static Dictionary<string, ImageFormat> FormatosSuportados =
			new Dictionary<string, ImageFormat>()
		{
			{".bmp", ImageFormat.Bmp},
			{".gif", ImageFormat.Gif},
			{".jpg", ImageFormat.Jpeg},
			{".png", ImageFormat.Png}
		};
		public static List<string> ListaDeImagens(string pasta)
		{
			string[] arquivos = Directory.GetFiles(pasta);

			if (arquivos == null || arquivos.Length == 0)
				return new List<string>();

			List<string> retorno = new List<string>();

			foreach (string arquivo in arquivos)
				if (FormatosSuportados.Keys.Contains(Path.GetExtension(arquivo)))
					retorno.Add(arquivo);

			return retorno;
		}
		public static Image GerarMiniatura(string arquivo)
		{
			Image imagem = Image.FromFile(arquivo);
			Size tamanhoMiniatura = obterTamanhoMiniatura(imagem);
			return imagem.GetThumbnailImage(tamanhoMiniatura.Width, 
				tamanhoMiniatura.Height, null, IntPtr.Zero);
		}
		public static string GravarNovoArquivo(Image image, 
			string novoArquivo, string extensao)
		{
			novoArquivo = string.Format(novoArquivo, extensao);

			if (File.Exists(novoArquivo))
				return "O arquivo de destino:\n" + novoArquivo + "\njá existe.";

			try
			{
				image.Save(novoArquivo, FormatosSuportados[extensao]);
				return "";
			}
			catch (Exception ex)
			{
				return ex.Message;
			}
		}
		public static string ImagemParaHtmlString(ImagemModelo imagem)
		{
			byte[] bytesDaImagem = ImagemParaBytes(imagem);

			if (bytesDaImagem.Length == 0)
				return "";

			return string.Format("<img src=\"data:image/{0};base64,{1}\" />",
				imagem.ExtensaoDoArquivo.Replace(".",""), 
				Convert.ToBase64String(bytesDaImagem));
		}
		private static byte[] ImagemParaBytes(ImagemModelo imagem)
		{
			using (MemoryStream memoryStream = new MemoryStream())
			{
				if(!FormatosSuportados.ContainsKey(imagem.ExtensaoDoArquivo))
					return new byte[0];

				imagem.ImagemCarregada.Save(memoryStream, 
					FormatosSuportados[imagem.ExtensaoDoArquivo]);
				return memoryStream.ToArray();
			}
		}
		private static Size obterTamanhoMiniatura(Image imagem)
		{
			int tamanhoMaximo = 80;
			int alturaOriginal = imagem.Height;
			int larguraOriginal = imagem.Width;
			double fator;

			if (larguraOriginal > alturaOriginal)
				fator = (double)tamanhoMaximo / larguraOriginal;
			else
				fator = (double)tamanhoMaximo / alturaOriginal;

			return new Size((int)(larguraOriginal * fator),
				(int)(alturaOriginal * fator));
		}
	}
}