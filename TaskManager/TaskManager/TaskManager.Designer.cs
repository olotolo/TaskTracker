﻿namespace TaskManager
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
            taskInput = new TextBox();
            taskPanel = new Panel();
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
            // taskPanel
            // 
            taskPanel.Location = new Point(0, 29);
            taskPanel.Name = "taskPanel";
            taskPanel.Size = new Size(402, 442);
            taskPanel.TabIndex = 5;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(822, 470);
            Controls.Add(taskPanel);
            Controls.Add(taskInput);
            Controls.Add(dateTimePicker1);
            Controls.Add(addTaskBtn);
            Name = "TaskManager";
            Text = "TaskManager";
            ResumeLayout(false);
            PerformLayout();
        }


        #endregion
        private Button addTaskBtn;
        private DateTimePicker dateTimePicker1;
        private TextBox taskInput;
        private Panel taskPanel;
    }
}