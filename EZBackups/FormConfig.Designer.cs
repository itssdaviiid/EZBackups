namespace EZBackups
{
    partial class FormConfig
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
            this.cbPregunta = new System.Windows.Forms.CheckBox();
            this.cbComprimir = new System.Windows.Forms.CheckBox();
            this.edRuta = new System.Windows.Forms.TextBox();
            this.lbLoginAuxUser = new System.Windows.Forms.Label();
            this.panelSuperior = new System.Windows.Forms.Panel();
            this.btnEng = new System.Windows.Forms.Button();
            this.btnEsp = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.cbNormativa = new System.Windows.Forms.ComboBox();
            this.lbNormativa = new System.Windows.Forms.Label();
            this.lbEjemplo = new System.Windows.Forms.Label();
            this.panelSuperior.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbPregunta
            // 
            this.cbPregunta.AutoSize = true;
            this.cbPregunta.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.cbPregunta.ForeColor = System.Drawing.Color.Snow;
            this.cbPregunta.Location = new System.Drawing.Point(324, 232);
            this.cbPregunta.Name = "cbPregunta";
            this.cbPregunta.Size = new System.Drawing.Size(142, 24);
            this.cbPregunta.TabIndex = 22;
            this.cbPregunta.Text = "Preguntar antes";
            this.cbPregunta.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbPregunta.UseVisualStyleBackColor = true;
            // 
            // cbComprimir
            // 
            this.cbComprimir.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.cbComprimir.ForeColor = System.Drawing.Color.Snow;
            this.cbComprimir.Location = new System.Drawing.Point(77, 232);
            this.cbComprimir.Name = "cbComprimir";
            this.cbComprimir.Size = new System.Drawing.Size(197, 24);
            this.cbComprimir.TabIndex = 21;
            this.cbComprimir.Text = "Comprimir backups";
            this.cbComprimir.UseVisualStyleBackColor = true;
            // 
            // edRuta
            // 
            this.edRuta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.edRuta.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.edRuta.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edRuta.ForeColor = System.Drawing.Color.DimGray;
            this.edRuta.Location = new System.Drawing.Point(50, 62);
            this.edRuta.Name = "edRuta";
            this.edRuta.Size = new System.Drawing.Size(435, 19);
            this.edRuta.TabIndex = 19;
            this.edRuta.Text = "Carpeta de Proyextos";
            this.edRuta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.edRuta.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // lbLoginAuxUser
            // 
            this.lbLoginAuxUser.BackColor = System.Drawing.Color.Transparent;
            this.lbLoginAuxUser.ForeColor = System.Drawing.Color.Aqua;
            this.lbLoginAuxUser.Location = new System.Drawing.Point(46, 75);
            this.lbLoginAuxUser.Name = "lbLoginAuxUser";
            this.lbLoginAuxUser.Size = new System.Drawing.Size(439, 23);
            this.lbLoginAuxUser.TabIndex = 18;
            this.lbLoginAuxUser.Text = "_________________________________________________________";
            this.lbLoginAuxUser.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelSuperior
            // 
            this.panelSuperior.Controls.Add(this.btnEng);
            this.panelSuperior.Controls.Add(this.btnEsp);
            this.panelSuperior.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSuperior.Location = new System.Drawing.Point(0, 0);
            this.panelSuperior.Margin = new System.Windows.Forms.Padding(0);
            this.panelSuperior.Name = "panelSuperior";
            this.panelSuperior.Size = new System.Drawing.Size(550, 30);
            this.panelSuperior.TabIndex = 23;
            // 
            // btnEng
            // 
            this.btnEng.BackgroundImage = global::EZBackups.Properties.Resources.estados_unidos;
            this.btnEng.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnEng.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnEng.FlatAppearance.BorderSize = 0;
            this.btnEng.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEng.Location = new System.Drawing.Point(59, 0);
            this.btnEng.Name = "btnEng";
            this.btnEng.Size = new System.Drawing.Size(59, 30);
            this.btnEng.TabIndex = 25;
            this.btnEng.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnEng.UseVisualStyleBackColor = true;
            this.btnEng.Click += new System.EventHandler(this.btnEng_Click);
            // 
            // btnEsp
            // 
            this.btnEsp.BackgroundImage = global::EZBackups.Properties.Resources.espana__1_;
            this.btnEsp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnEsp.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnEsp.FlatAppearance.BorderSize = 0;
            this.btnEsp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEsp.Location = new System.Drawing.Point(0, 0);
            this.btnEsp.Name = "btnEsp";
            this.btnEsp.Size = new System.Drawing.Size(59, 30);
            this.btnEsp.TabIndex = 24;
            this.btnEsp.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnEsp.UseVisualStyleBackColor = true;
            this.btnEsp.Click += new System.EventHandler(this.btnEsp_Click);
            // 
            // cbNormativa
            // 
            this.cbNormativa.FormattingEnabled = true;
            this.cbNormativa.Items.AddRange(new object[] {
            "ISO 90081"});
            this.cbNormativa.Location = new System.Drawing.Point(334, 128);
            this.cbNormativa.Name = "cbNormativa";
            this.cbNormativa.Size = new System.Drawing.Size(151, 21);
            this.cbNormativa.TabIndex = 25;
            // 
            // lbNormativa
            // 
            this.lbNormativa.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lbNormativa.ForeColor = System.Drawing.Color.Snow;
            this.lbNormativa.Location = new System.Drawing.Point(55, 129);
            this.lbNormativa.Name = "lbNormativa";
            this.lbNormativa.Size = new System.Drawing.Size(267, 20);
            this.lbNormativa.TabIndex = 26;
            this.lbNormativa.Text = "Normativa de nomenclatura backups";
            this.lbNormativa.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbEjemplo
            // 
            this.lbEjemplo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lbEjemplo.ForeColor = System.Drawing.Color.DimGray;
            this.lbEjemplo.Location = new System.Drawing.Point(74, 170);
            this.lbEjemplo.Name = "lbEjemplo";
            this.lbEjemplo.Size = new System.Drawing.Size(387, 15);
            this.lbEjemplo.TabIndex = 27;
            this.lbEjemplo.Text = "Nombre de archivos ejemplo: \"AAAAMMDD_MiProyectoEnDesarrollo\"";
            this.lbEjemplo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FormConfig
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.ClientSize = new System.Drawing.Size(550, 315);
            this.Controls.Add(this.lbEjemplo);
            this.Controls.Add(this.lbNormativa);
            this.Controls.Add(this.cbNormativa);
            this.Controls.Add(this.panelSuperior);
            this.Controls.Add(this.cbPregunta);
            this.Controls.Add(this.cbComprimir);
            this.Controls.Add(this.edRuta);
            this.Controls.Add(this.lbLoginAuxUser);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormConfig";
            this.Text = "frmConfig";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormConfig_FormClosing);
            this.Load += new System.EventHandler(this.FormConfig_Load);
            this.panelSuperior.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox cbPregunta;
        private System.Windows.Forms.CheckBox cbComprimir;
        private System.Windows.Forms.TextBox edRuta;
        private System.Windows.Forms.Label lbLoginAuxUser;
        private System.Windows.Forms.Panel panelSuperior;
        private System.Windows.Forms.Button btnEsp;
        private System.Windows.Forms.Button btnEng;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.ComboBox cbNormativa;
        private System.Windows.Forms.Label lbNormativa;
        private System.Windows.Forms.Label lbEjemplo;
    }
}