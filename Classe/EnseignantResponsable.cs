using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionCegep.Classe
{
    public class EnseignantResponsable : Enseignants
    {
        //Attributs
        private string numResponsable;
        private string programmeResponsable;
        private int nbEnsInferieur;
        public static List<EnseignantResponsable> listResponsables = new List<EnseignantResponsable>();

        //Méthodes d'accès
        public string NumResponsable
        {
            get { return numResponsable; }
            set { if (value.Length == 5) { this.numResponsable = value; } }
        }

        public string ProgrammeResponsable
        {
            get { return programmeResponsable; }
            set { this.programmeResponsable = value; }
        }

        public int NbEnsInferieur
        {
            get { return nbEnsInferieur; }
            set { if (value > 0) { nbEnsInferieur = value; } }
        }

        //public static List<EnseignantResponsable> ListResponsables
        //{
        //    get { return ListResponsables; }
        //    set { ListResponsables = value; }
        //}

        //Construteur sans paramètre
        public  EnseignantResponsable() { }

        //Constructeur avec paramètres

        public EnseignantResponsable(string pPrenom = "ABC", string pNom = "XYZ", DateTime pDateNaissance = default(DateTime),
            string pNumEnseignant = "ABC1234", Programme pProgramme = default(Programme), List<Cours> pListeCoursEnseigne = default(List<Cours>), DateTime pDateDebutEnseigne = default(DateTime), string pMotDePasse = "AAA",
            string pNumResponsable = "AA123", string pProgrammeResponsable = "ABC", int pNbInferieur = -1)
            : base(pPrenom, pNom, pDateNaissance, pNumEnseignant, pProgramme, pListeCoursEnseigne, pDateDebutEnseigne, pMotDePasse)
        {
            numResponsable = pNumResponsable;
            programmeResponsable = pProgrammeResponsable;
            nbEnsInferieur = pNbInferieur;
        }


        /// <summary>
        /// Méthode ToString override
        /// </summary>
        /// <returns>Une chaine de caractère représentant l'enseignant responsable</returns>
        public override string ToString()
        {
            return $"NumResponsable: {this.NumResponsable}\nNumEnseignant: {this.NumEnseignant}\nPrenom: {this.Prenom}\nNom: {this.Nom}\nDate de naissance: {this.DateNaissance.ToString()}";
        }
    }
}
