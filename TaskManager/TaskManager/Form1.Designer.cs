﻿namespace TaskManager
{
    partial class Form1
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
            displayText = new Label();
            dateTimePicker1 = new DateTimePicker();
            taskInput = new TextBox();
            SuspendLayout();
            // 
            // addTaskBtn
            // 
            addTaskBtn.Location = new Point(408, 113);
            addTaskBtn.Name = "addTaskBtn";
            addTaskBtn.Size = new Size(120, 45);
            addTaskBtn.TabIndex = 1;
            addTaskBtn.Text = "Add Task";
            addTaskBtn.UseVisualStyleBackColor = true;
            addTaskBtn.Click += addTaskBtn_Click;
            // 
            // displayText
            // 
            displayText.AutoSize = true;
            displayText.Location = new Point(408, 9);
            displayText.Name = "displayText";
            displayText.Size = new Size(38, 15);
            displayText.TabIndex = 2;
            displayText.Text = "label1";
            displayText.Click += displayText_Click;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(0, 0);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(200, 23);
            dateTimePicker1.TabIndex = 3;
            dateTimePicker1.ValueChanged += dateTimePicker1_ValueChanged;
            // 
            // taskInput
            // 
            taskInput.Location = new Point(408, 69);
            taskInput.Name = "taskInput";
            taskInput.Size = new Size(187, 23);
            taskInput.TabIndex = 4;
            taskInput.TextChanged += taskInput_TextChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(822, 470);
            Controls.Add(taskInput);
            Controls.Add(dateTimePicker1);
            Controls.Add(displayText);
            Controls.Add(addTaskBtn);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button addTaskBtn;
        private Label displayText;
        private DateTimePicker dateTimePicker1;
        private TextBox taskInput;
    }
}