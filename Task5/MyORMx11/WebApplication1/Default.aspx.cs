using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyORMx;
using MyORMx.AccessorsClasses;
using  NLog;

namespace WebApplication1
{
    public partial class WebForm1 : System.Web.UI.Page
    {

        //лог файл находится в      C:\Program Files (x86)\Common Files\Microsoft Shared\DevServer\11.0
        private Logger logger = LogManager.GetCurrentClassLogger();

        private IAccessor accessor;
        private IAccessor accessorbinary = new AccessorBinarry();
        private IAccessor accessorxml = new AccessorXML();
        private IAccessor accessordb = new AccessorDB();

        private Client client = new Client();

        private Person _p = null;
        private int _index = 0;


        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "SUPER PROGRAM";

            radioAddPerson.Text = "Add Person";
            radionRemovePerson.Text = "Remove Person";
            radioInsertPerson.Text = "Insert Person";
            radioGetPersonByIndex.Text = "Get Person by Index";
            radioShowAll.Text = "Show All";
            radioCount.Text = "Count";
            radioClear.Text = "Clear";


            LabelName.Text = "Name";
            LabelAge.Text = "Age";
            LabelIndex.Text = "Index";

            radioBinary.Checked = true;
            radioBinary.Text = "Binary File";
            radioXML.Text = "XML File";
            radioDB.Text = "Data Base";

            Button1.Text = "ok";

            TextBoxName.MaxLength = 25;
            TextBoxAge.MaxLength = 3;
            TextBoxIndex.MaxLength = 4;
            TextBox1.TextMode = TextBoxMode.MultiLine;

            CompareValidator1.ControlToValidate = "TextBoxAge";
            CompareValidator1.EnableClientScript = false;
            CompareValidator1.Type = ValidationDataType.Integer;
            CompareValidator1.Operator = ValidationCompareOperator.DataTypeCheck;
            CompareValidator1.ErrorMessage = "*Следует вводить числа!";

            CompareValidator2.ControlToValidate = "TextBoxIndex";
            CompareValidator2.EnableClientScript = false;
            CompareValidator2.Type = ValidationDataType.Integer;
            CompareValidator2.Operator = ValidationCompareOperator.DataTypeCheck;
            CompareValidator2.ErrorMessage = "*Следует вводить числа!";
        }

        public void AddPERSON()
        {
            if (TextBoxName.Text == string.Empty || TextBoxAge.Text==string.Empty)
            {
                TextBox1.Text = "Заполните имя и возраст!";
                return;
            }

            int tempAge = TextBoxAge.Text == string.Empty ? 0 : Convert.ToInt32(TextBoxAge.Text);

            

            TextBox1.Text = "";
            _p = new Person() {Name = TextBoxName.Text, Age = tempAge};

            try
            {
                client.AddPerson(_p, accessor);
            }
            catch (System.Data.SqlServerCe.SqlCeException e)
            {
                logger.Error(e.Message);
                logger.Error(e.StackTrace);
                TextBox1.Text = e.Message;
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
                logger.Error(e.StackTrace);
                TextBox1.Text = e.Message;
            }

        }

        public void RemovePERSON()
        {
            if (TextBoxName.Text == string.Empty)
            {
                TextBox1.Text = "Заполните имя персоны, котоую хотите удалить!";
                return;
            }
            TextBox1.Text = "";
            try
            {
                client.RemovePerson(TextBoxName.Text, accessor);
                TextBox1.Text = "ok\n";
            }
            catch (System.Data.SqlServerCe.SqlCeException e)
            {
                logger.Error(e.Message);
                logger.Error(e.StackTrace);
                TextBox1.Text = e.Message;
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
                logger.Error(e.StackTrace);
                TextBox1.Text = e.Message;
            }
            
        }

