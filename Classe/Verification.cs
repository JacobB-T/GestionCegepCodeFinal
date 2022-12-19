using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace GestionCegep.Classe
{
    public static class Verification
    {
        /// <summary>
        /// Méthode statique permettant de voir si il y a un conflit d'horaire avec un cours étant déjà dans la liste des cours avant d'en ajouter un autre
        /// </summary>
        /// <param name="pListeCours">Liste des cours à vérifier s'il y a conflit d'horaire avec</param>
        /// <param name="pNouveauCours">Nouveau cours à être ajouté</param>
        /// <returns>True si c'est compatible, False si il y a conflit d'horaire, donc le cours n'est pas compatible</returns>
        public static bool TempsCours(List<Cours> pListeCours, Cours pNouveauCours)
        {
            bool Verificateur = true; //Vérificateur pour savoir si un cours est en conflit d'horaire
            foreach(Cours coursAncien in pListeCours) //Parcourir la liste des cours dans la liste des cours donnée
            {
                int index1 = 0; //Index pour savoir quel jour on est rendu dans le parcour pour connaître l'heure du cours donné ce jour là
                foreach(int jourAncien in coursAncien.ListJours) //Parcourir la liste des jours du cours ou la boucle est rendue
                {
                    if(Verificateur == false)
                    {
                        break;
                    }
                    else
                    {
                        int index2 = 0;
                        foreach (int jourNouveau in pNouveauCours.ListJours)
                        {
                            //Puisque un cours va toujours avoir le jour et le créneau relié au même index,
                            //on vérifie pour chaque jour et créneau du nouveau cours s'ils sont déjà présent dans la liste des cours
                            if (coursAncien.ListJours[index1] == pNouveauCours.ListJours[index2] && coursAncien.ListCreneau[index1] == pNouveauCours.ListCreneau[index2])
                            {
                                Verificateur = false;
                                break;
                            }
                            index2++;
                        }
                        index1++; //Augmenter l'index rendu à la fin pour voir le prochains cours dans la liste
                    }
                    
                }
            }
            return Verificateur;
        }

        /// <summary>
        /// Méthode vérifiant si un cours a un prof d'assigné
        /// </summary>
        /// <param name="pCours">Le cours à vérifier</param>
        /// <returns>True si il y a un prof, false s'il n'y a pas de prof</returns>
        public static bool PresenceProf(Cours pCours)
        {
            if(pCours.Enseignant == "ABC" || pCours.Enseignant == null) //Vérifie si la valeur de l'attribut Enseignant du Cours est sa valeur par défaut
            {
                return false;
            }
            else
            {
                return true;
            }
        }


        /// <summary>
        /// Méthode permettant de savoir s'il reste de la place dans un cours
        /// </summary>
        /// <param name="pCours">Cours à vérifier</param>
        /// <returns>True s'il reste de la place, sinon retourne False</returns>
        public static bool PlaceCours(Cours pCours)
        {
            if(pCours.ListEtudiants.Count() < pCours.NbPlaces)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
