using System;
using System.Collections.Generic;
using MyClassLibrary.Accessors;
using MyClassLibrary.DataClasses;
using NSubstitute.Core;
using NSubstitute.Core.Arguments;
using NSubstitute.Routing.Handlers;
using NUnit.Framework;
using NSubstitute;
using TypeMock.ArrangeActAssert;


namespace Test_MyClassLibrary.Test_Accessors
{
    [TestFixture]
    class Test_AccessorDB
    {
        private Well well = new Well() { Number = 10, Debit = 10, Pump = "REDA" };

        #region вспомогательные методы-------↓-----------------------

        //создать лист скважин
        public List<Well> CreateListWells()
        {
            Well well1 = new Well() { Number = 1, Debit = 100, Pump = "ШГН" };
            Well well2 = new Well() { Number = 2, Debit = 200, Pump = "ЭЦН-30-1500" };
            Well well3 = new Well() { Number = 3, Debit = 300, Pump = "REDA-500" };

            List<Well> listWell = new List<Well>();
            listWell.Add(well1);
            listWell.Add(well2);
            listWell.Add(well3);

            return listWell;
        }

        //создать месторождение алакаевка
        public Oilfield CreateOilfieldAlacaevka()
        {
            Oilfield alak = new Oilfield();
            alak.Name = "Алакаевка";
            alak.OilReserves = 1111;
            alak.Wells = CreateListWells();

            return alak;
        }

        //создание месторождения каменка
        public Oilfield CreateOilfieldKamenka()
        {
            Oilfield kamen = new Oilfield();
            kamen.Name = "Каменка";
            kamen.OilReserves = 2222;
            kamen.Wells = CreateListWells();

            return kamen;
        }

        //создание месторождения зольное
        public Oilfield CreatOilfieldZolnoe()
        {
            Oilfield zolnoe = new Oilfield();
            zolnoe.Name = "Зольное";
            zolnoe.OilReserves = 3333;
            zolnoe.Wells = CreateListWells();

            return zolnoe;
        }

        //создание accessorDb
        public AccessorDB CreateAccessorDb()
        {
            return new AccessorDB();
        }


        #endregion вспомогательные методы----↑----------------------

        [Test]
        public void Test_AccessorDB_AddOIlfield()
        {
            //arrange
            //созадть фейк
            var fake = Substitute.For<DALdb>();
            //создать аксессор
            var accessor = CreateAccessorDb();
            //разорвать связь
            accessor.Dal = fake;
            //создать месторождение
            var zol = CreatOilfieldZolnoe();

            //act
            //вызвать метод
            accessor.AddOilfield(zol);


            //assert
            //проверить что метод вызывался
            fake.Received().AddOilfield(zol);

        }

        [Test]
        public void Test_AccessorDB_RemoveOilfield()
        {
            //arrange
            var fake = Substitute.For<DALdb>();
            var accessor = CreateAccessorDb();
            accessor.Dal = fake;

            //act
            accessor.RemoveOilfield(0);

            //assert
            fake.Received().DeleteOilfield(0);


        }

        [Test]
        public void Test_AccessorDB_AddWell()
        {
            //arrange
            var fake = Substitute.For<DALdb>();
            var accesor = CreateAccessorDb();
            accesor.Dal = fake;

            //act
            accesor.AddWell(well,"....");

            //assert
            fake.Received().AddWell(well,"....");
        }

        [Test]
        public void Test_AccessorDB_RemoweWell()
        {
            //arrange
            var fake = Substitute.For<DALdb>();
            var accessor = CreateAccessorDb();
            accessor.Dal = fake;

            //act
            accessor.RemoveWell(5,"...");

            //assert
            fake.Received().RemoveWell(5,"...");
        }

        [Test]
        public void Test_AccessorDB_UpdateOilfield()
        {
            //arrange
            var accessor = CreateAccessorDb();
            var fake = Substitute.For<DALdb>();
            accessor.Dal = fake;
            var zol = CreatOilfieldZolnoe();

            //act
            accessor.UpdateOilfield(0,zol);

            //assert
            fake.Received().UpdateOilfield(0,zol);
        }

        [Test]
        public void Test_AccessorDB_GetAllOilfield()
        {
            //arrange
            var accessor = CreateAccessorDb();
            var fake = Substitute.For<DALdb>();
            accessor.Dal = fake;

            //act
            accessor.GetAllOilfield();

            //assert
            fake.Received().GetAllOilfield();
        }

        [Test]
        public void Test_AccessorDB_GetOilfieldByIndex()
        {
            //arrange
            var accessor = CreateAccessorDb();
            var fake = Substitute.For<DALdb>();
            accessor.Dal = fake;

            //act
            accessor.GetOilfieldByIndex(5);

            //assert
            fake.Received().GetOilfieldById(5);
        }

        [Test]
        public void Test_AccessorDB_CountOilfield()
        {
            //arrange
            var accessor = CreateAccessorDb();
            var fake = Substitute.For<DALdb>();
            fake.GetAllOilfield().Returns(x=>new List<Oilfield>());
            accessor.Dal = fake;

            //act
            accessor.CountOilfield();

            //assert
            fake.Received().GetAllOilfield();
        }

        [Test]
        public void Test_AccessorDB_CountWells()
        {
            //ARRANGE
            //создать фейк
            var fake = Substitute.For<DALdb>();
            //создать аксессор
            var accessor = CreateAccessorDb();
            //разорвать связь
            accessor.Dal = fake;
            //переопределить метод
            fake.GetAllWells().Returns(new List<Well>());

            //ACT
            //выполнить метод
            accessor.CountWells();

            //ASSERT
            //проверить что метод вызывался
            fake.Received().GetAllWells();



        }

        [Test]
        public void Test_AccessorDB_CountWellsInOilfield()
        {
            var zol = CreatOilfieldZolnoe();
            //arrange
            //создать аксессор
            var accessor = CreateAccessorDb();
            
            //переопределить метод
            Isolate.WhenCalled(()=>accessor.Dal.GetOilfieldById(0)).WillReturn(zol);

            //act
            accessor.CountWellsInOilfield(0);

            //assert
            Isolate.Verify.WasCalledWithAnyArguments(()=>accessor.Dal.GetOilfieldById(0));
        }

        [Test]
        public void Test_AccessorDB_Clear()
        {
           //arrange
            var accessor = CreateAccessorDb();

            var fake = Isolate.Fake.Instance<DALdb>();
            Isolate.Swap.AllInstances<DALdb>().With(fake);


            //act
            //выполнить метод
            accessor.Clear();

            //assert
            //проверить результат
            Isolate.Verify.WasCalledWithAnyArguments(() => fake.Clear());
        }

        [Test]
        public void Test_AccessorDB_GetNameByIndex()
        {
            var fake = Isolate.Fake.Instance<DALdb>();
            
            var accessor = CreateAccessorDb();
            Isolate.Swap.AllInstances<DALdb>().With(fake);

            accessor.GetNameByIndex(0);

            Isolate.Verify.WasCalledWithAnyArguments(()=>fake.GetNameByIndex(0));

        }


    }
}
