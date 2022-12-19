using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace GestionCegep.Classe
{
    /// <summary>
    /// Classe static permettant de se connecter à la base de données et de fairte des requêtes
    /// </summary>
    public static class SeConnecter
    {

        

        /// <summary>
        /// Fonction permettant de se connecter à la base de donnée et d'exécuter une commande select dans la base de donnée
        /// </summary>
        /// <param name="pRequete">Requête à effectuer</param>
        /// <returns>Le datareader contenant le résultat du select</returns>
        public static SqlDataReader Lire(string pRequete)
        {
            //Instancier la connexion
            string Requete;
            SqlConnection cnx;
            SqlCommand command;
            SqlDataReader resultat;


            String connectionString = ConfigurationManager.ConnectionStrings["cnxSqlServer"].ConnectionString;
            cnx = new SqlConnection();
            cnx.ConnectionString = connectionString;


            //Créer la requête
            Requete = pRequete;
            //Créer la commande
            command = new SqlCommand(Requete, cnx);
            //Mettre La requête dans la propriété CommandText de l’objet command
            command.CommandText = Requete;
            //Établir la connexion avec le serveur
            if (cnx.State == ConnectionState.Closed)
            {
                cnx.Open();
            }
            //Exécuter la commande
            resultat = command.ExecuteReader();
            return resultat;
        }


        /// <summary>
        /// Fonction permettant d'ajouterdes données à la base de données
        /// </summary>
        /// <param name="pRequete"></param>
        /// <returns></returns>
        public static int Inserer(String pRequete)
        {
            //Instancier la connexion
            string Requete;
            SqlConnection cnx;
            SqlCommand command;
            int resultat;


            String connectionString = ConfigurationManager.ConnectionStrings["cnxSqlServer"].ConnectionString;
            cnx = new SqlConnection();
            cnx.ConnectionString = connectionString;


            //Créer la requête
            Requete = pRequete;
            //Créer la commande
            command = new SqlCommand(Requete, cnx);
            //Mettre La requête dans la propriété CommandText de l’objet command
            command.CommandText = Requete;
            //Établir la connexion avec le serveur
            if (cnx.State == ConnectionState.Closed)
            {
                cnx.Open();
            }
            //Exécuter la commande
            resultat = command.ExecuteNonQuery();
            return resultat;
        }
    }
}
