using DR_Rest.Managers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModelLib;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DR_Rest_Test
{
    [TestClass]
    public class UnitTest1
    {
        IManager mgr;

        [TestInitialize]
        public void TestInit()
        {
            mgr = new Manager();
        }

        [TestMethod]
        public void GetTest()
        {
            // Test specific
            Model model = new Model(1, "Eminem", "When im gone", 120, 2006);
            Assert.AreEqual(model.Artist, mgr.Get(1).Artist);

            // Test length
            List<Model> models = mgr.Get().ToList();
            Assert.AreEqual(2, models.Count);

            Assert.ThrowsException<KeyNotFoundException>(() => mgr.Get(100));
        }

        [DataRow(3, "John", "Hej", 134, 2019)]
        [DataRow(4, "Iben", "Nej", 132, 2012)]
        [DataTestMethod]
        public void PostTest(int id, string artist, string title, int duration, int year)
        {
            Model model = new Model(id, artist, title, duration, year);
            mgr.Create(model);

            Assert.IsNotNull(mgr.Get(id));
            Assert.AreEqual(artist, mgr.Get(id).Artist);
        }
    }
}
