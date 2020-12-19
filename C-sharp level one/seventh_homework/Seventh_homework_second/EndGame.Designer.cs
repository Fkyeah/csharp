namespace Seventh_homework_second
{
    partial class EndGame
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
            this.label_resultGame = new System.Windows.Forms.Label();
            this.Button_NewGame = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label_resultGame
            // 
            this.label_resultGame.AutoSize = true;
            this.label_resultGame.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_resultGame.Location = new System.Drawing.Point(232, 139);
            this.label_resultGame.Name = "label_resultGame";
            this.label_resultGame.Size = new System.Drawing.Size(102, 20);
            this.label_resultGame.TabIndex = 0;
            this.label_resultGame.Text = "ResultGame";
            // 
            // Button_NewGame
            // 
            this.Button_NewGame.Font = new System.Drawing.Font("Comic Sans MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Button_NewGame.Location = new System.Drawing.Point(148, 299);
            this.Button_NewGame.Name = "Button_NewGame";
            this.Button_NewGame.Size = new System.Drawing.Size(130, 50);
            this.Button_NewGame.TabIndex = 1;
            this.Button_NewGame.Text = "Начать заново";
            this.Button_NewGame.UseVisualStyleBackColor = true;
            this.Button_NewGame.Click += new System.EventHandler(this.Button_NewGame_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Comic Sans MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button2.Location = new System.Drawing.Point(476, 299);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(130, 50);
            this.button2.TabIndex = 2;
            this.button2.Text = "Выход";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // EndGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 553);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.Button_NewGame);
            this.Controls.Add(this.label_resultGame);
            this.Name = "EndGame";
            this.Text = "EndGame";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_resultGame;
        private System.Windows.Forms.Button Button_NewGame;
        private System.Windows.Forms.Button button2;
    }
}