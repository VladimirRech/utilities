using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Imagem.UI
{
	public partial class FormPrincipal : Form
	{
		Core.ImagemModelo imagemCarregada;
		Dictionary<string, RadioButton> extensoesValidasParaExportar;

		public FormPrincipal()
		{
			InitializeComponent();
			extensoesValidasParaExportar = new Dictionary<string, RadioButton>() {
						{".bmp", rdBmp},
						{".gif", rbGif},
						{".jpg", rbJpg},
						{".png", rbPng}};
		}
		private void btnSelecionar_Click(object sender, EventArgs e)
		{
			folderBrowserDialog.ShowDialog();

			if (string.IsNullOrEmpty(folderBrowserDialog.SelectedPath))
				return;
			else
				carregarMiniaturas(folderBrowserDialog.SelectedPath);
		}
		private void carregarMiniaturas(string pasta)
		{
			List<string> imagens = Imagem.Core.Ferramentas.ListaDeImagens(pasta);

			if (imagens.Count == 0)
			{
				MessageBox.Show("Nenhuma imagem disponível");
				return;
			}

			txtPasta.Text = pasta;

			foreach (string arquivo in imagens)
			{
				PictureBox pbImagemTemp = new PictureBox();
				pbImagemTemp.Image = Imagem.Core.Ferramentas.GerarMiniatura(arquivo);
				pbImagemTemp.Tag = arquivo;
				pbImagemTemp.DoubleClick += pictureBox_onDoubleclick;
				flowPanel.Controls.Add(pbImagemTemp);
			}
		}
		private void pictureBox_onDoubleclick(object sender, EventArgs e)
		{
			imagemCarregada = new Core.ImagemModelo()
			{
				ImagemCarregada = Image.FromFile((sender as PictureBox)
					.Tag
					.ToString()),
				ArquivoOriginal = (sender as PictureBox).Tag.ToString()
			};

			pbImagem.Image = imagemCarregada.ImagemCarregada;
			txtImagem.Text = imagemCarregada.ArquivoOriginal;
			txtImagemHtml.Text = imagemCarregada.ArquivoOriginal;
			string extensao = Path.GetExtension(imagemCarregada.ArquivoOriginal);
			bool selecionar = true;
			tabPrincipal.SelectedIndex = 1;

			foreach (string key in extensoesValidasParaExportar.Keys)
			{
				extensoesValidasParaExportar[key].Visible = key != extensao;

				if (extensoesValidasParaExportar[key].Visible && selecionar)
				{
					extensoesValidasParaExportar[key].Checked = true;
					selecionar = false;
				}
			}			
		}
		private void btnGravar_Click(object sender, EventArgs e)
		{
			string extensao = extensoesValidasParaExportar
				.Where(v => v.Value.Checked)
				.FirstOrDefault()
				.Key;
			
			string novoArquivo = String.Format("{0}{1}", 
				Path.Combine(imagemCarregada.PastaOriginal, 
					imagemCarregada.NomeDoArquivo),
				extensao);

			if (MessageBox.Show(
					string.Format("Confirma gravação do arquivo\n{0}\ncomo\n{1}", 
						imagemCarregada.ArquivoOriginal,	novoArquivo), 
					"Confirmação", MessageBoxButtons.YesNo, 
					MessageBoxIcon.Question) == DialogResult.Yes)
			{
				string erro = Core.Ferramentas.GravarNovoArquivo(
					imagemCarregada.ImagemCarregada, novoArquivo, extensao);

				if (string.IsNullOrEmpty(erro))
					MessageBox.Show("Operação concluída com sucesso");
				else
					MessageBox.Show("Erro: " + erro);
			}
		}
		private void btnGerarString_Click(object sender, EventArgs e)
		{
			if (imagemCarregada != null)
				txtHtml.Text = Core.Ferramentas.ImagemParaHtmlString(imagemCarregada);
		}
	}
}
