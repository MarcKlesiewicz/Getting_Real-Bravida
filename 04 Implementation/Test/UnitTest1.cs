using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using GettingReal;

namespace Test
{
    [TestClass]
    public class UnitTest1
    {
        private Controller cs;
        private EntrepriseOversigt entre;
        private ArbejdsbeskrivelseRepo ab;

        [TestInitialize]
        public void Init()
        {
            cs = new Controller();
            ab = new ArbejdsbeskrivelseRepo();
            cs.OpretAftaleseddel();
            cs.GodkendAftaleseddel();
            cs.OpretAftaleseddel();

        }

        [TestMethod]
        public void DeaktiverAftaleseddel()
        {
            cs.GodkendAftaleseddel();

            cs.VælgAftaleseddel(cs.VisEntrepriseOversigt()[0].Overskrift);
            cs.AktiverAftaleseddel();

            Assert.AreEqual(false, cs.VisEntrepriseOversigt()[0].Aktiveret);
        }
        [TestMethod]
        public void AktiverAftaleseddel()
        {
            //Godkender den anden aftaleseddel fra vores initialize
            cs.GodkendAftaleseddel();
            //Tjekker den første aftaleseddel
            Assert.AreEqual(true, cs.VisEntrepriseOversigt()[0].Aktiveret);

            cs.VælgAftaleseddel(cs.VisEntrepriseOversigt()[0].Overskrift);
            
            cs.AktiverAftaleseddel();
            Assert.AreEqual(false, cs.VisEntrepriseOversigt()[0].Aktiveret);
            cs.AktiverAftaleseddel();
            cs.AktiverAftaleseddel();
            Assert.AreEqual(false, cs.VisEntrepriseOversigt()[0].Aktiveret);
           // Tjekker hvis der er 2 aftaleseddler  om den ændrer værdien i den anden.
            cs.VælgAftaleseddel(cs.VisEntrepriseOversigt()[1].Overskrift);

            Assert.AreEqual(true, cs.VisEntrepriseOversigt()[1].Aktiveret);
        }
        [TestMethod]
        public void DeaktiverArbejdsbeskrivelse()
        {
            cs.OpretArbejdsbeskrivelse();
            cs.TilføjArbejdsbeskrivelse("Løbenr", "0");

            cs.OpretArbejdsbeskrivelse();
            cs.TilføjArbejdsbeskrivelse("Løbenr", "0");
            cs.AktiverArbejdsbeskrivelse(cs.VisArbejdsbeskrivelser(0)[0].ID);

            Assert.AreEqual(false, cs.VisArbejdsbeskrivelser(0)[0].Aktiveret);

            cs.AktiverArbejdsbeskrivelse(cs.VisArbejdsbeskrivelser(0)[1].ID);

            Assert.AreEqual(false, cs.VisArbejdsbeskrivelser(0)[1].Aktiveret);

            // for et andet løbenr.
            cs.OpretArbejdsbeskrivelse();
            cs.TilføjArbejdsbeskrivelse("Løbenr", "1");

            cs.OpretArbejdsbeskrivelse();
            cs.TilføjArbejdsbeskrivelse("Løbenr", "1");


            cs.AktiverArbejdsbeskrivelse(cs.VisArbejdsbeskrivelser(1)[0].ID);

            Assert.AreEqual(false, cs.VisArbejdsbeskrivelser(1)[0].Aktiveret);

            cs.AktiverArbejdsbeskrivelse(cs.VisArbejdsbeskrivelser(1)[1].ID);

            Assert.AreEqual(false, cs.VisArbejdsbeskrivelser(1)[1].Aktiveret);
        }
    }
}
