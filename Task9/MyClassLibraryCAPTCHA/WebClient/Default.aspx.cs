using System;
using System.Data;
using System.Web.UI.WebControls;
using ConsoleClient;
using MyClassLibrary.Accessors;
using MyClassLibrary.DataClasses;
using MyClassLibrary.Interfaces;
using MyClassLibrary.MyExceptions;
using Ninject;
using NLog;

namespace WebClient
{
    public partial class Default : System.Web.UI.Page
    {
        //поля класса
        #region -------↓---------------------------------

        //ioc
        IKernel ninjectKernel = new StandardKernel(new SimpleConfigurationModule());

        //логер
        private Logger log = LogManager.GetCurrentClassLogger();

        //аксессор
        private IAccessor _accessor;

        //создаем табличку
        private DataTable _tableSowAll = new DataTable();

        //объект для создания капчи
        Сaptcha captcha = new Сaptcha();

        #endregion поля класса----↑----------------------

        //привытные методы
        #region  -------↓-------------------------------------------------

        //- alert1
        private void alert()
        {
            DataTable tableCount = new DataTable();

            tableCount.Columns.Add("ERROR");
            tableCount.Rows.Add("Заполните необходимые поля и капчу");

            GridView1.DataSource = tableCount;
            GridView1.DataBind();
        }

        //- alert2
        private void alert(string str0)
        {
            DataTable tableCount = new DataTable();

            tableCount.Columns.Add("ERROR");
            tableCount.Rows.Add(str0);

            GridView1.DataSource = tableCount;
            GridView1.DataBind();
        }

        //- проверить выбран ли хоть один аксессор
        private bool checkAccessor()
        {
            //проверить выбран ли хоть один аксессор
            if (RadioBinary.Checked == false && RadioXML.Checked == false && RadioDB.Checked == false)
            {
                DataTable tableError = new DataTable();
                tableError.Columns.Add("Ошибка:");
                tableError.Rows.Add("Выберите источник данных.");

                GridView1.DataSource = tableError;
                GridView1.DataBind();
                return false;
            }
            else
            {
                GridView1.DataBind();
                return true;
            }
        }

        //-проверить отображать капчу или нет
        private void CaptchaVisible()
        {
            if (RadioAddOil.Checked)
                Panel1.Visible = true;
            if (RadioRemoveOilfield.Checked)
                Panel1.Visible = true;
            if (RadioAddWell.Checked)
                Panel1.Visible = true;
            if (RadioRemoveWell.Checked)
                Panel1.Visible = true;
            if (RadioUpdateOilfield.Checked)
                Panel1.Visible = true;
            if (RadioClear.Checked)
                Panel1.Visible = true;
        }

        //- проверить выбран ли хоть одно действие
        private void checkAction()
        {
            //проверить выбран ли хоть одно действие
            if (
                RadioAddOil.Checked == false &&
                RadioRemoveOilfield.Checked == false &&
                RadioGetAllOilfield.Checked == false &&
                RadioAddWell.Checked == false &&
                RadioRemoveWell.Checked == false &&
                RadioCountOilfield.Checked == false &&
                RadioUpdateOilfield.Checked == false &&
                RadioUpdateOilfield.Checked == false &&
                RadioCountWells.Checked == false &&
                RadioCountWellsInOilfield.Checked == false &&
                RadioGetOilfieldByIndex.Checked == false &&
                RadioClear.Checked == false
                )
            {
                DataTable tableError = new DataTable();
                tableError.Columns.Add("Ошибка:");
                tableError.Rows.Add("Выберите действие.");

                GridView1.DataSource = tableError;
                GridView1.DataBind();
            }
            else
            {
                GridView1.DataBind();
            }
        }

        //- выбор аксессора
        private void selectAccessor()
        {
            if (RadioBinary.Checked)
                _accessor = ninjectKernel.Get<AccessorBinary>();
            if (RadioXML.Checked)
                _accessor = ninjectKernel.Get<AccessorXML>();
            if (RadioDB.Checked)
                _accessor = ninjectKernel.Get<AccessorDB>();
        }

        //- скрыть все поля
        private void hideAll()
        {
            //скрыть все поля
            TextBoxDebit.Visible = false;
            TextBoxIdOil.Visible = false;
            TextBoxNumber.Visible = false;
            TextBoxNameOil.Visible = false;
            TextBoxPump.Visible = false;
            TextBoxReserve.Visible = false;
            Panel1.Visible = false;
        }

