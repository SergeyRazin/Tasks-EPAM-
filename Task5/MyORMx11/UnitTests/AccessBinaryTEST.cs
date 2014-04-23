using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using MyORMx.AccessorsClasses;
using MyORMx;
using System.IO;

namespace UnitTests
{
    [TestFixture]
    class AccessBinaryTEST
    {
        Person Homer = new Person() { Name = "Homer", Age = 47 };
        Person Marge = new Person() { Name = "Marge", Age = 40 };
        Person Bart = new Person() { Name = "Bart", Age = 9 };
        Person Lisa = new Person() { Name = "Lisa", Age = 8 };


        [SetUp]
        public void DeleteBegin() 
        {
            if (File.Exists("SerializationBinary.dat"))
            {
                AccessorBinarry bi = new AccessorBinarry();
                bi.Clear();
            }
        }

        [TearDown]
        public void DeleteEnd() 
        {
            if (File.Exists("SerializationBinary.dat"))
            {
                AccessorBinarry bi = new AccessorBinarry();
                bi.Clear();
            }
        }

        [Test]
        public void AddPersonTEST() 
        {
            AccessorBinarry bi = new AccessorBinarry();
            bi.Clear();
            Assert.AreEqual(0, bi.Count());

            bi.AddPerson(Homer);
            
            Assert.AreEqual(1,bi.Count());
        }

        [Test]
        public void RemovePersonTEST()
        {
            AccessorBinarry bi = new AccessorBinarry();
            bi.AddPerson(Homer);
            bi.AddPerson(Marge);
            bi.RemovePerson("Homer");

            Assert.AreEqual(1, bi.Count());
        }

        [Test]
        public void InsertPersonTEST() 
        {
            AccessorBinarry bi = new AccessorBinarry();
            bi.AddPerson(Homer);
            bi.AddPerson(Homer);
            bi.AddPerson(Homer);
            bi.InsertPerson(0, Marge);

            Assert.AreEqual(4, bi.Count());
            Assert.AreEqual("Marge", bi.GetPersonByIndex(0).Name);
        }

        [Test]
        public void GetPersonByIndex() 
        {
            AccessorBinarry bi = new AccessorBinarry();
            bi.AddPerson(Homer);
            bi.AddPerson(Marge);
            bi.AddPerson(Lisa);
            bi.AddPerson(Bart);

            Assert.AreEqual("Marge", bi.GetPersonByIndex(1).Name);
        }

        [Test]
        public void GetAllPersonTEST() 
        {
            AccessorBinarry bi = new AccessorBinarry();
            bi.AddPerson(Homer);
            bi.AddPerson(Marge);
            bi.AddPerson(Lisa);
            bi.AddPerson(Bart);



            //Assert.AreEqual(4, bi.GetAllPerson().Count());
            List<Person> p = bi.GetAllPerson();

            Assert.AreEqual(4, bi.Count());
            Assert.AreEqual("Homer", bi.GetPersonByIndex(0).Name);
            Assert.AreEqual("Marge", bi.GetPersonByIndex(1).Name);
            Assert.AreEqual("Lisa", bi.GetPersonByIndex(2).Name);
            Assert.AreEqual("Bart", bi.GetPersonByIndex(3).Name);
           

            
        }

    }
}
