using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestionCegep.Interfaces;

namespace GestionCegep.Models
{
    public class Etudiants : MembreCegep, IHeureCours
    {
        //Attributs
        private string numEtu;
        private Programme programme = new Programme();
        private List<Cours> listeCoursInscrits = new List<Cours>();
        private string motDePasse;
        public static int nbEtudiant; //Attribut static pour connaître le nombre total d'étudiant
        public static List<Etudiants> listeEtudiants = new List<Etudiants>();


        //Méthodes d'accès
        public string NumEtu
        {
            get { return numEtu; }
            set { if (value.Length == 7) { numEtu = value; } }
        }

        public Programme Programme
        {
            get { return programme; }
            set { programme = value; }
        }

        public List<Cours> ListeCoursInscrits
        {
            get { return listeCoursInscrits; }
            set { listeCoursInscrits = value; }
        }

        public string MotDePasse
        {
            get { return motDePasse; }
            set { motDePasse = value; }
        }

        public static List<Etudiants> ListeEtudiants
        {
            get { return listeEtudiants; }
            set { listeEtudiants = value; }
        }

        //Contructeur sans paramètre
        public Etudiants() { }

        //Csontructeur avec paramètre
        public Etudiants(string pPrenom = "ABC", string pNom = "XYZ", DateTime pDateNaissance = default(DateTime),
            string pNumEtu = "ABC12345", Programme pProgramme = default(Programme) ,List<Cours> pListeCoursInscrit = default(List<Cours>), string pMotDePasse = "AAA")
            : base(pPrenom, pNom, pDateNaissance)
        {
            this.numEtu = pNumEtu;
            this.programme = pProgramme;
            this.listeCoursInscrits = pListeCoursInscrit;
            this.motDePasse = pMotDePasse;

        }


        /// <summary>
        /// Méthode hérité de l'Interface IHeureCours permettant de calculer le nombre d'heure de cours qu'un étudiant a chaque semaine.
        /// </summary>
        /// <returns>Le nombres d'heures de cours</returns>
        public int CalculHeuresCours()
        {
            int heureCours = 0;
            foreach (Cours cours in listeCoursInscrits)
            {
                heureCours += cours.CalculNbHeures();
            }
            return heureCours;
        }

        /// <summary>
        /// Méthode permettant de calculer le cout d'impression d'un certain nombre de page
        /// </summary>
        /// <param name="pNbPages">Le nombre de pages a imprimer</param>
        /// <returns>Le prix d'impression</returns>
        public override double CoutImpression(int pNbPages)
        {
            double CoutImpression;
            CoutImpression = pNbPages * 0.1;
            return CoutImpression;
        }
    }
}
