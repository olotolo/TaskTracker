namespace TaskManager
{
    partial class TaskManager
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            addTaskBtn = new Button();
            dateTimePicker1 = new DateTimePicker();
            taskDescription = new TextBox();
            taskPanel = new Panel();
            taskName = new TextBox();
            carryOverCheckBox = new CheckBox();
            repeatTaskCheckBox = new CheckBox();
            mondayCheckBox = new CheckBox();
            tuesdayCheckBox = new CheckBox();
            WednesdayCheckBox = new CheckBox();
            thursdayCheckBox = new CheckBox();
            fridayCheckBox = new CheckBox();
            saturdayCheckBox = new CheckBox();
            sundayCheckBox = new CheckBox();
            SuspendLayout();
            // 
            // addTaskBtn
            // 
            addTaskBtn.Location = new Point(417, 184);
            addTaskBtn.Name = "addTaskBtn";
            addTaskBtn.Size = new Size(120, 45);
            addTaskBtn.TabIndex = 1;
            addTaskBtn.Text = "Add Task";
            addTaskBtn.UseVisualStyleBackColor = true;
            addTaskBtn.Click += addTaskBtn_Click;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(0, 0);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(200, 23);
            dateTimePicker1.TabIndex = 3;
            dateTimePicker1.ValueChanged += dateTimePicker1_ValueChanged;
            // 
            // taskDescription
            // 
            taskDescription.Location = new Point(417, 58);
            taskDescription.Multiline = true;
            taskDescription.Name = "taskDescription";
            taskDescription.Size = new Size(402, 120);
            taskDescription.TabIndex = 4;
            taskDescription.TextChanged += taskDescription_TextChanged;
            // 
            // taskPanel
            // 
            taskPanel.Location = new Point(0, 29);
            taskPanel.Name = "taskPanel";
            taskPanel.Size = new Size(402, 442);
            taskPanel.TabIndex = 5;
            // 
            // taskName
            // 
            taskName.Location = new Point(417, 29);
            taskName.Name = "taskName";
            taskName.Size = new Size(213, 23);
            taskName.TabIndex = 6;
            taskName.TextChanged += taskName_TextChanged;
            // 
            // carryOverCheckBox
            // 
            carryOverCheckBox.AutoSize = true;
            carryOverCheckBox.Location = new Point(417, 245);
            carryOverCheckBox.Name = "carryOverCheckBox";
            carryOverCheckBox.Size = new Size(234, 19);
            carryOverCheckBox.TabIndex = 7;
            carryOverCheckBox.Text = "Carry over to next Day if not completed";
            carryOverCheckBox.UseVisualStyleBackColor = true;
            carryOverCheckBox.Click += carryOver_Click;
            // 
            // repeatTaskCheckBox
            // 
            repeatTaskCheckBox.AutoSize = true;
            repeatTaskCheckBox.Location = new Point(732, 245);
            repeatTaskCheckBox.Name = "repeatTaskCheckBox";
            repeatTaskCheckBox.Size = new Size(87, 19);
            repeatTaskCheckBox.TabIndex = 8;
            repeatTaskCheckBox.Text = "Repeat Task";
            repeatTaskCheckBox.UseVisualStyleBackColor = true;
            // 
            // mondayCheckBox
            // 
            mondayCheckBox.AutoSize = true;
            mondayCheckBox.Location = new Point(732, 294);
            mondayCheckBox.Name = "mondayCheckBox";
            mondayCheckBox.Size = new Size(70, 19);
            mondayCheckBox.TabIndex = 9;
            mondayCheckBox.Text = "Monday";
            mondayCheckBox.UseVisualStyleBackColor = true;
            mondayCheckBox.CheckedChanged += mondayCheckBox_CheckedChanged;
            // 
            // tuesdayCheckBox
            // 
            tuesdayCheckBox.AutoSize = true;
            tuesdayCheckBox.Location = new Point(732, 319);
            tuesdayCheckBox.Name = "tuesdayCheckBox";
            tuesdayCheckBox.Size = new Size(69, 19);
            tuesdayCheckBox.TabIndex = 10;
            tuesdayCheckBox.Text = "Tuesday";
            tuesdayCheckBox.UseVisualStyleBackColor = true;
            tuesdayCheckBox.CheckedChanged += tuesdayCheckBox_CheckedChanged;
            // 
            // WednesdayCheckBox
            // 
            WednesdayCheckBox.AutoSize = true;
            WednesdayCheckBox.Location = new Point(732, 344);
            WednesdayCheckBox.Name = "WednesdayCheckBox";
            WednesdayCheckBox.Size = new Size(87, 19);
            WednesdayCheckBox.TabIndex = 11;
            WednesdayCheckBox.Text = "Wednesday";
            WednesdayCheckBox.UseVisualStyleBackColor = true;
            // 
            // thursdayCheckBox
            // 
            thursdayCheckBox.AutoSize = true;
            thursdayCheckBox.Location = new Point(732, 369);
            thursdayCheckBox.Name = "thursdayCheckBox";
            thursdayCheckBox.Size = new Size(74, 19);
            thursdayCheckBox.TabIndex = 12;
            thursdayCheckBox.Text = "Thursday";
            thursdayCheckBox.UseVisualStyleBackColor = true;
            // 
            // fridayCheckBox
            // 
            fridayCheckBox.AutoSize = true;
            fridayCheckBox.Location = new Point(732, 394);
            fridayCheckBox.Name = "fridayCheckBox";
            fridayCheckBox.Size = new Size(58, 19);
            fridayCheckBox.TabIndex = 13;
            fridayCheckBox.Text = "Friday";
            fridayCheckBox.UseVisualStyleBackColor = true;
            // 
            // saturdayCheckBox
            // 
            saturdayCheckBox.AutoSize = true;
            saturdayCheckBox.Location = new Point(732, 419);
            saturdayCheckBox.Name = "saturdayCheckBox";
            saturdayCheckBox.Size = new Size(72, 19);
            saturdayCheckBox.TabIndex = 14;
            saturdayCheckBox.Text = "Saturday";
            saturdayCheckBox.UseVisualStyleBackColor = true;
            // 
            // sundayCheckBox
            // 
            sundayCheckBox.AutoSize = true;
            sundayCheckBox.Location = new Point(732, 444);
            sundayCheckBox.Name = "sundayCheckBox";
            sundayCheckBox.Size = new Size(65, 19);
            sundayCheckBox.TabIndex = 15;
            sundayCheckBox.Text = "Sunday";
            sundayCheckBox.UseVisualStyleBackColor = true;
            // 
            // TaskManager
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(994, 601);
            Controls.Add(sundayCheckBox);
            Controls.Add(saturdayCheckBox);
            Controls.Add(fridayCheckBox);
            Controls.Add(thursdayCheckBox);
            Controls.Add(WednesdayCheckBox);
            Controls.Add(tuesdayCheckBox);
            Controls.Add(mondayCheckBox);
            Controls.Add(repeatTaskCheckBox);
            Controls.Add(carryOverCheckBox);
            Controls.Add(taskName);
            Controls.Add(taskPanel);
            Controls.Add(taskDescription);
            Controls.Add(dateTimePicker1);
            Controls.Add(addTaskBtn);
            Name = "TaskManager";
            Text = "TaskManager";
            Load += TaskManager_Load;
            ResumeLayout(false);
            PerformLayout();
        }


        #endregion
        private Button addTaskBtn;
        private DateTimePicker dateTimePicker1;
        private TextBox taskDescription;
        private Panel taskPanel;
        private TextBox taskName;
        private CheckBox carryOverCheckBox;
        private CheckBox repeatTaskCheckBox;
        private CheckBox mondayCheckBox;
        private CheckBox tuesdayCheckBox;
        private CheckBox WednesdayCheckBox;
        private CheckBox thursdayCheckBox;
        private CheckBox fridayCheckBox;
        private CheckBox saturdayCheckBox;
        private CheckBox sundayCheckBox;
    }
}