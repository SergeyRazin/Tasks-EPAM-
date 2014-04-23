using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace MyORM
{
    [TestFixture]
    class TEST
    {
        [Test]
        public void AddPerson() 
        {
            AccessorMemory amemTest = new AccessorMemory();
            bool rez = amemTest.AddPerson(new Person() { Name = "Homer", Age = 47 });

            Assert.IsTrue(rez);
        }
    }
}
