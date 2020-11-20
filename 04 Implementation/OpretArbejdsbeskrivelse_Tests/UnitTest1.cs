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
        public void Oprette�nArbejdsbeskrivelse()
        {
            mainController.OpretArbejdsbeskrivelse();
            mainController.Tilf�jArbejdsbeskrivelse("L�benr", "1");

            Assert.AreEqual(mainController.VisArbejdsbeskrivelser(1)[0].L�beNr, 1);
            Assert.AreEqual(mainController.VisArbejdsbeskrivelser(1)[0].ID, 0);
        }

        [TestMethod]
        public void OpretteFlereArbejdsbeskrivelser()
        {
            mainController.OpretArbejdsbeskrivelse();
            mainController.Tilf�jArbejdsbeskrivelse("L�benr", "1");
            mainController.OpretArbejdsbeskrivelse();
            mainController.Tilf�jArbejdsbeskrivelse("L�benr", "1");
            mainController.OpretArbejdsbeskrivelse();
            mainController.Tilf�jArbejdsbeskrivelse("L�benr", "1");

            for (int i = 0; i < 3; i++)
            {
                Assert.AreEqual(mainController.VisArbejdsbeskrivelser(1)[i].L�beNr, 1);
            }
            for (int i = 0; i < 3; i++)
            {
                Assert.AreEqual(mainController.VisArbejdsbeskrivelser(1)[i].ID, i);
            }
        }

        [TestMethod]
        public void OpretteArbejdsbeskrivelserMedForskelligeL�benumre()
        {
            mainController.OpretArbejdsbeskrivelse();
            mainController.Tilf�jArbejdsbeskrivelse("L�benr", "1");
            mainController.OpretArbejdsbeskrivelse();
            mainController.Tilf�jArbejdsbeskrivelse("L�benr", "2");
            mainController.OpretArbejdsbeskrivelse();
            mainController.Tilf�jArbejdsbeskrivelse("L�benr", "3");

            Assert.AreEqual(mainController.VisArbejdsbeskrivelser(1)[0].L�beNr, 1);
            Assert.AreEqual(mainController.VisArbejdsbeskrivelser(2)[0].L�beNr, 2);
            Assert.AreEqual(mainController.VisArbejdsbeskrivelser(3)[0].L�beNr, 3);
        }

        [TestMethod]
        public void OpretteArbejdsbeskrivelserMedKneppetL�benumre()
        {
            mainController.OpretArbejdsbeskrivelse();
            mainController.Tilf�jArbejdsbeskrivelse("L�benr", "1");
            mainController.OpretArbejdsbeskrivelse();
            mainController.Tilf�jArbejdsbeskrivelse("L�benr", "-42");
            mainController.OpretArbejdsbeskrivelse();
            mainController.Tilf�jArbejdsbeskrivelse("L�benr", "1068432");

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
                mainController.Tilf�jArbejdsbeskrivelse("L�benr", "1");
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
