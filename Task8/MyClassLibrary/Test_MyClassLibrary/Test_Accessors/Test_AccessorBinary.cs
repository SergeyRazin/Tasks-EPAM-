using System.Collections.Generic;
using MyClassLibrary.Accessors;
using MyClassLibrary.DataClasses;
using MyClassLibrary.Interfaces;
using NUnit.Framework;


namespace Test_MyClassLibrary.Test_Accessors
{
    //ПОДДЕЛКА для DAL
    public class FakeDalBinary : IDAL
    {
        //переменная для хранения конечного результата работы объекта accessorBinary
        public List<Oilfield> oilList; 

        //подделываем метод сериализовать
        public void SerializtionWithExchengeFile(string path, List<Oilfield> oilfields0)
        {
            //сохраняет конечный результат(как бы)
            oilList = oilfields0;
        }

        //подделываем метод десериализовать
        public List<Oilfield> Desirializ(string path)
        {
            //создать месторождение алакаевка и каменка
            var alacaevka = new Test_AccessorBinary().CreateOilfieldAlacaevka();
            var camenka = new Test_AccessorBinary().CreateOilfieldKamenka();
            //создать лист месторождений
            var tempOilLIst = new List<Oilfield>();
            //добавить в лист месторождений алакаевку и каменку
            tempOilLIst.Add(alacaevka);
            tempOilLIst.Add(camenka);
            //вернуть лист месторождений
            return tempOilLIst;
        }
    }


    //ТЕСТ
    [TestFixture]
    class Test_AccessorBinary
    {

        //вспомогательные методы
        #region-----------------------------------------------------------------------------------

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

        public Oilfield CreateOilfieldAlacaevka()
        {
            Oilfield oil = new Oilfield() { Index = 0, Name = "Алакаевка", OilReserves = 555, Wells = CreateListWells() };
            return oil;
        }

        public Oilfield CreateOilfieldKamenka()
        {
            Oilfield oil = new Oilfield() { Index = 0, Name = "Каменка", OilReserves = 666, Wells = CreateListWells() };
            return oil;
        }

        public Oilfield CreateOilfieldZolnoe()
        {
            Oilfield oil = new Oilfield() { Index = 0, Name = "Зольное", OilReserves = 777, Wells = CreateListWells() };
            return oil;
        }

        public AccessorBinary CreaterAccessorBinary()
        {
            return new AccessorBinary();
        }

        #endregion вспомогательные методы---------------------------------------------------------

        [Test]
        public void Test_AccesosrBinary_AddWell_if_Oilfield_With_this_Name_Alredy_Exists()
        {
            //arrange
            var alak = CreateOilfieldAlacaevka();
            var accessor = new AccessorBinary();
            accessor.Dal = new FakeDalBinary();


            //act

            //assert
            var ex = Assert.Catch(() => accessor.AddOilfield(alak));
            StringAssert.Contains("такое месторождение уже есть в списке", ex.Message);
        }

        [Test]
        public void Test_AccessorBinary_AddWell_Normal()
        {
            //arrange
            var zolnoe = CreateOilfieldZolnoe();
            var accessor = new AccessorBinary();
            accessor.Dal = new FakeDalBinary();
            FakeDalBinary stubDal = (FakeDalBinary) accessor.Dal;

            //act
            accessor.AddOilfield(zolnoe);

            //assert
            Assert.AreEqual(3, stubDal.oilList.Count);
        }

        [Test]
        public void Test_AccessorBinary_RemoveOilfild_if_index_not_found()
        {
            //arrange
            var accessor = new AccessorBinary();
            accessor.Dal = new FakeDalBinary();

            //act
            //assert
            Assert.Catch(() => accessor.RemoveOilfield(100));
        }

        [Test]
        public void Test_AccessorBinary_RemoveOilfield_Normal()
        {
            //arrange
            //создаем аксессор 
            var accessor = new AccessorBinary();
            //настраиваем его на заглушку 
            accessor.Dal = new FakeDalBinary();
            FakeDalBinary stubDal = (FakeDalBinary) accessor.Dal;

            //act
            accessor.RemoveOilfield(0);

            //assert
            Assert.AreEqual(1,stubDal.oilList.Count);
        }

