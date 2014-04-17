using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace EPAM_TASK_1_ATTRIBUTES
{
    //тестовые классы
    class неизвестныйПотомокJava : Java { }
    class новыйПотомокC_plus_plus : C_plus_plus { }

    [TestFixture]
    class TEST
    {
        //ПЕРЕМЕННЫЕ
        Java j          = new Java();
        C_sharp cs      = new C_sharp();
        C_plus_plus cpp = new C_plus_plus();
        неизвестныйПотомокJava jtest = new неизвестныйПотомокJava();
        новыйПотомокC_plus_plus неизвестынй_С = new новыйПотомокC_plus_plus();

        [Test]
        public void ПолучитьВладельцаTEST()
        {
            string rez ;
            rez = Program.ПолучитьВладельца(j);
            Assert.AreEqual("Oracle", rez);
            rez = Program.ПолучитьВладельца(cs);
            Assert.AreEqual("Microsoft", rez);
            rez = Program.ПолучитьВладельца(cpp);
            Assert.AreEqual("атрибутов нет",rez);
        }

        [Test]
        public void ПоказатьВоЧтоКомпилируетсяTEST() 
        {
            string rez;
            Program.ПоказатьВоЧтоКомпилируется(j);
            Assert.AreEqual("байт код", j.КомпилируетсяВ);
            Program.ПоказатьВоЧтоКомпилируется(cs);
            Assert.AreEqual("IL код", cs.КомпилируетсяВ);
            Program.ПоказатьВоЧтоКомпилируется(cpp);
            Assert.AreEqual("неуправляемый код",cpp.КомпилируетсяВ);
            rez = Program.ПоказатьВоЧтоКомпилируется(jtest);
            Assert.AreEqual("неизвестный язык программирования во что компилируется мы не знаем", rez);
        }

        [Test]
        public void ПолучитьИнформациюОКомпанииВладельцеTEST()
        {
            //проверяем объект j
            string [] temp1 = {
                                    "ГодОснования:\t1977",
                                    "ОтцыОснователи:\tЛари Эллисон, Боб Майнер, Эд Оутсом",
                                    "ДопИнформация:\tКомпания является вторым по объёмам продаж разработчиком программного обеспечения после Microsoft"
                                };
            Assert.That(temp1, Is.EquivalentTo(Program.ПолучитьИнформациюОКомпанииВладельце(j)));


            //проверяем объект cs 
            string [] temp2 = {
                                "ГодОснования:\t1975",
                                "ОтцыОснователи:\tБилл Гейтс , Пол Аллен",
                                "ДопИнформация:\tВ 2013 году Microsoft заняла 75 место в рейтинге 100 лучших работодателей США."
                                };

            Assert.That(temp2, Is.EquivalentTo(Program.ПолучитьИнформациюОКомпанииВладельце(cs)));

            //проверяем объект cpp
            string[] temp3 = { 
                             
                                "атрибутов нет",
                                null,
                                null
                             
                             };
            Assert.That(temp3, Is.EquivalentTo(Program.ПолучитьИнформациюОКомпанииВладельце(cpp)));

            //проверить объект неизвестныйПотомок_C_plus_plus
            string[] temp4 = { 
                             
                                "атрибутов нет",
                                null,
                                null
                             
                             };
            Assert.That(temp4, Is.EquivalentTo(Program.ПолучитьИнформациюОКомпанииВладельце(неизвестынй_С)));

            
            
        }
    }
}
