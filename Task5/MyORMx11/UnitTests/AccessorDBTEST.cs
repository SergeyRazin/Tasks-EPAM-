using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyORMx;
using MyORMx.AccessorsClasses;
using NUnit.Framework;

 

namespace UnitTests
{
    [TestFixture]
    class AccessorDBTEST
    {
        AccessorDB adb = new AccessorDB();

         Person Homer = new Person() { Name = "Homer", Age = 47 };
         Person Marge = new Person() { Name = "Marge", Age = 40 };
         Person Bart = new Person() { Name = "Bart", Age = 9 };
         Person Lisa = new Person() { Name = "Lisa", Age = 8 };

         [SetUp]
         public void DeleteBegin()
         {
             adb.Clear();
         }

         [TearDown]
         public void DeleteEnd()
         {
             adb.Clear();
         }


         [Test]
         public void AddPersonTEST()
         {
             adb.AddPerson(Homer);
             adb.AddPerson(Homer);
             
             Assert.AreEqual(2, adb.Count());
         }

         [Test]
         public void RemovePersonTEST() 
         {
             adb.AddPerson(Homer);
             adb.AddPerson(Marge);
             adb.AddPerson(Bart);

             adb.RemovePerson("Homer");

             Assert.AreEqual(2, adb.Count());
         }

         [Test]
         public void InsertPersonTEST() 
         {
             adb.AddPerson(Homer);
             adb.AddPerson(Homer);

             adb.InsertPerson(1, Marge);

             Assert.AreEqual(3, adb.Count());
         }

         [Test]
         public void GetAllPersonTEST() 
         {
             adb.AddPerson(Homer);
             adb.AddPerson(Marge);
             adb.AddPerson(Bart);
             adb.AddPerson(Lisa);

             List<Person> l = new List<Person>();
             l = adb.GetAllPerson();

             Assert.AreEqual(4, l.Count());
         }
        
    }
}
