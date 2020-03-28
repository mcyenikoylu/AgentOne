namespace agentone
{
    partial class frm_FirmaKartiSec
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
            this.dgv_firmakartisec = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btn_sec = new System.Windows.Forms.Button();
            this.btn_kapat = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_yenifirmakartiac = new System.Windows.Forms.Button();
            this.btn_ara = new System.Windows.Forms.Button();
            this.txt_ara = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_firmakartisec)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgv_firmakartisec
            // 
            this.dgv_firmakartisec.AllowUserToAddRows = false;
            this.dgv_firmakartisec.AllowUserToDeleteRows = false;
            this.dgv_firmakartisec.AllowUserToResizeRows = false;
            this.dgv_firmakartisec.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_firmakartisec.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_firmakartisec.Location = new System.Drawing.Point(0, 0);
            this.dgv_firmakartisec.MultiSelect = false;
            this.dgv_firmakartisec.Name = "dgv_firmakartisec";
            this.dgv_firmakartisec.ReadOnly = true;
            this.dgv_firmakartisec.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_firmakartisec.Size = new System.Drawing.Size(460, 400);
            this.dgv_firmakartisec.TabIndex = 0;
            this.dgv_firmakartisec.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgv_firmakartisec_CellMouseClick);
            this.dgv_firmakartisec.DoubleClick += new System.EventHandler(this.dgv_firmakartisec_DoubleClick);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.dgv_firmakartisec);
            this.panel2.Location = new System.Drawing.Point(12, 61);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(462, 402);
            this.panel2.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.btn_sec);
            this.panel3.Controls.Add(this.btn_kapat);
            this.panel3.Location = new System.Drawing.Point(12, 469);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(462, 31);
            this.panel3.TabIndex = 3;
            // 
            // btn_sec
            // 
            this.btn_sec.Location = new System.Drawing.Point(301, 3);
            this.btn_sec.Name = "btn_sec";
            this.btn_sec.Size = new System.Drawing.Size(75, 23);
            this.btn_sec.TabIndex = 1;
            this.btn_sec.Text = "Sec";
            this.btn_sec.UseVisualStyleBackColor = true;
            this.btn_sec.Click += new System.EventHandler(this.btn_sec_Click);
            // 
            // btn_kapat
            // 
            this.btn_kapat.Location = new System.Drawing.Point(382, 3);
            this.btn_kapat.Name = "btn_kapat";
            this.btn_kapat.Size = new System.Drawing.Size(75, 23);
            this.btn_kapat.TabIndex = 0;
            this.btn_kapat.Text = "Kapat";
            this.btn_kapat.UseVisualStyleBackColor = true;
            this.btn_kapat.Click += new System.EventHandler(this.btn_kapat_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btn_yenifirmakartiac);
            this.panel1.Controls.Add(this.btn_ara);
            this.panel1.Controls.Add(this.txt_ara);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(462, 43);
            this.panel1.TabIndex = 5;
            // 
            // btn_yenifirmakartiac
            // 
            this.btn_yenifirmakartiac.Location = new System.Drawing.Point(424, 9);
            this.btn_yenifirmakartiac.Name = "btn_yenifirmakartiac";
            this.btn_yenifirmakartiac.Size = new System.Drawing.Size(28, 23);
            this.btn_yenifirmakartiac.TabIndex = 3;
            this.btn_yenifirmakartiac.Text = "...";
            this.btn_yenifirmakartiac.UseVisualStyleBackColor = true;
            this.btn_yenifirmakartiac.Click += new System.EventHandler(this.btn_yenifirmakartiac_Click);
            // 
            // btn_ara
            // 
            this.btn_ara.Enabled = false;
            this.btn_ara.Location = new System.Drawing.Point(343, 9);
            this.btn_ara.Name = "btn_ara";
            this.btn_ara.Size = new System.Drawing.Size(75, 23);
            this.btn_ara.TabIndex = 2;
            this.btn_ara.Text = "Ara";
            this.btn_ara.UseVisualStyleBackColor = true;
            // 
            // txt_ara
            // 
            this.txt_ara.Enabled = false;
            this.txt_ara.Location = new System.Drawing.Point(85, 11);
            this.txt_ara.Name = "txt_ara";
            this.txt_ara.Size = new System.Drawing.Size(252, 20);
            this.txt_ara.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Arama Motoru";
            // 
            // frm_FirmaKartiSec
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(486, 512);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Name = "frm_FirmaKartiSec";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Firma Seç";
            this.Load += new System.EventHandler(this.frm_FirmaKartiSec_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_firmakartisec)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_firmakartisec;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btn_sec;
        private System.Windows.Forms.Button btn_kapat;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_yenifirmakartiac;
        private System.Windows.Forms.Button btn_ara;
        private System.Windows.Forms.TextBox txt_ara;
        private System.Windows.Forms.Label label1;
    }
}