using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestionCegep.Interfaces;

namespace GestionCegep.Models
{
    public abstract class MembreCegep
    {
        //implémantation des attributs de la classe
        private string prenom;
        private string nom;
        private DateTime dateNaissance;

        //Implémenter les méthodes d'accès
        public string Prenom //Méthode d'Accès pour l'attribut prenom
        {
            get { return prenom; }
            set { prenom = value; }
        }

        public string Nom //Méthode d'Accès pour l'attribut nom
        {
            get { return nom; }
            set { nom = value; }
        }

        public DateTime DateNaissance //Méthode d'Accès pour l'attribut dateNaissance
        {
            get { return dateNaissance; }
            set { if (dateNaissance <= DateTime.Now) { dateNaissance = value; } }
        }

        //Constructeur sans paramètre
        public MembreCegep() { }

        //Constructeur avec paramètre
        public MembreCegep(string pPrenom = "ABC", string pNom = "XYZ", DateTime pDateNaissance = default(DateTime))
        {
            this.prenom = pPrenom;
            this.nom = pNom;
            this.dateNaissance = pDateNaissance;
        }


        /// <summary>
        /// Méthode permettant de calculer le prix pour imprimer
        /// </summary>
        /// <param name="pNbPages">Nombre de pages à imprimer</param>
        /// <returns>Le prix pour imprimer le nombre de pages</returns>
        public abstract double CoutImpression(int pNbPages);

    }
}
