using System.Collections.Generic;
using MyClassLibrary.Accessors;
using MyClassLibrary.Interfaces;
using NUnit.Framework;
using MyClassLibrary.DataClasses;

namespace Test_MyClassLibrary.Test_Accessors
{
    //ПОДДЕЛКА для XPath
    public class FakeXPath:MyXPath
    {
        //получить месторождение со скважинами
        public override Oilfield getOil(string oilName0)
        {
            return new Test_Accessor_XML().CreateOilfieldAlacaevka();
        }

        //получить все месторождения со скважинами
        public override List<Oilfield> getAllOil()
        {
            //создать лист месторождений со скважинами 
            List<Oilfield> oilList = new List<Oilfield>();
            //создать месторождения алакаевку и каменку
            var alak = new Test_Accessor_XML().CreateOilfieldAlacaevka();
            var kamen = new Test_Accessor_XML().CreateOilfieldKamenka();
            //добавить в этот лист алакаевку и каменку
            oilList.Add(alak);
            oilList.Add(kamen);

            //вернуть этот лист
            return oilList;
        }
    }

    //ПОДДЕЛКА для DAL
    public class FakeDalxml:IDAL
    {
        public List<Oilfield> OilLIst;


        public void SerializtionWithExchengeFile(string path, List<Oilfield> oilfields0)
        {
            //создать лист с месторождениями(в него будем сохранять результат работы кода)
             OilLIst = new List<Oilfield>();

            //сохранить результат работы кода
            OilLIst = oilfields0;
        }

        public List<Oilfield> Desirializ(string path)
        {
            //создать лист месторождений со скважинами 
            List<Oilfield> oilList = new List<Oilfield>();
            //добавить в этот лист алакаевку и каменку
            oilList.Add(new Test_Accessor_XML().CreateOilfieldAlacaevka());
            oilList.Add(new Test_Accessor_XML().CreateOilfieldKamenka());
            
            //вернуть этот лист
            return oilList;
        }
    }


    
    [TestFixture]
    class Test_Accessor_XML
    {
        private Well well = new Well() {Number = 10,Debit = 10,Pump = "REDA"};

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


        #endregion вспомогательные методы----↑----------------------

        [Test]
        public void Test_AccessorXML_AddOilfield_if_oilfield_with_this_name_olredy_exists()
        {
            //arrange
            var accessor = new AccessorXML();
            accessor.Dal = new FakeDalBinary();
            accessor.xpath = new FakeXPath();
            var alak = CreateOilfieldAlacaevka();

            //act
            //assert
            Assert.Catch(() => accessor.AddOilfield(alak));
        }

        [Test]
        public void Test_AccessorXML_AddOilfield_Normal()
        {
            //arrange
            var accessor = new AccessorXML();
            accessor.Dal = new FakeDalxml();
            accessor.xpath = new FakeXPath();
            var zol = CreatOilfieldZolnoe();
            FakeDalxml fakeDal = (FakeDalxml) accessor.Dal;

            //act
            accessor.AddOilfield(zol);

            //assert
            Assert.AreEqual(3,fakeDal.OilLIst.Count);
        }

        [Test]
        public void Test_AccessorXML_RemoveOilfield_if_index_not_found()
        {
            //arrange
            var accessor = new AccessorXML();
            accessor.Dal = new FakeDalxml();
            accessor.xpath = new FakeXPath();
 
            //act
            //assert
            Assert.Catch(() => accessor.RemoveOilfield(100));

        }

        [Test]
        public void Test_AccessorXML_RemoveOilfield_Normal()
        {
            //arrange
            var accessor = new AccessorXML();
            accessor.Dal = new FakeDalxml();
            accessor.xpath = new FakeXPath();

            FakeDalxml fakeDal = (FakeDalxml) accessor.Dal;

            //act
            accessor.RemoveOilfield(0);

            //assert
            Assert.AreEqual(1, fakeDal.OilLIst.Count);

        }

        [Test]
        public void Test_AccessorXML_AddWell_if_Oilfield_not_found()
        {
            //arrange
            var accessor = new AccessorXML();
            accessor.Dal = new FakeDalxml();
            accessor.xpath = new FakeXPath();

            //act
            //assert
            var ex = Assert.Catch(() => accessor.AddWell(well, "юююю"));
            StringAssert.Contains("Месторождения с таким именем нет", ex.Message);
        }

        [Test]
        public void Test_AccessorXML_AddWell_Normal()
        {
            //arrange
            var accessor = new AccessorXML();
            accessor.Dal = new FakeDalxml();
            accessor.xpath = new FakeXPath();
            FakeDalxml fakeDalxml = (FakeDalxml) accessor.Dal;

            //act
            accessor.AddWell(well, "Алакаевка");

            //assert
            Assert.AreEqual(4,fakeDalxml.OilLIst[0].Wells.Count);

        }

        [Test]
        public void Test_RemoveWell_if_Oilfield_not_found()
        {
            //arrange
            var accessor = new AccessorXML();
            accessor.Dal = new FakeDalxml();
            accessor.xpath = new FakeXPath();
            FakeDalxml fakeDalxml = (FakeDalxml)accessor.Dal;

            //act
            //assert
            var ex = Assert.Catch(() => accessor.RemoveWell(1, "....."));
            StringAssert.Contains("Месторождения с таким именем нет.", ex.Message);
        }

        [Test]
        public void Test_RemoveWell_if_number_well_not_found()
        {
            //arrange
            var accessor = new AccessorXML();
            accessor.Dal = new FakeDalxml();
            accessor.xpath = new FakeXPath();
            FakeDalxml fakeDalxml = (FakeDalxml)accessor.Dal;

            //act
            //assert
            var ex = Assert.Catch(() => accessor.RemoveWell(1000, "Алакаевка"));
            StringAssert.Contains("Скважины с таким номером нет.", ex.Message);
        }

