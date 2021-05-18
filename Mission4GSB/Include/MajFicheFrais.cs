
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mission4GSB
{
    class MajFicheFrais
    {
        private ConnexionSql maConnexionSql;

        private MySqlCommand com;

        public void cloturer(GestionDate date)
        {
            try
            {
                maConnexionSql = ConnexionSql.GetInstance(Parametre.ProviderMysql, Parametre.DataBaseMysql, Parametre.UidMysql, Parametre.MdpMysql);

                maConnexionSql.openConnection();

                com = maConnexionSql.reqExec("Update testfichefrais set idEtat = 'CL' where mois = " + date.moisPrecedent()
                            + " and idEtat = 'CR'");
                com.ExecuteNonQuery();
            }
            catch (Exception emp)
            {

                throw (emp);
            }


        }

        public void rembourser(GestionDate date)
        {
            try
            {
                maConnexionSql = ConnexionSql.GetInstance(Parametre.ProviderMysql, Parametre.DataBaseMysql, Parametre.UidMysql, Parametre.MdpMysql);

                maConnexionSql.openConnection();

                com = maConnexionSql.reqExec("Update testfichefrais set idEtat = 'RB' where mois = " + date.moisPrecedent()
                            + " and idEtat = 'VA'");

                com.ExecuteNonQuery();

            }
            catch (Exception emp)
            {

                throw (emp);
            }

        }

    }
}
