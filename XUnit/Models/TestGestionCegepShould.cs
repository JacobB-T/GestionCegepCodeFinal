using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestionCegep.Models;

namespace XUnit.Tests.Models
{
    public class TestGestionCegepShould
    {


        /// <summary>
        /// Méthode de test Xunit pour la méthode CoutImpression de la classe Etudiants
        /// </summary>
        /// <param name="nbPage">Nombre de page à imprimer donné paramètre à la fonction</param>
        /// <param name="expected">Prix attendu à l'issu de la fonction</param>
        [Theory]
        [InlineData(10, 1)]
        [InlineData(0, 0)]
        [InlineData(101, 10.01)]
        public void TestCoutImpressionEtudiant(int nbPage, double expected)
        {
            Etudiants etudiants1 = new Etudiants();
            double resultat = etudiants1.CoutImpression(nbPage);
            Assert.Equal(expected, resultat);
        }


        /// <summary>
        /// Méthode de test Xunit pour la méthode AnneeExp de la classe Enseignant
        /// </summary>
        /// <param name="DateDebut">date représentant la date où l'enseignant à commencer à enseigner</param>
        /// <param name="nbAnneExpect">Nombre d'année supposé donné à l'issu de la fonction</param>
        [Theory]
        [InlineData(Convert.ToDateTime("10/10/2020"), 2)]
        [InlineData(Convert.ToDateTime("12/08/2015"), 7)]
        [InlineData(Convert.ToDateTime("05/05/2010"), 12)]
        public void TestAnneeExp(DateTime DateDebut, int nbAnneExpect)
        {
            Enseignants enseignants1 = new Enseignants();
            enseignants1.DateDebutEnseigne = DateDebut;
            int resultat = enseignants1.NbAnneeExperience();
            Assert.Equal(nbAnneExpect, resultat);
        }
    }
}
