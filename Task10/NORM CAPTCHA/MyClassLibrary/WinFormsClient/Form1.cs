using System;
using System.Data;
using System.Windows.Forms;
using MyClassLibrary.Accessors;
using MyClassLibrary.DataClasses;
using MyClassLibrary.Interfaces;
using MyClassLibrary.MyExceptions;
using NLog;

namespace WinFormsClient
{
    public partial class Form1 : Form
    {

        //поля класса
        #region -----------------------------------------------

        //логер
        private Logger log = LogManager.GetCurrentClassLogger();

        //создаем табличку
        private DataTable _tableSowAll = new DataTable();

        //член класса аксессор (по умолчанию бинарный файл)
        private IAccessor _accessor = new AccessorBinary();

        #endregion-----------------------------------------------


        //приватные методы
        #region ----------------------------------------------------------

        private bool emptyTextbox(string str)
        {
            if (string.IsNullOrEmpty(str))
                return true;
            return false;
        }

        //- алерт 1
        private void alert()
        {
            MessageBox.Show("Заполните необходимые поля");
        }

        //- алерт 2
        private void alert(string str0)
        {
            MessageBox.Show(str0);
        }


        //- если выбрана радиокнопка добавить месторождение
        private void ifAddOilChecked()
        {
            try
            {
                //если выбрана радиокнопка добавить скважину
                if (radioAddOil.Checked)
                {
                    //если текстбокс имя месторождения не заполнено
                    if (emptyTextbox(textBoxIdOil.Name))
                    {
                        alert();
                        return;
                    }

                    //если текстбокс запасы нефти не заполнено
                    if (emptyTextbox(textBoxRezerv.Text))
                    {
                        alert();
                        return;
                    }

                    var temp = new Oilfield();
                    temp.Name = textBoxNameOil.Text;
                    temp.OilReserves = Convert.ToInt32(textBoxRezerv.Text);

                    _accessor.AddOilfield(temp);

                    showAll();
                }
            }
            catch (MyOilfieldNameNotFoundException e)
            {
                alert(e.Message);
                log.Error(e.Message);
                log.Error(e.StackTrace);
                return;
            }
            catch (MyOverlapNameException e)
            {
                alert(e.Message);
                log.Error(e.Message);
                log.Error(e.StackTrace);
                return;
            }
            catch (Exception e)
            {
                alert("ERROR");
                log.Error(e.Message);
                log.Error(e.StackTrace);
                return;
            }
        }

        //- если выбраан радиокнопка показать все
        private void ifGetAllChecked()
        {
            try
            {
                //если показать все
                if (radioGetAllOilfield.Checked)
                {
                    showAll();
                }
            }
            catch (MyOilfieldNameNotFoundException e)
            {
                alert(e.Message);
                log.Error(e.Message);
                log.Error(e.StackTrace);
                return;
            }
            catch (MyOverlapNameException e)
            {
                alert(e.Message);
                log.Error(e.Message);
                log.Error(e.StackTrace);
                return;
            }
            catch (Exception e)
            {
                alert("ERROR");
                log.Error(e.Message);
                log.Error(e.StackTrace);
                return;
            }
        }

        //- показать все
        private void showAll()
        {
            //очистить таблицу
            _tableSowAll.Clear();

            dataGridView1.DataSource = _tableSowAll;
            var list = _accessor.GetAllOilfield();

            foreach (var i in list)
            {
                if (i.Wells.Count == 0)
                {
                    _tableSowAll.Rows.Add(i.Index, i.Name, i.OilReserves);
                }

                for (int w = 0; w < i.Wells.Count; w++)
                {
                    _tableSowAll.Rows.Add(i.Index, i.Name, i.OilReserves, i.Wells[w].Number, i.Wells[w].Debit,
                        i.Wells[w].Pump);
                }
            }
        }

        //- если выбраано  добавить скважину
        private void ifAddWellChecked()
        {
            
            //если добавить скважину
            if (radioAddWell.Checked)
            {
                if (emptyTextbox(textBoxNumber.Text))
                {
                    alert();
                    return;
                }

                if (emptyTextbox(textBoxDebit.Text))
                {
                    alert();
                    return;
                }

                if (emptyTextbox(textBoxPump.Text))
                {
                    alert();
                    return;
                }

                if (emptyTextbox(textBoxNameOil.Text))
                {
                    alert();
                    return;
                }

                try
                {
                    var tempWell = new Well();

                    tempWell.Number = Convert.ToInt32(textBoxNumber.Text);
                    tempWell.Debit = Convert.ToInt32(textBoxDebit.Text);
                    tempWell.Pump = textBoxPump.Text;

                    _accessor.AddWell(tempWell, textBoxNameOil.Text);
                }
                catch (MyOilfieldNameNotFoundException e)
                {
                    alert(e.Message);
                    log.Error(e.Message);
                    log.Error(e.StackTrace);
                    return;
                }
                catch (MyOverlapNameException e)
                {
                    alert(e.Message);
                    log.Error(e.Message);
                    log.Error(e.StackTrace);
                    return;
                }
                catch (Exception e)
                {
                    alert("ERROR");
                    log.Error(e.Message);
                    log.Error(e.StackTrace);
                    return;
                }

                showAll();
            }
        }

