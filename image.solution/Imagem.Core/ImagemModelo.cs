using System.Drawing;
using System.IO;

namespace Imagem.Core
{
	public class ImagemModelo
	{
		public Image ImagemCarregada { get; set; }
		public string ArquivoOriginal { get; set; }
		public string PastaOriginal
		{
			get
			{
				return ArquivoOriginal != null ?
					Path.GetDirectoryName(ArquivoOriginal) : "";
			}
		}
		public string NomeDoArquivo
		{
			get
			{
				return ArquivoOriginal != null ?
					Path.GetFileNameWithoutExtension(ArquivoOriginal) : "";
			}
		}
		public string ExtensaoDoArquivo
		{
			get
			{
				return ArquivoOriginal != null ?
					Path.GetExtension(ArquivoOriginal) : "";
			}
		}
	}
}
