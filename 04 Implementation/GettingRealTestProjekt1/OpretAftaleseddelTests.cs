using Microsoft.VisualStudio.TestTools.UnitTesting;
using GettingReal;

namespace GettingRealTestProjekt1
{
    [TestClass]
    public class OpretAftaleseddelTests
    {
        Controller controller;

        [TestInitialize]
        public void Init()
        {
            controller = new Controller();
        }

        [TestMethod]
        public void OprettelseAfEnAftaleseddel()
        {
            controller.OpretAftaleseddel();

            controller.TilføjAftaleSeddelInformation("AftaleseddelTest", "Anders og P", "Lige nu", 100000.ToString(), "Fra nu til nu");

            controller.GodkendAftaleseddel();

            Assert.AreEqual(controller.VælgAftaleseddel("AftaleseddelTest").ToString(), "AftaleseddelTest Anders og P Lige nu 100000 Fra nu til nu");
        }

        [TestMethod]
        public void OprettelseAfMangeAftalesedler()
        {
            controller.OpretAftaleseddel();
            controller.TilføjAftaleSeddelInformation("AftaleseddelTest", "Anders og P", "Lige nu", 100000.ToString(), "Fra nu til nu");
            controller.GodkendAftaleseddel();

            controller.OpretAftaleseddel();
            controller.TilføjAftaleSeddelInformation("AftaleseddelTest2", "Bare Anders", "Lige om Snart", 500.ToString(), "Fra om lidt til om snart");
            controller.GodkendAftaleseddel();

            controller.OpretAftaleseddel();
            controller.TilføjAftaleSeddelInformation("AftaleseddelTest3", "Bare P", "Om lidt", 0.ToString(), "I morgen");
            controller.GodkendAftaleseddel();

            Assert.AreEqual(controller.VælgAftaleseddel("AftaleseddelTest2").ToString(), "AftaleseddelTest2 Bare Anders Lige om Snart 500 Fra om lidt til om snart");
        }

        [TestMethod]
        public void FortrydEnAftaleseddelOgSåLavEn()
        {
            controller.OpretAftaleseddel();
            controller.TilføjAftaleSeddelInformation("AftaleseddelTest", "Anders og P", "Lige nu", 100000.ToString(), "Fra nu til nu");

            controller.OpretAftaleseddel();
            controller.TilføjAftaleSeddelInformation("AftaleseddelTest2", "Bare Anders", "Lige om Snart", 500.ToString(), "Fra om lidt til om snart");
            controller.GodkendAftaleseddel();

            Assert.AreEqual(controller.VisEntrepriseOversigt()[0].ToString(), "AftaleseddelTest2 Bare Anders Lige om Snart 500 Fra om lidt til om snart");
        }
    }
}