        //- если выбрано удалить месторождение
        private void ifRemoveOilfield()
        {
            

            //если выбрано удалить месторождение
            if (radioRemoveOilfield.Checked)
            {
                //если не заполнен индекс месторождения
                if (emptyTextbox(textBoxIdOil.Text))
                {
                    alert();
                    return;
                }


                try
                {
                    var id = Convert.ToInt32(textBoxIdOil.Text);
                    _accessor.RemoveOilfield(id);
                }
                catch (MyOilfieldNameNotFoundException e)
                {
                    alert(e.Message);
                    log.Error(e.Message);
                    log.Error(e.StackTrace);
                    return;
                }
                catch (MyOverlapNameException e)
                {
                    alert(e.Message);
                    log.Error(e.Message);
                    log.Error(e.StackTrace);
                    return;
                }
                catch (Exception e)
                {
                    alert("ERROR");
                    log.Error(e.Message);
                    log.Error(e.StackTrace);
                    return;
                }

                showAll();
            }
        }

        //- если выбрано удалить скважину
        private void ifRemoweWell()
        {
            //если выбрано удалить скважину
            if (radioRemoveWell.Checked)
            {
                //если незаполнен номер скважины
                if (emptyTextbox(textBoxNumber.Text))
                {
                    alert();
                    return;
                }

                //если незаполнено название месторождение
                if (emptyTextbox(textBoxNameOil.Text))
                {
                    alert();
                    return;
                }

                try
                {
                    var numberWell = Convert.ToInt32(textBoxNumber.Text);
                    var oilfieldName0 = textBoxNameOil.Text;

                    _accessor.RemoveWell(numberWell, oilfieldName0);
                }
                catch (MyOilfieldNameNotFoundException e)
                {
                    alert(e.Message);
                    log.Error(e.Message);
                    log.Error(e.StackTrace);
                    return;
                }
                catch (MyOverlapNameException e)
                {
                    alert(e.Message);
                    log.Error(e.Message);
                    log.Error(e.StackTrace);
                    return;
                }
                catch (Exception e)
                {
                    alert("ERROR");
                    log.Error(e.Message);
                    log.Error(e.StackTrace);
                    return;
                }

                showAll();
            }
        }

        //- если выбрано поазать количество месторождений
        private void ifCountOil()
        {
            try
            {
                //если выбрано поазать количество месторождений
                if (radioCountOilfield.Checked)
                {
                    var countOil = _accessor.CountOilfield();

                    DataTable tableCount = new DataTable();

                    tableCount.Columns.Add("Количество месторождений");
                    tableCount.Rows.Add(countOil);

                    dataGridView1.DataSource = tableCount;
                }
            }
            catch (MyOilfieldNameNotFoundException e)
            {
                alert(e.Message);
                log.Error(e.Message);
                log.Error(e.StackTrace);
                return;
            }
            catch (MyOverlapNameException e)
            {
                alert(e.Message);
                log.Error(e.Message);
                log.Error(e.StackTrace);
                return;
            }
            catch (Exception e)
            {
                alert("ERROR");
                log.Error(e.Message);
                log.Error(e.StackTrace);
                return;
            }
        }

