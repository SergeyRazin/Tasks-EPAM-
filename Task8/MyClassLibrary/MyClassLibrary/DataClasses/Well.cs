using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyClassLibrary.Attributes;

namespace MyClassLibrary.DataClasses
{
    /// <summary>
    /// класс описывающий нефтяную скважину
    /// </summary>
    [Serializable]
    [TableAttribute("Well")]
    public class Well
    {
        /// <summary>
        /// номер скважины
        /// </summary>
        [PropertyAttribute("Number")]
        public int Number { get; set; }

        /// <summary>
        /// дебит нефти скважины (тонн)
        /// </summary>
        [PropertyAttribute("Debit")]
        public int Debit { get; set; }

        /// <summary>
        /// насос которым эксплуатируется скважина
        /// </summary>
        [PropertyAttribute("Pump")]
        public string Pump { get; set; }
    }
}