        //- если добавить месторождение*
        private void ifAddOil()
        {
            //если добавить месторождение
            if (RadioAddOil.Checked)
            {
                //если не капча
                if (TextBoxCaptcha.Text != Session["scap"].ToString())
                {
                    alert();
                    return;
                }

                //если имя месторождения не заполнено
                if (string.IsNullOrEmpty(RadioAddOil.Text))
                {
                    alert();
                    return;
                }

                //если запасы месторождения не зполнено
                if (String.IsNullOrEmpty(TextBoxReserve.Text))
                {
                    alert();
                    return;
                }

                var temp = new Oilfield();
                temp.Name = TextBoxNameOil.Text;
                temp.OilReserves = Convert.ToInt32(TextBoxReserve.Text);
                try
                {
                    _accessor.AddOilfield(temp);
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

        //- если удалить месторождение*
        private void ifRemoveOil()
        {
            //если удалить месторождение
            if (RadioRemoveOilfield.Checked)
            {
                //если не капча
                if (TextBoxCaptcha.Text != Session["scap"].ToString())
                {
                    alert();
                    return;
                }

                //если индекс месторождения не заполнен
                if (string.IsNullOrEmpty(TextBoxIdOil.Text))
                {
                    alert();
                    return;
                }

                var index = Convert.ToInt32(TextBoxIdOil.Text);
                try
                {
                    _accessor.RemoveOilfield(index);
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

        //- показать все
        private void showAll()
        {
            try
            {
                //очистить таблицу
                _tableSowAll.Clear();

                GridView1.DataSource = _tableSowAll;
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
                GridView1.DataBind();
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

        //- если показать все
        private void ifGetAll()
        {
            //если показать все
            if (RadioGetAllOilfield.Checked)
            {
                var rez = _accessor.GetAllOilfield();
                showAll();
            }
        }

        //- если добавить скважину*
        private void ifAddWell()
        {
            if (RadioAddWell.Checked)
            {
                //если не капча
                if (TextBoxCaptcha.Text != Session["scap"].ToString())
                {
                    alert();
                    return;
                }

                if (string.IsNullOrEmpty(TextBoxNumber.Text))
                {
                    alert();
                    return;
                }

                if (string.IsNullOrEmpty(TextBoxDebit.Text))
                {
                    alert();
                    return;
                }

                if (string.IsNullOrEmpty(TextBoxPump.Text))
                {
                    alert();
                    return;
                }

                if (string.IsNullOrEmpty(TextBoxNameOil.Text))
                {
                    alert();
                    return;
                }

                var tempWell = new Well();

                tempWell.Number = Convert.ToInt32(TextBoxNumber.Text);
                tempWell.Debit = Convert.ToInt32(TextBoxDebit.Text);
                tempWell.Pump = TextBoxPump.Text;

                try
                {
                    _accessor.AddWell(tempWell, TextBoxNameOil.Text);
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

        //- если удалить скважину*
        private void ifRemoveWell()
        {
            if (RadioRemoveWell.Checked)
            {
                //если не капча
                if (TextBoxCaptcha.Text != Session["scap"].ToString())
                {
                    alert();
                    return;
                }

                if (string.IsNullOrEmpty(TextBoxNumber.Text))
                {
                    alert();
                    return;
                }

                if (string.IsNullOrEmpty(TextBoxNameOil.Text))
                {
                    alert();
                    return;
                }

                var numberWell = Convert.ToInt32(TextBoxNumber.Text);
                var oilfieldName0 = TextBoxNameOil.Text;

                try
                {
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

        //- если показать количество месторождений
        private void ifCountOil()
        {
            try
            {
                if (RadioCountOilfield.Checked)
                {
                    var countOil = _accessor.CountOilfield();

                    DataTable tableCount = new DataTable();

                    tableCount.Columns.Add("Количество месторождений");
                    tableCount.Rows.Add(countOil);

                    GridView1.DataSource = tableCount;
                    GridView1.DataBind();
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

        //- если обновить месторождение*
        private void ifUpdate()
        {
            try
            {
                if (RadioUpdateOilfield.Checked)
                {
                    //если не капча
                    if (TextBoxCaptcha.Text != Session["scap"].ToString())
                    {
                        alert();
                        return;
                    }

                    if (string.IsNullOrEmpty(TextBoxNameOil.Text))
                    {
                        alert();
                        return;
                    }
                    if (string.IsNullOrEmpty(TextBoxReserve.Text))
                    {
                        alert();
                        return;
                    }
                    if (string.IsNullOrEmpty(TextBoxIdOil.Text))
                    {
                        alert();
                        return;
                    }

                    var index = Convert.ToInt32(TextBoxIdOil.Text);
                    var oilfield = new Oilfield();

                    oilfield.Name = TextBoxNameOil.Text;
                    oilfield.OilReserves = Convert.ToInt32(TextBoxReserve.Text);

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

        //- если показать количество всех скважин
        private void ifCountWells()
        {
            try
            {
                //если показать количество всех скважин
                if (RadioCountWells.Checked)
                {
                    var countWells = _accessor.CountWells();

                    //создаем таблицу
                    DataTable tableCountWells = new DataTable();

                    tableCountWells.Columns.Add("Количество скважин:");
                    tableCountWells.Rows.Add(countWells);

                    GridView1.DataSource = tableCountWells;
                    GridView1.DataBind();
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

        //- если показать количество скважин месторождения
        private void ifCountWellsInOil()
        {
            try
            {
                //если показать количество скважин месторождения
                if (RadioCountWellsInOilfield.Checked)
                {
                    if (string.IsNullOrEmpty(TextBoxIdOil.Text))
                    {
                        alert();
                        return;
                    }

                    var index = Convert.ToInt32(TextBoxIdOil.Text);


                    //создать таблицу
                    DataTable tableCount = new DataTable();

                    tableCount.Columns.Add("Месторождение:");
                    tableCount.Columns.Add("Количество скважин:");

                    tableCount.Rows.Add(_accessor.GetNameByIndex(index), _accessor.CountWellsInOilfield(index));


                    GridView1.DataSource = tableCount;
                    GridView1.DataBind();
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

        //- если показать месторождение
        private void ifGetOIlById()
        {
            try
            {
                //если показать месторождение
                if (RadioGetOilfieldByIndex.Checked)
                {
                    if (string.IsNullOrEmpty(TextBoxIdOil.Text))
                    {
                        alert();
                        return;
                    }

                    //получить индекс
                    var idOil = Convert.ToInt32(TextBoxIdOil.Text);

                    //получить месторождение по индексу
                    var oil = _accessor.GetOilfieldByIndex(idOil);

                    //очистить таблицу
                    _tableSowAll.Clear();

                    //установить ресурс dataGridViev
                    GridView1.DataSource = _tableSowAll;


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
                    GridView1.DataBind();
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

        //- если удалить все*
        private void ifClear()
        {
            try
            {
                if (RadioClear.Checked)
                {
                    //если не капча
                    if (TextBoxCaptcha.Text != Session["scap"].ToString())
                    {
                        alert();
                        return;
                    }

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

        #endregion привытные методы----↑----------------------------------

        //события
        #region события -----↓-------------------------------

        //загрузка страницы
        protected void Page_Load(object sender, EventArgs e)
        {
            Panel1.Visible = false;

            //определяем поазывать ли панель с капчей
            CaptchaVisible();

            //**
            if (!IsPostBack)
            {
                captcha = new Сaptcha();
                captcha.CreateCaptcha(this.Context);
            }

            //устанавливаем столбцы для нашей таблицы
            _tableSowAll.Columns.Add("ID месторождения");
            _tableSowAll.Columns.Add("имя месторождения");
            _tableSowAll.Columns.Add("извлекаемые запасы");
            _tableSowAll.Columns.Add("Номер скв.");
            _tableSowAll.Columns.Add("дебит скважины");
            _tableSowAll.Columns.Add("марка насоса");

            GridView1.DataSource = _tableSowAll;

            //валидация
            CompareValidator1.ControlToValidate = "TextBoxIdOil";
            CompareValidator1.EnableClientScript = false;
            CompareValidator1.Type = ValidationDataType.Integer;
            CompareValidator1.Operator = ValidationCompareOperator.DataTypeCheck;
            CompareValidator1.ErrorMessage = "*следует вводить числа";

            CompareValidator2.ControlToValidate = "TextBoxReserve";
            CompareValidator2.EnableClientScript = false;
            CompareValidator2.Type = ValidationDataType.Integer;
            CompareValidator2.Operator = ValidationCompareOperator.DataTypeCheck;
            CompareValidator2.ErrorMessage = "*следует вводить числа";

            CompareValidator3.ControlToValidate = "TextBoxNumber";
            CompareValidator3.EnableClientScript = false;
            CompareValidator3.Type = ValidationDataType.Integer;
            CompareValidator3.Operator = ValidationCompareOperator.DataTypeCheck;
            CompareValidator3.ErrorMessage = "*следует вводить числа";

            CompareValidator4.ControlToValidate = "TextBoxDebit";
            CompareValidator4.EnableClientScript = false;
            CompareValidator4.Type = ValidationDataType.Integer;
            CompareValidator4.Operator = ValidationCompareOperator.DataTypeCheck;
            CompareValidator4.ErrorMessage = "*следует вводить числа";
        }

        //событие нажание на buttonOk
        protected void ButtonOk_Click(object sender, EventArgs e)
        {
            if (Page.IsValid != true)
            {
                return;
            }


            if (!checkAccessor())
            {
                return;
            }

            checkAction();

            selectAccessor();

            ifAddOil();

            ifRemoveOil();

            ifGetAll();

            ifAddWell();

            ifRemoveWell();

            ifCountOil();

            ifUpdate();

            ifCountWells();

            ifCountWellsInOil();

            ifGetOIlById();

            ifClear();
        }



        //радиокнопка добавить месторождение+
        protected void RadioAddOil_CheckedChanged(object sender, EventArgs e)
        {
            hideAll();

            //обновить капчу
            captcha.CreateCaptcha(this.Context);

            TextBoxNameOil.Visible = true;
            TextBoxReserve.Visible = true;
            Panel1.Visible = true;

        }
        
        //радиокнопка удалить месторождение+
        protected void RadioRemoveOilfield_CheckedChanged(object sender, EventArgs e)
        {
            hideAll();

            //обновить капчу
            captcha.CreateCaptcha(this.Context);

            TextBoxIdOil.Visible = true;
            Panel1.Visible = true;
        }

        //радиокнопка добавить скважину+
        protected void RadioAddWell_CheckedChanged(object sender, EventArgs e)
        {
            hideAll();

            //обновить капчу
            captcha.CreateCaptcha(this.Context);

            TextBoxNameOil.Visible = true;
            TextBoxNumber.Visible = true;
            TextBoxDebit.Visible = true;
            TextBoxPump.Visible = true;
            Panel1.Visible = true;
        }

        //радиокнопка удалить скважину+
        protected void RadioRemoveWell_CheckedChanged(object sender, EventArgs e)
        {
            hideAll();

            //обновить капчу
            captcha.CreateCaptcha(this.Context);

            TextBoxNumber.Visible = true;
            TextBoxNameOil.Visible = true;
            Panel1.Visible = true;
        }

        //радиокнопка показать количество месторождений
        protected void RadioCountOilfield_CheckedChanged(object sender, EventArgs e)
        {
            hideAll();
        }

        //радиокнопка обновить месторождение+
        protected void RadioUpdateOilfield_CheckedChanged(object sender, EventArgs e)
        {
            hideAll();

            //обновить капчу
            captcha.CreateCaptcha(this.Context);

            TextBoxIdOil.Visible = true;
            TextBoxNameOil.Visible = true;
            TextBoxReserve.Visible = true;
            Panel1.Visible = true;
        }

        //радиокнопка показать все
        protected void RadioGetAllOilfield_CheckedChanged(object sender, EventArgs e)
        {
            hideAll();
        }

        //радиокнопка показать количество скважин
        protected void RadioCountWells_CheckedChanged(object sender, EventArgs e)
        {
            hideAll();
        }

        //радиокнопка показать количество скважин месторождения
        protected void RadioCountWellsInOilfield_CheckedChanged(object sender, EventArgs e)
        {
            hideAll();

            TextBoxIdOil.Visible = true;
        }

        //радиокнопка получиь месторождение по индексу
        protected void RadioGetOilfieldByIndex_CheckedChanged(object sender, EventArgs e)
        {
            hideAll();

            TextBoxIdOil.Visible = true;
        }

        //радиокнопка удалить все+
        protected void RadioClear_CheckedChanged(object sender, EventArgs e)
        {
            hideAll();

            //обновить капчу
            captcha.CreateCaptcha(this.Context);

            Panel1.Visible = true;
        }

        #endregion события-------↑---------------------------


        //событие клик на кнопке обновить капчу
        protected void ButtonRefresh_Click(object sender, EventArgs e)
        {
            Сaptcha captcha = new Сaptcha();
            captcha.CreateCaptcha(this.Context);
            Panel1.Visible = true;
        }


    }
}