        //- если выбрано обновить месторождение
        private void ifUpdateOil()
        {
            try{
            //если выбрано обновить месторождение
                if (radioUpdateOilfield.Checked)
                {
                    //если не заполнен название месторождения
                    if (emptyTextbox(textBoxNameOil.Text))
                    {
                        alert();
                        return;
                    }

                    //если не заполнен извлекаемые запасы
                    if (emptyTextbox(textBoxRezerv.Text))
                    {
                        alert();
                        return;
                    }

                    //если не заполнен индекс месторождения
                    if (emptyTextbox(textBoxIdOil.Text))
                    {
                        alert();
                        return;
                    }

                    var index = Convert.ToInt32(textBoxIdOil.Text);
                    var oilfield = new Oilfield();

                    oilfield.Name = textBoxNameOil.Text;
                    oilfield.OilReserves = Convert.ToInt32(textBoxRezerv.Text);

                    _accessor.UpdateOilfield(index, oilfield);
                    showAll();
                }

                
            }
            catch (MyOilfieldNameNotFoundException e)
            {
                alert(e.Message);
                log.Error(e.Message);
                log.Error(e.StackTrace);
                return;
            }
            catch (MyOverlapNameException e)
            {
                alert(e.Message);
                log.Error(e.Message);
                log.Error(e.StackTrace);
                return;
            }
            catch (Exception e)
            {
                alert("ERROR");
                log.Error(e.Message);
                log.Error(e.StackTrace);
                return;
            }
        }

        //- если выбрано количество скважин
        private void ifCountWells()
        {
            try
            {
                //если выбрано количество скважин
                if (radioCountWells.Checked)
                {
                    var countWells = _accessor.CountWells();

                    //создаем таблицу
                    DataTable tableCountWells = new DataTable();

                    tableCountWells.Columns.Add("Количество скважин:");
                    tableCountWells.Rows.Add(countWells);

                    dataGridView1.DataSource = tableCountWells;
                }
            }
            catch (MyOilfieldNameNotFoundException e)
            {
                alert(e.Message);
                log.Error(e.Message);
                log.Error(e.StackTrace);
                return;
            }
            catch (MyOverlapNameException e)
            {
                alert(e.Message);
                log.Error(e.Message);
                log.Error(e.StackTrace);
                return;
            }
            catch (Exception e)
            {
                alert("ERROR");
                log.Error(e.Message);
                log.Error(e.StackTrace);
                return;
            }
        }

        //- если выбрано получить количестов скважин по месторождению
        private void ifCountWellsInOilfield()
        {
            try
            {
                //если выбрано получить количестов скважин по месторождению
                if (radioCountWellsInOilfield.Checked)
                {
                    //если индекс месторождения не заполнен
                    if (emptyTextbox(textBoxIdOil.Text))
                    {
                        alert();
                        return;
                    }

                    var index = Convert.ToInt32(textBoxIdOil.Text);


                    //создать таблицу
                    DataTable tableCount = new DataTable();

                    tableCount.Columns.Add("Месторождение:");
                    tableCount.Columns.Add("Количество скважин:");

                    tableCount.Rows.Add(_accessor.GetNameByIndex(index), _accessor.CountWellsInOilfield(index));


                    dataGridView1.DataSource = tableCount;
                }
            }
            catch (MyOilfieldNameNotFoundException e)
            {
                alert(e.Message);
                log.Error(e.Message);
                log.Error(e.StackTrace);
                return;
            }
            catch (MyOverlapNameException e)
            {
                alert(e.Message);
                log.Error(e.Message);
                log.Error(e.StackTrace);
                return;
            }
            catch (Exception e)
            {
                alert("ERROR");
                log.Error(e.Message);
                log.Error(e.StackTrace);
                return;
            }
        }

        //- если выбрано получить месторождение по индексу
        private void ifGetOilBiIndex()
        {
            try{
            //если выбрано получить месторождение по индексу
                if (radioGetOilfieldByIndex.Checked)
                {
                    //если не заполнен индекс месторождения
                    if (emptyTextbox(textBoxIdOil.Text))
                    {
                        alert();
                        return;
                    }

                    //получить индекс
                    var idOil = Convert.ToInt32(textBoxIdOil.Text);

                    //получить месторождение по индексу
                    var oil = _accessor.GetOilfieldByIndex(idOil);

                    //очистить таблицу
                    _tableSowAll.Clear();

                    //установить ресурс dataGridViev
                    dataGridView1.DataSource = _tableSowAll;

                    //если количество скважин равно нулю тогда вывести данные только по месторождению
                    if (oil.Wells.Count == 0)
                    {
                        _tableSowAll.Rows.Add(oil.Index, oil.Name, oil.OilReserves);
                    }
                    //иначе
                    //вывести данные по месторождению и по его скважинам
                    for (int w = 0; w < oil.Wells.Count; w++)
                    {
                        _tableSowAll.Rows.Add(oil.Index, oil.Name, oil.OilReserves, oil.Wells[w].Number,
                            oil.Wells[w].Debit,
                            oil.Wells[w].Pump);
                    }
                }
            }
            catch (MyOilfieldNameNotFoundException e)
            {
                alert(e.Message);
                log.Error(e.Message);
                log.Error(e.StackTrace);
                return;
            }
            catch (MyOverlapNameException e)
            {
                alert(e.Message);
                log.Error(e.Message);
                log.Error(e.StackTrace);
                return;
            }
            catch (Exception e)
            {
                alert("ERROR");
                log.Error(e.Message);
                log.Error(e.StackTrace);
                return;
            }
        }

