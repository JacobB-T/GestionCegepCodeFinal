using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using GestionCegep.Formulaires;
using GestionCegep;
using GestionCegep.Classe;
using GestionCegep.Interfaces;
using GestionCegep.Properties;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Security.Cryptography.X509Certificates;

namespace GestionCegep
{
    internal static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormConnexion());


            
        }
    }
}
