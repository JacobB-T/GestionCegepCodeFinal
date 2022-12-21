using GestionCegep.Classe;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionCegep.Formulaires
{
    public partial class FormAccueil : Form
    {

        string Requete;
        SqlConnection cnx;
        SqlCommand command;
        SqlDataReader resultat;

        public FormAccueil()
        {
            InitializeComponent();
        }

        public string TypeUsager //Permet d'affecter une valeur au label depuis un autre form pour transférer le type d'usager
        {
            get
            {
                return (this.lblTypeUsager.Text);
            }
            set
            {
                this.lblTypeUsager.Text = value;
            }
        }
        public string NumeroUsager
        {
            get
            {
                return (this.lblAfficherNumero.Text);
            }
            set
            {
                this.lblAfficherNumero.Text = value;
            }
        }

        Enseignants enseignantConnecte = default(Enseignants);
        EnseignantResponsable responsableConnecte = default(EnseignantResponsable);
        Etudiants etudiantConnecte = default(Etudiants);

        private void Accueil_Load(object sender, EventArgs e)
        {
            //Mettre en place la connexion avec la base de données
            String connectionString = ConfigurationManager.ConnectionStrings["cnxSqlServer"].ConnectionString;
            cnx = new SqlConnection();
            cnx.ConnectionString = connectionString;

            //Vider les messages d'erreurs d'ajout de gens
            lblErreurDate.Text = "";
            lblErreurNuméro.Text = "";
            lblNomErreurAjout.Text = "";
            lblPrenomErreurAjout.Text = "";


            //Mettre les programmes dans la combobox d'ajout de programme
            foreach (Programme programme1 in Programme.ListProgrammes)
            {
                cboProgrammeMembreAjout.Items.Add(programme1.ToString());
            }



            /**
             * Afficher les informations personnelles de la personnes qui se connecte
             * 
             */

            //////////////////////Si c'est un enseignant qui se connecte//////////////////////////////
            if (lblTypeUsager.Text == "Enseignant")
            {
                //Trouver quel enseignant se connecte

                foreach (Enseignants enseignants1 in Enseignants.ListEnseignant)
                {
                    if (enseignants1.NumEnseignant == lblAfficherNumero.Text)
                    {
                        enseignantConnecte = enseignants1;
                        break;
                    }
                }
                //Mettre les infos dans les labels correspondants
                lblAfficherPrenom.Text = enseignantConnecte.Prenom;
                lblAfficherNom.Text = enseignantConnecte.Nom;
                lblAfficherProgramme.Text = enseignantConnecte.Programme.ToString();
                lblAfficherDateNaissance.Text = $"{enseignantConnecte.DateNaissance.Day.ToString()}/{enseignantConnecte.DateNaissance.Month.ToString()}/{enseignantConnecte.DateNaissance.Year.ToString()}";
                if (enseignantConnecte.NbAnneeExperience() > 1) { lblAfficherAutre.Text = enseignantConnecte.NbAnneeExperience().ToString() + "ans"; }
                else { lblAfficherAutre.Text = enseignantConnecte.NbAnneeExperience().ToString() + "an"; }
                lblAutreAffichage.Text = "Années d'ancienneté: ";
                lblAutre2Affichage.Hide();
                lblAfficherAutre2.Hide();

                //Cacher le groupbox des choses de responsables
                gbxResponsable.Visible = false;


                //Mettre les cours disponibles à enseigner dans la combobox d'inscription
                foreach (Cours cours1 in Cours.ListCours)
                {
                    if (enseignantConnecte.NumEnseignant != cours1.Enseignant && Verification.PresenceProf(cours1) == false && (cours1.Programme == enseignantConnecte.Programme.NumProgramme.ToString() || cours1.Statut == "G"))
                    {
                        cboListeCoursDispo.Items.Add(cours1.ToString());

                    }
                }

                //Mettre les cours que l'enseignant enseigne dans le combobox
                foreach (Cours cours1 in Cours.ListCours)
                {
                    if (enseignantConnecte.NumEnseignant == cours1.Enseignant)
                    {
                        cboListeCoursInscrit.Items.Add(cours1.ToString());
                    }
                }

                

            }


            //////////////////////Si c'est un responsable qui se connecte//////////////////////////////
            else if (lblTypeUsager.Text == "Enseignant Responsable")
            {
                //Trouver quel responsable se connecte

                foreach (EnseignantResponsable responsable1 in EnseignantResponsable.listResponsables)
                {
                    if (responsable1.NumEnseignant == lblAfficherNumero.Text)
                    {
                        responsableConnecte = responsable1;
                        break;
                    }
                }
                //Mettre les infos dans les labels correspondants
                lblAfficherPrenom.Text = responsableConnecte.Prenom;
                lblAfficherNom.Text = responsableConnecte.Nom;
                lblAfficherProgramme.Text = responsableConnecte.Programme.ToString();
                lblAfficherDateNaissance.Text = responsableConnecte.DateNaissance.Date.ToString();
                if (responsableConnecte.NbAnneeExperience() > 1) { lblAfficherAutre.Text = responsableConnecte.NbAnneeExperience().ToString() + "ans"; }
                else { lblAfficherAutre.Text = responsableConnecte.NbAnneeExperience().ToString() + "an"; }
                lblAutreAffichage.Text = "Années d'ancienneté";
                lblAutre2Affichage.Text = "Nb enseignant inférieur:";
                lblAfficherAutre2.Text = responsableConnecte.NbEnsInferieur.ToString();


                //Mettre tous les cours qu'il enseigne dans la combobox correspondante
                foreach (Cours cours1 in Cours.ListCours)
                {
                    if (responsableConnecte.NumEnseignant == cours1.Enseignant)
                    {
                        cboListeCoursInscrit.Items.Add(cours1.ToString());
                    }
                }


                //Mettre les cours disponibles à enseigner dans la combobox d'inscription
                foreach (Cours cours1 in Cours.ListCours)
                {
                    if (responsableConnecte.NumEnseignant != cours1.Enseignant && Verification.PresenceProf(cours1) == false && cours1.Programme == responsableConnecte.Programme.NumProgramme.ToString() || cours1.Statut == "G")
                    {
                        cboListeCoursDispo.Items.Add(cours1.ToString());

                    }
                }

            }


            //////////////////////Si c'est un étudiant qui se connecte//////////////////////////////
            else if (lblTypeUsager.Text == "Étudiant")
            {
                //Trouver quel étudiant se connecte

                foreach (Etudiants etudiant1 in Etudiants.listeEtudiants)
                {
                    if (etudiant1.NumEtu == lblAfficherNumero.Text)
                    {
                        etudiantConnecte = etudiant1;
                        break;
                    }
                }
                //Mettre les infos dans les labels correspondants
                lblAfficherPrenom.Text = etudiantConnecte.Prenom;
                lblAfficherNom.Text = etudiantConnecte.Nom;
                lblAfficherProgramme.Text = etudiantConnecte.Programme.ToString();
                lblAfficherDateNaissance.Text = $"{etudiantConnecte.DateNaissance.Day.ToString()}/{etudiantConnecte.DateNaissance.Month.ToString()}/{etudiantConnecte.DateNaissance.Year.ToString()}";
                lblAfficherAutre.Hide();
                lblAutreAffichage.Hide();
                lblAutre2Affichage.Hide();
                lblAfficherAutre2.Hide();


                //Mettre les cours disponibles à voir dans la combobox d'inscription
                foreach (Cours cours1 in Cours.ListCours)
                {
                    if (etudiantConnecte.Programme.NumProgramme == cours1.Programme || cours1.Statut == "G")
                    {
                        cboListeCoursDispo.Items.Add(cours1.ToString());

                    }
                }

                //Mettre les cours que l'enseignant enseigne dans le combobox
                foreach (Cours cours1 in Cours.ListCours)
                {
                    if (cours1.ListEtudiants.Contains(etudiantConnecte.NumEtu))
                    {
                        cboListeCoursInscrit.Items.Add(cours1.ToString());
                    }
                }

                //Cacher le groupbox des choses de responsables
                gbxResponsable.Visible = false;
            }
        }

        /// <summary>
        /// Bouton permettant d'appeler le form horaire
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnVoirHorraire_Click(object sender, EventArgs e)
        {
            //Instancier le formHoraire
            formHoraire horaire = new formHoraire();
            //Mettre le numéro d'usager dans la form horaire
            horaire.NumeroHoraire = lblAfficherNumero.Text;
            horaire.TypeUsagerHoraire = lblTypeUsager.Text;
            //Afficher le formulaire horaire
            horaire.Show();
        }


        /// <summary>
        /// Bouton permettant de s'inscrire ou de s'assigner pour enseigner un cours
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInscrire_Click(object sender, EventArgs e)
        {
            //trouver de quel type est la personne connectée

            //////////////////////Si c'est un enseignant qui se connecte//////////////////////////////
            if (lblTypeUsager.Text == "Enseignant")
            {
                //Trouver quel cours est sélectionnée dans la combobox pour s'inscrire
                foreach (Cours cours1 in Cours.ListCours)
                {
                    if(cours1.ToString() == cboListeCoursDispo.SelectedItem.ToString())
                    {
                        //S'Assurer que l'enseignant n'enseigne pas déjà ce cours
                        if (enseignantConnecte.ListCoursEnseigne.Contains(cours1) == false)
                        {
                            //S'assurer que le cours n'a pas déjà un prof
                            if(Verification.PresenceProf(cours1) == false)
                            {
                                //S'assurer que le cours respecte l'emploi du temps
                                if(Verification.TempsCours(enseignantConnecte.ListCoursEnseigne, cours1) == true)
                                {
                                    //Demander si la personne veut vraiment s'inscrire à ce cours
                                    if (MessageBox.Show($"Confirmation de l'inscription pour le cours {cours1.ToString()}", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                                    {
                                        //Mettre à jour le cours et lui mettre le nouveau prof dans la base de données

                                        int NbLignes = SeConnecter.Inserer($"update Cours set Enseignant = '{enseignantConnecte.NumEnseignant}' where NumCours = '{cours1.NumCours}'");
                                        if (NbLignes > 0)
                                        {
                                            //Ajouter le cours au combobox avec tous les cours inscrits
                                            cboListeCoursInscrit.Items.Add(cours1.ToString());

                                            //Ajouter le cours à la liste des cours inscrits de l'objet 
                                            enseignantConnecte.ListCoursEnseigne.Add(cours1);
                                            MessageBox.Show("Inscription réussie", "Succès");
                                            break;
                                        }
                                        else
                                        {
                                            MessageBox.Show("Erreur", "Échec");
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Inscription annulée");
                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show("Inscription impossible, enseignant déjà assigné pour ce cours.", "Inscription impossible");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Inscription impossible, cours déjà présent.", "Inscription impossible");
                        }
                    }
                }
            }


            //////////////////////Si c'est un responsable qui se connecte//////////////////////////////
            else if (lblTypeUsager.Text == "Enseignant Responsable")
            {
                //Trouver quel cours est sélectionnée dans la combobox pour s'inscrire
                foreach (Cours cours1 in Cours.ListCours)
                {
                    if (cours1.ToString() == cboListeCoursDispo.SelectedItem.ToString())
                    {
                        //S'Assurer que l'enseignant n'enseigne pas déjà ce cours
                        if (responsableConnecte.ListCoursEnseigne.Contains(cours1) == false)
                        {
                            //S'assurer que le cours n'a pas déjà un prof
                            if (Verification.PresenceProf(cours1) == false)
                            {
                                //S'assurer que le cours respecte l'emploi du temps
                                if (Verification.TempsCours(enseignantConnecte.ListCoursEnseigne, cours1) == true)
                                {
                                    //Demander si la personne veut vraiment s'inscrire à ce cours
                                    if (MessageBox.Show($"Confirmation de l'inscription pour le cours {cours1.ToString()}", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                                    {
                                        

                                        //Mettre à jour le cours et lui mettre le nouveau prof dans la base de données

                                        int NbLignes = SeConnecter.Inserer($"update Cours set Enseignant = '{responsableConnecte.NumEnseignant}' where NumCours = '{cours1.NumCours}'");
                                        if (NbLignes > 0)
                                        {
                                            //Ajouter le cours au combobox avec tous les cours inscrits
                                            cboListeCoursInscrit.Items.Add(cours1.ToString());

                                            //Ajouter le cours à la liste des cours inscrits de l'objet 
                                            responsableConnecte.ListCoursEnseigne.Add(cours1);
                                            MessageBox.Show("Inscription réussie", "Succès");
                                            break;
                                        }
                                        else
                                        {
                                            MessageBox.Show("Inscription annulée");
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Inscription annulée");
                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show("Inscription impossible, enseignant déjà assigné pour ce cours.", "Inscription impossible");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Inscription impossible, cours déjà présent.", "Inscription impossible");
                        }
                    }
                }
            }


            //////////////////////Si c'est un étudiant qui se connecte//////////////////////////////
            else if (lblTypeUsager.Text == "Étudiant")
            {
                //Trouver quel cours est sélectionnée dans la combobox pour s'inscrire
                foreach (Cours cours1 in Cours.ListCours)
                {
                    //S'assurer que l'étudiant n'a pas déjà ce cours
                    if (cours1.ToString() == cboListeCoursDispo.SelectedItem.ToString())
                    {
                        if(etudiantConnecte.ListeCoursInscrits.Contains(cours1) == false)
                        {
                            //S'assurer que le cours est disponible
                            if (Verification.TempsCours(etudiantConnecte.ListeCoursInscrits, cours1) == true)
                            {
                                if (Verification.PlaceCours(cours1) == true)
                                {
                                    //Demander si la personne veut vraiment s'inscrire à ce cours
                                    if (MessageBox.Show($"Confirmation de l'inscription pour le cours {cours1.ToString()}", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                                    {
                                        

                                        //Ajouter le cours à la liste des cours dans la base de données
                                        int NbLignes = SeConnecter.Inserer($"Insert into LiensEtudCours(NumCours, Etudiant) values('{cours1.NumCours}', '{etudiantConnecte.NumEtu}')");
                                        if (NbLignes > 0)
                                        {
                                            //Ajouter le cours au combobox avec tous les cours inscrits
                                            cboListeCoursInscrit.Items.Add(cours1.ToString());

                                            //Ajouter le cours à la liste des cours inscrits de l'objet 
                                            etudiantConnecte.ListeCoursInscrits.Add(cours1);
                                            MessageBox.Show("Inscription réussie", "Succès");
                                            break;
                                        }
                                        else
                                        {
                                            MessageBox.Show("Inscription annulée");
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Inscription annulée");
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Inscription impossible, cours plein.", "Inscription impossible");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Inscription impossible, conflit d'horaire présent.", "Inscription impossible");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Inscription impossible, cours déjà présent.", "Inscription impossible");
                        }
                        

                        break;
                    }
                }
            }
        }

        /// <summary>
        /// Bouton permettant de se désinscrire ou d'arrêter d'enseigner un cours
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDesinscrire_Click(object sender, EventArgs e)
        {
            //trouver de quel type est la personne connectée

            //////////////////////Si c'est un enseignant qui se connecte//////////////////////////////
            if (lblTypeUsager.Text == "Enseignant")
            {
                //Trouver quel cours est sélectionné
                foreach (Cours cours1 in Cours.ListCours)
                {
                    if(cours1.ToString() == cboListeCoursInscrit.SelectedItem.ToString())
                    {
                        //Demander la confirmation si l'enseignant veut vraiment ne plus enseigner ce cours
                        if (MessageBox.Show($"Confirmation de la désinscription pour le cours {cours1.ToString()}", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            
                            //Mettre l'enseignant par défaut comme enseignant pour le cours dans la base de données
                            int NbLignes = SeConnecter.Inserer($"update Cours set Enseignant = 'ABC' where NumCours = '{cours1.NumCours}'");
                            if (NbLignes > 0)
                            {
                                //Retirer le cours de la liste des cours enseignés par l'enseignant dans son objet
                                enseignantConnecte.ListCoursEnseigne.Remove(cours1);
                                //Retirer le cours de la liste des cours assignés
                                cboListeCoursInscrit.Items.Remove(cours1.ToString());
                                MessageBox.Show("Désinscription réussie", "Succès");
                                break;
                            }
                            else
                            {
                                MessageBox.Show("Erreur", "Échec");
                            }

                        }

                    }
                }
            }

            //////////////////////Si c'est un responsable qui se connecte//////////////////////////////
            else if (lblTypeUsager.Text == "Enseignant Responsable")
            {
                //Trouver quel cours est sélectionné
                foreach (Cours cours1 in Cours.ListCours)
                {
                    if (cours1.ToString() == cboListeCoursInscrit.SelectedItem.ToString())
                    {
                        //Demander la confirmation si l'enseignant responsable veut vraiment ne plus enseigner ce cours
                        if (MessageBox.Show($"Confirmation de la désinscription pour le cours {cours1.ToString()}", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {

                            //Mettre l'enseignant par défaut comme enseignant pour le cours dans la base de données
                            int NbLignes = SeConnecter.Inserer($"update Cours set Enseignant = 'ABC' where NumCours = '{cours1.NumCours}'");
                            if (NbLignes > 0)
                            {
                                //Retirer le cours de la liste des cours enseignés par l'enseignant dans son objet
                                responsableConnecte.ListCoursEnseigne.Remove(cours1);
                                //Retirer le cours de la liste des cours assignés
                                cboListeCoursInscrit.Items.Remove(cours1.ToString());
                                MessageBox.Show("Désinscription réussie", "Succès");
                                break;
                            }
                            else
                            {
                                MessageBox.Show("Erreur", "Échec");
                            }

                        }

                    }
                }
            }

            //////////////////////Si c'est un étudiant qui se connecte//////////////////////////////
            else if (lblTypeUsager.Text == "Étudiant")
            {
                //Trouver quel cours est sélectionné
                foreach (Cours cours1 in Cours.ListCours)
                {
                    if (cours1.ToString() == cboListeCoursInscrit.SelectedItem.ToString())
                    {
                        //Demander la confirmation si l'enseignant veut vraiment ne plus enseigner ce cours
                        if (MessageBox.Show($"Confirmation de la désinscription pour le cours {cours1.ToString()}", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {

                            //Mettre l'enseignant par défaut comme prof pour le cours dans la base de données
                            int NbLignes = SeConnecter.Inserer($"delete LiensEtudCours where NumCours = '{cours1.NumCours.ToString()}' and Etudiant = '{etudiantConnecte.NumEtu.ToString()}'");
                            if (NbLignes > 0)
                            {
                                //Retirer le cours de la liste des cours enseignés par l'enseignant dans son objet
                                etudiantConnecte.ListeCoursInscrits.Remove(cours1);
                                //Retirer le cours de la liste des cours assignés
                                cboListeCoursInscrit.Items.Remove(cours1.ToString());
                                MessageBox.Show("Désinscription réussie", "Succès");
                                break;
                            }
                            else
                            {
                                MessageBox.Show("Erreur", "Échec");
                            }

                        }

                    }
                }
            }
        }

        //Bouton permettant de calculer le cout d'impression en fonction du nombre de pages
        private void btnCalculerPrixImp_Click(object sender, EventArgs e)
        {
            //Déterminer si c'set un étudiant ou un enseignant
            //////////////////////Si c'est un étudiant qui se connecte//////////////////////////////
            if (lblTypeUsager.Text == "Étudiant")
            {
                lblPrixImpressionResultat.Text = etudiantConnecte.CoutImpression(Int16.Parse(txtNbPages.Value.ToString())).ToString() + "$";
            }
            //////////////////////Si c'est un responsable qui se connecte//////////////////////////////
            else if (lblTypeUsager.Text == "Enseignant Responsable")
            {
                lblPrixImpressionResultat.Text = responsableConnecte.CoutImpression(Int16.Parse(txtNbPages.Value.ToString())).ToString() + "$";
            }
            //////////////////////Si c'est un enseignant qui se connecte//////////////////////////////
            else if (lblTypeUsager.Text == "Enseignant")
            {
                lblPrixImpressionResultat.Text = enseignantConnecte.CoutImpression(Int16.Parse(txtNbPages.Value.ToString())).ToString() + "$";
            }

        }

        private void btnAjouterEleve_Click(object sender, EventArgs e)
        {
            //Instancier l'étudiant
            if(txtNumeroMembreAjout.Text.Length > 0 && txtNomMembreAjout.Text.Length > 0 && txtNomFamilleEMembreAjout.Text.Length > 0
                && cboProgrammeMembreAjout.SelectedIndex != -1 && txtMDPAjout.Text.Length > 0 && dateDateNaissanceAjout.Value != DateTime.Today)
            {
                bool verification = false; //flag pour voir s'il y a des erreurs
                Etudiants etudiant1 = new Etudiants();
                //Validation du numéro
                Regex patternEtudiant = new Regex("^[A-Z]{2}[0-9]{5}$");
                if (patternEtudiant.IsMatch(txtNumeroMembreAjout.Text)) 
                { 
                    etudiant1.NumEtu = txtNumeroMembreAjout.Text; 
                } 
                else 
                { 
                    lblErreurNuméro.Text = "Pattern: XX00000";
                    verification = true; 
                }
                //Validation du prénom
                Regex patternNomPrenom = new Regex("^([A-Z][a-z]+)(-? ?[A-Z][a-z]+)*$"); //Prénom et nom commencent par une majuscule, suivi d'une ou plusieurs minuscules, puis possibilité d'avoir un tiret ou un espace et répété
                if (patternNomPrenom.IsMatch(txtNomMembreAjout.Text))
                {
                    etudiant1.Prenom = txtNomMembreAjout.Text;
                }
                else
                {
                    lblPrenomErreurAjout.Text = "Prénom invalide (Aaaaa[(-Aaaaa)( Aaaaaa)])";
                    verification = false;
                }
                //Validation du nom
                if (patternNomPrenom.IsMatch(txtNomMembreAjout.Text))
                {
                    etudiant1.Nom = txtNomFamilleEMembreAjout.Text;
                }
                else
                {
                    lblNomErreurAjout.Text = "Nom invalide (Aaaaa[(-Aaaaa)( Aaaaaa)])";
                    verification = false;
                }
                //Trouver le programme
                foreach (Programme programme1 in Programme.ListProgrammes)
                {
                    if (cboProgrammeMembreAjout.Text == programme1.ToString())
                    {
                        etudiant1.Programme = programme1;
                        break;
                    }
                }
                etudiant1.MotDePasse = txtMDPAjout.Text;
                etudiant1.DateNaissance = dateDateNaissanceAjout.Value;
                if(verification == false)
                {
                    //Mettre le nouvel étudiant dans la base de données
                    int NbLigne = SeConnecter.Inserer($"insert into Etudiants(NumEtu, Programme, Nom, NomFamille, DateNaissance, MotDePasse)" +
                        $" values('{etudiant1.NumEtu}', '{etudiant1.Programme.NumProgramme}', '{etudiant1.Prenom}', '{etudiant1.Nom}', '{etudiant1.DateNaissance}', '{etudiant1.MotDePasse}')");
                    if (NbLigne > 0)
                    {
                        MessageBox.Show("Ajout réussi", "Succès");
                        //Vider les messages d'erreurs
                        lblErreurDate.Text = "";
                        lblErreurNuméro.Text = "";
                        lblNomErreurAjout.Text = "";
                        lblPrenomErreurAjout.Text = "";
                    }
                    else { MessageBox.Show("Échec de l'ajout", "Échec"); }
                }
                else
                {
                    MessageBox.Show("Erreurs. Échec de l'ajout.", "Échec");
                }
                
            }
            else
            {
                MessageBox.Show("Tous les champs sont obligatoires. Echec de l'ajout.", "Échec");
            }
            
        }

        private void lblSupprimerEleve_Click(object sender, EventArgs e)
        {
            //Trouver quel étudiant est sélectionné
            //Faire la requête SQL pour aller chercher l'étudiant sélectionné
            resultat = SeConnecter.Lire($"select * from Etudiants where NumEtu = '{txtNumeroMembreAjout.Text}'");
            if (resultat.HasRows)
            {
                //Confirmer vouloir effacer
                if (MessageBox.Show($"Confirmation de la suppression", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    //Supprimer tous les cours qu'il suivait
                    int resultat2 = SeConnecter.Inserer($"delete LiensEtudCours where Etudiant = '{txtNumeroMembreAjout.Text}'");
                    //Supprimer l'étudiant de la table étudiant
                    resultat2 = SeConnecter.Inserer($"delete Etudiants where NumEtu = '{txtNumeroMembreAjout.Text}'");
                    if(resultat2 > 0)
                    {
                        MessageBox.Show("Suppression réussie", "Succès");
                    }
                }
                else
                {
                    MessageBox.Show("Annulation de la suppression", "Annulation");
                }

            }
        }

        private void btnSelectionnerModif_Click(object sender, EventArgs e)
        {
            //Trouver quel étudiant est sélectionné
            //Faire la requête SQL pour aller chercher l'étudiant sélectionné
            resultat =  SeConnecter.Lire($"select * from Etudiants where NumEtu = '{txtNumeroMembreAjout.Text}'");
            if (resultat.HasRows)
            {
                while (resultat.Read())
                {
                    //Mettre les informations de la personne dans les textbox d'ajout
                    txtNomMembreAjout.Text = resultat[2].ToString();
                    txtNomFamilleEMembreAjout.Text = resultat[3].ToString();
                    txtMDPAjout.Text = resultat[5].ToString();
                    dateDateNaissanceAjout.Value = Convert.ToDateTime(resultat[4].ToString());
                    //Trouver le programme
                    foreach(Programme programme1 in Programme.ListProgrammes)
                    {
                        if (resultat[1].ToString() == programme1.NumProgramme)
                        {
                            cboProgrammeMembreAjout.Text = programme1.ToString();
                            break;
                        }
                    }
                }
                resultat.Close();
            }

            else
            {
                MessageBox.Show("Aucun étudiant ne correspond.", "Erreur");
                //Vider tous les champs
                txtMDPAjout.Text = "";
                txtNomFamilleEMembreAjout.Text = "";
                txtNomMembreAjout.Text = "";
                cboProgrammeMembreAjout.SelectedIndex = -1;

            }
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            //Trouver quel étudiant est sélectionné
            //Faire la requête SQL pour aller chercher l'étudiant sélectionné
            resultat = SeConnecter.Lire($"select * from Etudiants where NumEtu = '{txtNumeroMembreAjout.Text}'");
            if (resultat.HasRows)
            {
                if (txtNumeroMembreAjout.Text.Length > 0 && txtNomMembreAjout.Text.Length > 0 && txtNomFamilleEMembreAjout.Text.Length > 0
                && cboProgrammeMembreAjout.SelectedIndex != -1 && txtMDPAjout.Text.Length > 0 && dateDateNaissanceAjout.Value != DateTime.Today)
                {
                    while (resultat.Read())
                    {
                        //Validation du numéro
                        Etudiants etudiant1 = new Etudiants();
                        if (txtNumeroMembreAjout.Text == resultat[0].ToString()) { etudiant1.NumEtu = txtNumeroMembreAjout.Text; }
                        else { MessageBox.Show("Ne pas modifier le numéro", "Erreur"); txtNumeroMembreAjout.Text = resultat[0].ToString(); }
                        etudiant1.Prenom = txtNomMembreAjout.Text;
                        etudiant1.Nom = txtNomFamilleEMembreAjout.Text;

                        etudiant1.MotDePasse = txtMDPAjout.Text;
                        etudiant1.DateNaissance = dateDateNaissanceAjout.Value;
                        //Trouver le programme
                        foreach (Programme programme1 in Programme.ListProgrammes)
                        {
                            if (cboProgrammeMembreAjout.Text == programme1.ToString())
                            {
                                etudiant1.Programme = programme1;
                                break;
                            }
                        }
                        //Si le programme est modifié, supprimer tous les cours qu suit cet étudiant
                        if (etudiant1.Programme.ToString() != cboProgrammeMembreAjout.Text)
                        {
                            SqlDataReader resultat2 = SeConnecter.Lire($"select * from LiensEtudCours where Etudiant = '{txtNumeroMembreAjout}'");
                            if (resultat2.HasRows)
                            {
                                resultat2.Close();
                                //Confirmer que c'est bien voulu de tout supprimer
                                if (MessageBox.Show($"Programme modifier. Confirmation de désinscrire l'élève de tous ses cours ", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                                {
                                    int resultat3 = SeConnecter.Inserer($"delete * from LiensEtudCours where Etudiant = '{txtNumeroMembreAjout}'");
                                    if (resultat3 > 0)
                                    {
                                        MessageBox.Show("Désinscription des cours réussis");
                                        //Trouver le programme
                                        foreach (Programme programme1 in Programme.ListProgrammes)
                                        {
                                            if (cboProgrammeMembreAjout.Text == programme1.ToString())
                                            {
                                                etudiant1.Programme = programme1;
                                                break;
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Annulation de la modification de programme");
                                    foreach (Programme programme1 in Programme.ListProgrammes)
                                    {
                                        if (resultat[1].ToString() == programme1.NumProgramme)
                                        {
                                            cboProgrammeMembreAjout.Text = programme1.ToString();
                                            etudiant1.Programme = programme1;

                                            break;
                                        }
                                    }
                                }
                            }
                            else
                            {
                                //Trouver le programme
                                foreach (Programme programme1 in Programme.ListProgrammes)
                                {
                                    if (cboProgrammeMembreAjout.Text == programme1.ToString())
                                    {
                                        etudiant1.Programme = programme1;
                                        break;
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (MessageBox.Show($"Confirmation changement de programme", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                            {
                                //Trouver le programme
                                foreach (Programme programme1 in Programme.ListProgrammes)
                                {
                                    if (cboProgrammeMembreAjout.Text == programme1.ToString())
                                    {
                                        etudiant1.Programme = programme1;
                                        break;
                                    }
                                }
                            }
                        }

                        //Modifier l'étudiant dans la base de données
                        int NbLigne = SeConnecter.Inserer($"update Etudiants set NumEtu = '{etudiant1.NumEtu}', Programme = '{etudiant1.Programme.NumProgramme}'," +
                            $"  Nom = '{etudiant1.Prenom}', NomFamille = '{etudiant1.Nom}', DateNaissance = '{etudiant1.DateNaissance}', MotDePasse = '{etudiant1.MotDePasse}' where NumEtu = '{txtNumeroMembreAjout.Text}'");
                        if (NbLigne > 0)
                        {
                            MessageBox.Show("Modification réussis", "Succès");
                            //Vider les messages d'erreurs
                            lblErreurDate.Text = "";
                            lblErreurNuméro.Text = "";
                        }
                        else { MessageBox.Show("Échec de la modification", "Échec"); }
                    }
                    
                }
                else
                {
                    MessageBox.Show("Tous les champs sont obligatoires. Echec de l'ajout.", "Échec");
                }
                resultat.Close();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}