        //- если выбрано очистить
        private void ifClear()
        {
            try
            {
                //если выбрано очистить
                if (radioClear.Checked)
                {
                    _accessor.Clear();
                    showAll();
                }
            }
            catch (MyOilfieldNameNotFoundException e)
            {
                alert(e.Message);
                log.Error(e.Message);
                log.Error(e.StackTrace);
                return;
            }
            catch (MyOverlapNameException e)
            {
                alert(e.Message);
                log.Error(e.Message);
                log.Error(e.StackTrace);
                return;
            }
            catch (Exception e)
            {
                alert("ERROR");
                log.Error(e.Message);
                log.Error(e.StackTrace);
                return;
            }
        }

        //- проверить выбрано ли одно из действий
        private bool checkActionSelect()
        {
            
            var check = false;

            //пробежать по всем радиокнопкам действия
            foreach (var contr in panelAction.Controls)
            {
                var radio = (RadioButton)contr;
                if (radio.Checked == true)
                    check = true;
            }
            //если не одно действие не выбрано, то показать сообщение, закончить работу события
            if (check == false)
            {
                MessageBox.Show("Выберите одно из действий.");
                return true;
            }
            return false;
        }

        //- закрыть текстбоксы 
        private void closeTextBox()
        {
            foreach (var r in panelOil.Controls)
            {
                if (r is TextBox)
                {
                    var rad = (TextBox)r;

                    rad.Enabled = false;
                }
            }

            //закрыть текстбоксы панели скважины
            foreach (var r in panelWells.Controls)
            {
                if (r is TextBox)
                {
                    var rad = (TextBox)r;

                    rad.Enabled = false;
                }
            }
        }

