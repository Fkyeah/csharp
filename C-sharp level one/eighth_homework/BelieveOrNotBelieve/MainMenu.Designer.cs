namespace BelieveOrNotBelieve
{
    partial class MainMenu
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
            this.btnPlayGame = new System.Windows.Forms.Button();
            this.btnLoadDB = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.lblGameName = new System.Windows.Forms.Label();
            this.lblGameRules = new System.Windows.Forms.Label();
            this.lblStatusDB = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnPlayGame
            // 
            this.btnPlayGame.Location = new System.Drawing.Point(60, 278);
            this.btnPlayGame.Name = "btnPlayGame";
            this.btnPlayGame.Size = new System.Drawing.Size(140, 80);
            this.btnPlayGame.TabIndex = 0;
            this.btnPlayGame.Text = "Играть";
            this.btnPlayGame.UseVisualStyleBackColor = true;
            this.btnPlayGame.Click += new System.EventHandler(this.btnPlayGame_Click);
            // 
            // btnLoadDB
            // 
            this.btnLoadDB.Location = new System.Drawing.Point(320, 278);
            this.btnLoadDB.Name = "btnLoadDB";
            this.btnLoadDB.Size = new System.Drawing.Size(140, 80);
            this.btnLoadDB.TabIndex = 1;
            this.btnLoadDB.Text = "Загрузить вопросы";
            this.btnLoadDB.UseVisualStyleBackColor = true;
            this.btnLoadDB.Click += new System.EventHandler(this.btnLoadDB_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(571, 278);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(140, 80);
            this.btnExit.TabIndex = 2;
            this.btnExit.Text = "Выход";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // lblGameName
            // 
            this.lblGameName.AutoSize = true;
            this.lblGameName.Font = new System.Drawing.Font("Felix Titling", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblGameName.Location = new System.Drawing.Point(267, 57);
            this.lblGameName.Name = "lblGameName";
            this.lblGameName.Size = new System.Drawing.Size(264, 27);
            this.lblGameName.TabIndex = 3;
            this.lblGameName.Text = "Игра \"Верю - не верю\"";
            // 
            // lblGameRules
            // 
            this.lblGameRules.AutoSize = true;
            this.lblGameRules.Font = new System.Drawing.Font("Felix Titling", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblGameRules.Location = new System.Drawing.Point(56, 115);
            this.lblGameRules.Name = "lblGameRules";
            this.lblGameRules.Size = new System.Drawing.Size(107, 19);
            this.lblGameRules.TabIndex = 4;
            this.lblGameRules.Text = "lblGameRules";
            this.lblGameRules.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblStatusDB
            // 
            this.lblStatusDB.AutoSize = true;
            this.lblStatusDB.Font = new System.Drawing.Font("Felix Titling", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblStatusDB.Location = new System.Drawing.Point(251, 214);
            this.lblStatusDB.Name = "lblStatusDB";
            this.lblStatusDB.Size = new System.Drawing.Size(71, 17);
            this.lblStatusDB.TabIndex = 5;
            this.lblStatusDB.Text = "StatusDB";
            this.lblStatusDB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblStatusDB);
            this.Controls.Add(this.lblGameRules);
            this.Controls.Add(this.lblGameName);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnLoadDB);
            this.Controls.Add(this.btnPlayGame);
            this.Name = "MainMenu";
            this.Text = "Главное меню";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPlayGame;
        private System.Windows.Forms.Button btnLoadDB;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label lblGameName;
        private System.Windows.Forms.Label lblGameRules;
        private System.Windows.Forms.Label lblStatusDB;
    }
}

