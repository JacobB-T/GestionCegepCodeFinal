using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionCegep.Models
{
    public class Programme
    {
        //Attributs
        private string numProgramme;
        private string nomProgramme;
        private List<Cours> listCours;
        private static List<Programme> listProgrammes = new List<Programme>();

        //Méthodes d'accès
        public string NumProgramme
        {
            get { return numProgramme; }
            set { if (value.Length == 5) { numProgramme = value; } }
        }
        public string NomProgramme
        {
            get { return nomProgramme; }
            set { if(value.Length <= 75) { nomProgramme = value; } }
        }
        public List<Cours> ListCours
        {
            get { return listCours; }
            set { listCours = value; }
        }

        public static List<Programme> ListProgrammes
        {
            get { return listProgrammes; }
            set { listProgrammes = value; }
        }

        //Constructeur sans paramètre
        public Programme() { }

        //Constructeur avec paramètres
        public Programme(string pNumProgramme = "AA123", string pNomProgramme = "ABC", List<Cours> pListeCours = default(List<Cours>))
        {
            numProgramme = pNumProgramme;
            nomProgramme = pNomProgramme;
            listCours = pListeCours;
        }

        //ToString()
        public override string ToString()
        {
            return this.NumProgramme + " - " + this.NomProgramme;
        }

    }
}
