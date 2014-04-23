using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyORMx;
using MyORMx.Interfaces;
using MyORMx.AccessorsClasses;
using System.Data.SqlServerCe;
using  NLog;


namespace MyWinFormProject
{
    public partial class Form1 : Form,Chief
    {
         private Logger logger = LogManager.GetCurrentClassLogger();

         IAccessor accessor;
         IAccessor accessorbinary=new AccessorBinarry();
         IAccessor accessroxml = new AccessorXML();
         IAccessor accessordb = new AccessorDB();
         Client client = new Client();
         Person p = null;
         int index = 0;

         string action="addperson";
        

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "SUPER PROGRAM";

            radioAddPerson.Text = "Add person";
            radioRemovePerson.Text = "Remove person";
            radioInsertPerson.Text = "Insert person";
            radioGetPersonByIndex.Text = "Get perosn by index";
            radioShowAll.Text = "Show all";
            radioCount.Text = "Count";
            radioClear.Text = "Clear";

            labelName.Text = "Name:";
            labelAge.Text = "Age:";
            labelIndex.Text = "Index:";

            labelName.Visible = false;
            labelAge.Visible = false;
            textboxName.Visible = false;
            textboxAge.Visible = false;
            labelIndex.Visible = false;
            textBoxIndex.Visible = false;

            radioBinary.Checked = true;
            radioBinary.Text = "Binary file";
            radioXML.Text = "XML file";
            radioDB.Text = "Data base";

            buttonOk.Text = "ok";
            
           
            accessor = new AccessorBinarry();

            textboxName.MaxLength = 25;
            textboxAge.MaxLength = 3;
            textBoxIndex.MaxLength = 4;
        }

        

        public void AddPERSON()
        {
            richTextBox1.Clear();
            p = new Person() { Name = textboxName.Text, Age = Convert.ToInt32(textboxAge.Text) };

            try
            {
                client.AddPerson(p, accessor);
                richTextBox1.Text = "ok\n";
            }
            catch (System.Data.SqlServerCe.SqlCeException e)
            {
                logger.Error(e.Message);
                logger.Error(e.StackTrace);
                MessageBox.Show(e.Message);
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
                logger.Error(e.StackTrace);
                MessageBox.Show(e.Message);
            }

        }

        public void RemovePERSON()
        {
            richTextBox1.Clear();
            try
            {
                client.RemovePerson(textboxName.Text, accessor);
                 richTextBox1.Text = "ok\n";
            }
            catch (System.Data.SqlServerCe.SqlCeException e)
            {
                logger.Error(e.Message);
                logger.Error(e.StackTrace);
                MessageBox.Show(e.Message);
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
                logger.Error(e.StackTrace);
                MessageBox.Show(e.Message);
            }
            
        }

        public void InsertPERSON()
        {
            richTextBox1.Clear();
            index = Convert.ToInt32(textBoxIndex.Text);
            p = new Person() { Name = textboxName.Text, Age = Convert.ToInt32(textboxAge.Text) };
            try
            {
                client.InsertPerson(index, p, accessor);
                richTextBox1.Text = "ok\n";
            }
            catch (System.Data.SqlServerCe.SqlCeException e)
            {
                logger.Error(e.Message);
                logger.Error(e.StackTrace);
                MessageBox.Show(e.Message);
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
                logger.Error(e.StackTrace);
                MessageBox.Show(e.Message);
            }
            
        }

        public void showALL()
        {
            richTextBox1.Clear();
            try
            {
                var persons = client.GetAllPerson(accessor);
                foreach (var i in persons) 
                {
                    richTextBox1.AppendText(i.Name + "  " + i.Age + "\n");
                }
            }
            catch (System.Data.SqlServerCe.SqlCeException e)
            {
                logger.Error(e.Message);
                logger.Error(e.StackTrace);
                MessageBox.Show(e.Message);
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
                logger.Error(e.StackTrace);
                MessageBox.Show(e.Message);
            }
            

        }

        public void Clear()
        {
            richTextBox1.Clear();
            try
            {
                client.Clear(accessor);
                richTextBox1.Text = "ok\n";
            }
            catch (System.Data.SqlServerCe.SqlCeException e)
            {
                logger.Error(e.Message);
                logger.Error(e.StackTrace);
                MessageBox.Show(e.Message);
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
                logger.Error(e.StackTrace);
                MessageBox.Show(e.Message);
            }
            
        }

