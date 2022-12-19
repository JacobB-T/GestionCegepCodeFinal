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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionCegep.Formulaires
{
    public partial class FormConnexion : Form
    {
        string Requete;
        SqlConnection cnx;
        SqlCommand command;
        SqlDataReader resultat;


        //public List<EnseignantResponsable> listResponsables = new List<EnseignantResponsable>(); //liste contenant tous les responsables
        //public List<Enseignants> listEnseignants = new List<Enseignants>();
        //public List<Cours> listCours = new List<Cours>();
        //public List<Programme> listProgrammes = new List<Programme>();
        //public List<Etudiants> listEtudiants = new List<Etudiants>();

        public FormConnexion()
        {
            InitializeComponent();
        }


        private void Connexion_Load(object sender, EventArgs e)
        {


            //Créer tous les objets depuis la base de données
            //Établir la connexion avec la base de données

            String connectionString = ConfigurationManager.ConnectionStrings["cnxSqlServer"].ConnectionString;
            cnx = new SqlConnection();
            cnx.ConnectionString = connectionString;


            /**
             * Créer tous les objets à partir de la base de données
             * 
             */

            ///////////////////////////Objets Cours////////////////////////////////////////
            //Créer la requête pour aller cherchr les premières informations
            Requete = "select * from Cours";
            //Créer la commande
            command = new SqlCommand(Requete, cnx);
            //Mettre La requête dans la propriété CommandText de l’objet command
            command.CommandText = Requete;
            //Établir la connexion avec le serveur
            if (cnx.State == ConnectionState.Closed)
            {
                cnx.Open();
            }
            //Exécuter la commande
            resultat = command.ExecuteReader();
            //Vérifier si il y a un résultat
            if (resultat.HasRows)
            {
                while (resultat.Read()) //parcourir tous les cours
                {
                    Cours cours = new Cours();
                    cours.NumCours = resultat[0].ToString();
                    cours.NomCours = resultat[1].ToString();
                    if (resultat[2].ToString() != "") { cours.Enseignant = resultat[2].ToString(); }
                    else if (resultat[2].ToString() == "") { cours.Enseignant = null; }
                    cours.Programme = resultat[3].ToString();
                    cours.NbPlaces = Int16.Parse(resultat[4].ToString());
                    cours.ListJours = new List<int>();
                    cours.ListCreneau = new List<int>();
                    cours.ListEtudiants = new List<string>();

                    if (cours.Programme == "")
                    {
                        cours.Statut = "G";
                    }
                    else
                    {
                        cours.Statut = "S";
                    }
                    Cours.ListCours.Add(cours);
                }
            }
            //Fermer le datareader
            resultat.Close();

            //Aller chercher la liste des jours et des créneaux d'un cours afin d'ajouter à ses listes
            resultat = SeConnecter.Lire("select * from CreneauCours");
            while (resultat.Read())
            {
                foreach (Cours cours1 in Cours.ListCours)
                {
                    if (cours1.NumCours == resultat[0].ToString())
                    {
                        cours1.ListJours.Add(Int16.Parse(resultat[1].ToString()));
                        cours1.ListCreneau.Add(Int16.Parse(resultat[2].ToString()));
                        break;
                    }
                }
            }
            //Fermer le datareader
            resultat.Close();

            //Aller chercher la liste des étudiants suivant le cous
            resultat = SeConnecter.Lire("select * from LiensEtudCours");
            while (resultat.Read())
            {
                foreach (Cours cours1 in Cours.ListCours)
                {
                    if (cours1.NumCours == resultat[0].ToString())
                    {
                        cours1.ListEtudiants.Add(resultat[1].ToString());
                        break;
                    }
                }
            }
            resultat.Close();



            ////////////////////Objets programmes/////////////////////////////////
            resultat = SeConnecter.Lire("select * from programmes"); //Aller chercher le numéro et le nom des programmes
            if (resultat.HasRows)
            {
                while (resultat.Read())
                {
                    Programme programme = new Programme();
                    programme.NumProgramme = resultat[0].ToString();
                    programme.NomProgramme = resultat[1].ToString();
                    programme.ListCours = new List<Cours>();
                    Programme.ListProgrammes.Add(programme);
                }
            }
            resultat.Close(); //Fermer le datareader
            //Aller chercher la liste des cours
            resultat = SeConnecter.Lire("select * from Cours");
            while (resultat.Read()) //parcourir toutes les lignes du select
            {
                //Parcourir tous les programmes pour voir s'il correspond
                foreach (Programme programme1 in Programme.ListProgrammes)
                {
                    if (programme1.NumProgramme == resultat[3].ToString()) //Vérifier si le programme correspond
                    {
                        //Parcourir tous les cours de la liste pour voir si il correspond et l'ajouter à la liste de cours du programme
                        foreach (Cours cours1 in Cours.ListCours)
                        {
                            if (resultat[0].ToString() == cours1.NumCours)
                            {
                                programme1.ListCours.Add(cours1);
                            }
                        }
                    }
                    break; //briser car on a tourver le programme correspondant à cette ligne du select
                }
            }

            resultat.Close(); //Fermer le datareader








            /**
             *Préparer la page d'Accueil 
             */
            //Vider le message d'erreur
            lblErreurConenxion.Text = "";

            //Sélectionner le type Etudiant pour le combobox
            cboTypeUtilisateurConnexion.SelectedIndex = 0;
            txtNumConnexion.MaxLength = 7;
        }

        private void cboTypeUtilisateurConnexion_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Mettre une longueur maximale pour le numéro en fonction du type sélectionné
            if (cboTypeUtilisateurConnexion.SelectedIndex == 0) //Longueur du numéro pour les étudiants
            {
                txtNumConnexion.MaxLength = 7;
            }
            else if (cboTypeUtilisateurConnexion.SelectedIndex == 1) //Longueur du numéro pour les enseignants
            {
                txtNumConnexion.MaxLength = 6;
            }
            else if (cboTypeUtilisateurConnexion.MaxLength == 2) //Longueur du numéro pour les responsables
            {
                txtNumConnexion.MaxLength = 6;
            }
        }

        private void btnConnexion_Click(object sender, EventArgs e)
        {

            String connectionString = ConfigurationManager.ConnectionStrings["cnxSqlServer"].ConnectionString;
            cnx = new SqlConnection();
            cnx.ConnectionString = connectionString;

            //Aller chercher dans la base de donnée si le numéro correspond au mot de passe
            //Vérifier quel type d'utilisateur est demandé pour envoyer la bonne requête
            if (cboTypeUtilisateurConnexion.SelectedIndex == 0)
            {
                //Créer la requête
                Requete = $"SELECT NumEtu from Etudiants where MotDePasse = '{txtMDPConnexion.Text}' and NumEtu = '{txtNumConnexion.Text}'";
            }
            else if (cboTypeUtilisateurConnexion.SelectedIndex == 1)
            {
                //Créer la requête
                Requete = $"SELECT NumEnseignant from Enseignants where MotDePasse = '{txtMDPConnexion.Text}' and NumEnseignant = '{txtNumConnexion.Text}'";
            }
            else
            {
                //Créer la requête
                Requete = $"SELECT r.NumEnseignant from Responsables r" +
                    $" join Enseignants e on r.NumEnseignant = e.NumEnseignant" +
                    $" where MotDePasse = '{txtMDPConnexion.Text}' and r.NumEnseignant = '{txtNumConnexion.Text}'";
            }

            //Créer la commande
            command = new SqlCommand(Requete, cnx);
            //Mettre La requête dans la propriété CommandText de l’objet command
            command.CommandText = Requete;

            //Établir la connexion avec le serveur
            if (cnx.State == ConnectionState.Closed)
            {
                cnx.Open();
            }
            //Exécuter la commande
            resultat = command.ExecuteReader();

            //Vérifier si la commande a reçut des lignes pour vérifier s'il y a correspondance avec la connexion
            if (resultat.HasRows)
            {
                resultat.Close();

                /***************************************
                 * Créer l'objet correspondant à la personne qui se connecte
                 ***************************************/

                ///////////////////////Si c'est un enseignant responsable////////////////////////////
                if (cboTypeUtilisateurConnexion.SelectedIndex == 2)
                {
                    resultat = SeConnecter.Lire($"select * from Responsables r left join Enseignants e on r.NumEnseignant = e.NumEnseignant" +
                        $" left join LienEnsProg l on r.NumEnseignant = l.NumEnseignant where r.NumEnseignant = '{txtNumConnexion.Text}'");

                    //Vérifier si il y a un résultat
                    if (resultat.HasRows)
                    {
                        while (resultat.Read())
                        {
                            //EnseignantResponsable responsable = new EnseignantResponsable();
                            //responsable.NumResponsable = resultat[0].ToString();
                            string numResponsable = resultat[0].ToString();
                            //responsable.NumEnseignant = resultat[1].ToString();
                            string numEnseignant = resultat[1].ToString();
                            //responsable.Prenom = resultat[3].ToString();
                            string prenom = resultat[3].ToString();
                            //responsable.Nom = resultat[4].ToString();
                            string nom = resultat[4].ToString();
                            //responsable.DateNaissance = Convert.ToDateTime(resultat[5].ToString());
                            DateTime dateNaissance = Convert.ToDateTime(resultat[5].ToString());
                            //responsable.DateDebutEnseigne = Convert.ToDateTime(resultat[7].ToString());
                            DateTime dateDebut = Convert.ToDateTime(resultat[7].ToString());
                            //responsable.MotDePasse = resultat[6].ToString();
                            string motDePasse = resultat[6].ToString();
                            //responsable.ProgrammeResponsable = resultat[9].ToString();
                            string programmeResponsable = resultat[9].ToString();
                            //responsable.ListCoursEnseigne = new List<Cours>();
                            List<Cours> listCours = new List<Cours>();
                            ////Trouver le programme
                            Programme programme = new Programme();
                            foreach (Programme programme1 in Programme.ListProgrammes)
                            {
                                if (programme1.NumProgramme == resultat[9].ToString())
                                {
                                    //responsable.Programme = programme1;
                                    programme = programme1;
                                    break;
                                }
                            }
                            
                            EnseignantResponsable.listResponsables.Add(new EnseignantResponsable(prenom, nom, dateNaissance, numEnseignant, programme, listCours, dateDebut, motDePasse, numResponsable, programmeResponsable));
                            break;
                        }
                        resultat.Close(); //Fermer le DataReader

                        //Aller chercher les informations manquantes pour chaque responsable comme la liste des cours enseignées
                        resultat = SeConnecter.Lire($"select NumCours, Enseignant from Cours where Enseignant = '{txtNumConnexion.Text}'");

                        //Vérifier si il y a un résultat
                        if (resultat.HasRows)
                        {
                            while (resultat.Read())
                            {
                                //Parcourir les cours et les enseignants pour savoir quel cours l'enseignant enseigne
                                foreach (Cours cours1 in Cours.ListCours)
                                {
                                    if (resultat[0].ToString() == cours1.NumCours)
                                    {
                                        foreach (EnseignantResponsable responsable1 in EnseignantResponsable.listResponsables)
                                        {
                                            if (txtNumConnexion.Text == responsable1.NumEnseignant)
                                            {
                                                responsable1.ListCoursEnseigne.Add(cours1);
                                                break; //On peut briser car on a trouvé quel enseignant enseigne ce cours
                                            }
                                        }
                                        break; //On peut briser car on a trouver quel cours correspond à celui sur cette ligne
                                    }
                                }
                            }
                        }
                        resultat.Close();

                        //Aller chercher le nombre d'enseignants inférieurs
                        resultat = SeConnecter.Lire($"select * from LienEnsProg");
                        //Vérifier si il y a un résultat
                        if (resultat.HasRows)
                        {
                            foreach (EnseignantResponsable responsable1 in EnseignantResponsable.listResponsables)
                            {
                                int compteur = 0;
                                while (resultat.Read())
                                {
                                    if (resultat[1].ToString() == responsable1.ProgrammeResponsable && resultat[0].ToString() != responsable1.NumEnseignant)
                                    {
                                        compteur++;
                                    }
                                }
                                responsable1.NbEnsInferieur = compteur;
                            }
                        }
                        resultat.Close();
                    }
                }
                    

                /**********************************
                 * Si la connexion est un enseignant
                 **********************************/
                else if (cboTypeUtilisateurConnexion.SelectedIndex == 1)
                {
                    resultat = SeConnecter.Lire($"SELECT * FROM enseignants e left join LienEnsProg l on e.NumEnseignant = l.NumEnseignant" +
                        $" where e.NumEnseignant = '{txtNumConnexion.Text}'"); //requete qui va chercher toutes les informations de l'enseignant qui se connecte
                    if (resultat.HasRows)
                    {
                        while (resultat.Read()) //Tant que la requête a des lignes restantes, les parcours 
                        {
                            Enseignants enseignant = new Enseignants(); //Créer l'enseignant et lui assigne ses attributs
                            enseignant.NumEnseignant = resultat[0].ToString();
                            enseignant.Prenom = resultat[1].ToString();
                            enseignant.Nom = resultat[2].ToString();
                            enseignant.DateNaissance = Convert.ToDateTime(resultat[3].ToString());
                            enseignant.DateDebutEnseigne = Convert.ToDateTime(resultat[5].ToString());
                            enseignant.MotDePasse = resultat[4].ToString();
                            enseignant.ListCoursEnseigne = new List<Cours>();
                            //trouver le programme
                            foreach (Programme programme1 in Programme.ListProgrammes)
                            {
                                if (resultat[7].ToString() == programme1.NumProgramme)
                                {
                                    enseignant.Programme = programme1;
                                }
                            }
                            Enseignants.ListEnseignant.Add(enseignant);
                        }
                        resultat.Close();

                        //Aller chercher les informations manquantes pour chaque responsable comme la liste des cours enseignées
                        resultat = SeConnecter.Lire($"select NumCours, Enseignant from Cours where Enseignant = '{txtNumConnexion.Text}'"); //Requete allant chercher l'ensemble des cours reliés à l'enseignant qui se connecte

                        //Vérifier si il y a un résultat
                        if (resultat.HasRows)
                        {
                            while (resultat.Read())
                            {
                                //Parcourir les cours et les enseignants pour savoir quel cours l'enseignant enseigne
                                foreach (Cours cours1 in Cours.ListCours)
                                {
                                    if (resultat[0].ToString() == cours1.NumCours)
                                    {
                                        //Parcourir les enseignants créés afin de savoir quel qui se connecte et ajouter les cours au bon
                                        foreach (Enseignants enseignants1 in Enseignants.ListEnseignant)
                                        {
                                            if (txtNumConnexion.Text == enseignants1.NumEnseignant)
                                            {
                                                enseignants1.ListCoursEnseigne.Add(cours1);
                                                break; //On peut briser car on a trouvé quel enseignant enseigne ce cours
                                            }
                                        }
                                        break; //On peut briser car on a trouver quel cours correspond à celui sur cette ligne
                                    }
                                }
                            }
                        }
                        resultat.Close();
                    }
                }


                /**********************************
                 * Si la connexion est un étudiant
                 **********************************/
                else if (cboTypeUtilisateurConnexion.SelectedIndex == 0)
                {
                    resultat = SeConnecter.Lire($"select * from Etudiants where NumEtu = '{txtNumConnexion.Text}'"); //Requete pour aller chercher l'ensemble des cours relié à l'enseignant qui se connecte
                    if (resultat.HasRows)
                    {
                        while (resultat.Read())
                        {
                            Etudiants etudiant = new Etudiants();
                            etudiant.NumEtu = resultat[0].ToString();
                            etudiant.Prenom = resultat[2].ToString();
                            etudiant.Nom = resultat[3].ToString();
                            etudiant.DateNaissance = Convert.ToDateTime(resultat[4].ToString());
                            etudiant.MotDePasse = resultat[5].ToString();
                            //Trouver le programme
                            foreach (Programme programme1 in Programme.ListProgrammes)
                            {
                                if (programme1.NumProgramme == resultat[1].ToString())
                                {
                                    etudiant.Programme = programme1;
                                }
                            }
                            Etudiants.ListeEtudiants.Add(etudiant);
                        }
                        resultat.Close();

                        //Aller chercher la liste de cours suivis
                        resultat = SeConnecter.Lire($"select * from LiensEtudCours where Etudiant = '{txtNumConnexion.Text}'");

                        if (resultat.HasRows)
                        {
                            while (resultat.Read())
                            {
                                //Parcourir la liste des cours pour savoir quel est le cours sélectionné dans la requete
                                foreach (Cours cours1 in Cours.ListCours)
                                {
                                    if (resultat[0].ToString() == cours1.NumCours)
                                    {
                                        //Parcourir les étudiants pour savoir quel est celui qui doit ajouter ces cours
                                        foreach (Etudiants etudiant1 in Etudiants.ListeEtudiants)
                                        {
                                            etudiant1.ListeCoursInscrits.Add(cours1);
                                            break; //On peut briser car on a trouver quel étudiant correspond à celui qu'on cherchait
                                        }
                                        break; //On peut briser car on a trouver quel cours correspond à celui qu'on cherche
                                    }
                                }
                            }
                        }
                    }
                }



                /**
                 * Créer la page du prochain formulaire si la connexion est bonne
                 *
                 */
                //Instancier un objet FormAccueil
                FormAccueil Accueil = new FormAccueil();
                Accueil.TypeUsager = cboTypeUtilisateurConnexion.Text; //Indiquer le type d'usager sélectionné dans le formulaire Accueil
                Accueil.NumeroUsager = txtNumConnexion.Text;
                this.Hide();
                Accueil.ShowDialog(); //Afficher le formulaire d'Accueil
                this.Close(); //Fermer le formulaire de connexion


            }
            else
            {
                lblErreurConenxion.Text = "Erreur de connexion: Numéro ou mot de passe éroné";
                resultat.Close();
            }



        }

        private void txtMDPConnexion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) //Si la touche Enter est appuyée
                btnConnexion.PerformClick();
        }

        ///// <summary>
        ///// Fonction permettant de se connecter à la base de donnée et d'exécuter une commande select dans la base de donnée
        ///// </summary>
        ///// <param name="pRequete">Requête à effectuer</param>
        ///// <returns>Le datareader contenant le résultat du select</returns>
        //public SqlDataReader SeConnecterLire(string pRequete)
        //{
        //    //Créer la requête
        //    Requete = pRequete;
        //    //Créer la commande
        //    command = new SqlCommand(Requete, cnx);
        //    //Mettre La requête dans la propriété CommandText de l’objet command
        //    command.CommandText = Requete;
        //    //Établir la connexion avec le serveur
        //    if (cnx.State == ConnectionState.Closed)
        //    {
        //        cnx.Open();
        //    }
        //    //Exécuter la commande
        //    resultat = command.ExecuteReader();
        //    return resultat;
        //}

    }
}
    
