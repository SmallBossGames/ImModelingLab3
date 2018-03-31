namespace WindowsFormsApp1
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
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
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.mainButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.ShipTimeTextBox = new System.Windows.Forms.TextBox();
            this.shipsTextBox = new System.Windows.Forms.TextBox();
            this.timeTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.fiveShipsButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // mainButton
            // 
            this.mainButton.Location = new System.Drawing.Point(12, 92);
            this.mainButton.Name = "mainButton";
            this.mainButton.Size = new System.Drawing.Size(164, 92);
            this.mainButton.TabIndex = 0;
            this.mainButton.Text = "Стандартная симуляция";
            this.mainButton.UseVisualStyleBackColor = true;
            this.mainButton.Click += new System.EventHandler(this.mainButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(167, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Среднее время обслуживания: ";
            // 
            // ShipTimeTextBox
            // 
            this.ShipTimeTextBox.Location = new System.Drawing.Point(185, 6);
            this.ShipTimeTextBox.Name = "ShipTimeTextBox";
            this.ShipTimeTextBox.ReadOnly = true;
            this.ShipTimeTextBox.Size = new System.Drawing.Size(100, 20);
            this.ShipTimeTextBox.TabIndex = 2;
            // 
            // shipsTextBox
            // 
            this.shipsTextBox.Location = new System.Drawing.Point(212, 34);
            this.shipsTextBox.Name = "shipsTextBox";
            this.shipsTextBox.ReadOnly = true;
            this.shipsTextBox.Size = new System.Drawing.Size(100, 20);
            this.shipsTextBox.TabIndex = 3;
            // 
            // timeTextBox
            // 
            this.timeTextBox.Location = new System.Drawing.Point(117, 66);
            this.timeTextBox.Name = "timeTextBox";
            this.timeTextBox.Size = new System.Drawing.Size(100, 20);
            this.timeTextBox.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(194, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Количество обслуженных кораблей: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Часы симуляции: ";
            // 
            // fiveShipsButton
            // 
            this.fiveShipsButton.Location = new System.Drawing.Point(192, 92);
            this.fiveShipsButton.Name = "fiveShipsButton";
            this.fiveShipsButton.Size = new System.Drawing.Size(168, 92);
            this.fiveShipsButton.TabIndex = 7;
            this.fiveShipsButton.Text = "Симуляция с пятью дополнительными кораблями";
            this.fiveShipsButton.UseVisualStyleBackColor = true;
            this.fiveShipsButton.Click += new System.EventHandler(this.fiveShipsButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(372, 194);
            this.Controls.Add(this.fiveShipsButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.timeTextBox);
            this.Controls.Add(this.shipsTextBox);
            this.Controls.Add(this.ShipTimeTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.mainButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button mainButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox ShipTimeTextBox;
        private System.Windows.Forms.TextBox shipsTextBox;
        private System.Windows.Forms.TextBox timeTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button fiveShipsButton;
    }
}

