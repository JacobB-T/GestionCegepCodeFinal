namespace GestionCegep.Formulaires
{
    partial class formHoraire
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
            this.dataGVHoraire = new System.Windows.Forms.DataGridView();
            this.colHeure = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLundi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMardi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMercredi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colJeudi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colVendredi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblBienvenuHoraire = new System.Windows.Forms.Label();
            this.lblNombreHeureCoursAnnonce = new System.Windows.Forms.Label();
            this.lblNbHeuresCours = new System.Windows.Forms.Label();
            this.lblNumeroHoraire = new System.Windows.Forms.Label();
            this.btnRetourAccueil = new System.Windows.Forms.Button();
            this.lblTypeUsagerHoraire = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGVHoraire)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGVHoraire
            // 
            this.dataGVHoraire.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGVHoraire.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGVHoraire.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colHeure,
            this.colLundi,
            this.colMardi,
            this.colMercredi,
            this.colJeudi,
            this.colVendredi});
            this.dataGVHoraire.Location = new System.Drawing.Point(28, 72);
            this.dataGVHoraire.Name = "dataGVHoraire";
            this.dataGVHoraire.Size = new System.Drawing.Size(1226, 485);
            this.dataGVHoraire.TabIndex = 0;
            // 
            // colHeure
            // 
            this.colHeure.HeaderText = "Heure";
            this.colHeure.Name = "colHeure";
            // 
            // colLundi
            // 
            this.colLundi.HeaderText = "Lundi";
            this.colLundi.Name = "colLundi";
            // 
            // colMardi
            // 
            this.colMardi.HeaderText = "Mardi";
            this.colMardi.Name = "colMardi";
            // 
            // colMercredi
            // 
            this.colMercredi.HeaderText = "Mercredi";
            this.colMercredi.Name = "colMercredi";
            // 
            // colJeudi
            // 
            this.colJeudi.HeaderText = "Jeudi";
            this.colJeudi.Name = "colJeudi";
            // 
            // colVendredi
            // 
            this.colVendredi.HeaderText = "Vendredi";
            this.colVendredi.Name = "colVendredi";
            // 
            // lblBienvenuHoraire
            // 
            this.lblBienvenuHoraire.AutoSize = true;
            this.lblBienvenuHoraire.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBienvenuHoraire.Location = new System.Drawing.Point(584, 22);
            this.lblBienvenuHoraire.Name = "lblBienvenuHoraire";
            this.lblBienvenuHoraire.Size = new System.Drawing.Size(96, 28);
            this.lblBienvenuHoraire.TabIndex = 1;
            this.lblBienvenuHoraire.Text = "Horaire";
            // 
            // lblNombreHeureCoursAnnonce
            // 
            this.lblNombreHeureCoursAnnonce.AutoSize = true;
            this.lblNombreHeureCoursAnnonce.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombreHeureCoursAnnonce.Location = new System.Drawing.Point(42, 587);
            this.lblNombreHeureCoursAnnonce.Name = "lblNombreHeureCoursAnnonce";
            this.lblNombreHeureCoursAnnonce.Size = new System.Drawing.Size(256, 22);
            this.lblNombreHeureCoursAnnonce.TabIndex = 2;
            this.lblNombreHeureCoursAnnonce.Text = "Nombre d\'heures de cours:";
            // 
            // lblNbHeuresCours
            // 
            this.lblNbHeuresCours.AutoSize = true;
            this.lblNbHeuresCours.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNbHeuresCours.Location = new System.Drawing.Point(304, 587);
            this.lblNbHeuresCours.Name = "lblNbHeuresCours";
            this.lblNbHeuresCours.Size = new System.Drawing.Size(65, 22);
            this.lblNbHeuresCours.TabIndex = 3;
            this.lblNbHeuresCours.Text = "label1";
            // 
            // lblNumeroHoraire
            // 
            this.lblNumeroHoraire.AutoSize = true;
            this.lblNumeroHoraire.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumeroHoraire.Location = new System.Drawing.Point(1145, 27);
            this.lblNumeroHoraire.Name = "lblNumeroHoraire";
            this.lblNumeroHoraire.Size = new System.Drawing.Size(65, 22);
            this.lblNumeroHoraire.TabIndex = 4;
            this.lblNumeroHoraire.Text = "label1";
            // 
            // btnRetourAccueil
            // 
            this.btnRetourAccueil.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRetourAccueil.Location = new System.Drawing.Point(1086, 576);
            this.btnRetourAccueil.Name = "btnRetourAccueil";
            this.btnRetourAccueil.Size = new System.Drawing.Size(107, 33);
            this.btnRetourAccueil.TabIndex = 5;
            this.btnRetourAccueil.Text = "Accueil";
            this.btnRetourAccueil.UseVisualStyleBackColor = true;
            this.btnRetourAccueil.Click += new System.EventHandler(this.btnRetourAccueil_Click);
            // 
            // lblTypeUsagerHoraire
            // 
            this.lblTypeUsagerHoraire.AutoSize = true;
            this.lblTypeUsagerHoraire.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTypeUsagerHoraire.Location = new System.Drawing.Point(42, 27);
            this.lblTypeUsagerHoraire.Name = "lblTypeUsagerHoraire";
            this.lblTypeUsagerHoraire.Size = new System.Drawing.Size(65, 22);
            this.lblTypeUsagerHoraire.TabIndex = 6;
            this.lblTypeUsagerHoraire.Text = "label1";
            // 
            // formHoraire
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1272, 642);
            this.Controls.Add(this.lblTypeUsagerHoraire);
            this.Controls.Add(this.btnRetourAccueil);
            this.Controls.Add(this.lblNumeroHoraire);
            this.Controls.Add(this.lblNbHeuresCours);
            this.Controls.Add(this.lblNombreHeureCoursAnnonce);
            this.Controls.Add(this.lblBienvenuHoraire);
            this.Controls.Add(this.dataGVHoraire);
            this.Name = "formHoraire";
            this.Text = "Horaire";
            this.Load += new System.EventHandler(this.Horaire_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGVHoraire)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGVHoraire;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHeure;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLundi;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMardi;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMercredi;
        private System.Windows.Forms.DataGridViewTextBoxColumn colJeudi;
        private System.Windows.Forms.DataGridViewTextBoxColumn colVendredi;
        private System.Windows.Forms.Label lblBienvenuHoraire;
        private System.Windows.Forms.Label lblNombreHeureCoursAnnonce;
        private System.Windows.Forms.Label lblNbHeuresCours;
        private System.Windows.Forms.Label lblNumeroHoraire;
        private System.Windows.Forms.Button btnRetourAccueil;
        private System.Windows.Forms.Label lblTypeUsagerHoraire;
    }
}