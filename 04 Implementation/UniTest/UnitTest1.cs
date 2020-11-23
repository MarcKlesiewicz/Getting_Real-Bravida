using Microsoft.VisualStudio.TestTools.UnitTesting;
using GettingReal;

namespace UniTest
{
    [TestClass]
    public class UnitTest1
    {
        Controller cs;
        ArbejdsbeskrivelseRepo ab;

        [TestInitialize]
        public void Initialize()
        {
            cs = new Controller();
            ab = new ArbejdsbeskrivelseRepo();
            cs.OpretAftaleseddel();


        }

        [TestMethod]
        public void RedigerBeskrivelse()
        {
            cs.OpretArbejdsbeskrivelse();
            Assert.AreEqual(null, cs.ValgtArbejdsbeskrivelse.Tekst);

            cs.RedigerArbejdsbeskrivelse("Danny er sej");

            Assert.AreEqual("Danny er sej", cs.ValgtArbejdsbeskrivelse.Tekst);
        }

        [TestMethod]
        public void RedigerAntal()
        {
            cs.OpretArbejdsbeskrivelse();
            Assert.AreEqual(0.0, cs.ValgtArbejdsbeskrivelse.Antal);

            cs.RedigerArbejdsbeskrivelse(50);

            Assert.AreEqual(50, cs.ValgtArbejdsbeskrivelse.Antal);
        }

        [TestMethod]
        public void RedigerEnhedsPris()
        {
            cs.OpretArbejdsbeskrivelse();
            Assert.AreEqual(0.0, cs.ValgtArbejdsbeskrivelse.EnhedsPris);

            cs.RedigerArbejdsbeskrivelse(20.0);

            Assert.AreEqual(20.0, cs.ValgtArbejdsbeskrivelse.EnhedsPris);
        }

        [TestMethod]
        public void DeaktiverArbejdsbeskrivelse()
        {
            cs.OpretArbejdsbeskrivelse();

            Assert.AreEqual(true, cs.ValgtArbejdsbeskrivelse.Aktiveret);

            cs.DeaktiverArbejdsbeskrivelse();

            Assert.AreEqual(false, cs.ValgtArbejdsbeskrivelse.Aktiveret);

        }

        [TestClass]
        public class UnitTestListe
        {
            Controller cs;
            ArbejdsbeskrivelseRepo ab;

            [TestInitialize]
            public void Initialize()
            {
                cs = new Controller();
                ab = new ArbejdsbeskrivelseRepo();
                cs.OpretAftaleseddel();


            }

            [TestMethod]
            public void RedigerBeskrivelse()
            {
                cs.OpretArbejdsbeskrivelse();
                Assert.AreEqual(null, cs.ValgtArbejdsbeskrivelse.Tekst);

                cs.RedigerArbejdsbeskrivelse("Danny er sej");

                Assert.AreEqual("Danny er sej", cs.VisArbejdsbeskrivelser(0)[0].Tekst);
            }

            [TestMethod]
            public void RedigerAntal()
            {
                cs.OpretArbejdsbeskrivelse();
                Assert.AreEqual(0.0, cs.ValgtArbejdsbeskrivelse.Antal);

                cs.RedigerArbejdsbeskrivelse(50);

                Assert.AreEqual(50, cs.VisArbejdsbeskrivelser(0)[0].Antal);
            }

            [TestMethod]
            public void RedigerEnhedsPris()
            {
                cs.OpretArbejdsbeskrivelse();
                Assert.AreEqual(0.0, cs.ValgtArbejdsbeskrivelse.EnhedsPris);

                cs.RedigerArbejdsbeskrivelse(20.0);

                Assert.AreEqual(20.0, cs.VisArbejdsbeskrivelser(0)[0].EnhedsPris);
            }

            [TestMethod]
            public void DeaktiverArbejdsbeskrivelse()
            {
                cs.OpretArbejdsbeskrivelse();

                Assert.AreEqual(true, cs.ValgtArbejdsbeskrivelse.Aktiveret);

                cs.DeaktiverArbejdsbeskrivelse();

                Assert.AreEqual(false, cs.VisArbejdsbeskrivelser(0)[0].Aktiveret);

            }
        }
    }
}
