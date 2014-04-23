using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyORMx.DataClasses;
using NUnit.Framework;
using MyORMx.AccessorsClasses;
using MyORMx;
using System.IO;

namespace UnitTests
{
    [TestFixture]
    class AccessorXMLTEST
    {
        public Person Homer = new Person() { Name = "Homer", Age = 47 };
        public Person Marge = new Person() { Name = "Marge", Age = 40 };
        public Person Bart = new Person() { Name = "Bart", Age = 9 };
        public Person Lisa = new Person() { Name = "Lisa", Age = 8 };

        [SetUp]
        public void DeleteBegin()
        {
            if (File.Exists("Serialization_XML.xml"))
            {
                AccessorXml bi = new AccessorXml();
                bi.Clear();
            }
        }

        [TearDown]
        public void DeleteEnd()
        {
            if (File.Exists("Serialization_XML.xml"))
            {
                AccessorXml bi = new AccessorXml();
                bi.Clear();
            }
        }

        [Test]
        public void AddPersonTEST() 
        {
            AccessorXml axml = new AccessorXml();
            axml.AddPerson(Homer);

            Assert.AreEqual(1, axml.Count());
        }

        [Test]
        public void RemovePersonTEST() 
        {
            AccessorXml axml = new AccessorXml();
            axml.AddPerson(Homer);
            axml.RemovePerson("Homer");
            Assert.AreEqual(0, axml.Count());
        }

        [Test]
        public void InsertPersonTEST() 
        {
            AccessorXml axml = new AccessorXml();
            axml.AddPerson(Homer);
            axml.AddPerson(Marge);
            axml.AddPerson(Bart);
            axml.AddPerson(Lisa);

            axml.InsertPerson(4, Homer);
            Assert.AreEqual(5, axml.Count());

        }

        [Test]
        public void GetAllPersonTEST() 
        {
            AccessorXml axml = new AccessorXml();
            axml.AddPerson(Homer);
            axml.AddPerson(Marge);
            axml.AddPerson(Bart);
            axml.AddPerson(Lisa);

            Assert.AreEqual(4, axml.Count());
            Assert.AreEqual("Homer", axml.GetPersonByIndex(0).Name);
            Assert.AreEqual("Marge", axml.GetPersonByIndex(1).Name);
            Assert.AreEqual("Bart", axml.GetPersonByIndex(2).Name);
            Assert.AreEqual("Lisa", axml.GetPersonByIndex(3).Name);

        }

        [Test]
        public void GetPersonByIndexTEST()
        {
            AccessorXml axml = new AccessorXml();

            axml.AddPerson(Homer);
            axml.AddPerson(Marge);

            Assert.AreEqual("Marge", axml.GetPersonByIndex(1).Name);
        }


        [Test]
        public void CountTEST() 
        {
            AccessorXml axml = new AccessorXml();
            axml.AddPerson(Homer);

            Assert.AreEqual(1, axml.Count());
        }

        [Test]
        public void ClearTEST() 
        {
            AccessorXml axml = new AccessorXml();
            axml.AddPerson(Homer);
            axml.Clear();
            Assert.AreEqual(0, axml.Count());
        }
    }
}
