namespace Seventh_homework_first_quest
{
    partial class MainMenu
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
            this.MenuInfoLabel = new System.Windows.Forms.Label();
            this.NameGameLabel = new System.Windows.Forms.Label();
            this.GameRulesLabel = new System.Windows.Forms.Label();
            this.ButtonExit = new System.Windows.Forms.Button();
            this.ButtonPlay = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // MenuInfoLabel
            // 
            this.MenuInfoLabel.AutoSize = true;
            this.MenuInfoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MenuInfoLabel.Location = new System.Drawing.Point(135, 75);
            this.MenuInfoLabel.Name = "MenuInfoLabel";
            this.MenuInfoLabel.Size = new System.Drawing.Size(118, 20);
            this.MenuInfoLabel.TabIndex = 0;
            this.MenuInfoLabel.Text = "MenuInfoLabel";
            // 
            // NameGameLabel
            // 
            this.NameGameLabel.AutoSize = true;
            this.NameGameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NameGameLabel.Location = new System.Drawing.Point(274, 139);
            this.NameGameLabel.Name = "NameGameLabel";
            this.NameGameLabel.Size = new System.Drawing.Size(139, 20);
            this.NameGameLabel.TabIndex = 1;
            this.NameGameLabel.Text = "NameGameLabel";
            // 
            // GameRulesLabel
            // 
            this.GameRulesLabel.AutoSize = true;
            this.GameRulesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.GameRulesLabel.Location = new System.Drawing.Point(136, 200);
            this.GameRulesLabel.Name = "GameRulesLabel";
            this.GameRulesLabel.Size = new System.Drawing.Size(122, 18);
            this.GameRulesLabel.TabIndex = 2;
            this.GameRulesLabel.Text = "GameRulesLabel";
            this.GameRulesLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // ButtonExit
            // 
            this.ButtonExit.Location = new System.Drawing.Point(479, 270);
            this.ButtonExit.Name = "ButtonExit";
            this.ButtonExit.Size = new System.Drawing.Size(124, 44);
            this.ButtonExit.TabIndex = 3;
            this.ButtonExit.Text = "Выход";
            this.ButtonExit.UseVisualStyleBackColor = true;
            this.ButtonExit.Click += new System.EventHandler(this.ButtonExit_Click);
            // 
            // ButtonPlay
            // 
            this.ButtonPlay.Location = new System.Drawing.Point(157, 270);
            this.ButtonPlay.Name = "ButtonPlay";
            this.ButtonPlay.Size = new System.Drawing.Size(124, 44);
            this.ButtonPlay.TabIndex = 4;
            this.ButtonPlay.Text = "Играть";
            this.ButtonPlay.UseVisualStyleBackColor = true;
            this.ButtonPlay.Click += new System.EventHandler(this.ButtonPlay_Click);
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 453);
            this.Controls.Add(this.ButtonPlay);
            this.Controls.Add(this.ButtonExit);
            this.Controls.Add(this.GameRulesLabel);
            this.Controls.Add(this.NameGameLabel);
            this.Controls.Add(this.MenuInfoLabel);
            this.MaximumSize = new System.Drawing.Size(800, 500);
            this.MinimumSize = new System.Drawing.Size(800, 500);
            this.Name = "MainMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "MainMenu";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainMenu_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label MenuInfoLabel;
        private System.Windows.Forms.Label NameGameLabel;
        private System.Windows.Forms.Label GameRulesLabel;
        private System.Windows.Forms.Button ButtonExit;
        private System.Windows.Forms.Button ButtonPlay;
    }
}