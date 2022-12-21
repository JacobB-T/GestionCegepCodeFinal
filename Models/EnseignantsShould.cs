using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestionCegep.Interfaces;

namespace GestionCegep.Models
{
    public class Enseignants : MembreCegep, IHeureCours
    {
        //Attributs
        private string numEnseignant;
        private Programme programme;
        private List<Cours> listCoursEnseigne = new List<Cours>();
        private DateTime dateDebutEnseigne;
        private string motDePasse;
        private static List<Enseignants> listEnseignants = new List<Enseignants>();

        //Implémenter les méthodes d'accès
        public string NumEnseignant
        {
            get { return numEnseignant; }
            set { if(value.Length == 6) { numEnseignant = value; } } //Le numéro d'enseignant doit être d'une longueur de 6
        }

        public Programme Programme
        {
            get { return programme; }
            set { programme = value; }
        }

        public List<Cours> ListCoursEnseigne
        {
            get { return listCoursEnseigne; }
            set { listCoursEnseigne = value; }
        }

        public DateTime DateDebutEnseigne
        {
            get { return dateDebutEnseigne; }
            set { if (value <= DateTime.Now) { dateDebutEnseigne = value; } }
        }

        public string MotDePasse
        {
            get { return motDePasse; }
            set { motDePasse = value; }
        }

        public static List<Enseignants> ListEnseignant
        {
            get { return listEnseignants; }
            set { listEnseignants = value; }
        }


        //Constructeur sans paramètre
        public Enseignants() { }

        //Constructeur avec paramètres
        public Enseignants(string pPrenom = "ABC", string pNom = "XYZ", DateTime pDateNaissance = default(DateTime),
            string pNumEnseignant = "ABC1234", Programme pProgramme = default(Programme) , List<Cours> pListeCoursEnseigne = default(List<Cours>), DateTime pDateDebutEnseigne = default(DateTime), string pMotDePasse = "AAA")
            : base(pPrenom, pNom, pDateNaissance)
        {
            this.numEnseignant = pNumEnseignant;
            this.programme = pProgramme;
            this.listCoursEnseigne = pListeCoursEnseigne;
            this.dateDebutEnseigne = pDateDebutEnseigne;
            this.motDePasse = pMotDePasse;
        }

        /// <summary>
        /// Méthode hérité de l'Interface IHeureCours permettant de calculer le nombre d'heure de cours qu'enseigne un enseignant par semaine.
        /// </summary>
        /// <returns>Le nombres d'heures de cours</returns>
        public int CalculHeuresCours()
        {
            int heureCours = 0;
            foreach (Cours cours in listCoursEnseigne)
            {
                heureCours += cours.CalculNbHeures();
            }
            return heureCours;
        }


        /// <summary>
        /// Méthode permettant de calculer le cout d'impression d'un certain nombre de pages en fonction du nombre d'année d'expériences
        /// </summary>
        /// <param name="pNbPages">Le nombre de pages a imprimer</param>
        /// <returns>Le prix d'impression</returns>
        public override double CoutImpression(int pNbPages)
        {
            double CoutImpression;
            if (this.NbAnneeExperience() > 1) //Vérifie pour ne pas diviser par 0 s'il n'y a pas d'année d'expérience
            {
                float NbAnneeExp = this.NbAnneeExperience();
                double coefficient = (1 / NbAnneeExp);
                CoutImpression = pNbPages * coefficient;
            }
            else
            {
                CoutImpression = pNbPages * 0.2 ;
            }
            return CoutImpression;
        }


        /// <summary>
        /// Méthode permettant de calculer le nombre d'année d'expérience d'un enseignant
        /// </summary>
        /// <returns></returns>
        public int NbAnneeExperience()
        {
            int NbAnneeExperience;
            NbAnneeExperience = DateTime.Now.Year - dateDebutEnseigne.Year;
            return NbAnneeExperience;
        }

    }
}