        public void InsertPERSON()
        {
            if (TextBoxName.Text == string.Empty || TextBoxAge.Text == string.Empty)
            {
                TextBox1.Text = "Заполните имя и возраст!";
                return;
            }

            if (TextBoxIndex.Text == string.Empty)
            {
                TextBox1.Text = "Заполните индекс!";
                return;
            }

            if (TextBoxName.Text != string.Empty && TextBoxAge.Text != string.Empty && TextBoxIndex.Text != string.Empty)
            {
                TextBox1.Text = "";
                _index = Convert.ToInt32(TextBoxIndex.Text);
                _p = new Person() {Name = TextBoxName.Text, Age = Convert.ToInt32(TextBoxAge.Text)};
                try
                {
                    client.InsertPerson(_index, _p, accessor);
                }
                catch (System.Data.SqlServerCe.SqlCeException e)
                {
                    logger.Error(e.Message);
                    logger.Error(e.StackTrace);
                    TextBox1.Text = e.Message;
                }
                catch (Exception e)
                {
                    logger.Error(e.Message);
                    logger.Error(e.StackTrace);
                    TextBox1.Text = e.Message;
                }
                
            }
            
        }

        public void showALL()
        {
            TextBox1.Text = "";

            try
            {
                var persons = client.GetAllPerson(accessor);
                string temp = string.Empty;
                foreach (var i in persons)
                {
                    temp += string.Format("{0}  {1}\n", i.Name, i.Age);
                }
                TextBox1.Text = temp;
            }
            catch (System.Data.SqlServerCe.SqlCeException e)
            {
                logger.Error(e.Message);
                logger.Error(e.StackTrace);
                TextBox1.Text = e.Message;
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
                logger.Error(e.StackTrace);
                TextBox1.Text = e.Message;
            }
            
        }

        public void Clear()
        {
            TextBox1.Text = "";
            try
            {
                client.Clear(accessor);
                TextBox1.Text = "ok\n";
            }
            catch (System.Data.SqlServerCe.SqlCeException e)
            {
                logger.Error(e.Message);
                logger.Error(e.StackTrace);
                TextBox1.Text = e.Message;
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
                logger.Error(e.StackTrace);
                TextBox1.Text = e.Message;
            }
            
        }

        public void GetPersonByIndex()
        {
            if (TextBoxIndex.Text == string.Empty)
            {
                TextBox1.Text = "Заполните индекс!";
                return;
            }

            TextBox1.Text = "";
            try
            {
                Person temp = client.GetPersonByIndex(_index, accessor);

                try
                {
                    string message = string.Format("{0}   {1}\n", temp.Name, temp.Age);
                    TextBox1.Text = message;
                }
                catch
                {
                    TextBox1.Text = ("такого индекса нет");
                }
            }
            catch (System.Data.SqlServerCe.SqlCeException e)
            {
                logger.Error(e.Message);
                logger.Error(e.StackTrace);
                TextBox1.Text = e.Message;
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
                logger.Error(e.StackTrace);
                TextBox1.Text = e.Message;
            }
            
        }

        public void Count()
        {
            TextBox1.Text = "";
            try
            {
                int count = client.Count(accessor);
                TextBox1.Text = count.ToString();
            }
            catch (System.Data.SqlServerCe.SqlCeException e)
            {
                logger.Error(e.Message);
                logger.Error(e.StackTrace);
                TextBox1.Text = e.Message;
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
                logger.Error(e.StackTrace);
                TextBox1.Text = e.Message;
            }
            
        }



        //action
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid) return;

            //select accessor
            string accessorstring = "";
            if (radioBinary.Checked)
                accessor = accessorbinary;
            if (radioXML.Checked)
                accessor = accessorxml;
            if (radioDB.Checked)
                accessor = accessordb;

            if (TextBoxIndex.Text != "")
            {
                _index = Convert.ToInt32(TextBoxIndex.Text);
            }


            if (radioAddPerson.Checked == false && radionRemovePerson.Checked == false &&
                radioInsertPerson.Checked == false && radioGetPersonByIndex.Checked == false &&
                radioShowAll.Checked == false && radioCount.Checked == false && radioCount.Checked == false)
            {
                TextBox1.Text = "выберите одно из действий";
            }
            //select accessor
            if (radioAddPerson.Checked)
                AddPERSON();
            if (radionRemovePerson.Checked)
                RemovePERSON();
            if (radioInsertPerson.Checked)
                InsertPERSON();
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