        //- вводить только числа для текстбокса
        private void enterOnlyNumberTextbox(KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) == true) return;
            if (e.KeyChar == Convert.ToChar(Keys.Back)) return;
            e.Handled = true;
        }

        #endregion приватные методы--↑--------------------------------------------------------

        //конструктор формы
        public Form1()
        {
            InitializeComponent();
        }

        //события 
        #region--------↓---------------------------------------------------------------------------

        //событие загрузка формы
        private void Form1_Load(object sender, EventArgs e)
        {
            //устанавливаем столбцы для нашей таблицы
            _tableSowAll.Columns.Add("ID месторождения");
            _tableSowAll.Columns.Add("имя месторождения");
            _tableSowAll.Columns.Add("извлекаемые запасы");
            _tableSowAll.Columns.Add("Номер скв.");
            _tableSowAll.Columns.Add("дебит скважины");
            _tableSowAll.Columns.Add("марка насоса");

            dataGridView1.DataSource = _tableSowAll;


            //создаем интерфейс аццессор
            //IAccessor accessor;

            //текст главного окна
            this.Text = @"Автоматизация нефтяной промышленности.";

            //установка текста радиокнопок (accessors: binary, XML, BD)
            radioBinary.Text = "бинарный файл";
            radioXML.Text = "xml файл";
            radioDB.Text = "база данных";

            //установка текста радиокнопок методов (aciton)
            radioAddOil.Text = "добавить месторождение";
            radioRemoveOilfield.Text = "удалить месторождение";
            radioAddWell.Text = "добавить скважину";
            radioRemoveWell.Text = "удалить скважину";
            radioUpdateOilfield.Text = "обновить месторождение";
            radioGetAllOilfield.Text = "показать все";
            radioGetOilfieldByIndex.Text = "получить месторождение по индексу";
            radioCountOilfield.Text = "показать количество месторождений";
            radioCountWells.Text = "показать количество всех скважин";
            radioCountWellsInOilfield.Text = "показать количество скважин месторождения";
            radioClear.Text = "удалить все";

            //текст лейблов
            labelDebit.Text = "Дебит скв.";
            labelIDOil.Text = "ID месторождения";
            labelIDOilInWell.Text = "индекс месторождения";
            labelIDWell.Text = "индекс скважины";
            labelNameOil.Text = "имя месторождения";
            labelNumber.Text = "номер скважины";
            labelPump.Text = "марка насоса";
            labelRezerv.Text = "запасы нефти";

            //текст кнопки
            buttonOk.Text = "";
        }

        

        //радиокнопка (база данных)
        private void radioDB_CheckedChanged(object sender, EventArgs e)
        {
            _accessor = new AccessorDB();
        }

        //радиокнопка (бинарный файл)
        private void radioBinary_CheckedChanged(object sender, EventArgs e)
        {
            _accessor = new AccessorBinary();
        }

        //радиокнопка (xml)
        private void radioXML_CheckedChanged(object sender, EventArgs e)
        {
            _accessor = new AccessorXML();
        }

        //нажатие кнопки
        private void buttonOk_Click(object sender, EventArgs e)
        {
            //проверить выбрано ли одно из действий
            if (checkActionSelect()) return;


            ifAddOilChecked();

            ifGetAllChecked();

            ifAddWellChecked();

            ifRemoveOilfield();

            ifRemoweWell();

            ifCountOil();

            ifUpdateOil();

            ifCountWells();

            ifCountWellsInOilfield();

            ifGetOilBiIndex();

            ifClear();
        }

        

        //радиокнопка добавить месторождение
        private void radioAddOil_CheckedChanged(object sender, EventArgs e)
        {
            closeTextBox();

            textBoxNameOil.Enabled = true;
            textBoxRezerv.Enabled = true;
        }

        //радиокнопка удалить месторождение
        private void radioRemoveOilfield_CheckedChanged(object sender, EventArgs e)
        {
            closeTextBox();
            textBoxIdOil.Enabled = true;
        }

        //радиокнопка добавить скважину
        private void radioAddWell_CheckedChanged(object sender, EventArgs e)
        {
            //закрыть текстбоксы 
            closeTextBox();

            textBoxNameOil.Enabled = true;
            textBoxNumber.Enabled = true;
            textBoxDebit.Enabled = true;
            textBoxPump.Enabled = true;
        }

        //радиокнопка удалить скважину
        private void radioRemoveWell_CheckedChanged(object sender, EventArgs e)
        {
            closeTextBox();

            textBoxNumber.Enabled = true;
            textBoxNameOil.Enabled = true;
        }

        //радиокнопка показать количество месторождений
        private void radioCountOilfield_CheckedChanged(object sender, EventArgs e)
        {
            closeTextBox();
        }

        //радиокнопка обновить месторождение
        private void radioUpdateOilfield_CheckedChanged(object sender, EventArgs e)
        {
            closeTextBox();

            textBoxIdOil.Enabled = true;
            textBoxNameOil.Enabled = true;
            textBoxRezerv.Enabled = true;
        }

        //радиокнопка показать все
        private void radioGetAllOilfield_CheckedChanged(object sender, EventArgs e)
        {
            closeTextBox();
        }

        //радиокнопка показать количество всех скважин
        private void radioCountWells_CheckedChanged(object sender, EventArgs e)
        {
            closeTextBox();
        }

        //радиокнопка показать количество скважин месторождения
        private void radioCountWellsInOilfield_CheckedChanged(object sender, EventArgs e)
        {
            closeTextBox();

            textBoxIdOil.Enabled = true;
        }

        //радиокнопка получить месторождение по индексу
        private void radioGetOilfieldByIndex_CheckedChanged(object sender, EventArgs e)
        {
            closeTextBox();

            textBoxIdOil.Enabled = true;
        }

        //радиокнопка удалить все
        private void radioClear_CheckedChanged(object sender, EventArgs e)
        {
            closeTextBox();
        }

        

        //вводить только числа (ID oil)
        private void textBoxIdOil_KeyPress(object sender, KeyPressEventArgs e)
        {
            enterOnlyNumberTextbox(e);
        }

        //вводить только числа (oilRezolv)
        private void textBoxRezerv_KeyPress(object sender, KeyPressEventArgs e)
        {
            enterOnlyNumberTextbox(e);
        }

        //вводить только числа(индекс скважины)
        private void textBoxIDWell_KeyPress(object sender, KeyPressEventArgs e)
        {
            enterOnlyNumberTextbox(e);
        }

        //вводить только числа (индекс месторождения в скважине)
        private void textBoxIDOilInWell_KeyPress(object sender, KeyPressEventArgs e)
        {
            enterOnlyNumberTextbox(e);
        }

        //вводить только числа(номер скважины)
        private void textBoxNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            enterOnlyNumberTextbox(e);
        }

        //вводить только числа(дебит скважины)
        private void textBoxDebit_KeyPress(object sender, KeyPressEventArgs e)
        {
            enterOnlyNumberTextbox(e);
        }



        #endregion события----↑-----------------------------------------------------------------------------





    }
}
