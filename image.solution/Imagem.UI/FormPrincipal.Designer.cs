namespace Imagem.UI
{
	partial class FormPrincipal
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.tabPrincipal = new System.Windows.Forms.TabControl();
			this.tabImagens = new System.Windows.Forms.TabPage();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.btnSelecionar = new System.Windows.Forms.Button();
			this.txtPasta = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.flowPanel = new System.Windows.Forms.FlowLayoutPanel();
			this.tabConverter = new System.Windows.Forms.TabPage();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.btnGravar = new System.Windows.Forms.Button();
			this.rbGif = new System.Windows.Forms.RadioButton();
			this.rbPng = new System.Windows.Forms.RadioButton();
			this.rbJpg = new System.Windows.Forms.RadioButton();
			this.rdBmp = new System.Windows.Forms.RadioButton();
			this.pbImagem = new System.Windows.Forms.PictureBox();
			this.txtImagem = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.tabGerarHtml = new System.Windows.Forms.TabPage();
			this.btnGerarString = new System.Windows.Forms.Button();
			this.txtHtml = new System.Windows.Forms.TextBox();
			this.txtImagemHtml = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.tabPrincipal.SuspendLayout();
			this.tabImagens.SuspendLayout();
			this.tabConverter.SuspendLayout();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pbImagem)).BeginInit();
			this.tabGerarHtml.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabPrincipal
			// 
			this.tabPrincipal.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tabPrincipal.Controls.Add(this.tabImagens);
			this.tabPrincipal.Controls.Add(this.tabConverter);
			this.tabPrincipal.Controls.Add(this.tabGerarHtml);
			this.tabPrincipal.Location = new System.Drawing.Point(13, 13);
			this.tabPrincipal.Name = "tabPrincipal";
			this.tabPrincipal.SelectedIndex = 0;
			this.tabPrincipal.Size = new System.Drawing.Size(607, 425);
			this.tabPrincipal.TabIndex = 0;
			// 
			// tabImagens
			// 
			this.tabImagens.Controls.Add(this.label3);
			this.tabImagens.Controls.Add(this.label2);
			this.tabImagens.Controls.Add(this.btnSelecionar);
			this.tabImagens.Controls.Add(this.txtPasta);
			this.tabImagens.Controls.Add(this.label1);
			this.tabImagens.Controls.Add(this.flowPanel);
			this.tabImagens.Location = new System.Drawing.Point(4, 22);
			this.tabImagens.Name = "tabImagens";
			this.tabImagens.Padding = new System.Windows.Forms.Padding(3);
			this.tabImagens.Size = new System.Drawing.Size(599, 399);
			this.tabImagens.TabIndex = 0;
			this.tabImagens.Text = "Imagens";
			this.tabImagens.UseVisualStyleBackColor = true;
			// 
			// label3
			// 
			this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(6, 379);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(297, 13);
			this.label3.TabIndex = 5;
			this.label3.Text = "Dê um clique duplo para abrir a imagem na aba de conversão";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(6, 43);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(112, 13);
			this.label2.TabIndex = 4;
			this.label2.Text = "Imagens encontradas:";
			// 
			// btnSelecionar
			// 
			this.btnSelecionar.Location = new System.Drawing.Point(424, 6);
			this.btnSelecionar.Name = "btnSelecionar";
			this.btnSelecionar.Size = new System.Drawing.Size(75, 23);
			this.btnSelecionar.TabIndex = 3;
			this.btnSelecionar.Text = "Selecionar...";
			this.btnSelecionar.UseVisualStyleBackColor = true;
			this.btnSelecionar.Click += new System.EventHandler(this.btnSelecionar_Click);
			// 
			// txtPasta
			// 
			this.txtPasta.Location = new System.Drawing.Point(113, 7);
			this.txtPasta.Name = "txtPasta";
			this.txtPasta.ReadOnly = true;
			this.txtPasta.Size = new System.Drawing.Size(304, 20);
			this.txtPasta.TabIndex = 2;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(6, 11);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "Pasta selecionada: ";
			// 
			// flowPanel
			// 
			this.flowPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.flowPanel.AutoScroll = true;
			this.flowPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.flowPanel.Location = new System.Drawing.Point(6, 59);
			this.flowPanel.Name = "flowPanel";
			this.flowPanel.Padding = new System.Windows.Forms.Padding(5);
			this.flowPanel.Size = new System.Drawing.Size(587, 317);
			this.flowPanel.TabIndex = 0;
			// 
			// tabConverter
			// 
			this.tabConverter.Controls.Add(this.groupBox1);
			this.tabConverter.Controls.Add(this.pbImagem);
			this.tabConverter.Controls.Add(this.txtImagem);
			this.tabConverter.Controls.Add(this.label4);
			this.tabConverter.Location = new System.Drawing.Point(4, 22);
			this.tabConverter.Name = "tabConverter";
			this.tabConverter.Padding = new System.Windows.Forms.Padding(3);
			this.tabConverter.Size = new System.Drawing.Size(599, 399);
			this.tabConverter.TabIndex = 1;
			this.tabConverter.Text = "Converter";
			this.tabConverter.UseVisualStyleBackColor = true;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.btnGravar);
			this.groupBox1.Controls.Add(this.rbGif);
			this.groupBox1.Controls.Add(this.rbPng);
			this.groupBox1.Controls.Add(this.rbJpg);
			this.groupBox1.Controls.Add(this.rdBmp);
			this.groupBox1.Location = new System.Drawing.Point(11, 36);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(582, 54);
			this.groupBox1.TabIndex = 6;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Salvar como: ";
			// 
			// btnGravar
			// 
			this.btnGravar.Location = new System.Drawing.Point(210, 16);
			this.btnGravar.Name = "btnGravar";
			this.btnGravar.Size = new System.Drawing.Size(75, 23);
			this.btnGravar.TabIndex = 1;
			this.btnGravar.Text = "Gravar";
			this.btnGravar.UseVisualStyleBackColor = true;
			this.btnGravar.Click += new System.EventHandler(this.btnGravar_Click);
			// 
			// rbGif
			// 
			this.rbGif.AutoSize = true;
			this.rbGif.Location = new System.Drawing.Point(162, 19);
			this.rbGif.Name = "rbGif";
			this.rbGif.Size = new System.Drawing.Size(42, 17);
			this.rbGif.TabIndex = 0;
			this.rbGif.TabStop = true;
			this.rbGif.Text = "GIF";
			this.rbGif.UseVisualStyleBackColor = true;
			// 
			// rbPng
			// 
			this.rbPng.AutoSize = true;
			this.rbPng.Location = new System.Drawing.Point(112, 19);
			this.rbPng.Name = "rbPng";
			this.rbPng.Size = new System.Drawing.Size(48, 17);
			this.rbPng.TabIndex = 0;
			this.rbPng.TabStop = true;
			this.rbPng.Text = "PNG";
			this.rbPng.UseVisualStyleBackColor = true;
			// 
			// rbJpg
			// 
			this.rbJpg.AutoSize = true;
			this.rbJpg.Location = new System.Drawing.Point(65, 19);
			this.rbJpg.Name = "rbJpg";
			this.rbJpg.Size = new System.Drawing.Size(45, 17);
			this.rbJpg.TabIndex = 0;
			this.rbJpg.TabStop = true;
			this.rbJpg.Text = "JPG";
			this.rbJpg.UseVisualStyleBackColor = true;
			// 
			// rdBmp
			// 
			this.rdBmp.AutoSize = true;
			this.rdBmp.Location = new System.Drawing.Point(15, 19);
			this.rdBmp.Name = "rdBmp";
			this.rdBmp.Size = new System.Drawing.Size(48, 17);
			this.rdBmp.TabIndex = 0;
			this.rdBmp.TabStop = true;
			this.rdBmp.Text = "BMP";
			this.rdBmp.UseVisualStyleBackColor = true;
			// 
			// pbImagem
			// 
			this.pbImagem.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.pbImagem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.pbImagem.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.pbImagem.Location = new System.Drawing.Point(11, 96);
			this.pbImagem.Name = "pbImagem";
			this.pbImagem.Size = new System.Drawing.Size(582, 297);
			this.pbImagem.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pbImagem.TabIndex = 5;
			this.pbImagem.TabStop = false;
			// 
			// txtImagem
			// 
			this.txtImagem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtImagem.Location = new System.Drawing.Point(121, 7);
			this.txtImagem.Name = "txtImagem";
			this.txtImagem.ReadOnly = true;
			this.txtImagem.Size = new System.Drawing.Size(472, 20);
			this.txtImagem.TabIndex = 4;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(8, 10);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(107, 13);
			this.label4.TabIndex = 3;
			this.label4.Text = "Imagem selecionada:";
			// 
			// tabGerarHtml
			// 
			this.tabGerarHtml.Controls.Add(this.btnGerarString);
			this.tabGerarHtml.Controls.Add(this.txtHtml);
			this.tabGerarHtml.Controls.Add(this.txtImagemHtml);
			this.tabGerarHtml.Controls.Add(this.label6);
			this.tabGerarHtml.Controls.Add(this.label5);
			this.tabGerarHtml.Location = new System.Drawing.Point(4, 22);
			this.tabGerarHtml.Name = "tabGerarHtml";
			this.tabGerarHtml.Padding = new System.Windows.Forms.Padding(3);
			this.tabGerarHtml.Size = new System.Drawing.Size(599, 399);
			this.tabGerarHtml.TabIndex = 2;
			this.tabGerarHtml.Text = "Gerar Html";
			this.tabGerarHtml.UseVisualStyleBackColor = true;
			// 
			// btnGerarString
			// 
			this.btnGerarString.Location = new System.Drawing.Point(507, 33);
			this.btnGerarString.Name = "btnGerarString";
			this.btnGerarString.Size = new System.Drawing.Size(75, 23);
			this.btnGerarString.TabIndex = 9;
			this.btnGerarString.Text = "Gerar";
			this.btnGerarString.UseVisualStyleBackColor = true;
			this.btnGerarString.Click += new System.EventHandler(this.btnGerarString_Click);
			// 
			// txtHtml
			// 
			this.txtHtml.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtHtml.Location = new System.Drawing.Point(11, 62);
			this.txtHtml.Multiline = true;
			this.txtHtml.Name = "txtHtml";
			this.txtHtml.ReadOnly = true;
			this.txtHtml.Size = new System.Drawing.Size(571, 320);
			this.txtHtml.TabIndex = 7;
			// 
			// txtImagemHtml
			// 
			this.txtImagemHtml.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtImagemHtml.Location = new System.Drawing.Point(121, 6);
			this.txtImagemHtml.Name = "txtImagemHtml";
			this.txtImagemHtml.ReadOnly = true;
			this.txtImagemHtml.Size = new System.Drawing.Size(461, 20);
			this.txtImagemHtml.TabIndex = 6;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(8, 38);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(67, 13);
			this.label6.TabIndex = 5;
			this.label6.Text = "Html gerado:";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(8, 9);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(107, 13);
			this.label5.TabIndex = 5;
			this.label5.Text = "Imagem selecionada:";
			// 
			// folderBrowserDialog
			// 
			this.folderBrowserDialog.Description = "Escolha a pasta para as imagens";
			this.folderBrowserDialog.ShowNewFolderButton = false;
			// 
			// FormPrincipal
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(632, 450);
			this.Controls.Add(this.tabPrincipal);
			this.Name = "FormPrincipal";
			this.Text = "Easy .Net - Manipulando Imagens";
			this.tabPrincipal.ResumeLayout(false);
			this.tabImagens.ResumeLayout(false);
			this.tabImagens.PerformLayout();
			this.tabConverter.ResumeLayout(false);
			this.tabConverter.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pbImagem)).EndInit();
			this.tabGerarHtml.ResumeLayout(false);
			this.tabGerarHtml.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TabControl tabPrincipal;
		private System.Windows.Forms.TabPage tabImagens;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button btnSelecionar;
		private System.Windows.Forms.TextBox txtPasta;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.FlowLayoutPanel flowPanel;
		private System.Windows.Forms.TabPage tabConverter;
		private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button btnGravar;
		private System.Windows.Forms.RadioButton rbGif;
		private System.Windows.Forms.RadioButton rbPng;
		private System.Windows.Forms.RadioButton rbJpg;
		private System.Windows.Forms.RadioButton rdBmp;
		private System.Windows.Forms.PictureBox pbImagem;
		private System.Windows.Forms.TextBox txtImagem;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TabPage tabGerarHtml;
		private System.Windows.Forms.TextBox txtHtml;
		private System.Windows.Forms.TextBox txtImagemHtml;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.Button btnGerarString;
	}
}

