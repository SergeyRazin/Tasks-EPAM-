namespace MyWinFormProject
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
            this.radioAddPerson = new System.Windows.Forms.RadioButton();
            this.radioRemovePerson = new System.Windows.Forms.RadioButton();
            this.radioInsertPerson = new System.Windows.Forms.RadioButton();
            this.radioGetPersonByIndex = new System.Windows.Forms.RadioButton();
            this.radioShowAll = new System.Windows.Forms.RadioButton();
            this.radioCount = new System.Windows.Forms.RadioButton();
            this.radioClear = new System.Windows.Forms.RadioButton();
            this.textboxName = new System.Windows.Forms.TextBox();
            this.textboxAge = new System.Windows.Forms.TextBox();
            this.labelName = new System.Windows.Forms.Label();
            this.labelAge = new System.Windows.Forms.Label();
            this.textBoxIndex = new System.Windows.Forms.TextBox();
            this.labelIndex = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.radioDB = new System.Windows.Forms.RadioButton();
            this.radioXML = new System.Windows.Forms.RadioButton();
            this.radioBinary = new System.Windows.Forms.RadioButton();
            this.buttonOk = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // radioAddPerson
            // 
            this.radioAddPerson.AutoSize = true;
            this.radioAddPerson.Location = new System.Drawing.Point(3, 3);
            this.radioAddPerson.Name = "radioAddPerson";
            this.radioAddPerson.Size = new System.Drawing.Size(85, 17);
            this.radioAddPerson.TabIndex = 0;
            this.radioAddPerson.TabStop = true;
            this.radioAddPerson.Text = "radioButton1";
            this.radioAddPerson.UseVisualStyleBackColor = true;
            this.radioAddPerson.CheckedChanged += new System.EventHandler(this.radioAddPerson_CheckedChanged);
            // 
            // radioRemovePerson
            // 
            this.radioRemovePerson.AutoSize = true;
            this.radioRemovePerson.Location = new System.Drawing.Point(111, 3);
            this.radioRemovePerson.Name = "radioRemovePerson";
            this.radioRemovePerson.Size = new System.Drawing.Size(85, 17);
            this.radioRemovePerson.TabIndex = 1;
            this.radioRemovePerson.TabStop = true;
            this.radioRemovePerson.Text = "radioButton2";
            this.radioRemovePerson.UseVisualStyleBackColor = true;
            this.radioRemovePerson.CheckedChanged += new System.EventHandler(this.radioRemovePerson_CheckedChanged);
            // 
            // radioInsertPerson
            // 
            this.radioInsertPerson.AutoSize = true;
            this.radioInsertPerson.Location = new System.Drawing.Point(220, 3);
            this.radioInsertPerson.Name = "radioInsertPerson";
            this.radioInsertPerson.Size = new System.Drawing.Size(85, 17);
            this.radioInsertPerson.TabIndex = 2;
            this.radioInsertPerson.TabStop = true;
            this.radioInsertPerson.Text = "radioButton3";
            this.radioInsertPerson.UseVisualStyleBackColor = true;
            this.radioInsertPerson.CheckedChanged += new System.EventHandler(this.radioInsertPerson_CheckedChanged);
            // 
            // radioGetPersonByIndex
            // 
            this.radioGetPersonByIndex.AutoSize = true;
            this.radioGetPersonByIndex.Location = new System.Drawing.Point(359, 3);
            this.radioGetPersonByIndex.Name = "radioGetPersonByIndex";
            this.radioGetPersonByIndex.Size = new System.Drawing.Size(85, 17);
            this.radioGetPersonByIndex.TabIndex = 3;
            this.radioGetPersonByIndex.TabStop = true;
            this.radioGetPersonByIndex.Text = "radioButton4";
            this.radioGetPersonByIndex.UseVisualStyleBackColor = true;
            this.radioGetPersonByIndex.CheckedChanged += new System.EventHandler(this.radioGetPersonByIndex_CheckedChanged);
            // 
            // radioShowAll
            // 
            this.radioShowAll.AutoSize = true;
            this.radioShowAll.Location = new System.Drawing.Point(492, 3);
            this.radioShowAll.Name = "radioShowAll";
            this.radioShowAll.Size = new System.Drawing.Size(85, 17);
            this.radioShowAll.TabIndex = 4;
            this.radioShowAll.TabStop = true;
            this.radioShowAll.Text = "radioButton5";
            this.radioShowAll.UseVisualStyleBackColor = true;
            this.radioShowAll.CheckedChanged += new System.EventHandler(this.radioShowAll_CheckedChanged);
            // 
            // radioCount
            // 
            this.radioCount.AutoSize = true;
            this.radioCount.Location = new System.Drawing.Point(616, 3);
            this.radioCount.Name = "radioCount";
            this.radioCount.Size = new System.Drawing.Size(85, 17);
            this.radioCount.TabIndex = 5;
            this.radioCount.TabStop = true;
            this.radioCount.Text = "radioButton6";
            this.radioCount.UseVisualStyleBackColor = true;
            this.radioCount.CheckedChanged += new System.EventHandler(this.radioCount_CheckedChanged);
            // 
            // radioClear
            // 
            this.radioClear.AutoSize = true;
            this.radioClear.Location = new System.Drawing.Point(741, 3);
            this.radioClear.Name = "radioClear";
            this.radioClear.Size = new System.Drawing.Size(85, 17);
            this.radioClear.TabIndex = 6;
            this.radioClear.TabStop = true;
            this.radioClear.Text = "radioButton7";
            this.radioClear.UseVisualStyleBackColor = true;
            this.radioClear.CheckedChanged += new System.EventHandler(this.radioClear_CheckedChanged);
            // 
            // textboxName
            // 
            this.textboxName.Location = new System.Drawing.Point(56, 113);
            this.textboxName.Name = "textboxName";
            this.textboxName.Size = new System.Drawing.Size(100, 20);
            this.textboxName.TabIndex = 7;
            // 
            // textboxAge
            // 
            this.textboxAge.Location = new System.Drawing.Point(56, 140);
            this.textboxAge.Name = "textboxAge";
            this.textboxAge.Size = new System.Drawing.Size(100, 20);
            this.textboxAge.TabIndex = 8;
            this.textboxAge.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textboxAge_KeyPress);
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(15, 116);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(35, 13);
            this.labelName.TabIndex = 10;
            this.labelName.Text = "label1";
            // 
            // labelAge
            // 
            this.labelAge.AutoSize = true;
            this.labelAge.Location = new System.Drawing.Point(15, 144);
            this.labelAge.Name = "labelAge";
            this.labelAge.Size = new System.Drawing.Size(35, 13);
            this.labelAge.TabIndex = 11;
            this.labelAge.Text = "label2";
            // 
            // textBoxIndex
            // 
            this.textBoxIndex.Location = new System.Drawing.Point(56, 168);
            this.textBoxIndex.Name = "textBoxIndex";
            this.textBoxIndex.Size = new System.Drawing.Size(100, 20);
            this.textBoxIndex.TabIndex = 12;
            this.textBoxIndex.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxIndex_KeyPress);
            // 
            // labelIndex
            // 
            this.labelIndex.AutoSize = true;
            this.labelIndex.Location = new System.Drawing.Point(16, 172);
            this.labelIndex.Name = "labelIndex";
            this.labelIndex.Size = new System.Drawing.Size(35, 13);
            this.labelIndex.TabIndex = 13;
            this.labelIndex.Text = "label1";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.radioAddPerson);
            this.panel1.Controls.Add(this.radioRemovePerson);
            this.panel1.Controls.Add(this.radioInsertPerson);
            this.panel1.Controls.Add(this.radioGetPersonByIndex);
            this.panel1.Controls.Add(this.radioShowAll);
            this.panel1.Controls.Add(this.radioCount);
            this.panel1.Controls.Add(this.radioClear);
            this.panel1.Location = new System.Drawing.Point(18, 58);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(837, 29);
            this.panel1.TabIndex = 17;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.radioDB);
            this.panel2.Controls.Add(this.radioXML);
            this.panel2.Controls.Add(this.radioBinary);
            this.panel2.Location = new System.Drawing.Point(129, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(673, 40);
            this.panel2.TabIndex = 18;
            // 
            // radioDB
            // 
            this.radioDB.AutoSize = true;
            this.radioDB.Location = new System.Drawing.Point(505, 12);
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
            this.radioXML.Location = new System.Drawing.Point(247, 12);
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
            this.radioBinary.Location = new System.Drawing.Point(6, 12);
            this.radioBinary.Name = "radioBinary";
            this.radioBinary.Size = new System.Drawing.Size(85, 17);
            this.radioBinary.TabIndex = 0;
            this.radioBinary.TabStop = true;
            this.radioBinary.Text = "radioButton1";
            this.radioBinary.UseVisualStyleBackColor = true;
            this.radioBinary.CheckedChanged += new System.EventHandler(this.radioBinary_CheckedChanged);
            // 
            // buttonOk
            // 
            this.buttonOk.Location = new System.Drawing.Point(21, 220);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 19;
            this.buttonOk.Text = "ok";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(390, 113);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(223, 167);
            this.richTextBox1.TabIndex = 20;
            this.richTextBox1.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(878, 304);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.labelIndex);
            this.Controls.Add(this.textBoxIndex);
            this.Controls.Add(this.labelAge);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.textboxAge);
            this.Controls.Add(this.textboxName);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton radioAddPerson;
        private System.Windows.Forms.RadioButton radioRemovePerson;
        private System.Windows.Forms.RadioButton radioInsertPerson;
        private System.Windows.Forms.RadioButton radioGetPersonByIndex;
        private System.Windows.Forms.RadioButton radioShowAll;
        private System.Windows.Forms.RadioButton radioCount;
        private System.Windows.Forms.RadioButton radioClear;
        private System.Windows.Forms.TextBox textboxName;
        private System.Windows.Forms.TextBox textboxAge;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label labelAge;
        private System.Windows.Forms.TextBox textBoxIndex;
        private System.Windows.Forms.Label labelIndex;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton radioDB;
        private System.Windows.Forms.RadioButton radioXML;
        private System.Windows.Forms.RadioButton radioBinary;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}

