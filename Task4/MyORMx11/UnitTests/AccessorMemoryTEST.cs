using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyORMx;
using NUnit.Framework;

namespace UnitTests
{
    public class AccessorMemoryTEST
    {
        [TestFixture]
        public class UnitTest1
        {
            public Person Homer = new Person() { Name = "Homer", Age = 47 };
            public Person Marge = new Person() { Name = "Marge", Age = 40 };
            public Person Bard = new Person() { Name = "Bard", Age = 9 };
            public Person Lisa = new Person() { Name = "Lisa", Age = 8 };



            [Test]
            public void StorageTEST()
            {
                Storage s = new Storage();
                Assert.AreEqual(0, s.L.Count);
            }

            [Test]
            public void CountTEST()
            {
                AccessorMemory amem = new AccessorMemory();
                Assert.AreEqual(0, amem.Count());
            }


            [Test]
            public void AddPersonTEST()
            {
                AccessorMemory amem = new AccessorMemory();
                amem.AddPerson(Homer);
                Assert.AreEqual(1, amem.Count());

            }

            [Test]
            public void RemovePersonTEST()
            {
                AccessorMemory amem = new AccessorMemory();
                amem.AddPerson(Homer);
                amem.RemovePerson("Homer");
                Assert.AreEqual(0, amem.Count());
            }

            [Test]
            public void InsertPerson()
            {
                AccessorMemory amem = new AccessorMemory();
                amem.AddPerson(Homer);
                amem.AddPerson(Marge);
                amem.AddPerson(Lisa);
                amem.AddPerson(Bard);

                amem.InsertPerson(4, Homer);

                Assert.AreEqual("Homer", amem.GetPersonByIndex(4).Name);
                Assert.AreEqual(5, amem.Count());

            }

            [Test]
            public void GetAllPersonTEST()
            {
                List<Person> testList = new List<Person>();
                testList.Add(Homer);
                testList.Add(Marge);
                testList.Add(Lisa);
                testList.Add(Bard);

                AccessorMemory amem = new AccessorMemory();
                amem.AddPerson(Homer);
                amem.AddPerson(Marge);
                amem.AddPerson(Lisa);
                amem.AddPerson(Bard);

                Assert.That(testList, Is.EquivalentTo(amem.GetAllPerson()));
            }

            [Test]
            public void ClearTEST() 
            {
                AccessorMemory amem = new AccessorMemory();
                amem.AddPerson(Homer);
                amem.AddPerson(Marge);
                amem.AddPerson(Lisa);
                amem.AddPerson(Bard);

                amem.Clear();
                Assert.IsEmpty(amem.GetAllPerson());
            }
        }
    }
}
