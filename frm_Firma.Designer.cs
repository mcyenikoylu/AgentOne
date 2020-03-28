namespace agentone
{
    partial class frm_Firma
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.dosyaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.çıkışToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.işlemlerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.firmaKartlarıToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tekliflerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.siparişlerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.raporlarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.araçlarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.renkBilgilerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bedenBilgileriToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kullanıcıBilgileriToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ürünGrubuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ürünDurumuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.teklifDurumuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.siparişDurumuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.paraBirimleriToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.yüklemeŞekliToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ödemeŞekliToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.birimBilgileriToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dgw_firma = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cb_firmadurumu = new System.Windows.Forms.ComboBox();
            this.cb_kullanici = new System.Windows.Forms.ComboBox();
            this.frm_ara = new System.Windows.Forms.Button();
            this.txt_ara = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_ekraniguncelle = new System.Windows.Forms.Button();
            this.btn_liste = new System.Windows.Forms.Button();
            this.btn_kartiyazdir = new System.Windows.Forms.Button();
            this.btn_goruntule = new System.Windows.Forms.Button();
            this.btn_yenikayit = new System.Windows.Forms.Button();
            this.btn_sil = new System.Windows.Forms.Button();
            this.btn_duzenle = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgw_firma)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dosyaToolStripMenuItem,
            this.işlemlerToolStripMenuItem,
            this.araçlarToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1008, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // dosyaToolStripMenuItem
            // 
            this.dosyaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.çıkışToolStripMenuItem});
            this.dosyaToolStripMenuItem.Name = "dosyaToolStripMenuItem";
            this.dosyaToolStripMenuItem.Size = new System.Drawing.Size(49, 20);
            this.dosyaToolStripMenuItem.Text = "Dosya";
            // 
            // çıkışToolStripMenuItem
            // 
            this.çıkışToolStripMenuItem.Name = "çıkışToolStripMenuItem";
            this.çıkışToolStripMenuItem.Size = new System.Drawing.Size(95, 22);
            this.çıkışToolStripMenuItem.Text = "Çıkış";
            this.çıkışToolStripMenuItem.Click += new System.EventHandler(this.çıkışToolStripMenuItem_Click);
            // 
            // işlemlerToolStripMenuItem
            // 
            this.işlemlerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.firmaKartlarıToolStripMenuItem,
            this.tekliflerToolStripMenuItem,
            this.siparişlerToolStripMenuItem,
            this.raporlarToolStripMenuItem});
            this.işlemlerToolStripMenuItem.Name = "işlemlerToolStripMenuItem";
            this.işlemlerToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.işlemlerToolStripMenuItem.Text = "İşlemler";
            // 
            // firmaKartlarıToolStripMenuItem
            // 
            this.firmaKartlarıToolStripMenuItem.Name = "firmaKartlarıToolStripMenuItem";
            this.firmaKartlarıToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.firmaKartlarıToolStripMenuItem.Text = "Firma Kartları";
            this.firmaKartlarıToolStripMenuItem.Click += new System.EventHandler(this.firmaKartlarıToolStripMenuItem_Click);
            // 
            // tekliflerToolStripMenuItem
            // 
            this.tekliflerToolStripMenuItem.Name = "tekliflerToolStripMenuItem";
            this.tekliflerToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.tekliflerToolStripMenuItem.Text = "Teklifler";
            this.tekliflerToolStripMenuItem.Click += new System.EventHandler(this.tekliflerToolStripMenuItem_Click);
            // 
            // siparişlerToolStripMenuItem
            // 
            this.siparişlerToolStripMenuItem.Name = "siparişlerToolStripMenuItem";
            this.siparişlerToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.siparişlerToolStripMenuItem.Text = "Siparişler";
            this.siparişlerToolStripMenuItem.Click += new System.EventHandler(this.siparişlerToolStripMenuItem_Click);
            // 
            // raporlarToolStripMenuItem
            // 
            this.raporlarToolStripMenuItem.Name = "raporlarToolStripMenuItem";
            this.raporlarToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.raporlarToolStripMenuItem.Text = "Raporlar";
            this.raporlarToolStripMenuItem.Visible = false;
            this.raporlarToolStripMenuItem.Click += new System.EventHandler(this.raporlarToolStripMenuItem_Click);
            // 
            // araçlarToolStripMenuItem
            // 
            this.araçlarToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.renkBilgilerToolStripMenuItem,
            this.bedenBilgileriToolStripMenuItem,
            this.kullanıcıBilgileriToolStripMenuItem,
            this.ürünGrubuToolStripMenuItem,
            this.ürünDurumuToolStripMenuItem,
            this.teklifDurumuToolStripMenuItem,
            this.siparişDurumuToolStripMenuItem,
            this.paraBirimleriToolStripMenuItem,
            this.yüklemeŞekliToolStripMenuItem,
            this.ödemeŞekliToolStripMenuItem,
            this.birimBilgileriToolStripMenuItem});
            this.araçlarToolStripMenuItem.Name = "araçlarToolStripMenuItem";
            this.araçlarToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.araçlarToolStripMenuItem.Text = "Araçlar";
            this.araçlarToolStripMenuItem.Visible = false;
            // 
            // renkBilgilerToolStripMenuItem
            // 
            this.renkBilgilerToolStripMenuItem.Name = "renkBilgilerToolStripMenuItem";
            this.renkBilgilerToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.renkBilgilerToolStripMenuItem.Text = "Renk Bilgiler";
            // 
            // bedenBilgileriToolStripMenuItem
            // 
            this.bedenBilgileriToolStripMenuItem.Name = "bedenBilgileriToolStripMenuItem";
            this.bedenBilgileriToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.bedenBilgileriToolStripMenuItem.Text = "Beden Bilgileri";
            // 
            // kullanıcıBilgileriToolStripMenuItem
            // 
            this.kullanıcıBilgileriToolStripMenuItem.Name = "kullanıcıBilgileriToolStripMenuItem";
            this.kullanıcıBilgileriToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.kullanıcıBilgileriToolStripMenuItem.Text = "Kullanıcı Bilgileri";
            // 
            // ürünGrubuToolStripMenuItem
            // 
            this.ürünGrubuToolStripMenuItem.Name = "ürünGrubuToolStripMenuItem";
            this.ürünGrubuToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.ürünGrubuToolStripMenuItem.Text = "Ürün Grubu";
            // 
            // ürünDurumuToolStripMenuItem
            // 
            this.ürünDurumuToolStripMenuItem.Name = "ürünDurumuToolStripMenuItem";
            this.ürünDurumuToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.ürünDurumuToolStripMenuItem.Text = "Ürün Durumu";
            // 
            // teklifDurumuToolStripMenuItem
            // 
            this.teklifDurumuToolStripMenuItem.Name = "teklifDurumuToolStripMenuItem";
            this.teklifDurumuToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.teklifDurumuToolStripMenuItem.Text = "Teklif Durumu";
            // 
            // siparişDurumuToolStripMenuItem
            // 
            this.siparişDurumuToolStripMenuItem.Name = "siparişDurumuToolStripMenuItem";
            this.siparişDurumuToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.siparişDurumuToolStripMenuItem.Text = "Sipariş Durumu";
            // 
            // paraBirimleriToolStripMenuItem
            // 
            this.paraBirimleriToolStripMenuItem.Name = "paraBirimleriToolStripMenuItem";
            this.paraBirimleriToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.paraBirimleriToolStripMenuItem.Text = "Para Birimleri";
            // 
            // yüklemeŞekliToolStripMenuItem
            // 
            this.yüklemeŞekliToolStripMenuItem.Name = "yüklemeŞekliToolStripMenuItem";
            this.yüklemeŞekliToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.yüklemeŞekliToolStripMenuItem.Text = "Yükleme Şekli";
            // 
            // ödemeŞekliToolStripMenuItem
            // 
            this.ödemeŞekliToolStripMenuItem.Name = "ödemeŞekliToolStripMenuItem";
            this.ödemeŞekliToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.ödemeŞekliToolStripMenuItem.Text = "Ödeme Şekli";
            // 
            // birimBilgileriToolStripMenuItem
            // 
            this.birimBilgileriToolStripMenuItem.Name = "birimBilgileriToolStripMenuItem";
            this.birimBilgileriToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.birimBilgileriToolStripMenuItem.Text = "Birim Bilgileri";
            // 
            // dgw_firma
            // 
            this.dgw_firma.AllowDrop = true;
            this.dgw_firma.AllowUserToAddRows = false;
            this.dgw_firma.AllowUserToDeleteRows = false;
            this.dgw_firma.AllowUserToOrderColumns = true;
            this.dgw_firma.AllowUserToResizeRows = false;
            this.dgw_firma.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgw_firma.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgw_firma.Location = new System.Drawing.Point(0, 0);
            this.dgw_firma.MultiSelect = false;
            this.dgw_firma.Name = "dgw_firma";
            this.dgw_firma.ReadOnly = true;
            this.dgw_firma.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgw_firma.Size = new System.Drawing.Size(1008, 633);
            this.dgw_firma.TabIndex = 4;
            this.dgw_firma.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgw_firma_CellMouseClick);
            this.dgw_firma.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgw_firma_CellMouseDoubleClick);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 657);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1008, 75);
            this.panel2.TabIndex = 6;
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.label2);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Controls.Add(this.cb_firmadurumu);
            this.panel4.Controls.Add(this.cb_kullanici);
            this.panel4.Controls.Add(this.frm_ara);
            this.panel4.Controls.Add(this.txt_ara);
            this.panel4.Location = new System.Drawing.Point(278, 6);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(399, 62);
            this.panel4.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(194, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Firma Durumu";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Kullanıcı";
            // 
            // cb_firmadurumu
            // 
            this.cb_firmadurumu.Enabled = false;
            this.cb_firmadurumu.FormattingEnabled = true;
            this.cb_firmadurumu.Location = new System.Drawing.Point(272, 34);
            this.cb_firmadurumu.Name = "cb_firmadurumu";
            this.cb_firmadurumu.Size = new System.Drawing.Size(121, 21);
            this.cb_firmadurumu.TabIndex = 3;
            // 
            // cb_kullanici
            // 
            this.cb_kullanici.Enabled = false;
            this.cb_kullanici.FormattingEnabled = true;
            this.cb_kullanici.Location = new System.Drawing.Point(52, 34);
            this.cb_kullanici.Name = "cb_kullanici";
            this.cb_kullanici.Size = new System.Drawing.Size(121, 21);
            this.cb_kullanici.TabIndex = 2;
            // 
            // frm_ara
            // 
            this.frm_ara.Location = new System.Drawing.Point(318, 3);
            this.frm_ara.Name = "frm_ara";
            this.frm_ara.Size = new System.Drawing.Size(75, 23);
            this.frm_ara.TabIndex = 1;
            this.frm_ara.Text = "Ara";
            this.frm_ara.UseVisualStyleBackColor = true;
            this.frm_ara.Click += new System.EventHandler(this.frm_ara_Click);
            // 
            // txt_ara
            // 
            this.txt_ara.Location = new System.Drawing.Point(6, 5);
            this.txt_ara.Name = "txt_ara";
            this.txt_ara.Size = new System.Drawing.Size(306, 20);
            this.txt_ara.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btn_ekraniguncelle);
            this.panel1.Controls.Add(this.btn_goruntule);
            this.panel1.Controls.Add(this.btn_yenikayit);
            this.panel1.Controls.Add(this.btn_sil);
            this.panel1.Controls.Add(this.btn_duzenle);
            this.panel1.Location = new System.Drawing.Point(5, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(267, 62);
            this.panel1.TabIndex = 3;
            // 
            // btn_ekraniguncelle
            // 
            this.btn_ekraniguncelle.Location = new System.Drawing.Point(165, 3);
            this.btn_ekraniguncelle.Name = "btn_ekraniguncelle";
            this.btn_ekraniguncelle.Size = new System.Drawing.Size(95, 23);
            this.btn_ekraniguncelle.TabIndex = 5;
            this.btn_ekraniguncelle.Text = "Ekranı Güncelle";
            this.btn_ekraniguncelle.UseVisualStyleBackColor = true;
            this.btn_ekraniguncelle.Click += new System.EventHandler(this.btn_ekraniguncelle_Click);
            // 
            // btn_liste
            // 
            this.btn_liste.Location = new System.Drawing.Point(3, 32);
            this.btn_liste.Name = "btn_liste";
            this.btn_liste.Size = new System.Drawing.Size(75, 23);
            this.btn_liste.TabIndex = 4;
            this.btn_liste.Text = "Liste";
            this.btn_liste.UseVisualStyleBackColor = true;
            this.btn_liste.Click += new System.EventHandler(this.btn_liste_Click);
            // 
            // btn_kartiyazdir
            // 
            this.btn_kartiyazdir.Enabled = false;
            this.btn_kartiyazdir.Location = new System.Drawing.Point(3, 3);
            this.btn_kartiyazdir.Name = "btn_kartiyazdir";
            this.btn_kartiyazdir.Size = new System.Drawing.Size(75, 23);
            this.btn_kartiyazdir.TabIndex = 4;
            this.btn_kartiyazdir.Text = "Kartı Yazdır";
            this.btn_kartiyazdir.UseVisualStyleBackColor = true;
            // 
            // btn_goruntule
            // 
            this.btn_goruntule.Location = new System.Drawing.Point(84, 3);
            this.btn_goruntule.Name = "btn_goruntule";
            this.btn_goruntule.Size = new System.Drawing.Size(75, 23);
            this.btn_goruntule.TabIndex = 3;
            this.btn_goruntule.Text = "Görüntüle";
            this.btn_goruntule.UseVisualStyleBackColor = true;
            this.btn_goruntule.Click += new System.EventHandler(this.btn_goruntule_Click);
            // 
            // btn_yenikayit
            // 
            this.btn_yenikayit.Location = new System.Drawing.Point(3, 3);
            this.btn_yenikayit.Name = "btn_yenikayit";
            this.btn_yenikayit.Size = new System.Drawing.Size(75, 23);
            this.btn_yenikayit.TabIndex = 0;
            this.btn_yenikayit.Text = "Yeni Kayıt";
            this.btn_yenikayit.UseVisualStyleBackColor = true;
            this.btn_yenikayit.Click += new System.EventHandler(this.btn_yenikayit_Click);
            // 
            // btn_sil
            // 
            this.btn_sil.Location = new System.Drawing.Point(84, 32);
            this.btn_sil.Name = "btn_sil";
            this.btn_sil.Size = new System.Drawing.Size(75, 23);
            this.btn_sil.TabIndex = 2;
            this.btn_sil.Text = "Sil";
            this.btn_sil.UseVisualStyleBackColor = true;
            this.btn_sil.Click += new System.EventHandler(this.btn_sil_Click);
            // 
            // btn_duzenle
            // 
            this.btn_duzenle.Location = new System.Drawing.Point(3, 32);
            this.btn_duzenle.Name = "btn_duzenle";
            this.btn_duzenle.Size = new System.Drawing.Size(75, 23);
            this.btn_duzenle.TabIndex = 1;
            this.btn_duzenle.Text = "Düzenle";
            this.btn_duzenle.UseVisualStyleBackColor = true;
            this.btn_duzenle.Click += new System.EventHandler(this.btn_duzenle_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dgw_firma);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 24);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1008, 633);
            this.panel3.TabIndex = 7;
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.btn_kartiyazdir);
            this.panel5.Controls.Add(this.btn_liste);
            this.panel5.Location = new System.Drawing.Point(683, 6);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(84, 62);
            this.panel5.TabIndex = 5;
            // 
            // frm_Firma
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 732);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.menuStrip1);
            this.Name = "frm_Firma";
            this.Text = "Firma";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frm_Firma_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgw_firma)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem dosyaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem çıkışToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem işlemlerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem firmaKartlarıToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tekliflerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem siparişlerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem raporlarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem araçlarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem renkBilgilerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bedenBilgileriToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kullanıcıBilgileriToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ürünGrubuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ürünDurumuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem teklifDurumuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem siparişDurumuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem paraBirimleriToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem yüklemeŞekliToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ödemeŞekliToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem birimBilgileriToolStripMenuItem;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_yenikayit;
        private System.Windows.Forms.Button btn_sil;
        private System.Windows.Forms.Button btn_duzenle;
        private System.Windows.Forms.Button btn_kartiyazdir;
        private System.Windows.Forms.Button btn_goruntule;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox txt_ara;
        private System.Windows.Forms.Button btn_liste;
        private System.Windows.Forms.Button frm_ara;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cb_firmadurumu;
        private System.Windows.Forms.ComboBox cb_kullanici;
        private System.Windows.Forms.Button btn_ekraniguncelle;
        public System.Windows.Forms.DataGridView dgw_firma;
        private System.Windows.Forms.Panel panel5;
    }
}