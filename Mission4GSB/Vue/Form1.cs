using Mission4GSB.Controleur;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace Mission4GSB
{
    public partial class Form1 : Form
    {
        private ConnexionSql myConnexion;
        private MySqlCommand com;
        private MySqlCommand com1;
        DataTable dt;
        GestionDate date = new GestionDate();
        Mgr mgr = new Mgr();
        

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                myConnexion = (ConnexionSql)ConnexionSql.GetInstance(Parametre.ProviderMysql, Parametre.DataBaseMysql, Parametre.UidMysql, Parametre.MdpMysql);
                myConnexion.openConnection();
                


                myConnexion.closeConnection();
            }
            catch (Exception emp)
            {
                throw (emp);
            }
        }

        /// <summary>
        /// Initialise le timer
        /// </summary>
        private void InitializeTimer()
        {
            timer1.Interval = 5000;
            timer1.Tick += new EventHandler(timer1_Tick);

            // Enable timer.  
            timer1.Enabled = true;

          
        }

        /// <summary>
        /// changement de l'etat des fiches frais en fonction de la date à chaque fois que l'intervalle du timer est passé
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                timer1.Start();

                myConnexion = (ConnexionSql)ConnexionSql.GetInstance(Parametre.ProviderMysql, Parametre.DataBaseMysql, Parametre.UidMysql, Parametre.MdpMysql);
                myConnexion.openConnection();
                
                int jour = Int32.Parse(DateTime.Now.ToString("dd"));
                

                if(jour <= 10)
                {
                    com = myConnexion.reqExec("Update testfichefrais set idEtat = 'CL' where mois = " + date.moisPrecedent() 
                        +" and idEtat = 'CR'");
                    com.ExecuteNonQuery();

                    //mgr.updateCL(date);
                    
                }

                if(jour >= 20)
                {
                    com = myConnexion.reqExec("Update testfichefrais set idEtat = 'RB' where mois = " + date.moisPrecedent() 
                        + " and idEtat = 'VA'");
                    com.ExecuteNonQuery();
                }

                myConnexion.closeConnection();
                timer1.Stop();
            }
            
            catch (Exception emp)
            {
                throw (emp);
            }
         }
    }
}
