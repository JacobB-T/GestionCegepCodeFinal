using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionCegep.Models
{
    public class Cours
    {
        //attributs 
        private string numCours;
        private string nomCours;
        private string enseignant = "ABC";
        private List<string> listEtudiants;
        private string programme;
        private List<int> listJours;
        private List<int> listCreneau;
        private string statut;
        private int nbPlaces;
        private static List<Cours> listCours = new List<Cours>();


        //Méthodes d'accès
        public string NumCours
        {
            get { return numCours; }
            set { if(value.Length == 6) { numCours = value; } }
        }

        public string NomCours
        {
            get { return nomCours; }
            set { if(value.Length <= 75) { nomCours = value; } }
        }
        public string Enseignant
        {
            get { return enseignant; }
            set { enseignant = value; }
        }
        public List<string> ListEtudiants
        {
            get { return listEtudiants; }
            set { listEtudiants = value; }
        }

        public string Programme
        {
            get { return programme; }
            set { programme = value; }
        }
        public List<int> ListJours
        {
            get { return listJours; }
            set { listJours = value; }
        }
        public List<int> ListCreneau
        {
            get { return listCreneau; }
            set { listCreneau = value; }
        }
        public string Statut
        {
            get { return statut; }
            set { if (value == "G" || value == "S") { statut = value; } }
        }
        public int NbPlaces
        {
            get { return nbPlaces; }
            set { if (value > 0) { nbPlaces = value; } }
        }

        public static List<Cours> ListCours
        {
            get { return listCours; }
            set { listCours = value; }
        }


        //Constructeur sans paramètre
        public Cours() { }

        //Constructeur avec paramètre
        public Cours(string pNumCours = "AA1234", string pNomCours = "AA", string pEnseignant = "ABC", List<string> pListeEtudiant = default(List<string>),
            string pProgramme = "ABC", List<int> pListeJours = default(List<int>), List<int> pListeCreneau = default(List<int>), string pStatut = "G", int pNbPlaces = -1)
        {
            this.numCours = pNumCours;
            this.nomCours = pNomCours;
            this.enseignant = pEnseignant;
            this.listEtudiants = pListeEtudiant;
            this.programme = pProgramme;
            this.listJours = pListeJours;
            this.listCreneau = pListeCreneau;
            this.statut = pStatut;
            this.nbPlaces = pNbPlaces;
        }



        /// <summary>
        /// Fonction permettant de calculer le nombre d'heures d'un  cours par semaine
        /// </summary>
        /// <returns></returns>
        public int CalculNbHeures()
        {
            int NbHeures = listJours.Count() * 2; //Puisqu'il ne peut y avoir qu'un cours d'un type par jour, il compte le nombre de jour où le cours est donné
            return NbHeures;
        }


        /// <summary>
        /// Méthode ToString permettant de faire un certain affichage du cours
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.numCours + " - " + this.nomCours;
        }
    }
}
