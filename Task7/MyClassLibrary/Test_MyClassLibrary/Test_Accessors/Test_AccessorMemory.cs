using System.Collections.Generic;
using MyClassLibrary.DataClasses;
using NUnit.Framework;
using MyClassLibrary.Accessors;

namespace Test_MyClassLibrary.Test_Accessors
{
    [TestFixture]
    class Test_AccessorMemory
    {

        Well _well = new Well() { Number = 100, Debit = 100, Pump = "ШГН" };

        //вспомогательные методы
        #region-----------------------------------------------------------------------------------

        public List<Well> CreateListWells()
        {
            Well well1 = new Well() {Number = 1, Debit = 100, Pump = "ШГН"};
            Well well2 = new Well() {Number = 2, Debit = 200, Pump = "ЭЦН-30-1500"};
            Well well3 = new Well() {Number = 3, Debit = 300, Pump = "REDA-500"};

            List<Well> listWell = new List<Well>();
            listWell.Add(well1);
            listWell.Add(well2);
            listWell.Add(well3);

            return listWell;
        }

        public Oilfield CreateOilfieldAlacaevka()
        {
            Oilfield oil = new Oilfield() {Index = 0, Name = "Алакаевка", OilReserves = 555, Wells = CreateListWells()};
            return oil;
        }

        public Oilfield CreateOilfieldKamenka()
        {
            Oilfield oil = new Oilfield() { Index = 0, Name = "Каменка", OilReserves = 666, Wells = CreateListWells() };
            return oil;
        }

        public AccessorMemory CreaterAccessorMemory()
        {
            return new AccessorMemory();
        }

        #endregion вспомогательные методы---------------------------------------------------------





        [Test]
        public void Test_AccessorMemory_Constructor()
        {
            AccessorMemory memory = new AccessorMemory();
        }

        [Test]
        public void Test_AccessorMemory_AddOilfield()
        {
            //arange
            var accessorMemory = CreaterAccessorMemory();
            var oilAlak = CreateOilfieldAlacaevka();

            //act
            accessorMemory.AddOilfield(oilAlak);

            //assert
            Assert.AreEqual(1, accessorMemory.CountOilfield());
            Assert.AreEqual("Алакаевка", accessorMemory.GetOilfieldByIndex(0).Name);
            Assert.AreEqual(3, accessorMemory.GetOilfieldByIndex(0).Wells.Count);
            Assert.AreEqual(3, accessorMemory.GetOilfieldByIndex(0).Wells[2].Number);
        }

        [Test]
        public void Test_AccessorMemory_RemoveOilfield()
        {
            //arange
            var accessorMemory = CreaterAccessorMemory();
            var oilAlak = CreateOilfieldAlacaevka();
            var oilCamenka = CreateOilfieldKamenka();

            //act
            accessorMemory.AddOilfield(oilAlak);
            accessorMemory.AddOilfield(oilCamenka);
            accessorMemory.RemoveOilfield(0);
            

            //assert
            Assert.AreEqual(1,accessorMemory.GetAllOilfield().Count);
            Assert.AreEqual("Каменка", accessorMemory.GetOilfieldByIndex(0).Name);
        }

        [Test]
        public void Test_AccessorMemory_AddWell()
        {
            //arange
            var accessorMemory = CreaterAccessorMemory();
            var oilAlak = CreateOilfieldAlacaevka();
            accessorMemory.AddOilfield(oilAlak);

            //act
            accessorMemory.AddWell(_well,"Алакаевка");

            //assert
            Assert.AreEqual(4,accessorMemory.GetOilfieldByIndex(0).Wells.Count);
            Assert.AreEqual(100, accessorMemory.GetOilfieldByIndex(0).Wells[3].Number);
        }
    }
}
