namespace Seventh_homework_first_quest
{
    partial class Game
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
            this.btnCommand1 = new System.Windows.Forms.Button();
            this.btnCommand2 = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.UserNumberLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.GameNumberLabel = new System.Windows.Forms.Label();
            this.LabelSteps = new System.Windows.Forms.Label();
            this.LabelCountSteps = new System.Windows.Forms.Label();
            this.ButtonMenu = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCommand1
            // 
            this.btnCommand1.Location = new System.Drawing.Point(574, 55);
            this.btnCommand1.Name = "btnCommand1";
            this.btnCommand1.Size = new System.Drawing.Size(126, 42);
            this.btnCommand1.TabIndex = 0;
            this.btnCommand1.Text = "+1";
            this.btnCommand1.UseVisualStyleBackColor = true;
            this.btnCommand1.Click += new System.EventHandler(this.btnCommand1_Click);
            // 
            // btnCommand2
            // 
            this.btnCommand2.Location = new System.Drawing.Point(574, 131);
            this.btnCommand2.Name = "btnCommand2";
            this.btnCommand2.Size = new System.Drawing.Size(126, 42);
            this.btnCommand2.TabIndex = 1;
            this.btnCommand2.Text = "x2";
            this.btnCommand2.UseVisualStyleBackColor = true;
            this.btnCommand2.Click += new System.EventHandler(this.btnCommand2_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(574, 210);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(126, 42);
            this.btnReset.TabIndex = 2;
            this.btnReset.Text = "Отменить ход";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // UserNumberLabel
            // 
            this.UserNumberLabel.AutoSize = true;
            this.UserNumberLabel.Location = new System.Drawing.Point(39, 210);
            this.UserNumberLabel.Name = "UserNumberLabel";
            this.UserNumberLabel.Size = new System.Drawing.Size(16, 17);
            this.UserNumberLabel.TabIndex = 3;
            this.UserNumberLabel.Text = "0";
            this.UserNumberLabel.TextChanged += new System.EventHandler(this.UserNumberLabel_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(269, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Число, которое должен получить игрок";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(39, 169);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(133, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Текущее значение";
            // 
            // GameNumberLabel
            // 
            this.GameNumberLabel.AutoSize = true;
            this.GameNumberLabel.Location = new System.Drawing.Point(42, 115);
            this.GameNumberLabel.Name = "GameNumberLabel";
            this.GameNumberLabel.Size = new System.Drawing.Size(16, 17);
            this.GameNumberLabel.TabIndex = 6;
            this.GameNumberLabel.Text = "0";
            // 
            // LabelSteps
            // 
            this.LabelSteps.AutoSize = true;
            this.LabelSteps.Location = new System.Drawing.Point(42, 272);
            this.LabelSteps.Name = "LabelSteps";
            this.LabelSteps.Size = new System.Drawing.Size(127, 17);
            this.LabelSteps.TabIndex = 7;
            this.LabelSteps.Text = "Количество ходов";
            // 
            // LabelCountSteps
            // 
            this.LabelCountSteps.AutoSize = true;
            this.LabelCountSteps.Location = new System.Drawing.Point(42, 325);
            this.LabelCountSteps.Name = "LabelCountSteps";
            this.LabelCountSteps.Size = new System.Drawing.Size(16, 17);
            this.LabelCountSteps.TabIndex = 8;
            this.LabelCountSteps.Text = "0";
            // 
            // ButtonMenu
            // 
            this.ButtonMenu.Location = new System.Drawing.Point(574, 294);
            this.ButtonMenu.Name = "ButtonMenu";
            this.ButtonMenu.Size = new System.Drawing.Size(126, 42);
            this.ButtonMenu.TabIndex = 9;
            this.ButtonMenu.Text = "Меню";
            this.ButtonMenu.UseVisualStyleBackColor = true;
            this.ButtonMenu.Click += new System.EventHandler(this.ButtonMenu_Click);
            // 
            // Game
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 453);
            this.Controls.Add(this.ButtonMenu);
            this.Controls.Add(this.LabelCountSteps);
            this.Controls.Add(this.LabelSteps);
            this.Controls.Add(this.GameNumberLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.UserNumberLabel);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnCommand2);
            this.Controls.Add(this.btnCommand1);
            this.MaximumSize = new System.Drawing.Size(800, 500);
            this.MinimumSize = new System.Drawing.Size(800, 500);
            this.Name = "Game";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Game";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Game_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCommand1;
        private System.Windows.Forms.Button btnCommand2;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Label UserNumberLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label GameNumberLabel;
        private System.Windows.Forms.Label LabelSteps;
        private System.Windows.Forms.Label LabelCountSteps;
        private System.Windows.Forms.Button ButtonMenu;
    }
}

