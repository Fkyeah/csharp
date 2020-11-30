namespace BelieveOrNotBelieve
{
    partial class Game
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblComp = new System.Windows.Forms.Label();
            this.lblQuestion = new System.Windows.Forms.Label();
            this.btnYes = new System.Windows.Forms.Button();
            this.btnNo = new System.Windows.Forms.Button();
            this.lblCountAnswers = new System.Windows.Forms.Label();
            this.lblTrueFalse = new System.Windows.Forms.Label();
            this.btnBackMenu = new System.Windows.Forms.Button();
            this.tBoxQuestion = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblComp
            // 
            this.lblComp.AutoSize = true;
            this.lblComp.Font = new System.Drawing.Font("Felix Titling", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblComp.Location = new System.Drawing.Point(80, 35);
            this.lblComp.Name = "lblComp";
            this.lblComp.Size = new System.Drawing.Size(163, 19);
            this.lblComp.TabIndex = 0;
            this.lblComp.Text = "Вопрос компьютера";
            // 
            // lblQuestion
            // 
            this.lblQuestion.AutoSize = true;
            this.lblQuestion.Font = new System.Drawing.Font("Felix Titling", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblQuestion.Location = new System.Drawing.Point(80, 76);
            this.lblQuestion.Name = "lblQuestion";
            this.lblQuestion.Size = new System.Drawing.Size(65, 19);
            this.lblQuestion.TabIndex = 1;
            this.lblQuestion.Text = "Вопрос";
            // 
            // btnYes
            // 
            this.btnYes.Font = new System.Drawing.Font("Felix Titling", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnYes.Location = new System.Drawing.Point(74, 328);
            this.btnYes.Name = "btnYes";
            this.btnYes.Size = new System.Drawing.Size(140, 80);
            this.btnYes.TabIndex = 2;
            this.btnYes.Text = "Да";
            this.btnYes.UseVisualStyleBackColor = true;
            this.btnYes.Click += new System.EventHandler(this.btnYes_Click);
            // 
            // btnNo
            // 
            this.btnNo.Font = new System.Drawing.Font("Felix Titling", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnNo.Location = new System.Drawing.Point(253, 328);
            this.btnNo.Name = "btnNo";
            this.btnNo.Size = new System.Drawing.Size(140, 80);
            this.btnNo.TabIndex = 3;
            this.btnNo.Text = "Нет";
            this.btnNo.UseVisualStyleBackColor = true;
            this.btnNo.Click += new System.EventHandler(this.btnNo_Click);
            // 
            // lblCountAnswers
            // 
            this.lblCountAnswers.AutoSize = true;
            this.lblCountAnswers.Font = new System.Drawing.Font("Felix Titling", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblCountAnswers.Location = new System.Drawing.Point(358, 236);
            this.lblCountAnswers.Name = "lblCountAnswers";
            this.lblCountAnswers.Size = new System.Drawing.Size(281, 19);
            this.lblCountAnswers.TabIndex = 4;
            this.lblCountAnswers.Text = "Количество правильных ответов: 0";
            // 
            // lblTrueFalse
            // 
            this.lblTrueFalse.AutoSize = true;
            this.lblTrueFalse.Font = new System.Drawing.Font("Felix Titling", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblTrueFalse.Location = new System.Drawing.Point(80, 236);
            this.lblTrueFalse.Name = "lblTrueFalse";
            this.lblTrueFalse.Size = new System.Drawing.Size(54, 19);
            this.lblTrueFalse.TabIndex = 5;
            this.lblTrueFalse.Text = "Ответ";
            // 
            // btnBackMenu
            // 
            this.btnBackMenu.Font = new System.Drawing.Font("Felix Titling", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnBackMenu.Location = new System.Drawing.Point(525, 328);
            this.btnBackMenu.Name = "btnBackMenu";
            this.btnBackMenu.Size = new System.Drawing.Size(140, 80);
            this.btnBackMenu.TabIndex = 6;
            this.btnBackMenu.Text = "Меню";
            this.btnBackMenu.UseVisualStyleBackColor = true;
            this.btnBackMenu.Click += new System.EventHandler(this.btnBackMenu_Click);
            // 
            // tBoxQuestion
            // 
            this.tBoxQuestion.Font = new System.Drawing.Font("Felix Titling", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tBoxQuestion.Location = new System.Drawing.Point(83, 98);
            this.tBoxQuestion.Multiline = true;
            this.tBoxQuestion.Name = "tBoxQuestion";
            this.tBoxQuestion.ReadOnly = true;
            this.tBoxQuestion.Size = new System.Drawing.Size(555, 100);
            this.tBoxQuestion.TabIndex = 7;
            // 
            // Game
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tBoxQuestion);
            this.Controls.Add(this.btnBackMenu);
            this.Controls.Add(this.lblTrueFalse);
            this.Controls.Add(this.lblCountAnswers);
            this.Controls.Add(this.btnNo);
            this.Controls.Add(this.btnYes);
            this.Controls.Add(this.lblQuestion);
            this.Controls.Add(this.lblComp);
            this.Name = "Game";
            this.Text = "Game";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Game_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblComp;
        private System.Windows.Forms.Label lblQuestion;
        private System.Windows.Forms.Button btnYes;
        private System.Windows.Forms.Button btnNo;
        private System.Windows.Forms.Label lblCountAnswers;
        private System.Windows.Forms.Label lblTrueFalse;
        private System.Windows.Forms.Button btnBackMenu;
        private System.Windows.Forms.TextBox tBoxQuestion;
    }
}