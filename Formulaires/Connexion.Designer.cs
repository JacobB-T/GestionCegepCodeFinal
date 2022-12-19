namespace GestionCegep.Formulaires
{
    partial class FormConnexion
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
            this.lblTypeUtilisateurConnexion = new System.Windows.Forms.Label();
            this.cboTypeUtilisateurConnexion = new System.Windows.Forms.ComboBox();
            this.txtMDPConnexion = new System.Windows.Forms.TextBox();
            this.txtNumConnexion = new System.Windows.Forms.TextBox();
            this.lblMDPConnexion = new System.Windows.Forms.Label();
            this.lblNumeroConnexion = new System.Windows.Forms.Label();
            this.btnConnexion = new System.Windows.Forms.Button();
            this.lblErreurConenxion = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblTypeUtilisateurConnexion
            // 
            this.lblTypeUtilisateurConnexion.AutoSize = true;
            this.lblTypeUtilisateurConnexion.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTypeUtilisateurConnexion.Location = new System.Drawing.Point(291, 88);
            this.lblTypeUtilisateurConnexion.Name = "lblTypeUtilisateurConnexion";
            this.lblTypeUtilisateurConnexion.Size = new System.Drawing.Size(144, 21);
            this.lblTypeUtilisateurConnexion.TabIndex = 11;
            this.lblTypeUtilisateurConnexion.Text = "Type d\'utilisateur:";
            // 
            // cboTypeUtilisateurConnexion
            // 
            this.cboTypeUtilisateurConnexion.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTypeUtilisateurConnexion.FormattingEnabled = true;
            this.cboTypeUtilisateurConnexion.Items.AddRange(new object[] {
            "Étudiant",
            "Enseignant",
            "Enseignant Responsable"});
            this.cboTypeUtilisateurConnexion.Location = new System.Drawing.Point(295, 112);
            this.cboTypeUtilisateurConnexion.Name = "cboTypeUtilisateurConnexion";
            this.cboTypeUtilisateurConnexion.Size = new System.Drawing.Size(225, 28);
            this.cboTypeUtilisateurConnexion.TabIndex = 1;
            this.cboTypeUtilisateurConnexion.SelectedIndexChanged += new System.EventHandler(this.cboTypeUtilisateurConnexion_SelectedIndexChanged);
            // 
            // txtMDPConnexion
            // 
            this.txtMDPConnexion.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMDPConnexion.Location = new System.Drawing.Point(295, 271);
            this.txtMDPConnexion.Name = "txtMDPConnexion";
            this.txtMDPConnexion.Size = new System.Drawing.Size(225, 26);
            this.txtMDPConnexion.TabIndex = 3;
            this.txtMDPConnexion.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMDPConnexion_KeyDown);
            // 
            // txtNumConnexion
            // 
            this.txtNumConnexion.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumConnexion.Location = new System.Drawing.Point(295, 199);
            this.txtNumConnexion.Name = "txtNumConnexion";
            this.txtNumConnexion.Size = new System.Drawing.Size(225, 26);
            this.txtNumConnexion.TabIndex = 2;
            // 
            // lblMDPConnexion
            // 
            this.lblMDPConnexion.AutoSize = true;
            this.lblMDPConnexion.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMDPConnexion.Location = new System.Drawing.Point(291, 246);
            this.lblMDPConnexion.Name = "lblMDPConnexion";
            this.lblMDPConnexion.Size = new System.Drawing.Size(123, 21);
            this.lblMDPConnexion.TabIndex = 7;
            this.lblMDPConnexion.Text = "Mot de passe: ";
            // 
            // lblNumeroConnexion
            // 
            this.lblNumeroConnexion.AutoSize = true;
            this.lblNumeroConnexion.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumeroConnexion.Location = new System.Drawing.Point(291, 175);
            this.lblNumeroConnexion.Name = "lblNumeroConnexion";
            this.lblNumeroConnexion.Size = new System.Drawing.Size(76, 21);
            this.lblNumeroConnexion.TabIndex = 6;
            this.lblNumeroConnexion.Text = "Numéro:";
            // 
            // btnConnexion
            // 
            this.btnConnexion.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConnexion.Location = new System.Drawing.Point(291, 350);
            this.btnConnexion.Name = "btnConnexion";
            this.btnConnexion.Size = new System.Drawing.Size(229, 36);
            this.btnConnexion.TabIndex = 4;
            this.btnConnexion.Text = "Se conencter";
            this.btnConnexion.UseVisualStyleBackColor = true;
            this.btnConnexion.Click += new System.EventHandler(this.btnConnexion_Click);
            // 
            // lblErreurConenxion
            // 
            this.lblErreurConenxion.AutoSize = true;
            this.lblErreurConenxion.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErreurConenxion.ForeColor = System.Drawing.Color.Red;
            this.lblErreurConenxion.Location = new System.Drawing.Point(292, 315);
            this.lblErreurConenxion.Name = "lblErreurConenxion";
            this.lblErreurConenxion.Size = new System.Drawing.Size(47, 17);
            this.lblErreurConenxion.TabIndex = 13;
            this.lblErreurConenxion.Text = "label1";
            // 
            // FormConnexion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblErreurConenxion);
            this.Controls.Add(this.btnConnexion);
            this.Controls.Add(this.lblTypeUtilisateurConnexion);
            this.Controls.Add(this.cboTypeUtilisateurConnexion);
            this.Controls.Add(this.txtMDPConnexion);
            this.Controls.Add(this.txtNumConnexion);
            this.Controls.Add(this.lblMDPConnexion);
            this.Controls.Add(this.lblNumeroConnexion);
            this.Name = "FormConnexion";
            this.Text = "Connexion";
            this.Load += new System.EventHandler(this.Connexion_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTypeUtilisateurConnexion;
        private System.Windows.Forms.ComboBox cboTypeUtilisateurConnexion;
        private System.Windows.Forms.TextBox txtMDPConnexion;
        private System.Windows.Forms.TextBox txtNumConnexion;
        private System.Windows.Forms.Label lblMDPConnexion;
        private System.Windows.Forms.Label lblNumeroConnexion;
        private System.Windows.Forms.Button btnConnexion;
        private System.Windows.Forms.Label lblErreurConenxion;
    }
}