        public void GetPersonByIndex()
        {
            richTextBox1.Clear();
            try
            {
                Person temp = client.GetPersonByIndex(index, accessor);//**

                try
                {
                    string message = temp.Name + "   " + temp.Age + "\n";
                    richTextBox1.AppendText(message);
                }
                catch { richTextBox1.AppendText("такого индекса нет"); }
            }
            catch (System.Data.SqlServerCe.SqlCeException e)
            {
                logger.Error(e.Message);
                logger.Error(e.StackTrace);
                MessageBox.Show(e.Message);
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
                logger.Error(e.StackTrace);
                MessageBox.Show(e.Message);
            }
            
        }

        public void Count()
        {
            richTextBox1.Clear();
            try
            {
                int count = client.Count(accessor);
                richTextBox1.AppendText(count.ToString()+"\n" );
            }
            catch (System.Data.SqlServerCe.SqlCeException e)
            {
                logger.Error(e.Message);
                logger.Error(e.StackTrace);
                MessageBox.Show(e.Message);
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
                logger.Error(e.StackTrace);
                MessageBox.Show(e.Message);
            }
            
        }



        //select action
        private void radioAddPerson_CheckedChanged(object sender, EventArgs e)
        {
            labelName.Visible = true;
            labelAge.Visible = true;
            textboxName.Visible = true;
            textboxAge.Visible = true;
            labelIndex.Visible = false;
            textBoxIndex.Visible = false;
            action = "addperson";
        }

        private void radioRemovePerson_CheckedChanged(object sender, EventArgs e)
        {
            labelName.Visible = true;
            labelAge.Visible = false;
            textboxName.Visible = true;
            textboxAge.Visible = false;
            labelIndex.Visible = false;
            textBoxIndex.Visible = false;
            action = "removeperson";
        }

        private void radioInsertPerson_CheckedChanged(object sender, EventArgs e)
        {
            labelName.Visible = true;
            labelAge.Visible = true;
            textboxName.Visible = true;
            textboxAge.Visible = true;
            labelIndex.Visible = true;
            textBoxIndex.Visible = true;
            action = "insertperson";
        }

        private void radioGetPersonByIndex_CheckedChanged(object sender, EventArgs e)
        {
            labelName.Visible = false;
            labelAge.Visible = false;
            textboxName.Visible = false;
            textboxAge.Visible = false;
            labelIndex.Visible = true;
            textBoxIndex.Visible = true;
            action = "getpersonbyindex";
        }

        private void radioShowAll_CheckedChanged(object sender, EventArgs e)
        {
            labelName.Visible = false;
            labelAge.Visible = false;
            textboxName.Visible = false;
            textboxAge.Visible = false;
            labelIndex.Visible = false;
            textBoxIndex.Visible = false;
            action = "showall";
        }

        private void radioCount_CheckedChanged(object sender, EventArgs e)
        {
            labelName.Visible = false;
            labelAge.Visible = false;
            textboxName.Visible = false;
            textboxAge.Visible = false;
            labelIndex.Visible = false;
            textBoxIndex.Visible = false;
            action = "count";
        }

        private void radioClear_CheckedChanged(object sender, EventArgs e)
        {
            labelName.Visible = false;
            labelAge.Visible = false;
            textboxName.Visible = false;
            textboxAge.Visible = false;
            labelIndex.Visible = false;
            textBoxIndex.Visible = false;
            action = "clear";
        }


        //select accessor
        private void radioBinary_CheckedChanged(object sender, EventArgs e)
        {
            accessor = accessorbinary;
        }

        private void radioXML_CheckedChanged(object sender, EventArgs e)
        {
            accessor = accessroxml;
        }

        private void radioDB_CheckedChanged(object sender, EventArgs e)
        {
            accessor = accessordb;
        }


        //action
        private void buttonOk_Click(object sender, EventArgs e)
        {

            if (textBoxIndex.Text != "")
            {
                index = Convert.ToInt32(textBoxIndex.Text);
            }

            Client client = new Client();
            switch (action) 
            {
                case ("addperson"):
                    AddPERSON();
                    break;
                case("removeperson"):
                    RemovePERSON();
                    break;
                case("insertperson"):
                    InsertPERSON();
                     break;
                case("getpersonbyindex"):
                     GetPersonByIndex();
                     break;
                case("count"):
                     Count();
                     break;
                case("clear"):
                     Clear();
                     break;
                case("showall"):
                     showALL();
                     break;

                    
            }
        }

        //age enter only number 
        private void textboxAge_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) == true) return;
            if (e.KeyChar == Convert.ToChar(Keys.Back)) return;
            e.Handled = true;
        }

        //index enter only number
        private void textBoxIndex_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) == true) return;
            if (e.KeyChar == Convert.ToChar(Keys.Back)) return;
            e.Handled = true;
        }
    }
}
