﻿namespace EmpireLauncher7DTD
{
    partial class LauncherEmpire
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LauncherEmpire));
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.dossier = new System.Windows.Forms.FolderBrowserDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.downloadLabel = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.percLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.AddExtension = false;
            this.openFileDialog1.CheckFileExists = false;
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Title = "Sélectionner le répertoire d\'installation de 7 DTD";
            // 
            // dossier
            // 
            this.dossier.RootFolder = System.Environment.SpecialFolder.MyComputer;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("DejaVu Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(518, 46);
            this.label1.TabIndex = 1;
            this.label1.Text = "L\'Empire du Charcuteur";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1265, 682);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // downloadLabel
            // 
            this.downloadLabel.AutoSize = true;
            this.downloadLabel.BackColor = System.Drawing.Color.Transparent;
            this.downloadLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.downloadLabel.Font = new System.Drawing.Font("DejaVu Serif", 15F);
            this.downloadLabel.ForeColor = System.Drawing.Color.Transparent;
            this.downloadLabel.Location = new System.Drawing.Point(12, 576);
            this.downloadLabel.Name = "downloadLabel";
            this.downloadLabel.Size = new System.Drawing.Size(0, 24);
            this.downloadLabel.TabIndex = 2;
            this.downloadLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 646);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(1240, 23);
            this.progressBar1.TabIndex = 3;
            // 
            // percLabel
            // 
            this.percLabel.AutoSize = true;
            this.percLabel.BackColor = System.Drawing.Color.Transparent;
            this.percLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.percLabel.Font = new System.Drawing.Font("DejaVu Serif", 10F);
            this.percLabel.ForeColor = System.Drawing.Color.Black;
            this.percLabel.Location = new System.Drawing.Point(17, 653);
            this.percLabel.Name = "percLabel";
            this.percLabel.Size = new System.Drawing.Size(0, 16);
            this.percLabel.TabIndex = 4;
            this.percLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LauncherEmpire
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.percLabel);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.downloadLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "LauncherEmpire";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Launcher Empire";
            this.Load += new System.EventHandler(this.LauncherEmpire_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.FolderBrowserDialog dossier;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label downloadLabel;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label percLabel;
    }
}

