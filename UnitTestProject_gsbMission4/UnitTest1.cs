using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Mission4GSB;

namespace UnitTestProject_gsbMission4
{
    [TestClass]
    public class UnitTest1
    {
        GestionDate d = new GestionDate();


        [TestMethod]
        
        public void TestDateJour()
        {

            Assert.AreEqual("202104", d.dateJour(), "Ce n'est pas la date du jour");
            Assert.AreNotEqual("202109", d.dateJour(), "Ce n'est pas la date du jour");


        }

        [TestMethod]
        public void TestMoisPrecedent()
        {
            Assert.AreEqual("202103", d.moisPrecedent(), "Ce n'est pas le mois précedant la date du jour");
            Assert.AreNotEqual("202203", d.moisPrecedent(), "Ce n'est pas le mois précedant la date du jour");
        }

        [TestMethod]
        public void TestMoisSuivant()
        {
            Assert.AreEqual("202106", d.moisSuivant(), "Ce n'est pas le mois précedant la date du jour");
            Assert.AreNotEqual("202106", d.moisSuivant(), "Ce n'est pas le mois précedant la date du jour");
        }
    }
    
}
