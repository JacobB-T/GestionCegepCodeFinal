using GestionCegep.Classe;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionCegep.Formulaires
{
    public partial class formHoraire : Form
    {
        public formHoraire()
        {
            InitializeComponent();
        }

        private void Horaire_Load(object sender, EventArgs e)
        {
            Etudiants etudiantConnecte = new Etudiants();
            Enseignants enseignantConencte = new Enseignants();
            EnseignantResponsable responsableconnecte = new EnseignantResponsable();
            // Aller chercher le type d'usager qui est connecté
            /////////////////////////////////////////Si c'est un étudiant qui est connecté///////////////////////////////////
            if(lblTypeUsagerHoraire.Text == "Étudiant")
            {
                //Trouver quel étudiant est connecté
                foreach(Etudiants etudiant1 in Etudiants.ListeEtudiants)
                {
                    if(etudiant1.NumEtu.ToString() == lblNumeroHoraire.Text)
                    {
                        etudiantConnecte = etudiant1;
                        break;
                    }
                }

                if (etudiantConnecte.ListeCoursInscrits.Count > 0) //Si l'étudiant n'a pas de cours inscrit, rien n'afficher et lui montrer un message d'Erreu
                {
                    //Mettre en place l'horaire
                    int compteurHeure = 8;
                    for (int numCreneau = 0; numCreneau < 5; numCreneau++)
                    {
                        string[] row = new string[7];
                        row[0] = $"{compteurHeure.ToString()}:00 - {(compteurHeure + 1).ToString()}:50";
                        if (compteurHeure != 12)  //Mettre une ligne vide pour l'heure du diner
                        {
                            //trouver quel cours se donne quel jour
                            for (int numJour = 0; numJour < 7; numJour++)
                            {
                                foreach (Cours cours1 in etudiantConnecte.ListeCoursInscrits)
                                {
                                    for (int i = 0; i < cours1.ListJours.Count(); i++) //Parcourir l'index des jours, donc des créneaux du cours à ajouter à l'horaire
                                    {
                                        if (numJour + 1 == cours1.ListJours[i] && numCreneau + 1 == cours1.ListCreneau[i])
                                        {
                                            row[numJour + 1] = cours1.ToString();
                                            break;
                                        }
                                    }
                                }

                            }
                        }
                        dataGVHoraire.Rows.Add(row);
                        compteurHeure += 2;
                    }

                    //Mettre le nombre d'heure de cours dans son label
                    lblNbHeuresCours.Text = etudiantConnecte.CalculHeuresCours().ToString();
                }
                else
                {
                    MessageBox.Show("Aucun cours n'est à l'horaire");
                    lblNbHeuresCours.Text = "0";
                }

                
                
            }

            /////////////////////////////////////////Si c'est un enseignant qui est connecté///////////////////////////////////
            else if(lblTypeUsagerHoraire.Text == "Enseignant")
            {
                //Trouver quel enseignant est connecté
                foreach(Enseignants enseignant1 in Enseignants.ListEnseignant)
                {
                    if(enseignant1.NumEnseignant.ToString() == lblNumeroHoraire.Text)
                    {
                        enseignantConencte = enseignant1;
                        break;
                    }
                }

                if (enseignantConencte.ListCoursEnseigne.Count > 0) //Si l'étudiant n'a pas de cours inscrit, rien n'afficher et lui montrer un message d'Erreu
                {
                    //Mettre en place l'horaire
                    int compteurHeure = 8;
                    for (int numCreneau = 0; numCreneau < 5; numCreneau++)
                    {
                        string[] row = new string[7];
                        row[0] = $"{compteurHeure.ToString()}:00 - {(compteurHeure + 1).ToString()}:50";
                        if (compteurHeure != 12)  //Mettre une ligne vide pour l'heure du diner
                        {
                            //trouver quel cours se donne quel jour
                            for (int numJour = 0; numJour < 7; numJour++)
                            {
                                foreach (Cours cours1 in enseignantConencte.ListCoursEnseigne)
                                {
                                    for (int i = 0; i < cours1.ListJours.Count(); i++) //Parcourir l'index des jours, donc des créneaux du cours à ajouter à l'horaire
                                    {
                                        if (numJour + 1 == cours1.ListJours[i] && numCreneau + 1 == cours1.ListCreneau[i])
                                        {
                                            row[numJour + 1] = cours1.ToString();
                                            break;
                                        }
                                    }
                                }

                            }
                        }
                        dataGVHoraire.Rows.Add(row);
                        compteurHeure += 2;
                    }

                    //Mettre le nombre d'heure de cours dans son label
                    lblNbHeuresCours.Text = etudiantConnecte.CalculHeuresCours().ToString();
                }
                else
                {
                    MessageBox.Show("Aucun cours n'est à l'horaire");
                    lblNbHeuresCours.Text = "0";
                }
            }

            /////////////////////////////////////////Si c'est un responsable qui est connecté///////////////////////////////////
            else if(lblTypeUsagerHoraire.Text == "Enseignant Responsable")
            {
                //Trouver quel responsable est connecté
                foreach (EnseignantResponsable responsable1 in EnseignantResponsable.listResponsables)
                {
                    if (responsable1.NumEnseignant.ToString() == lblNumeroHoraire.Text)
                    {
                        responsableconnecte = responsable1;
                        break;
                    }
                }

                if (responsableconnecte.ListCoursEnseigne.Count > 0) //Si l'étudiant n'a pas de cours inscrit, rien n'afficher et lui montrer un message d'Erreu
                {

                    int compteurHeure = 8;
                    //Mettre en place l'horaire
                    for (int numCreneau = 0; numCreneau < 5; numCreneau++)
                    {
                        string[] row = new string[7];

                        row[0] = $"{compteurHeure.ToString()}:00 - {(compteurHeure + 1).ToString()}:50";
                        if(compteurHeure != 12)  //Mettre une ligne vide pour l'heure du diner
                        {
                            
                            //trouver quel cours se donne quel jour
                            for (int numJour = 0; numJour < 7; numJour++)
                            {
                                foreach (Cours cours1 in responsableconnecte.ListCoursEnseigne)
                                {
                                    for (int i = 0; i < cours1.ListJours.Count(); i++) //Parcourir l'index des jours, donc des créneaux du cours à ajouter à l'horaire
                                    {
                                        if (numJour + 1 == cours1.ListJours[i] && numCreneau + 1 == cours1.ListCreneau[i])
                                        {
                                            row[numJour + 1] = cours1.ToString();
                                            break;
                                        }
                                    }
                                }

                            }
                        }
                       dataGVHoraire.Rows.Add(row);
                        compteurHeure += 2;
                    }

                    //Mettre le nombre d'heure de cours dans son label
                    lblNbHeuresCours.Text = etudiantConnecte.CalculHeuresCours().ToString();

                }
                else
                {
                    MessageBox.Show("Aucun cours n'est à l'horaire");
                    lblNbHeuresCours.Text = "0";
                }



            }
        }

        public string NumeroHoraire
        {
            get { return lblNumeroHoraire.Text; }
            set { lblNumeroHoraire.Text = value; }
        }

        public string TypeUsagerHoraire
        {
            get { return lblTypeUsagerHoraire.Text; }
            set { lblTypeUsagerHoraire.Text = value; }
        }

        private void btnRetourAccueil_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
