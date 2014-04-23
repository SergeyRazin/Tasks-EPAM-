using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using MyORMx;

namespace UnitTests
{
    [TestFixture]
    class ClientTEST
    {
        Person Homer = new Person() { Name = "Homer", Age = 47 };
        Person Marge = new Person() { Name = "Marge", Age = 40 };
        Person Bard = new Person() { Name = "Bard", Age = 9 };
        Person Lisa = new Person() { Name = "Lisa", Age = 8 };



        [Test]
        public void ClientConstructorTEST() 
        {
            List<Person> testList = new List<Person>();
            Client c = new Client();
        }

        [Test]
        public void GetAllPersonTEST() 
        {
            List<Person> listTest = new List<Person>();
            listTest.Add(Homer);

            Client c = new Client();
            IAccessor a = new AccessorMemory();
            c.AddPerson(Homer, a);

            Assert.That(listTest, Is.EquivalentTo(a.GetAllPerson()));
        }

        [Test]
        public void RemovePersonTEST()
        {
            List<Person> testList = new List<Person>();
            

            Client c = new Client();
            IAccessor a = new AccessorMemory();

            c.AddPerson(Homer,a);
            c.RemovePerson("Homer", a);
            Assert.That(testList, Is.EquivalentTo(c.GetAllPerson(a) ));
        }

        [Test]
        public void InsertPerson() 
        {
            List<Person> testList = new List<Person>();
            testList.Add(Homer);
            testList.Add(Marge);
            testList.Add(Lisa);

            Client c = new Client();
            AccessorMemory a = new AccessorMemory();

            c.AddPerson(Homer,a);
            c.AddPerson(Marge,a);

            c.InsertPerson(2, Lisa, a);

            Assert.That(testList, Is.EquivalentTo(c.GetAllPerson(a) ));
        }

        [Test]
        public void ClearTEST() 
        {
            Client c = new Client();
            IAccessor a = new AccessorMemory();
            c.AddPerson(Homer,a);
            c.AddPerson(Lisa,a);
            c.AddPerson(Marge,a);

            c.Clear(a);
            Assert.IsEmpty(c.GetAllPerson(a));
        }

        [Test]
        public void GetPersonByIndexTEST() 
        {
            Client c = new Client();
            AccessorMemory a = new AccessorMemory();
            c.AddPerson(Homer,a);
            c.AddPerson(Marge,a);
            c.AddPerson(Lisa,a);

            c.GetPersonByIndex(2,a);

            Assert.AreEqual("Lisa", c.GetPersonByIndex(2, a).Name);
        }

        [Test]
        public void CountTEST() 
        {
            Client c = new Client();
            AccessorMemory a = new AccessorMemory();

            c.AddPerson(Homer, a);
            c.AddPerson(Lisa, a);
            c.AddPerson(Marge, a);

            Assert.AreEqual(3, c.Count(a));


        }
    }
}
