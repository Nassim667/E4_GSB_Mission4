using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mission4GSB.Controleur
{
    class Mgr
    {
        MajFicheFrais maj = new MajFicheFrais();
        /// <summary>
        /// Mise a jour des fiches frais de l'etat CR à CL
        /// </summary>
        /// <param name="d"></param>
        public void updateCL(GestionDate d)
        {
            maj.cloturer(d);
        }
        /// <summary>
        /// Mise a jour des fiches frais de l'etat VA à RB
        /// </summary>
        /// <param name="d"></param>
        public void updateRB(GestionDate d)
        {
            maj.rembourser(d);
        }
    }
}
