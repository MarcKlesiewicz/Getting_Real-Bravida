using Microsoft.VisualStudio.TestTools.UnitTesting;
using GettingReal;

namespace OpretArbejdsbeskrivelse_Tests
{
    [TestClass]
    public class UnitTest1
    {
        Controller mainController;

        [TestInitialize]
        public void Init()
        {
            mainController = new Controller();

        }

        [TestMethod]
        public void OpretteÉnArbejdsbeskrivelse()
        {
            mainController.OpretArbejdsbeskrivelse();
            mainController.TilføjArbejdsbeskrivelse("Løbenr", "1");

            Assert.AreEqual(mainController.VisArbejdsbeskrivelser(1)[0].LøbeNr, 1);
            Assert.AreEqual(mainController.VisArbejdsbeskrivelser(1)[0].ID, 0);
        }

        [TestMethod]
        public void OpretteFlereArbejdsbeskrivelser()
        {
            mainController.OpretArbejdsbeskrivelse();
            mainController.TilføjArbejdsbeskrivelse("Løbenr", "1");
            mainController.OpretArbejdsbeskrivelse();
            mainController.TilføjArbejdsbeskrivelse("Løbenr", "1");
            mainController.OpretArbejdsbeskrivelse();
            mainController.TilføjArbejdsbeskrivelse("Løbenr", "1");

            for (int i = 0; i < 3; i++)
            {
                Assert.AreEqual(mainController.VisArbejdsbeskrivelser(1)[i].LøbeNr, 1);
            }
            for (int i = 0; i < 3; i++)
            {
                Assert.AreEqual(mainController.VisArbejdsbeskrivelser(1)[i].ID, i);
            }
        }

        [TestMethod]
        public void OpretteArbejdsbeskrivelserMedForskelligeLøbenumre()
        {
            mainController.OpretArbejdsbeskrivelse();
            mainController.TilføjArbejdsbeskrivelse("Løbenr", "1");
            mainController.OpretArbejdsbeskrivelse();
            mainController.TilføjArbejdsbeskrivelse("Løbenr", "2");
            mainController.OpretArbejdsbeskrivelse();
            mainController.TilføjArbejdsbeskrivelse("Løbenr", "3");

            Assert.AreEqual(mainController.VisArbejdsbeskrivelser(1)[0].LøbeNr, 1);
            Assert.AreEqual(mainController.VisArbejdsbeskrivelser(2)[0].LøbeNr, 2);
            Assert.AreEqual(mainController.VisArbejdsbeskrivelser(3)[0].LøbeNr, 3);
        }

        [TestMethod]
        public void OpretteArbejdsbeskrivelserMedKneppetLøbenumre()
        {
            mainController.OpretArbejdsbeskrivelse();
            mainController.TilføjArbejdsbeskrivelse("Løbenr", "1");
            mainController.OpretArbejdsbeskrivelse();
            mainController.TilføjArbejdsbeskrivelse("Løbenr", "-42");
            mainController.OpretArbejdsbeskrivelse();
            mainController.TilføjArbejdsbeskrivelse("Løbenr", "1068432");

            Assert.AreEqual(mainController.VisArbejdsbeskrivelser(1)[0].ID, 0);
            Assert.AreEqual(mainController.VisArbejdsbeskrivelser(-42)[0].ID, 1);
            Assert.AreEqual(mainController.VisArbejdsbeskrivelser(1068432)[0].ID, 2);
        }

        [TestMethod]
        public void SletteNogleArbejdsbeskrivelser()
        {
            for (int i = 0; i < 100; i++)
            {
                mainController.OpretArbejdsbeskrivelse();
                mainController.TilføjArbejdsbeskrivelse("Løbenr", "1");
                if (i % 10 == 1)
                {
                    mainController.SletArbejdsbeskrivelse();
                }
            }

            for (int i = 0; i < 90; i++)
            {
                Assert.AreEqual(mainController.VisArbejdsbeskrivelser(1)[i].ID, i);
            }
        }


    }
}
