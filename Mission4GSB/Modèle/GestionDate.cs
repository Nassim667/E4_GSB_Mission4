using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mission4GSB
{ 
    /// <summary>
    /// Classe qui gènere les dates dont on a besoin 
    /// tel que la date du jour, le mois précédent, le mois suivant
    /// </summary>
   public class GestionDate
    {
         DateTime aujourdhui = DateTime.Now;

        /// <summary>
        /// Récupération de la date du jour
        /// </summary>
        /// <returns> date du jour dans le format yyyyMM </returns>
        public String dateJour()
        {
            String ajd = aujourdhui.ToString("yyyyMM");
          
            return ajd;
        }

       /// <summary>
       /// Récuperation du mois qui précede le mois courant
       /// </summary>
       /// <returns>mois precedent dans le format yyyyMM </returns>
        public String moisPrecedent()
        {
            String moisPrecedent = aujourdhui.AddMonths(-1).ToString("yyyyMM");

            return moisPrecedent;
        }

        /// <summary>
        /// Récuperation du mois qui suit le mois courant
        /// </summary>
        /// <returns> mois suivant dans le format yyyyMM </returns>
        public String moisSuivant()
        {
            String moisSuivant = aujourdhui.AddMonths(1).ToString("yyyyMM");

            return moisSuivant;
        }
       
    }

   
}
