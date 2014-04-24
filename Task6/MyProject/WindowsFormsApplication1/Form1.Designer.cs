namespace WindowsFormsApplication1
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.radioDB = new System.Windows.Forms.RadioButton();
            this.radioXML = new System.Windows.Forms.RadioButton();
            this.radioBinary = new System.Windows.Forms.RadioButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.radioClear = new System.Windows.Forms.RadioButton();
            this.radioCount = new System.Windows.Forms.RadioButton();
            this.radioAddPerson = new System.Windows.Forms.RadioButton();
            this.radioRemovePerosn = new System.Windows.Forms.RadioButton();
            this.radioShowAll = new System.Windows.Forms.RadioButton();
            this.radioUpdatePerson = new System.Windows.Forms.RadioButton();
            this.radioGetPersonByIndex = new System.Windows.Forms.RadioButton();
            this.labelIndex = new System.Windows.Forms.Label();
            this.textboxIndex = new System.Windows.Forms.TextBox();
            this.labelName = new System.Windows.Forms.Label();
            this.textboxName = new System.Windows.Forms.TextBox();
            this.textboxAge = new System.Windows.Forms.TextBox();
            this.labelAge = new System.Windows.Forms.Label();
            this.textboxPhone = new System.Windows.Forms.TextBox();
            this.labelPhone = new System.Windows.Forms.Label();
            this.buttonOk = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.radioDB);
            this.panel1.Controls.Add(this.radioXML);
            this.panel1.Controls.Add(this.radioBinary);
            this.panel1.Location = new System.Drawing.Point(132, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(648, 54);
            this.panel1.TabIndex = 0;
            // 
            // radioDB
            // 
            this.radioDB.AutoSize = true;
            this.radioDB.Location = new System.Drawing.Point(528, 20);
            this.radioDB.Name = "radioDB";
            this.radioDB.Size = new System.Drawing.Size(85, 17);
            this.radioDB.TabIndex = 2;
            this.radioDB.TabStop = true;
            this.radioDB.Text = "radioButton3";
            this.radioDB.UseVisualStyleBackColor = true;
            this.radioDB.CheckedChanged += new System.EventHandler(this.radioDB_CheckedChanged);
            // 
            // radioXML
            // 
            this.radioXML.AutoSize = true;
            this.radioXML.Location = new System.Drawing.Point(296, 20);
            this.radioXML.Name = "radioXML";
            this.radioXML.Size = new System.Drawing.Size(85, 17);
            this.radioXML.TabIndex = 1;
            this.radioXML.TabStop = true;
            this.radioXML.Text = "radioButton2";
            this.radioXML.UseVisualStyleBackColor = true;
            this.radioXML.CheckedChanged += new System.EventHandler(this.radioXML_CheckedChanged);
            // 
            // radioBinary
            // 
            this.radioBinary.AutoSize = true;
            this.radioBinary.Location = new System.Drawing.Point(41, 20);
            this.radioBinary.Name = "radioBinary";
            this.radioBinary.Size = new System.Drawing.Size(85, 17);
            this.radioBinary.TabIndex = 0;
            this.radioBinary.TabStop = true;
            this.radioBinary.Text = "radioButton1";
            this.radioBinary.UseVisualStyleBackColor = true;
            this.radioBinary.CheckedChanged += new System.EventHandler(this.radioBinary_CheckedChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.radioClear);
            this.panel2.Controls.Add(this.radioCount);
            this.panel2.Controls.Add(this.radioAddPerson);
            this.panel2.Controls.Add(this.radioRemovePerosn);
            this.panel2.Controls.Add(this.radioShowAll);
            this.panel2.Controls.Add(this.radioUpdatePerson);
            this.panel2.Controls.Add(this.radioGetPersonByIndex);
            this.panel2.Location = new System.Drawing.Point(12, 83);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(908, 54);
            this.panel2.TabIndex = 1;
            // 
            // radioClear
            // 
            this.radioClear.AutoSize = true;
            this.radioClear.Location = new System.Drawing.Point(794, 18);
            this.radioClear.Name = "radioClear";
            this.radioClear.Size = new System.Drawing.Size(91, 17);
            this.radioClear.TabIndex = 7;
            this.radioClear.TabStop = true;
            this.radioClear.Text = "radioButton10";
            this.radioClear.UseVisualStyleBackColor = true;
            this.radioClear.CheckedChanged += new System.EventHandler(this.radioClear_CheckedChanged);
            // 
            // radioCount
            // 
            this.radioCount.AutoSize = true;
            this.radioCount.Location = new System.Drawing.Point(683, 18);
            this.radioCount.Name = "radioCount";
            this.radioCount.Size = new System.Drawing.Size(85, 17);
            this.radioCount.TabIndex = 6;
            this.radioCount.TabStop = true;
            this.radioCount.Text = "radioButton9";
            this.radioCount.UseVisualStyleBackColor = true;
            this.radioCount.CheckedChanged += new System.EventHandler(this.radioCount_CheckedChanged);
            // 
            // radioAddPerson
            // 
            this.radioAddPerson.AutoSize = true;
            this.radioAddPerson.Location = new System.Drawing.Point(46, 18);
            this.radioAddPerson.Name = "radioAddPerson";
            this.radioAddPerson.Size = new System.Drawing.Size(85, 17);
            this.radioAddPerson.TabIndex = 1;
            this.radioAddPerson.TabStop = true;
            this.radioAddPerson.Text = "radioButton4";
            this.radioAddPerson.UseVisualStyleBackColor = true;
            this.radioAddPerson.CheckedChanged += new System.EventHandler(this.radioAddPerson_CheckedChanged);
            // 
            // radioRemovePerosn
            // 
            this.radioRemovePerosn.AutoSize = true;
            this.radioRemovePerosn.Location = new System.Drawing.Point(161, 18);
            this.radioRemovePerosn.Name = "radioRemovePerosn";
            this.radioRemovePerosn.Size = new System.Drawing.Size(85, 17);
            this.radioRemovePerosn.TabIndex = 2;
            this.radioRemovePerosn.TabStop = true;
            this.radioRemovePerosn.Text = "radioButton5";
            this.radioRemovePerosn.UseVisualStyleBackColor = true;
            this.radioRemovePerosn.CheckedChanged += new System.EventHandler(this.radioRemovePerosn_CheckedChanged);
            // 
            // radioShowAll
            // 
            this.radioShowAll.AutoSize = true;
            this.radioShowAll.Location = new System.Drawing.Point(552, 18);
            this.radioShowAll.Name = "radioShowAll";
            this.radioShowAll.Size = new System.Drawing.Size(85, 17);
            this.radioShowAll.TabIndex = 5;
            this.radioShowAll.TabStop = true;
            this.radioShowAll.Text = "radioButton8";
            this.radioShowAll.UseVisualStyleBackColor = true;
            this.radioShowAll.CheckedChanged += new System.EventHandler(this.radioShowAll_CheckedChanged);
            // 
            // radioUpdatePerson
            // 
            this.radioUpdatePerson.AutoSize = true;
            this.radioUpdatePerson.Location = new System.Drawing.Point(292, 18);
            this.radioUpdatePerson.Name = "radioUpdatePerson";
            this.radioUpdatePerson.Size = new System.Drawing.Size(85, 17);
            this.radioUpdatePerson.TabIndex = 3;
            this.radioUpdatePerson.TabStop = true;
            this.radioUpdatePerson.Text = "radioButton6";
            this.radioUpdatePerson.UseVisualStyleBackColor = true;
            this.radioUpdatePerson.CheckedChanged += new System.EventHandler(this.radioUpdatePerson_CheckedChanged);
            // 
            // radioGetPersonByIndex
            // 
            this.radioGetPersonByIndex.AutoSize = true;
            this.radioGetPersonByIndex.Location = new System.Drawing.Point(416, 18);
            this.radioGetPersonByIndex.Name = "radioGetPersonByIndex";
            this.radioGetPersonByIndex.Size = new System.Drawing.Size(85, 17);
            this.radioGetPersonByIndex.TabIndex = 4;
            this.radioGetPersonByIndex.TabStop = true;
            this.radioGetPersonByIndex.Text = "radioButton7";
            this.radioGetPersonByIndex.UseVisualStyleBackColor = true;
            this.radioGetPersonByIndex.CheckedChanged += new System.EventHandler(this.radioGetPersonByIndex_CheckedChanged);
            // 
            // labelIndex
            // 
            this.labelIndex.AutoSize = true;
            this.labelIndex.Location = new System.Drawing.Point(13, 201);
            this.labelIndex.Name = "labelIndex";
            this.labelIndex.Size = new System.Drawing.Size(35, 13);
            this.labelIndex.TabIndex = 2;
            this.labelIndex.Text = "label1";
            // 
            // textboxIndex
            // 
            this.textboxIndex.Location = new System.Drawing.Point(71, 201);
            this.textboxIndex.Name = "textboxIndex";
            this.textboxIndex.Size = new System.Drawing.Size(100, 20);
            this.textboxIndex.TabIndex = 3;
            this.textboxIndex.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textboxIndex_KeyPress);
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(13, 242);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(35, 13);
            this.labelName.TabIndex = 4;
            this.labelName.Text = "label2";
            // 
            // textboxName
            // 
            this.textboxName.Location = new System.Drawing.Point(71, 242);
            this.textboxName.Name = "textboxName";
            this.textboxName.Size = new System.Drawing.Size(100, 20);
            this.textboxName.TabIndex = 5;
            // 
            // textboxAge
            // 
            this.textboxAge.Location = new System.Drawing.Point(71, 283);
            this.textboxAge.Name = "textboxAge";
            this.textboxAge.Size = new System.Drawing.Size(100, 20);
            this.textboxAge.TabIndex = 7;
            this.textboxAge.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textboxAge_KeyPress);
            // 
            // labelAge
            // 
            this.labelAge.AutoSize = true;
            this.labelAge.Location = new System.Drawing.Point(12, 283);
            this.labelAge.Name = "labelAge";
            this.labelAge.Size = new System.Drawing.Size(35, 13);
            this.labelAge.TabIndex = 6;
            this.labelAge.Text = "label3";
            // 
            // textboxPhone
            // 
            this.textboxPhone.Location = new System.Drawing.Point(71, 321);
            this.textboxPhone.Name = "textboxPhone";
            this.textboxPhone.Size = new System.Drawing.Size(100, 20);
            this.textboxPhone.TabIndex = 9;
            // 
            // labelPhone
            // 
            this.labelPhone.AutoSize = true;
            this.labelPhone.Location = new System.Drawing.Point(13, 321);
            this.labelPhone.Name = "labelPhone";
            this.labelPhone.Size = new System.Drawing.Size(35, 13);
            this.labelPhone.TabIndex = 8;
            this.labelPhone.Text = "label4";
            // 
            // buttonOk
            // 
            this.buttonOk.Location = new System.Drawing.Point(71, 380);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(100, 54);
            this.buttonOk.TabIndex = 10;
            this.buttonOk.Text = "button1";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(331, 201);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(449, 233);
            this.dataGridView1.TabIndex = 11;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(950, 455);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.textboxPhone);
            this.Controls.Add(this.labelPhone);
            this.Controls.Add(this.textboxAge);
            this.Controls.Add(this.labelAge);
            this.Controls.Add(this.textboxName);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.textboxIndex);
            this.Controls.Add(this.labelIndex);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton radioDB;
        private System.Windows.Forms.RadioButton radioXML;
        private System.Windows.Forms.RadioButton radioBinary;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton radioClear;
        private System.Windows.Forms.RadioButton radioCount;
        private System.Windows.Forms.RadioButton radioAddPerson;
        private System.Windows.Forms.RadioButton radioRemovePerosn;
        private System.Windows.Forms.RadioButton radioShowAll;
        private System.Windows.Forms.RadioButton radioUpdatePerson;
        private System.Windows.Forms.RadioButton radioGetPersonByIndex;
        private System.Windows.Forms.Label labelIndex;
        private System.Windows.Forms.TextBox textboxIndex;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.TextBox textboxName;
        private System.Windows.Forms.TextBox textboxAge;
        private System.Windows.Forms.Label labelAge;
        private System.Windows.Forms.TextBox textboxPhone;
        private System.Windows.Forms.Label labelPhone;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}

