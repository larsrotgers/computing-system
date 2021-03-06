using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CS.Architecture;
using System.Threading.Tasks;
using System.IO;

namespace CS.Architecture.Tests
{
    [TestClass]
    public class Architecture
    {
        [TestMethod]
        public void Computer_1()
        {
            Computer computer = new Computer();
            computer.Power = false;
            while (computer.Power) ;
            Assert.IsTrue(true);
            File.WriteAllText(@"C:\Test\Computer.json", computer.ToJson());
        }

        [TestMethod]
        public void Computer_2()
        {
            Computer computer = new Computer();
            computer.Power = false;
            while (computer.Power) ;
            Assert.IsTrue(true);
            File.WriteAllText(@"C:\Test\Computer.Memory.txt", computer.MemoryToString());
        }

        [TestMethod]
        public void ROM32K()
        {
            var rom = new ROM32K();
            Assert.IsTrue(rom != null);
            var data = new bool[16];
            data[15] = true;
            rom.Write(new bool[15], data);
            rom.SetAddress(new bool[15]);
            Assert.IsTrue(rom.Out[15]);
        }
    }
}