        [Test]
        public void Test_RemoveWell_if_Oilfield_Normal()
        {
            //arrange
            var accessor = new AccessorXML();
            accessor.Dal = new FakeDalxml();
            accessor.xpath = new FakeXPath();
            FakeDalxml fakeDalxml = (FakeDalxml)accessor.Dal;

            //act
            accessor.RemoveWell(1,"Алакаевка");

            //assert
            Assert.AreEqual(2,fakeDalxml.OilLIst[0].Wells.Count);

        }

        [Test]
        public void Test_Update_Oilfield_if_newName_alredy_exists()
        {
            //arrange
            var accessor = new AccessorXML();
            accessor.Dal = new FakeDalxml();
            accessor.xpath = new FakeXPath();

            var zol = CreatOilfieldZolnoe();
            zol.Name = "Каменка";

            //act

            //assert
            Assert.Catch(()=>accessor.UpdateOilfield(0,zol));
        }

        [Test]
        public void Test_Update_Oilfield_if_indexOilfield_not_found()
        {
            //arrange
            var accessor = new AccessorXML();
            accessor.Dal = new FakeDalxml();
            accessor.xpath = new FakeXPath();
            var zol = CreatOilfieldZolnoe();

            //act,assert
            var ex = Assert.Catch(() => accessor.UpdateOilfield(100, zol));
            StringAssert.Contains("месторождения с таким индексом нет", ex.Message);
        }

        [Test]
        public void Test_Update_Oilfield_Normal()
        {
            //arrange
            var accessor = new AccessorXML();
            accessor.Dal = new FakeDalxml();
            accessor.xpath = new FakeXPath();
            var zol = CreatOilfieldZolnoe();
            FakeDalxml fakeDalxml = (FakeDalxml) accessor.Dal;

            //act
            accessor.UpdateOilfield(0,zol);

            //assert
            Assert.AreEqual(2, fakeDalxml.OilLIst.Count);
            Assert.AreEqual("Зольное", fakeDalxml.OilLIst[0].Name);
        }

        [Test]
        public void Test_GetAllOilfield()
        {
            //arrange
            var accessor = new AccessorXML();
            accessor.Dal = new FakeDalxml();
            accessor.xpath = new FakeXPath();


            //act
            var rez = accessor.GetAllOilfield();

            //accert
            Assert.AreEqual(2, rez.Count);
            Assert.AreEqual("Алакаевка", rez[0].Name);
            Assert.AreEqual(0, rez[0].Index);
            Assert.AreEqual("Каменка", rez[1].Name);
            Assert.AreEqual(1, rez[1].Index);
        }

        [Test]
        public void Test_GetOilfieldByIndex_if_index_notFound()
        {
            //arrange
            var accessor = new AccessorXML();
            accessor.Dal = new FakeDalxml();
            accessor.xpath = new FakeXPath();

            //act

            //assert
            var ex = Assert.Catch(() => accessor.GetOilfieldByIndex(100));
            StringAssert.Contains("месторождения с таким индексом нет", ex.Message);
        }

        [Test]
        public void Test_GetOilfieldByIndex_Normal()
        {
            //arrange
            var accessor = new AccessorXML();
            accessor.Dal = new FakeDalxml();
            accessor.xpath = new FakeXPath();

            //act
            var rez = accessor.GetOilfieldByIndex(0);

            //assert
            Assert.AreEqual("Алакаевка", rez.Name);
        }

        [Test]
        public void Test_CountOilfield()
        {
            //arrange
            var accessor = new AccessorXML();
            accessor.Dal = new FakeDalxml();
            accessor.xpath = new FakeXPath();

            //act
            var rez = accessor.CountOilfield();

            //assert
            Assert.AreEqual(2,rez);
        }

        [Test]
        public void Test_CountWells()
        {
            //arrange
            var accessor = new AccessorXML();
            accessor.Dal = new FakeDalxml();
            accessor.xpath = new FakeXPath();

            //act
            var rez = accessor.CountWells();

            //assert
            Assert.AreEqual(6, rez);
        }

        [Test]
        public void Test_CountWellsInOilfields_if_index_notFound()
        {
            //arrange
            var accessor = new AccessorXML();
            accessor.Dal = new FakeDalxml();
            accessor.xpath = new FakeXPath();

            //act,assert
            Assert.Catch(() => accessor.CountWellsInOilfield(100));
        }

        [Test]
        public void Test_CountWellsInOilfields()
        {
            //arrange
            var accessor = new AccessorXML();
            accessor.Dal = new FakeDalxml();
            accessor.xpath = new FakeXPath();

            //act
            var rez = accessor.CountWellsInOilfield(0);

            //assert
            Assert.AreEqual(3,rez);
        }

        [Test]
        public void Test_GetNameByIndex_if_index_notFound()
        {
            //arrange
            var accessor = new AccessorXML();
            accessor.Dal = new FakeDalxml();
            accessor.xpath = new FakeXPath();

            //act,assert
            Assert.Catch(() => accessor.GetNameByIndex(100));
        }

        [Test]
        public void Test_GetNameByIndex_Normal()
        {
            //arrange
            var accessor = new AccessorXML();
            accessor.Dal = new FakeDalxml();
            accessor.xpath = new FakeXPath();

            //act
            var rez = accessor.GetNameByIndex(1);

            //assert
            Assert.AreEqual("Каменка", rez);
        }

    }
}
