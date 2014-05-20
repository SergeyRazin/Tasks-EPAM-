namespace WinFormsClient
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
            this.panelAccessor = new System.Windows.Forms.Panel();
            this.radioDB = new System.Windows.Forms.RadioButton();
            this.radioXML = new System.Windows.Forms.RadioButton();
            this.radioBinary = new System.Windows.Forms.RadioButton();
            this.panelAction = new System.Windows.Forms.Panel();
            this.radioCountOilfield = new System.Windows.Forms.RadioButton();
            this.radioGetOilfieldByIndex = new System.Windows.Forms.RadioButton();
            this.radioGetAllOilfield = new System.Windows.Forms.RadioButton();
            this.radioUpdateOilfield = new System.Windows.Forms.RadioButton();
            this.radioCountWells = new System.Windows.Forms.RadioButton();
            this.radioCountWellsInOilfield = new System.Windows.Forms.RadioButton();
            this.radioRemoveWell = new System.Windows.Forms.RadioButton();
            this.radioAddWell = new System.Windows.Forms.RadioButton();
            this.radioRemoveOilfield = new System.Windows.Forms.RadioButton();
            this.radioAddOil = new System.Windows.Forms.RadioButton();
            this.radioClear = new System.Windows.Forms.RadioButton();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.buttonOk = new System.Windows.Forms.Button();
            this.panelOil = new System.Windows.Forms.Panel();
            this.labelRezerv = new System.Windows.Forms.Label();
            this.labelNameOil = new System.Windows.Forms.Label();
            this.labelIDOil = new System.Windows.Forms.Label();
            this.textBoxRezerv = new System.Windows.Forms.TextBox();
            this.textBoxNameOil = new System.Windows.Forms.TextBox();
            this.textBoxIdOil = new System.Windows.Forms.TextBox();
            this.panelWells = new System.Windows.Forms.Panel();
            this.labelPump = new System.Windows.Forms.Label();
            this.labelDebit = new System.Windows.Forms.Label();
            this.labelNumber = new System.Windows.Forms.Label();
            this.labelIDOilInWell = new System.Windows.Forms.Label();
            this.labelIDWell = new System.Windows.Forms.Label();
            this.textBoxPump = new System.Windows.Forms.TextBox();
            this.textBoxDebit = new System.Windows.Forms.TextBox();
            this.textBoxNumber = new System.Windows.Forms.TextBox();
            this.textBoxIDOilInWell = new System.Windows.Forms.TextBox();
            this.textBoxIDWell = new System.Windows.Forms.TextBox();
            this.panelAccessor.SuspendLayout();
            this.panelAction.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panelOil.SuspendLayout();
            this.panelWells.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelAccessor
            // 
            this.panelAccessor.Controls.Add(this.radioDB);
            this.panelAccessor.Controls.Add(this.radioXML);
            this.panelAccessor.Controls.Add(this.radioBinary);
            this.panelAccessor.Location = new System.Drawing.Point(13, 13);
            this.panelAccessor.Name = "panelAccessor";
            this.panelAccessor.Size = new System.Drawing.Size(1220, 28);
            this.panelAccessor.TabIndex = 0;
            // 
            // radioDB
            // 
            this.radioDB.AutoSize = true;
            this.radioDB.Location = new System.Drawing.Point(953, 3);
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
            this.radioXML.Location = new System.Drawing.Point(517, 3);
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
            this.radioBinary.Location = new System.Drawing.Point(54, 3);
            this.radioBinary.Name = "radioBinary";
            this.radioBinary.Size = new System.Drawing.Size(85, 17);
            this.radioBinary.TabIndex = 0;
            this.radioBinary.TabStop = true;
            this.radioBinary.Text = "radioButton1";
            this.radioBinary.UseVisualStyleBackColor = true;
            this.radioBinary.CheckedChanged += new System.EventHandler(this.radioBinary_CheckedChanged);
            // 
            // panelAction
            // 
            this.panelAction.Controls.Add(this.radioCountOilfield);
            this.panelAction.Controls.Add(this.radioGetOilfieldByIndex);
            this.panelAction.Controls.Add(this.radioGetAllOilfield);
            this.panelAction.Controls.Add(this.radioUpdateOilfield);
            this.panelAction.Controls.Add(this.radioCountWells);
            this.panelAction.Controls.Add(this.radioCountWellsInOilfield);
            this.panelAction.Controls.Add(this.radioRemoveWell);
            this.panelAction.Controls.Add(this.radioAddWell);
            this.panelAction.Controls.Add(this.radioRemoveOilfield);
            this.panelAction.Controls.Add(this.radioAddOil);
            this.panelAction.Controls.Add(this.radioClear);
            this.panelAction.Location = new System.Drawing.Point(13, 47);
            this.panelAction.Name = "panelAction";
            this.panelAction.Size = new System.Drawing.Size(1220, 105);
            this.panelAction.TabIndex = 1;
            // 
            // radioCountOilfield
            // 
            this.radioCountOilfield.AutoSize = true;
            this.radioCountOilfield.Location = new System.Drawing.Point(517, 16);
            this.radioCountOilfield.Name = "radioCountOilfield";
            this.radioCountOilfield.Size = new System.Drawing.Size(91, 17);
            this.radioCountOilfield.TabIndex = 11;
            this.radioCountOilfield.TabStop = true;
            this.radioCountOilfield.Text = "radioButton14";
            this.radioCountOilfield.UseVisualStyleBackColor = true;
            this.radioCountOilfield.CheckedChanged += new System.EventHandler(this.radioCountOilfield_CheckedChanged);
            // 
            // radioGetOilfieldByIndex
            // 
            this.radioGetOilfieldByIndex.AutoSize = true;
            this.radioGetOilfieldByIndex.Location = new System.Drawing.Point(953, 62);
            this.radioGetOilfieldByIndex.Name = "radioGetOilfieldByIndex";
            this.radioGetOilfieldByIndex.Size = new System.Drawing.Size(91, 17);
            this.radioGetOilfieldByIndex.TabIndex = 10;
            this.radioGetOilfieldByIndex.TabStop = true;
            this.radioGetOilfieldByIndex.Text = "radioButton13";
            this.radioGetOilfieldByIndex.UseVisualStyleBackColor = true;
            this.radioGetOilfieldByIndex.CheckedChanged += new System.EventHandler(this.radioGetOilfieldByIndex_CheckedChanged);
            // 
            // radioGetAllOilfield
            // 
            this.radioGetAllOilfield.AutoSize = true;
            this.radioGetAllOilfield.Location = new System.Drawing.Point(517, 62);
            this.radioGetAllOilfield.Name = "radioGetAllOilfield";
            this.radioGetAllOilfield.Size = new System.Drawing.Size(91, 17);
            this.radioGetAllOilfield.TabIndex = 9;
            this.radioGetAllOilfield.TabStop = true;
            this.radioGetAllOilfield.Text = "radioButton12";
            this.radioGetAllOilfield.UseVisualStyleBackColor = true;
            this.radioGetAllOilfield.CheckedChanged += new System.EventHandler(this.radioGetAllOilfield_CheckedChanged);
            // 
            // radioUpdateOilfield
            // 
            this.radioUpdateOilfield.AutoSize = true;
            this.radioUpdateOilfield.Location = new System.Drawing.Point(517, 39);
            this.radioUpdateOilfield.Name = "radioUpdateOilfield";
            this.radioUpdateOilfield.Size = new System.Drawing.Size(91, 17);
            this.radioUpdateOilfield.TabIndex = 8;
            this.radioUpdateOilfield.TabStop = true;
            this.radioUpdateOilfield.Text = "radioButton11";
            this.radioUpdateOilfield.UseVisualStyleBackColor = true;
            this.radioUpdateOilfield.CheckedChanged += new System.EventHandler(this.radioUpdateOilfield_CheckedChanged);
            // 
            // radioCountWells
            // 
            this.radioCountWells.AutoSize = true;
            this.radioCountWells.Location = new System.Drawing.Point(953, 16);
            this.radioCountWells.Name = "radioCountWells";
            this.radioCountWells.Size = new System.Drawing.Size(85, 17);
            this.radioCountWells.TabIndex = 1;
            this.radioCountWells.TabStop = true;
            this.radioCountWells.Text = "radioButton4";
            this.radioCountWells.UseVisualStyleBackColor = true;
            this.radioCountWells.CheckedChanged += new System.EventHandler(this.radioCountWells_CheckedChanged);
            // 
            // radioCountWellsInOilfield
            // 
            this.radioCountWellsInOilfield.AutoSize = true;
            this.radioCountWellsInOilfield.Location = new System.Drawing.Point(953, 39);
            this.radioCountWellsInOilfield.Name = "radioCountWellsInOilfield";
            this.radioCountWellsInOilfield.Size = new System.Drawing.Size(85, 17);
            this.radioCountWellsInOilfield.TabIndex = 2;
            this.radioCountWellsInOilfield.TabStop = true;
            this.radioCountWellsInOilfield.Text = "radioButton5";
            this.radioCountWellsInOilfield.UseVisualStyleBackColor = true;
            this.radioCountWellsInOilfield.CheckedChanged += new System.EventHandler(this.radioCountWellsInOilfield_CheckedChanged);
            // 
            // radioRemoveWell
            // 
            this.radioRemoveWell.AutoSize = true;
            this.radioRemoveWell.Location = new System.Drawing.Point(6, 85);
            this.radioRemoveWell.Name = "radioRemoveWell";
            this.radioRemoveWell.Size = new System.Drawing.Size(91, 17);
            this.radioRemoveWell.TabIndex = 7;
            this.radioRemoveWell.TabStop = true;
            this.radioRemoveWell.Text = "radioButton10";
            this.radioRemoveWell.UseVisualStyleBackColor = true;
            this.radioRemoveWell.CheckedChanged += new System.EventHandler(this.radioRemoveWell_CheckedChanged);
            // 
            // radioAddWell
            // 
            this.radioAddWell.AutoSize = true;
            this.radioAddWell.Location = new System.Drawing.Point(6, 62);
            this.radioAddWell.Name = "radioAddWell";
            this.radioAddWell.Size = new System.Drawing.Size(85, 17);
            this.radioAddWell.TabIndex = 6;
            this.radioAddWell.TabStop = true;
            this.radioAddWell.Text = "radioButton9";
            this.radioAddWell.UseVisualStyleBackColor = true;
            this.radioAddWell.CheckedChanged += new System.EventHandler(this.radioAddWell_CheckedChanged);
            // 
            // radioRemoveOilfield
            // 
            this.radioRemoveOilfield.AutoSize = true;
            this.radioRemoveOilfield.Location = new System.Drawing.Point(6, 39);
            this.radioRemoveOilfield.Name = "radioRemoveOilfield";
            this.radioRemoveOilfield.Size = new System.Drawing.Size(85, 17);
            this.radioRemoveOilfield.TabIndex = 5;
            this.radioRemoveOilfield.TabStop = true;
            this.radioRemoveOilfield.Text = "radioButton8";
            this.radioRemoveOilfield.UseVisualStyleBackColor = true;
            this.radioRemoveOilfield.CheckedChanged += new System.EventHandler(this.radioRemoveOilfield_CheckedChanged);
            // 
            // radioAddOil
            // 
            this.radioAddOil.AutoSize = true;
            this.radioAddOil.Location = new System.Drawing.Point(6, 16);
            this.radioAddOil.Name = "radioAddOil";
            this.radioAddOil.Size = new System.Drawing.Size(85, 17);
            this.radioAddOil.TabIndex = 4;
            this.radioAddOil.TabStop = true;
            this.radioAddOil.Text = "radioButton7";
            this.radioAddOil.UseVisualStyleBackColor = true;
            this.radioAddOil.CheckedChanged += new System.EventHandler(this.radioAddOil_CheckedChanged);
            // 
            // radioClear
            // 
            this.radioClear.AutoSize = true;
            this.radioClear.Location = new System.Drawing.Point(953, 85);
            this.radioClear.Name = "radioClear";
            this.radioClear.Size = new System.Drawing.Size(85, 17);
            this.radioClear.TabIndex = 3;
            this.radioClear.TabStop = true;
            this.radioClear.Text = "radioButton6";
            this.radioClear.UseVisualStyleBackColor = true;
            this.radioClear.CheckedChanged += new System.EventHandler(this.radioClear_CheckedChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(496, 158);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(737, 214);
            this.dataGridView1.TabIndex = 3;
            // 
            // buttonOk
            // 
            this.buttonOk.Image = global::WinFormsClient.Properties.Resources.качалка_thumb;
            this.buttonOk.Location = new System.Drawing.Point(12, 419);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(91, 79);
            this.buttonOk.TabIndex = 2;
            this.buttonOk.Text = "button1";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // panelOil
            // 
            this.panelOil.Controls.Add(this.labelRezerv);
            this.panelOil.Controls.Add(this.labelNameOil);
            this.panelOil.Controls.Add(this.labelIDOil);
            this.panelOil.Controls.Add(this.textBoxRezerv);
            this.panelOil.Controls.Add(this.textBoxNameOil);
            this.panelOil.Controls.Add(this.textBoxIdOil);
            this.panelOil.Location = new System.Drawing.Point(13, 162);
            this.panelOil.Name = "panelOil";
            this.panelOil.Size = new System.Drawing.Size(223, 82);
            this.panelOil.TabIndex = 4;
            // 
            // labelRezerv
            // 
            this.labelRezerv.AutoSize = true;
            this.labelRezerv.Location = new System.Drawing.Point(6, 55);
            this.labelRezerv.Name = "labelRezerv";
            this.labelRezerv.Size = new System.Drawing.Size(35, 13);
            this.labelRezerv.TabIndex = 5;
            this.labelRezerv.Text = "label3";
            // 
            // labelNameOil
            // 
            this.labelNameOil.AutoSize = true;
            this.labelNameOil.Location = new System.Drawing.Point(6, 29);
            this.labelNameOil.Name = "labelNameOil";
            this.labelNameOil.Size = new System.Drawing.Size(35, 13);
            this.labelNameOil.TabIndex = 4;
            this.labelNameOil.Text = "label2";
            // 
            // labelIDOil
            // 
            this.labelIDOil.AutoSize = true;
            this.labelIDOil.Location = new System.Drawing.Point(6, 9);
            this.labelIDOil.Name = "labelIDOil";
            this.labelIDOil.Size = new System.Drawing.Size(35, 13);
            this.labelIDOil.TabIndex = 3;
            this.labelIDOil.Text = "label1";
            // 
            // textBoxRezerv
            // 
            this.textBoxRezerv.Location = new System.Drawing.Point(118, 55);
            this.textBoxRezerv.Name = "textBoxRezerv";
            this.textBoxRezerv.Size = new System.Drawing.Size(100, 20);
            this.textBoxRezerv.TabIndex = 2;
            this.textBoxRezerv.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxRezerv_KeyPress);
            // 
            // textBoxNameOil
            // 
            this.textBoxNameOil.Location = new System.Drawing.Point(118, 29);
            this.textBoxNameOil.Name = "textBoxNameOil";
            this.textBoxNameOil.Size = new System.Drawing.Size(100, 20);
            this.textBoxNameOil.TabIndex = 1;
            // 
            // textBoxIdOil
            // 
            this.textBoxIdOil.Location = new System.Drawing.Point(118, 3);
            this.textBoxIdOil.Name = "textBoxIdOil";
            this.textBoxIdOil.Size = new System.Drawing.Size(100, 20);
            this.textBoxIdOil.TabIndex = 0;
            this.textBoxIdOil.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxIdOil_KeyPress);
            // 
            // panelWells
            // 
            this.panelWells.Controls.Add(this.labelPump);
            this.panelWells.Controls.Add(this.labelDebit);
            this.panelWells.Controls.Add(this.labelNumber);
            this.panelWells.Controls.Add(this.labelIDOilInWell);
            this.panelWells.Controls.Add(this.labelIDWell);
            this.panelWells.Controls.Add(this.textBoxPump);
            this.panelWells.Controls.Add(this.textBoxDebit);
            this.panelWells.Controls.Add(this.textBoxNumber);
            this.panelWells.Controls.Add(this.textBoxIDOilInWell);
            this.panelWells.Controls.Add(this.textBoxIDWell);
            this.panelWells.Location = new System.Drawing.Point(250, 162);
            this.panelWells.Name = "panelWells";
            this.panelWells.Size = new System.Drawing.Size(240, 140);
            this.panelWells.TabIndex = 5;
            // 
            // labelPump
            // 
            this.labelPump.AutoSize = true;
            this.labelPump.Location = new System.Drawing.Point(3, 107);
            this.labelPump.Name = "labelPump";
            this.labelPump.Size = new System.Drawing.Size(35, 13);
            this.labelPump.TabIndex = 9;
            this.labelPump.Text = "label8";
            // 
            // labelDebit
            // 
            this.labelDebit.AutoSize = true;
            this.labelDebit.Location = new System.Drawing.Point(3, 81);
            this.labelDebit.Name = "labelDebit";
            this.labelDebit.Size = new System.Drawing.Size(35, 13);
            this.labelDebit.TabIndex = 8;
            this.labelDebit.Text = "label7";
            // 
            // labelNumber
            // 
            this.labelNumber.AutoSize = true;
            this.labelNumber.Location = new System.Drawing.Point(3, 55);
            this.labelNumber.Name = "labelNumber";
            this.labelNumber.Size = new System.Drawing.Size(35, 13);
            this.labelNumber.TabIndex = 7;
            this.labelNumber.Text = "label6";
            // 
            // labelIDOilInWell
            // 
            this.labelIDOilInWell.AutoSize = true;
            this.labelIDOilInWell.Location = new System.Drawing.Point(3, 29);
            this.labelIDOilInWell.Name = "labelIDOilInWell";
            this.labelIDOilInWell.Size = new System.Drawing.Size(35, 13);
            this.labelIDOilInWell.TabIndex = 6;
            this.labelIDOilInWell.Text = "label5";
            // 
            // labelIDWell
            // 
            this.labelIDWell.AutoSize = true;
            this.labelIDWell.Location = new System.Drawing.Point(3, 3);
            this.labelIDWell.Name = "labelIDWell";
            this.labelIDWell.Size = new System.Drawing.Size(35, 13);
            this.labelIDWell.TabIndex = 5;
            this.labelIDWell.Text = "label4";
            // 
            // textBoxPump
            // 
            this.textBoxPump.Location = new System.Drawing.Point(137, 107);
            this.textBoxPump.Name = "textBoxPump";
            this.textBoxPump.Size = new System.Drawing.Size(100, 20);
            this.textBoxPump.TabIndex = 4;
            // 
            // textBoxDebit
            // 
            this.textBoxDebit.Location = new System.Drawing.Point(137, 81);
            this.textBoxDebit.Name = "textBoxDebit";
            this.textBoxDebit.Size = new System.Drawing.Size(100, 20);
            this.textBoxDebit.TabIndex = 3;
            this.textBoxDebit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxDebit_KeyPress);
            // 
            // textBoxNumber
            // 
            this.textBoxNumber.Location = new System.Drawing.Point(137, 55);
            this.textBoxNumber.Name = "textBoxNumber";
            this.textBoxNumber.Size = new System.Drawing.Size(100, 20);
            this.textBoxNumber.TabIndex = 2;
            this.textBoxNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxNumber_KeyPress);
            // 
            // textBoxIDOilInWell
            // 
            this.textBoxIDOilInWell.Location = new System.Drawing.Point(137, 29);
            this.textBoxIDOilInWell.Name = "textBoxIDOilInWell";
            this.textBoxIDOilInWell.Size = new System.Drawing.Size(100, 20);
            this.textBoxIDOilInWell.TabIndex = 1;
            this.textBoxIDOilInWell.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxIDOilInWell_KeyPress);
            // 
            // textBoxIDWell
            // 
            this.textBoxIDWell.Location = new System.Drawing.Point(137, 3);
            this.textBoxIDWell.Name = "textBoxIDWell";
            this.textBoxIDWell.Size = new System.Drawing.Size(100, 20);
            this.textBoxIDWell.TabIndex = 0;
            this.textBoxIDWell.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxIDWell_KeyPress);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1245, 510);
            this.Controls.Add(this.panelWells);
            this.Controls.Add(this.panelOil);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.panelAction);
            this.Controls.Add(this.panelAccessor);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panelAccessor.ResumeLayout(false);
            this.panelAccessor.PerformLayout();
            this.panelAction.ResumeLayout(false);
            this.panelAction.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panelOil.ResumeLayout(false);
            this.panelOil.PerformLayout();
            this.panelWells.ResumeLayout(false);
            this.panelWells.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelAccessor;
        private System.Windows.Forms.RadioButton radioBinary;
        private System.Windows.Forms.Panel panelAction;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.RadioButton radioDB;
        private System.Windows.Forms.RadioButton radioXML;
        private System.Windows.Forms.RadioButton radioCountOilfield;
        private System.Windows.Forms.RadioButton radioGetOilfieldByIndex;
        private System.Windows.Forms.RadioButton radioGetAllOilfield;
        private System.Windows.Forms.RadioButton radioUpdateOilfield;
        private System.Windows.Forms.RadioButton radioCountWells;
        private System.Windows.Forms.RadioButton radioCountWellsInOilfield;
        private System.Windows.Forms.RadioButton radioRemoveWell;
        private System.Windows.Forms.RadioButton radioAddWell;
        private System.Windows.Forms.RadioButton radioRemoveOilfield;
        private System.Windows.Forms.RadioButton radioAddOil;
        private System.Windows.Forms.RadioButton radioClear;
        private System.Windows.Forms.Panel panelOil;
        private System.Windows.Forms.Panel panelWells;
        private System.Windows.Forms.Label labelRezerv;
        private System.Windows.Forms.Label labelNameOil;
        private System.Windows.Forms.Label labelIDOil;
        private System.Windows.Forms.TextBox textBoxRezerv;
        private System.Windows.Forms.TextBox textBoxNameOil;
        private System.Windows.Forms.TextBox textBoxIdOil;
        private System.Windows.Forms.Label labelPump;
        private System.Windows.Forms.Label labelDebit;
        private System.Windows.Forms.Label labelNumber;
        private System.Windows.Forms.Label labelIDOilInWell;
        private System.Windows.Forms.Label labelIDWell;
        private System.Windows.Forms.TextBox textBoxPump;
        private System.Windows.Forms.TextBox textBoxDebit;
        private System.Windows.Forms.TextBox textBoxNumber;
        private System.Windows.Forms.TextBox textBoxIDOilInWell;
        private System.Windows.Forms.TextBox textBoxIDWell;
    }
}