        [Test]
        public void Test_AccessorBinary_UpdateOilfield_if_Oilfield_With_this_Name_Alredy_Exists()
        {
            //arrange
            var alak = CreateOilfieldAlacaevka();
            var accessor = new AccessorBinary();
            accessor.Dal = new FakeDalBinary();


            //act

            //assert
            var ex = Assert.Catch(() => accessor.UpdateOilfield(0, alak));
            StringAssert.Contains("такое месторождение уже есть в списке", ex.Message);
        }

        [Test]
        public void Test_AccessorBinary_UpdateOIlfield_Normal()
        {
            //arrange
            var zolnoe = CreateOilfieldZolnoe();
            var accessor = new AccessorBinary();
            accessor.Dal = new FakeDalBinary();
            FakeDalBinary stubDal = (FakeDalBinary) accessor.Dal;

            //act
            accessor.UpdateOilfield(0, zolnoe);

            //assert
            Assert.AreEqual("Зольное", stubDal.oilList[0].Name);
            Assert.AreEqual("Каменка", stubDal.oilList[1].Name);
            Assert.AreEqual(2,stubDal.oilList.Count);
        }

        [Test]
        public void Test_GetAllOilfield()
        {
            //arrange
            var accessor = new AccessorBinary();
            accessor.Dal = new FakeDalBinary();

            //act
            var rez = accessor.GetAllOilfield();

            //assert
            Assert.AreEqual(2, rez.Count);
            Assert.AreEqual("Алакаевка", rez[0].Name);
            Assert.AreEqual("Каменка", rez[1].Name);
            

        }

        [Test]
        public void Test_GetOilfieldByIndex_if_this_index_not_found()
        {
            //arrange
            var accessor = new AccessorBinary();
            accessor.Dal = new FakeDalBinary();

            //act
            //assert
            var ex = Assert.Catch(() => accessor.GetOilfieldByIndex(100));
            StringAssert.Contains("месторождения с таким индексом нет", ex.Message);
        }

        [Test]
        public void Test_GetOilfieldByIndex_Normal()
        {
            //arrange
            var accessor = new AccessorBinary();
            accessor.Dal = new FakeDalBinary();

            //act
            var rez = accessor.GetOilfieldByIndex(0);

            //accert
            Assert.AreEqual("Алакаевка", rez.Name);
        }

        [Test]
        public void Test_CountOilfield()
        {
            //arrange
            var accessor = new AccessorBinary();
            accessor.Dal = new FakeDalBinary();
            
            //act
            var rez = accessor.CountOilfield();

            //assert
            Assert.AreEqual(2,rez);
        }

        [Test]
        public void Test_CountWells()
        {
            //arrange
            var accessor = new AccessorBinary();
            accessor.Dal = new FakeDalBinary();

            //act
            var rez = accessor.CountWells();

            //assert
            Assert.AreEqual(6,rez);
        }

        [Test]
        public void Test_CountWellsInOilfield_if_index_not_found()
        {
            //arrange
            var accessor = new AccessorBinary();
            accessor.Dal = new FakeDalBinary();

            //act
            //assert
            Assert.Catch(() => accessor.CountWellsInOilfield(100));
        }

        [Test]
        public void Test_CountWellsInOilfield_Normal()
        {
            //arrange
            var kamenka = CreateOilfieldKamenka();
            var accessor = new AccessorBinary();
            accessor.Dal = new FakeDalBinary();
            FakeDalBinary stubDal = (FakeDalBinary)accessor.Dal;

            //act
            var rez = accessor.CountWellsInOilfield(0);

            //assert
            Assert.AreEqual(3,rez);
        }

        [Test]
        public void Test_GetNameByIndex_if_index_not_found()
        {
            //arrange
            var kamenka = CreateOilfieldKamenka();
            var accessor = new AccessorBinary();
            accessor.Dal = new FakeDalBinary();
            FakeDalBinary stubDal = (FakeDalBinary)accessor.Dal;

            //act
            //assert
            var ex = Assert.Catch(() => accessor.GetNameByIndex(100));
            StringAssert.Contains("Месторождения с таким индексом нет", ex.Message);
        }

        [Test]
        public void Test_GetNameByIndex_Normal()
        {
            //arrange
            var kamenka = CreateOilfieldKamenka();
            var accessor = new AccessorBinary();
            accessor.Dal = new FakeDalBinary();
            FakeDalBinary stubDal = (FakeDalBinary)accessor.Dal;

            //act
            var rez = accessor.GetNameByIndex(0);

            //assert
            Assert.AreEqual("Алакаевка",rez);
        }

    }
}
