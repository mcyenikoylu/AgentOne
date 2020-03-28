namespace agentone
{
    partial class frm_RenkBedenDagilimi
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
            this.cbl_renk = new System.Windows.Forms.CheckedListBox();
            this.cbl_beden = new System.Windows.Forms.CheckedListBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btn_iptal = new System.Windows.Forms.Button();
            this.btn_kaydet = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel3.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbl_renk
            // 
            this.cbl_renk.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbl_renk.FormattingEnabled = true;
            this.cbl_renk.Location = new System.Drawing.Point(0, 0);
            this.cbl_renk.Name = "cbl_renk";
            this.cbl_renk.Size = new System.Drawing.Size(364, 319);
            this.cbl_renk.TabIndex = 0;
            // 
            // cbl_beden
            // 
            this.cbl_beden.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbl_beden.FormattingEnabled = true;
            this.cbl_beden.Location = new System.Drawing.Point(0, 0);
            this.cbl_beden.Name = "cbl_beden";
            this.cbl_beden.Size = new System.Drawing.Size(377, 319);
            this.cbl_beden.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.btn_iptal);
            this.panel3.Controls.Add(this.btn_kaydet);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 326);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(745, 48);
            this.panel3.TabIndex = 4;
            // 
            // btn_iptal
            // 
            this.btn_iptal.Location = new System.Drawing.Point(92, 12);
            this.btn_iptal.Name = "btn_iptal";
            this.btn_iptal.Size = new System.Drawing.Size(75, 23);
            this.btn_iptal.TabIndex = 1;
            this.btn_iptal.Text = "İptal";
            this.btn_iptal.UseVisualStyleBackColor = true;
            // 
            // btn_kaydet
            // 
            this.btn_kaydet.Location = new System.Drawing.Point(11, 12);
            this.btn_kaydet.Name = "btn_kaydet";
            this.btn_kaydet.Size = new System.Drawing.Size(75, 23);
            this.btn_kaydet.TabIndex = 0;
            this.btn_kaydet.Text = "Kaydet";
            this.btn_kaydet.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.cbl_renk);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.cbl_beden);
            this.splitContainer1.Size = new System.Drawing.Size(745, 326);
            this.splitContainer1.SplitterDistance = 364;
            this.splitContainer1.TabIndex = 5;
            // 
            // frm_RenkBedenDagilimi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(745, 374);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel3);
            this.Name = "frm_RenkBedenDagilimi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Renk Beden Dağılımı";
            this.Load += new System.EventHandler(this.frm_RenkBedenDagilimi_Load);
            this.panel3.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckedListBox cbl_renk;
        private System.Windows.Forms.CheckedListBox cbl_beden;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btn_iptal;
        private System.Windows.Forms.Button btn_kaydet;
        private System.Windows.Forms.SplitContainer splitContainer1;
    }
}