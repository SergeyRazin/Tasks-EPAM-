using System.Collections.Generic;
using MyClassLibrary.Interfaces;
using MyClassLibrary.DataClasses;


namespace MyClassLibrary.Accessors
{
    public class AccessorDB:IAccessor
    {
        public  DALdb Dal = new DALdb();

        public virtual void AddOilfield(Oilfield oilfield0)
        {
            Dal.AddOilfield(oilfield0);
        }

        public void RemoveOilfield(int index0)
        {
            Dal.DeleteOilfield(index0);
        }

        public virtual void AddWell(Well well0, string oilfieldName0)
        {
            Dal.AddWell(well0,oilfieldName0);
        }

        public void RemoveWell(int number0, string oilfieldName0)
        {
            Dal.RemoveWell(number0, oilfieldName0);
        }

        public void UpdateOilfield(int index0, Oilfield oilfield0)
        {
            Dal.UpdateOilfield(index0,oilfield0);
        }

        public List<Oilfield> GetAllOilfield()
        {
           return  Dal.GetAllOilfield();
        }

        public Oilfield GetOilfieldByIndex(int index0)
        {
            var rez = Dal.GetOilfieldById(index0);
            return rez;
        }

        public int CountOilfield()
        {
            return  Dal.GetAllOilfield().Count;
        }

        public int CountWells()
        {
            return  Dal.GetAllWells().Count;
        }

        public int CountWellsInOilfield(int indexOilfield0)
        {
            var rez = Dal.GetOilfieldById(indexOilfield0);
            return rez.Wells.Count;
        }

        public void Clear()
        {
            Dal.Clear();
        }

        public string GetNameByIndex(int index0)
        {
           return Dal.GetNameByIndex(index0);
        }
    }
}
