namespace Seventh_homework_second
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
            this.Label_InfoOfNumber = new System.Windows.Forms.Label();
            this.textBoxt_UserAnswer = new System.Windows.Forms.TextBox();
            this.Label_Rules = new System.Windows.Forms.Label();
            this.Label_Prompt = new System.Windows.Forms.Label();
            this.Label_NameGame = new System.Windows.Forms.Label();
            this.button_checkAnswer = new System.Windows.Forms.Button();
            this.Label_StepCounter = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Label_InfoOfNumber
            // 
            this.Label_InfoOfNumber.AutoSize = true;
            this.Label_InfoOfNumber.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Label_InfoOfNumber.Location = new System.Drawing.Point(285, 172);
            this.Label_InfoOfNumber.Name = "Label_InfoOfNumber";
            this.Label_InfoOfNumber.Size = new System.Drawing.Size(228, 24);
            this.Label_InfoOfNumber.TabIndex = 3;
            this.Label_InfoOfNumber.Text = "Введите число от 1 до 100";
            // 
            // textBoxt_UserAnswer
            // 
            this.textBoxt_UserAnswer.Location = new System.Drawing.Point(267, 222);
            this.textBoxt_UserAnswer.Name = "textBoxt_UserAnswer";
            this.textBoxt_UserAnswer.Size = new System.Drawing.Size(100, 22);
            this.textBoxt_UserAnswer.TabIndex = 2;
            // 
            // Label_Rules
            // 
            this.Label_Rules.AutoSize = true;
            this.Label_Rules.Font = new System.Drawing.Font("Comic Sans MS", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Label_Rules.Location = new System.Drawing.Point(205, 92);
            this.Label_Rules.Name = "Label_Rules";
            this.Label_Rules.Size = new System.Drawing.Size(44, 19);
            this.Label_Rules.TabIndex = 1;
            this.Label_Rules.Text = "Rules";
            this.Label_Rules.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Label_Prompt
            // 
            this.Label_Prompt.AutoSize = true;
            this.Label_Prompt.Font = new System.Drawing.Font("Comic Sans MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Label_Prompt.Location = new System.Drawing.Point(237, 286);
            this.Label_Prompt.Name = "Label_Prompt";
            this.Label_Prompt.Size = new System.Drawing.Size(58, 20);
            this.Label_Prompt.TabIndex = 4;
            this.Label_Prompt.Text = "Prompt";
            // 
            // Label_NameGame
            // 
            this.Label_NameGame.AutoSize = true;
            this.Label_NameGame.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Label_NameGame.Location = new System.Drawing.Point(317, 50);
            this.Label_NameGame.Name = "Label_NameGame";
            this.Label_NameGame.Size = new System.Drawing.Size(123, 24);
            this.Label_NameGame.TabIndex = 0;
            this.Label_NameGame.Text = "Угадай число";
            // 
            // button_checkAnswer
            // 
            this.button_checkAnswer.Font = new System.Drawing.Font("Comic Sans MS", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_checkAnswer.Location = new System.Drawing.Point(432, 213);
            this.button_checkAnswer.Name = "button_checkAnswer";
            this.button_checkAnswer.Size = new System.Drawing.Size(100, 40);
            this.button_checkAnswer.TabIndex = 5;
            this.button_checkAnswer.Text = "Проверить";
            this.button_checkAnswer.UseVisualStyleBackColor = true;
            this.button_checkAnswer.Click += new System.EventHandler(this.button_checkAnswer_Click);
            // 
            // Label_StepCounter
            // 
            this.Label_StepCounter.AutoSize = true;
            this.Label_StepCounter.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Label_StepCounter.Location = new System.Drawing.Point(318, 340);
            this.Label_StepCounter.Name = "Label_StepCounter";
            this.Label_StepCounter.Size = new System.Drawing.Size(93, 20);
            this.Label_StepCounter.TabIndex = 6;
            this.Label_StepCounter.Text = "countSteps";
            // 
            // Game
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 553);
            this.Controls.Add(this.Label_StepCounter);
            this.Controls.Add(this.button_checkAnswer);
            this.Controls.Add(this.Label_Prompt);
            this.Controls.Add(this.Label_NameGame);
            this.Controls.Add(this.textBoxt_UserAnswer);
            this.Controls.Add(this.Label_Rules);
            this.Controls.Add(this.Label_InfoOfNumber);
            this.MaximumSize = new System.Drawing.Size(800, 600);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "Game";
            this.Text = "Game";
            this.Deactivate += new System.EventHandler(this.Game_Deactivate);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Label_InfoOfNumber;
        private System.Windows.Forms.TextBox textBoxt_UserAnswer;
        private System.Windows.Forms.Label Label_Rules;
        private System.Windows.Forms.Label Label_Prompt;
        private System.Windows.Forms.Label Label_NameGame;
        private System.Windows.Forms.Button button_checkAnswer;
        private System.Windows.Forms.Label Label_StepCounter;
    }
}

