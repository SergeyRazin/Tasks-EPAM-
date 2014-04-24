using System;
using System.Data;
using System.Drawing;
using System.Web.UI.WebControls;
using MyProject;
using MyProject.AccessorsClasses;
using MyProject.DataClasses;
using MyProject.Interfaces;
using Ninject;
using NLog;

namespace WebApplication1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        //создаем объект (маршрутизатор)
        private IKernel _ninjectKernel = new StandardKernel(new SimpleConfigurationModule());

        //лог находится в C:\Program Files (x86)\IIS Express
        private Logger logger = LogManager.GetCurrentClassLogger();

        DataTable Table = new DataTable();

        private IAccessor _accessor;
        //private IAccessor _accessorbinary = new AccessorBinarry();
        //private IAccessor _accessorxml = new AccessorXML();
        //private IAccessor _accessordb = new AccessorDB();

        private Client _client = new Client();

        private Person _p = null;
        private int _index = 0;


        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "SUPER PROGRAM";

            Table.Columns.Add("Index");
            Table.Columns.Add("Name");
            Table.Columns.Add("Age");
            Table.Columns.Add("Phone");

            radioAddPerson.Text = "Add Person";
            radioRemovePerson.Text = "Remove Person";
            radioUpdatePerson.Text = "Update Person";
            radioGetPersonByIndex.Text = "Get Person by Index";
            radioShowAll.Text = "Show All";
            radioCount.Text = "Count";
            radioClear.Text = "Clear";


            labelName.Text = "Name";
            labelAge.Text = "Age";
            labelIndex.Text = "Index";
            labelPhone.Text = "Phone";

            radioBinary.Checked = true;
            radioBinary.Text = "Binary File";
            radioXML.Text = "XML File";
            radioDB.Text = "Data Base";

            Button1.Text = "ok";

            textboxName.MaxLength = 25;
            textboxAge.MaxLength = 3;
            textboxIndex.MaxLength = 4;


            CompareValidator1.ControlToValidate = "textboxAge";
            CompareValidator1.EnableClientScript = false;
            CompareValidator1.Type = ValidationDataType.Integer;
            CompareValidator1.Operator = ValidationCompareOperator.DataTypeCheck;
            CompareValidator1.ErrorMessage = "*Следует вводить числа!";

            CompareValidator2.ControlToValidate = "textboxIndex";
            CompareValidator2.EnableClientScript = false;
            CompareValidator2.Type = ValidationDataType.Integer;
            CompareValidator2.Operator = ValidationCompareOperator.DataTypeCheck;
            CompareValidator2.ErrorMessage = "*Следует вводить числа!";
        }

        public void AddPERSON()
        {
            if (textboxName.Text == string.Empty || textboxAge.Text == string.Empty)
            {
                labelError.Text = "Заполните имя и возраст!";
                labelError.ForeColor = Color.Red;
                return;
            }

            int tempAge = textboxAge.Text == string.Empty ? 0 : Convert.ToInt32(textboxAge.Text);



            Table.Clear();
            _p = new Person() { Name = textboxName.Text, Age = tempAge,Phone = textboxPhone.Text};

            try
            {
                _client.AddPerson(_p, _accessor);
                showALL();
            }
            catch (System.Data.SqlServerCe.SqlCeException e)
            {
                logger.Error(e.Message);
                logger.Error(e.StackTrace);
                labelError.Text = e.Message;
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
                logger.Error(e.StackTrace);
                labelError.Text = e.Message;
            }

        }

        public void RemovePERSON()
        {
            if (textboxIndex.Text == string.Empty)
            {
                labelError.Text = "Заполните индекс!";
                return;
            }
            Table.Clear();
            try
            {
                if (String.IsNullOrEmpty(textboxIndex.Text))
                {
                    labelError.Text = "*заполните индекс";
                    return;
                }
                _client.RemovePerson(Convert.ToInt32(textboxIndex.Text), _accessor);
                showALL();
            }
            catch (ArgumentOutOfRangeException e)
            {
                logger.Error(e.Message);
                logger.Error(e.StackTrace);
                labelError.Text = "такого индекса нет";
            }
            catch (System.Data.SqlServerCe.SqlCeException e)
            {
                logger.Error(e.Message);
                logger.Error(e.StackTrace);
                labelError.Text = e.Message;
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
                logger.Error(e.StackTrace);
                labelError.Text = e.Message;
            }

        }

        public void UpdatePERSON()
        {
            if (textboxName.Text == string.Empty || textboxAge.Text == string.Empty)
            {
                labelError.Text = "Заполните имя и возраст!";
                return;
            }

            if (textboxIndex.Text == string.Empty)
            {
                labelError.Text = "Заполните индекс!";
                return;
            }

            if (textboxName.Text != string.Empty && textboxAge.Text != string.Empty && textboxIndex.Text != string.Empty)
            {
                labelError.Text = "";
                _index = Convert.ToInt32(textboxIndex.Text);
                _p = new Person() { Name = textboxName.Text, Age = Convert.ToInt32(textboxAge.Text) };
                try
                {
                    _client.UpdatePerson(_index, textboxName.Text, _p.Age, textboxPhone.Text, _accessor);
                    showALL();
                }
                catch (ArgumentOutOfRangeException e)
                {
                    logger.Error(e.Message);
                    logger.Error(e.StackTrace);
                    labelError.Text = "Такого индекса нет";
                }
                catch (System.Data.SqlServerCe.SqlCeException e)
                {
                    logger.Error(e.Message);
                    logger.Error(e.StackTrace);
                    labelError.Text = "ошибка работы с базой данных";
                }
                catch (Exception e)
                {
                    logger.Error(e.Message);
                    logger.Error(e.StackTrace);
                    labelError.Text = "ERROR";
                }

            }

        }

        public void showALL()
        {
            labelError.Text = "";

            try
            {
                Table.Clear();
                var persons = _client.GetAllPerson(_accessor);
                string temp = string.Empty;
                foreach (var i in persons)
                {
                    Table.Rows.Add(i.ID,i.Name,i.Age,i.Phone);
                }
                GridView1.DataSource = Table;
                GridView1.DataBind();
            }
            catch (System.Data.SqlServerCe.SqlCeException e)
            {
                logger.Error(e.Message);
                logger.Error(e.StackTrace);
                labelError.Text = e.Message;
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
                logger.Error(e.StackTrace);
                labelError.Text = e.Message;
            }

        }

        public void Clear()
        {
            Table.Clear();
            try
            {
                _client.Clear(_accessor);
                showALL();
            }
            catch (System.Data.SqlServerCe.SqlCeException e)
            {
                logger.Error(e.Message);
                logger.Error(e.StackTrace);
                labelError.Text = e.Message;
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
                logger.Error(e.StackTrace);
                labelError.Text = e.Message;
            }

        }

        public void GetPersonByIndex()
        {
            if (textboxIndex.Text == string.Empty)
            {
                labelError.Text = "Заполните индекс!";
                return;
            }

            Table.Clear();
            try
            {
                Person temp = _client.GetPersonByIndex(_index, _accessor);

                Table.Rows.Add(temp.ID, temp.Name, temp.Age, temp.Phone);
                GridView1.DataSource = Table;
                GridView1.DataBind();
            }
            catch (ArgumentOutOfRangeException e)
            {
                logger.Error(e.Message);
                logger.Error(e.StackTrace);
                labelError.Text = "такого индекса нет";
            }
            catch (System.Data.SqlServerCe.SqlCeException e)
            {
                logger.Error(e.Message);
                logger.Error(e.StackTrace);
                labelError.Text = e.Message;
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
                logger.Error(e.StackTrace);
                labelError.Text = e.Message;
            }

        }

        public void Count()
        {
            Table.Clear();
            try
            {
                Table.Columns[0].ColumnName = ".";
                Table.Columns[1].ColumnName = "количество персон.";
                Table.Columns[2].ColumnName = "..";
                Table.Columns[3].ColumnName = "...";

                int count = _client.Count(_accessor);
                Table.Rows.Add("", count);
                GridView1.DataSource = Table;
                GridView1.DataBind();
            }
            catch (System.Data.SqlServerCe.SqlCeException e)
            {
                logger.Error(e.Message);
                logger.Error(e.StackTrace);
                labelError.Text = e.Message;
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
                logger.Error(e.StackTrace);
                labelError.Text = e.Message;
            }

        }

        //action
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid) return;

            //select accessor
            if (radioBinary.Checked)
                _accessor = _ninjectKernel.Get<AccessorBinarry>();
            if (radioXML.Checked)
                _accessor = _ninjectKernel.Get<AccessorXML>();
            if (radioDB.Checked)
                _accessor = _ninjectKernel.Get<AccessorDB>();

            if (textboxIndex.Text != "")
            {
                _index = Convert.ToInt32(textboxIndex.Text);
            }


            if (radioAddPerson.Checked == false && radioRemovePerson.Checked == false &&
                radioUpdatePerson.Checked == false && radioGetPersonByIndex.Checked == false &&
                radioShowAll.Checked == false && radioCount.Checked == false && radioCount.Checked == false && radioClear.Checked==false)
            {
                labelError.Text = "выберите одно из действий";
            }
            //select accessor
            if (radioAddPerson.Checked)
                AddPERSON();
            if (radioRemovePerson.Checked)
                RemovePERSON();
            if (radioUpdatePerson.Checked)
                UpdatePERSON();
            if (radioGetPersonByIndex.Checked)
                GetPersonByIndex();
            if (radioShowAll.Checked)
                showALL();
            if (radioCount.Checked)
                Count();
            if (radioClear.Checked)
                Clear();
        }

    }
}