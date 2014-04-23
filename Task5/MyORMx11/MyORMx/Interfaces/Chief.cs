using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyORMx.Interfaces
{
     public interface Chief
    {
         void AddPERSON();

         void RemovePERSON();

         void InsertPERSON();

         void showALL();

         void Clear();

         void GetPersonByIndex();

         void Count();
    }
}
