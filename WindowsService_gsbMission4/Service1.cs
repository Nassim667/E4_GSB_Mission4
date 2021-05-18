using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Mission4GSB;
using MySql.Data.MySqlClient;

namespace WindowsService_gsbMission4
{
    public partial class Service1 : ServiceBase
    {
        //Creation de variable pour le timer, la connexion, les requetes et la date
        private Timer timer = new Timer();
        private ConnexionSql myConnexion;
        private MySqlCommand myConn;
        GestionDate date = new GestionDate();

        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            InitializeTimer();
        }

        protected override void OnStop()
        {
        }

        private void InitializeTimer()
        {
            // Call this procedure when the application starts.  
            // Set to 5 second.
            //86400000 = 24h
            timer.Interval = 5000;
            timer.Elapsed += timer1_Tick;
            // Enable timer.  
            timer.Enabled = true;


        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                //Connexion a la base de données gsb_frais
                myConnexion = (ConnexionSql)ConnexionSql.GetInstance("localhost", "gsb_frais", "root", "");
                myConnexion.openConnection();

                //recuperation de la date du jour 
                int jour = Int32.Parse(DateTime.Now.ToString("dd"));


                if (jour <= 10)
                {
                    //Requete qui permet de mettre à jour l'état d'une fiche frais en fonction de la date
                    myConn = myConnexion.reqExec("Update fichefrais set idEtat = 'CL' where mois = " + date.moisPrecedent() + " and idEtat = 'CR'");
                    myConn.ExecuteNonQuery();
                }

                if (jour >= 20)
                {
                    myConn = myConnexion.reqExec("Update fichefrais set idEtat = 'RB' where mois = " + date.moisPrecedent() + " and idEtat = 'VA'");
                    myConn.ExecuteNonQuery();
                }
                //fermeture de la connexion
                myConnexion.closeConnection();
            }
            catch (Exception emp)
            {
                throw (emp);
            }

        }
    }
}
