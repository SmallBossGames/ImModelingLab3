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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.accuracyTextBox = new System.Windows.Forms.TextBox();
            this.kvantilTextBox = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.ITTextBox = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.ShipTypeTextBox = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.QueveTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // mainButton
            // 
            this.mainButton.Location = new System.Drawing.Point(12, 232);
            this.mainButton.Name = "mainButton";
            this.mainButton.Size = new System.Drawing.Size(164, 92);
            this.mainButton.TabIndex = 4;
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
            this.timeTextBox.Location = new System.Drawing.Point(163, 66);
            this.timeTextBox.Name = "timeTextBox";
            this.timeTextBox.Size = new System.Drawing.Size(100, 20);
            this.timeTextBox.TabIndex = 0;
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
            this.label3.Size = new System.Drawing.Size(145, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Интервал моделирования: ";
            // 
            // fiveShipsButton
            // 
            this.fiveShipsButton.Location = new System.Drawing.Point(185, 232);
            this.fiveShipsButton.Name = "fiveShipsButton";
            this.fiveShipsButton.Size = new System.Drawing.Size(168, 92);
            this.fiveShipsButton.TabIndex = 5;
            this.fiveShipsButton.Text = "Симуляция с пятью дополнительными кораблями";
            this.fiveShipsButton.UseVisualStyleBackColor = true;
            this.fiveShipsButton.Click += new System.EventHandler(this.fiveShipsButton_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(106, 149);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 8;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(106, 175);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 9;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(312, 149);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(100, 20);
            this.textBox3.TabIndex = 10;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(278, 175);
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(100, 20);
            this.textBox4.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 152);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Корабли 1 типа:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 178);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Корабли 2 типа:";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(218, 152);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Корабли 3 типа:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(217, 178);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Танкеры:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 97);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(127, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "Точность (в процентах):";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 120);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(58, 13);
            this.label9.TabIndex = 17;
            this.label9.Text = "Квантиль:";
            // 
            // accuracyTextBox
            // 
            this.accuracyTextBox.Location = new System.Drawing.Point(145, 92);
            this.accuracyTextBox.Name = "accuracyTextBox";
            this.accuracyTextBox.Size = new System.Drawing.Size(100, 20);
            this.accuracyTextBox.TabIndex = 1;
            // 
            // kvantilTextBox
            // 
            this.kvantilTextBox.Location = new System.Drawing.Point(76, 117);
            this.kvantilTextBox.Name = "kvantilTextBox";
            this.kvantilTextBox.Size = new System.Drawing.Size(100, 20);
            this.kvantilTextBox.TabIndex = 2;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 203);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(92, 13);
            this.label10.TabIndex = 20;
            this.label10.Text = "Число итераций:";
            // 
            // ITTextBox
            // 
            this.ITTextBox.Location = new System.Drawing.Point(111, 200);
            this.ITTextBox.Name = "ITTextBox";
            this.ITTextBox.ReadOnly = true;
            this.ITTextBox.Size = new System.Drawing.Size(100, 20);
            this.ITTextBox.TabIndex = 21;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(182, 120);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(120, 13);
            this.label11.TabIndex = 22;
            this.label11.Text = "Введите тип корабля: ";
            // 
            // ShipTypeTextBox
            // 
            this.ShipTypeTextBox.Location = new System.Drawing.Point(308, 118);
            this.ShipTypeTextBox.Name = "ShipTypeTextBox";
            this.ShipTypeTextBox.Size = new System.Drawing.Size(100, 20);
            this.ShipTypeTextBox.TabIndex = 3;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(244, 203);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(144, 13);
            this.label12.TabIndex = 24;
            this.label12.Text = "Среднее время в очереди: ";
            // 
            // QueveTextBox
            // 
            this.QueveTextBox.Location = new System.Drawing.Point(394, 201);
            this.QueveTextBox.Name = "QueveTextBox";
            this.QueveTextBox.ReadOnly = true;
            this.QueveTextBox.Size = new System.Drawing.Size(100, 20);
            this.QueveTextBox.TabIndex = 25;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(509, 336);
            this.Controls.Add(this.QueveTextBox);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.ShipTypeTextBox);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.ITTextBox);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.kvantilTextBox);
            this.Controls.Add(this.accuracyTextBox);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
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
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox accuracyTextBox;
        private System.Windows.Forms.TextBox kvantilTextBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox ITTextBox;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox ShipTypeTextBox;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox QueveTextBox;
    }
}

