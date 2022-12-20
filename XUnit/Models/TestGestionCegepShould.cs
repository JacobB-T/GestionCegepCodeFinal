using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XUnit;
using GestionCegep;

namespace XUnit.Models
{
    public class TestGestionCegepShould
    {
        [Theory]
        [InlineData(10,1)]
        [InlineData(0,0)]
        [InlineData(101,10.01)]
        public void TestCoutImpressionEtudiant(int nbPage, double expected)
        {
            Etudiants etudiants1 = new Etudiants();
            double resultat = etudiants1.CoutImpression(nbPage);
            Assert.Equal(expected, resultat);
        }

        [Theory]
        [InlineData(Convert.ToDateTime("10/10/2020"), 2)]
        [InlineData(Convert.ToDateTime("12/08/2015"), 7)]
        [InlineData(Convert.ToDateTime("05/05/2010"), 12)]
        public void TestAnneeExp(DateTime DateDebut, int nbAnneExpect)
        {
            Enseignants enseignants1 = new Enseignants();
            enseignants1.dateDebutEnseigne = DateDebut;
            int resultat = enseignants1.NbAnneeExperience();
            Assert.Equal(nbAnneExpect, resultat);
        }
    }
}
