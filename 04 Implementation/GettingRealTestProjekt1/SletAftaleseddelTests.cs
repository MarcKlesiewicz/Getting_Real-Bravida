using Microsoft.VisualStudio.TestTools.UnitTesting;
using GettingReal;

namespace GettingRealTestProjekt1
{
    [TestClass]
    public class SletAftaleseddelTests
    {
        Controller controller;
        Aftaleseddel a1, a2, a3, a4;
        [TestInitialize]
        public void Init()
        {
            controller = new Controller();

            controller.OpretAftaleseddel();
            controller.TilføjAftaleSeddelInformation("AftaleseddelTest", "Anders og P", "Lige nu", 100000.ToString(), "Fra nu til nu");
            controller.GodkendAftaleseddel();
            a1 = controller.VisEntrepriseOversigt()[0];

            controller.OpretAftaleseddel();
            controller.TilføjAftaleSeddelInformation("AftaleseddelTest2", "Bare Anders", "Lige om Snart", 500.ToString(), "Fra om lidt til om snart");
            controller.GodkendAftaleseddel();
            a2 = controller.VisEntrepriseOversigt()[1];

            controller.OpretAftaleseddel();
            controller.TilføjAftaleSeddelInformation("AftaleseddelTest3", "Bare P", "Om lidt", 0.ToString(), "I morgen");
            controller.GodkendAftaleseddel();
            a3 = controller.VisEntrepriseOversigt()[2];

            controller.OpretAftaleseddel();
            controller.TilføjAftaleSeddelInformation("AftaleseddelTest4", "Rune", "I går", (-42).ToString(), "Fra i går til 2021");
            controller.GodkendAftaleseddel();
            a4 = controller.VisEntrepriseOversigt()[3];
        }

        [TestMethod]
        public void SletFørsteAftaleseddel()
        {
            controller.SletAftaleseddel(a1);

            Assert.AreEqual(controller.VisEntrepriseOversigt().Count, 3);
        }

        [TestMethod]
        public void SletAlleAftalesedler()
        {
            controller.SletAftaleseddel(a1);
            controller.SletAftaleseddel(a2);
            controller.SletAftaleseddel(a3);
            controller.SletAftaleseddel(a4);

            Assert.AreEqual(controller.VisEntrepriseOversigt().Count, 0);
        }

        [TestMethod]
        public void SletDenSammeFlere()
        {
            controller.SletAftaleseddel(a1);
            controller.SletAftaleseddel(a1);

            Assert.AreEqual(controller.VisEntrepriseOversigt().Count, 3);
        }

        [TestMethod]
        public void SletEnNullAftaleseddel()
        {
            controller.SletAftaleseddel(null);

            Assert.AreEqual(controller.VisEntrepriseOversigt().Count, 4);
        }
    }
}
