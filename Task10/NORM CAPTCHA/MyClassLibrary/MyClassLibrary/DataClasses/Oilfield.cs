using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyClassLibrary.Attributes;

namespace MyClassLibrary.DataClasses
{
    /// <summary>
    /// класс описывающий нефтяное месторождение
    /// </summary>
    [Serializable]
    [TableAttribute("Oilfield")]
    public class Oilfield
    {
        /// <summary>
        /// индекс месторождения
        /// </summary>
        public int Index { get; set; }

        /// <summary>
        /// название нефтяного месторождения
        /// </summary>
        [PropertyAttribute("Name")]
        public string Name { get; set; }

        /// <summary>
        /// извлекаемые запасы нефти
        /// </summary>
        [PropertyAttribute("OilResolv")]
        public int OilReserves { get; set; }

        /// <summary>
        /// список скважин данного месторождения
        /// </summary>
        [CollectionAttribute]
        public List<Well> Wells = new List<Well>(); 
    }
}
