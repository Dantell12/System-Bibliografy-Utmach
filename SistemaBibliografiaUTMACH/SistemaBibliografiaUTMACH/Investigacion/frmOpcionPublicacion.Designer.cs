namespace SistemaBibliografiaUTMACH.Investigacion
{
    partial class frmOpcionPublicacion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOpcionPublicacion));
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnActa = new System.Windows.Forms.Button();
            this.btnInforme = new System.Windows.Forms.Button();
            this.btnRevista = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Roboto Medium", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.label3.Location = new System.Drawing.Point(158, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(316, 28);
            this.label3.TabIndex = 10;
            this.label3.Text = "Publicar Artículo Cientifico";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(83, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(465, 24);
            this.label2.TabIndex = 11;
            this.label2.Text = "Elegir donde se desea publicar el Artículo Cientifico";
            // 
            // btnActa
            // 
            this.btnActa.FlatAppearance.BorderSize = 0;
            this.btnActa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActa.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActa.ForeColor = System.Drawing.Color.White;
            this.btnActa.Image = ((System.Drawing.Image)(resources.GetObject("btnActa.Image")));
            this.btnActa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnActa.Location = new System.Drawing.Point(1, 11);
            this.btnActa.Name = "btnActa";
            this.btnActa.Size = new System.Drawing.Size(211, 70);
            this.btnActa.TabIndex = 22;
            this.btnActa.Text = "Acta de Congreso";
            this.btnActa.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnActa.UseVisualStyleBackColor = true;
            this.btnActa.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnInforme
            // 
            this.btnInforme.FlatAppearance.BorderSize = 0;
            this.btnInforme.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInforme.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInforme.ForeColor = System.Drawing.Color.White;
            this.btnInforme.Image = ((System.Drawing.Image)(resources.GetObject("btnInforme.Image")));
            this.btnInforme.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInforme.Location = new System.Drawing.Point(218, 10);
            this.btnInforme.Name = "btnInforme";
            this.btnInforme.Size = new System.Drawing.Size(198, 70);
            this.btnInforme.TabIndex = 23;
            this.btnInforme.Text = "Informe Técnico";
            this.btnInforme.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnInforme.UseVisualStyleBackColor = true;
            this.btnInforme.Click += new System.EventHandler(this.btnInforme_Click);
            // 
            // btnRevista
            // 
            this.btnRevista.FlatAppearance.BorderSize = 0;
            this.btnRevista.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRevista.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRevista.ForeColor = System.Drawing.Color.White;
            this.btnRevista.Image = ((System.Drawing.Image)(resources.GetObject("btnRevista.Image")));
            this.btnRevista.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRevista.Location = new System.Drawing.Point(422, 10);
            this.btnRevista.Name = "btnRevista";
            this.btnRevista.Size = new System.Drawing.Size(209, 70);
            this.btnRevista.TabIndex = 24;
            this.btnRevista.Text = "Revista Cientifica";
            this.btnRevista.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRevista.UseVisualStyleBackColor = true;
            this.btnRevista.Click += new System.EventHandler(this.btnRevista_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(116)))), ((int)(((byte)(166)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnRevista);
            this.panel1.Controls.Add(this.btnInforme);
            this.panel1.Controls.Add(this.btnActa);
            this.panel1.Location = new System.Drawing.Point(-1, 120);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(632, 93);
            this.panel1.TabIndex = 25;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.button3);
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(630, 243);
            this.panel2.TabIndex = 26;
            // 
            // button3
            // 
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Image = ((System.Drawing.Image)(resources.GetObject("button3.Image")));
            this.button3.Location = new System.Drawing.Point(568, 3);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(57, 34);
            this.button3.TabIndex = 26;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // frmOpcionPublicacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(630, 243);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmOpcionPublicacion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmOpcionPublicacion";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnActa;
        private System.Windows.Forms.Button btnInforme;
        private System.Windows.Forms.Button btnRevista;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button3;
    }
}