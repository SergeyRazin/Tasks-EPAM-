using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using MyORMx;

namespace UnitTests
{
    class PersonTEST
    {
        [Test]
        public void PersonConsstructorTEST()
        {
            Person p = new Person();
            Assert.AreEqual(null, p.Name);
            Assert.AreEqual(0, p.Age);
        }
    }
}
