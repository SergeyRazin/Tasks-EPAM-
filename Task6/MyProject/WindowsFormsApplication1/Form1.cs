using System;
using System.Data;
using System.Windows.Forms;
using MyProject;
using MyProject.AccessorsClasses;
using MyProject.DataClasses;
using MyProject.Interfaces;
using Ninject;
using NLog;


namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
       private IKernel _ninjectKernel = new StandardKernel(new SimpleConfigurationModule());

        private Logger logger = LogManager.GetCurrentClassLogger();

        DataTable table = new DataTable();


        IAccessor _accessor;
        //IAccessor accessorbinary = new AccessorBinarry();
        //IAccessor accessroxml = new AccessorXML();
        //IAccessor accessordb = new AccessorDB();
         Client _client = new Client();
        Person _p = null;
        int _index = 0;

        string action = "addperson";

        public Form1()
        {
            InitializeComponent();
        }

        //СОБЫТИЕ ЗАГРУЗКИ ФОРМЫ
        private void Form1_Load(object sender0, EventArgs e0)
        {
            this.Text = "SUPER PROGRAM";

            //даем названия столбцов таблицы для DataGridViev
            table.Columns.Add("Index");
            table.Columns.Add("Name");
            table.Columns.Add("Age");
            table.Columns.Add("Phone");

            radioAddPerson.Text = "Add person";
            radioRemovePerosn.Text = "Remove person";
            radioUpdatePerson.Text = "Update person";
            radioGetPersonByIndex.Text = "Get perosn by index";
            radioShowAll.Text = "Show all";
            radioCount.Text = "Count";
            radioClear.Text = "Clear";

            labelName.Text = "Name:";
            labelAge.Text = "Age:";
            labelIndex.Text = "Index:";
            labelPhone.Text = "Phone";

            labelName.Enabled = false;
            labelAge.Enabled = false;
            textboxAge.Enabled = false;
            textboxName.Enabled = false;
            textboxName.Enabled = false;
            labelIndex.Enabled = false;
            textboxIndex.Enabled = false;
            textboxPhone.Enabled = false;
            labelPhone.Enabled = false;
            buttonOk.Enabled = false;


            radioBinary.Checked = true;
            radioBinary.Text = "Binary file";
            radioXML.Text = "XML file";
            radioDB.Text = "Data base";

            buttonOk.Text = "ok";


            _accessor = new AccessorBinarry();

            textboxName.MaxLength = 25;
            textboxAge.MaxLength = 3;
            textboxIndex.MaxLength = 4;
            textboxPhone.MaxLength = 50;
        }

        //ОСНОВНЫЕ МЕТОДЫ
        private void AddPerson()
        {
            table.Clear();

            _p = new Person() { Name = textboxName.Text, Age = Convert.ToInt32(textboxAge.Text),Phone = textboxPhone.Text};

            try
            {
                _client.AddPerson(_p, _accessor);
                ShowAll();
            }
            catch (System.Data.SqlServerCe.SqlCeException e)
            {
                logger.Error(e.Message);
                logger.Error(e.StackTrace);
                MessageBox.Show("ERROR");
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
                logger.Error(e.StackTrace);
                MessageBox.Show("ERROR");
            }

        }

        private void RemovePerson()
        {
            table.Clear();

            try
            {
                _client.RemovePerson(Convert.ToInt32(textboxIndex.Text), _accessor);
                ShowAll();
            }
            catch (System.Data.SqlServerCe.SqlCeException e)
            {
                logger.Error(e.Message);
                logger.Error(e.StackTrace);
                MessageBox.Show("ERROR");
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
                logger.Error(e.StackTrace);
                MessageBox.Show("ERROR");
            }
        }

        private void UpdatePerson()
        {
            table.Clear();

            string name = "";
            int age = 0;
            string phone = "";

            if (String.IsNullOrEmpty(textboxName.Text))
            {
                MessageBox.Show("заполните имя.");
            }

            if (!string.IsNullOrEmpty(textboxName.Text))
            {
                if (!String.IsNullOrEmpty(textboxIndex.Text))
                    _index = Convert.ToInt32(textboxIndex.Text);

                if (!String.IsNullOrEmpty(textboxName.Text))
                    name = textboxName.Text;

                if (!String.IsNullOrEmpty(textboxAge.Text))
                    age = Convert.ToInt32(textboxAge.Text);

                if (!String.IsNullOrEmpty(textboxPhone.Text))
                    phone = textboxPhone.Text;

                try
                {
                    _client.UpdatePerson(_index, name, age, phone, _accessor);
                    GetPersonByIndex();
                }
                catch (ArgumentOutOfRangeException e)
                {
                    logger.Error(e.Message);
                    logger.Error(e.StackTrace);
                    MessageBox.Show("Персоны с таким индексом не существует!");
                }
                catch (System.Data.SqlServerCe.SqlCeException e)
                {
                    logger.Error(e.Message);
                    logger.Error(e.StackTrace);
                    MessageBox.Show("ERROR");
                }
                catch (Exception e)
                {
                    logger.Error(e.Message);
                    logger.Error(e.StackTrace);
                    MessageBox.Show("ERROR");
                }
            }
        }

        private void ShowAll()
        {
            table.Clear();
            try
            {
                var persons = _client.GetAllPerson(_accessor);

                foreach (var i in persons)
                {
                    table.Rows.Add(i.ID, i.Name, i.Age, i.Phone);
                }
                dataGridView1.DataSource = table;
            }
            catch (System.Data.SqlServerCe.SqlCeException e)
            {
                logger.Error(e.Message);
                logger.Error(e.StackTrace);
                MessageBox.Show("ERROR");
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
                logger.Error(e.StackTrace);
                MessageBox.Show("ERROR");
            }
        }

        private void Clear()
        {
            table.Clear();
            try
            {
                _client.Clear(_accessor);
                ShowAll();
            }
            catch (System.Data.SqlServerCe.SqlCeException e)
            {
                logger.Error(e.Message);
                logger.Error(e.StackTrace);
                MessageBox.Show("ERROR");
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
                logger.Error(e.StackTrace);
                MessageBox.Show("ERROR");
            }

        }

        private void GetPersonByIndex()
        {
            table.Clear();
            try
            {
                Person temp = _client.GetPersonByIndex(_index, _accessor);

                try
                {
                    table.Clear();
                    table.Rows.Add(temp.ID, temp.Name, temp.Age, temp.Phone);
                    dataGridView1.DataSource = table;
                }
                catch { MessageBox.Show("такого индекса нет"); }
            }
            catch (System.Data.SqlServerCe.SqlCeException e)
            {
                logger.Error(e.Message);
                logger.Error(e.StackTrace);
                MessageBox.Show("ERROR");
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
                logger.Error(e.StackTrace);
                MessageBox.Show("ERROR");
            }

        }

        private void Count()
        {
            //table.Clear();
            try
            {
                int count = _client.Count(_accessor);
                MessageBox.Show("Количество персон "+count);
            }
            catch (System.Data.SqlServerCe.SqlCeException e)
            {
                logger.Error(e.Message);
                logger.Error(e.StackTrace);
                MessageBox.Show("ERROR");
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
                logger.Error(e.StackTrace);
                MessageBox.Show("ERROR");
            }

        }


        // SELECT ACTION (СОБЫТИЯ)
        private void radioAddPerson_CheckedChanged(object sender0, EventArgs e0)
        {
            labelName.Enabled = true;
            labelAge.Enabled = true;
            textboxName.Enabled = true;
            textboxAge.Enabled = true;
            labelIndex.Enabled = false;
            textboxIndex.Enabled = false;
            labelPhone.Enabled = true;
            textboxPhone.Enabled = true;
            buttonOk.Enabled = true;
            action = "addperson";
        }

        private void radioRemovePerosn_CheckedChanged(object sender0, EventArgs e0)
        {
            labelName.Enabled = false;
            labelAge.Enabled = false;
            textboxName.Enabled = false;
            textboxAge.Enabled = false;
            labelIndex.Enabled = true;
            textboxIndex.Enabled = true;
            textboxPhone.Enabled = false;
            labelPhone.Enabled = false;
            buttonOk.Enabled = true;
            action = "removeperson";
        }

        private void radioGetPersonByIndex_CheckedChanged(object sender0, EventArgs e0)
        {
            labelName.Enabled = false;
            labelAge.Enabled = false;
            textboxName.Enabled = false;
            textboxAge.Enabled = false;
            labelIndex.Enabled = true;
            textboxIndex.Enabled = true;
            textboxPhone.Enabled = false;
            labelPhone.Enabled = false;
            buttonOk.Enabled = true;
            action = "getpersonbyindex";
        }

        private void radioShowAll_CheckedChanged(object sender0, EventArgs e0)
        {
            labelName.Enabled = false;
            labelAge.Enabled = false;
            textboxName.Enabled = false;
            textboxAge.Enabled = false;
            labelIndex.Enabled = false;
            textboxIndex.Enabled = false;
            textboxPhone.Enabled = false;
            labelPhone.Enabled = false;
            buttonOk.Enabled = true;
            action = "showall";
        }

        private void radioCount_CheckedChanged(object sender0, EventArgs e0)
        {
            labelName.Enabled = false;
            labelAge.Enabled = false;
            textboxName.Enabled = false;
            textboxAge.Enabled = false;
            labelIndex.Enabled = false;
            textboxIndex.Enabled = false;
            textboxPhone.Enabled = false;
            labelPhone.Enabled = false;
            buttonOk.Enabled = true;
            action = "count";
        }

        private void radioClear_CheckedChanged(object sender0, EventArgs e0)
        {
            labelName.Enabled = false;
            labelAge.Enabled = false;
            textboxName.Enabled = false;
            textboxAge.Enabled = false;
            labelIndex.Enabled = false;
            textboxIndex.Enabled = false;
            textboxPhone.Enabled = false;
            labelPhone.Enabled = false;
            buttonOk.Enabled = true;
            action = "clear";
        }

        private void radioUpdatePerson_CheckedChanged(object sender0, EventArgs e0)
        {
            labelName.Enabled = true;
            labelAge.Enabled = true;
            textboxName.Enabled = true;
            textboxAge.Enabled = true;
            labelIndex.Enabled = true;
            textboxIndex.Enabled = true;
            textboxPhone.Enabled = true;
            labelPhone.Enabled = true;
            buttonOk.Enabled = true;
            action = "updateperson";
        }


        //SELECT ACCESSOR (СОБЫТИЯ)
        private void radioBinary_CheckedChanged(object sender0, EventArgs e0)
        {
            _accessor = _ninjectKernel.Get<AccessorBinarry>();
        }

        private void radioXML_CheckedChanged(object sender0, EventArgs e0)
        {
            _accessor = _ninjectKernel.Get<AccessorXML>();
        }

        private void radioDB_CheckedChanged(object sender0, EventArgs e0)
        {
            _accessor = _ninjectKernel.Get<AccessorDB>(); ;
        }

        


        //ACTION (СОБЫТИЯ)
        private void buttonOk_Click(object sender0, EventArgs e0)
        {
            if (textboxIndex.Text != "")
            {
                _index = Convert.ToInt32(textboxIndex.Text);
            }

            Client client = new Client();
            switch (action)
            {
                case ("addperson"):
                    AddPerson();
                    break;
                case ("removeperson"):
                    RemovePerson();
                    break;
                case ("updateperson"):
                    UpdatePerson();
                    break;
                case ("getpersonbyindex"):
                    GetPersonByIndex();
                    break;
                case ("count"):
                    Count();
                    break;
                case ("clear"):
                    Clear();
                    break;
                case ("showall"):
                    ShowAll();
                    break;


            }
        }
        
        //enter only number into textboxIndex
        private void textboxIndex_KeyPress(object sender0, KeyPressEventArgs e0)
        {
            if (Char.IsDigit(e0.KeyChar) == true) return;
            if (e0.KeyChar == Convert.ToChar(Keys.Back)) return;
            e0.Handled = true;
        }
        
        //enter only number into textboxAge
        private void textboxAge_KeyPress(object sender0, KeyPressEventArgs e0)
        {
            if (Char.IsDigit(e0.KeyChar) == true) return;
            if (e0.KeyChar == Convert.ToChar(Keys.Back)) return;
            e0.Handled = true;
        }
    }
}
