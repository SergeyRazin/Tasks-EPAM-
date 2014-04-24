using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyProject.Annotations;
using MyProject.DataClasses;
using NUnit.Framework;
using MyProject.AccessorsClasses;

namespace TEST
{
    [TestFixture]
    class MyORMTEST
    {
        MyORM myorm = new MyORM();

        public Person Homer = new Person() { Name = "Homer", Age = 47 };
        public Person Marge = new Person() { Name = "Marge", Age = 40 };
        public Person Bart = new Person() { Name = "Bart", Age = 9 };
        public Person Lisa = new Person() { Name = "Lisa", Age = 8 };


        [SetUp]
        public void DeleteBegin()
        {
            myorm.Clear(typeof(Person));
        }

        [TearDown]
        public void DeleteEnd()
        {
            myorm.Clear(typeof(Person));
        }


        [Test]
        public void AddPersonTEST()
        {
            myorm.AddPerson(Homer);
            myorm.AddPerson(Marge);

            Assert.AreEqual(2, myorm.Count(typeof(Person)));
        }

        [Test]
        public void RemovePersonTEST()
        {
            myorm.AddPerson(Homer);
            myorm.AddPerson(Marge);
            myorm.AddPerson(Bart);
            myorm.AddPerson(Lisa);

            myorm.RemovePerson("Homer",typeof(Person));

            Assert.AreEqual(3, myorm.Count(typeof(Person)));
        }

        [Test]
        public void GetAllPersonTEST()
        {
            myorm.AddPerson(Homer);
            myorm.AddPerson(Marge);
            myorm.AddPerson(Bart);
            myorm.AddPerson(Lisa);

            List<object> list = new List<object>();
            list = myorm.GetAllPerson(typeof(Person));

            Person p = (Person) list[0];
            Person p1 = (Person)list[1];
            Person p2 = (Person)list[2];
            Person p3 = (Person)list[3];

            Assert.AreEqual(4,list.Count);
            Assert.AreEqual("Homer",p.Name);
            Assert.AreEqual("Marge",p1.Name);
            Assert.AreEqual("Bart", p2.Name);
            Assert.AreEqual("Lisa", p3.Name);
        }
    }
}
