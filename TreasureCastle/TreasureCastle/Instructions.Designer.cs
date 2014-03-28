namespace TreasureCastle
{
    partial class Instructions
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Instructions));
            this.instructionsLabel = new System.Windows.Forms.Label();
            this.backButton = new System.Windows.Forms.Button();
            this.nextButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.backgroundTextLabel = new System.Windows.Forms.Label();
            this.controlTextLabel = new System.Windows.Forms.Label();
            this.monstersTextLabel = new System.Windows.Forms.Label();
            this.goodLuckTextLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // instructionsLabel
            // 
            this.instructionsLabel.AutoSize = true;
            this.instructionsLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.instructionsLabel.Font = new System.Drawing.Font("Algerian", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.instructionsLabel.Location = new System.Drawing.Point(93, 9);
            this.instructionsLabel.Name = "instructionsLabel";
            this.instructionsLabel.Size = new System.Drawing.Size(191, 32);
            this.instructionsLabel.TabIndex = 0;
            this.instructionsLabel.Text = "Instructions";
            // 
            // backButton
            // 
            this.backButton.Enabled = false;
            this.backButton.Location = new System.Drawing.Point(12, 229);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(75, 23);
            this.backButton.TabIndex = 1;
            this.backButton.Text = "Back";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // nextButton
            // 
            this.nextButton.Location = new System.Drawing.Point(290, 229);
            this.nextButton.Name = "nextButton";
            this.nextButton.Size = new System.Drawing.Size(75, 23);
            this.nextButton.TabIndex = 2;
            this.nextButton.Text = "Next";
            this.nextButton.UseVisualStyleBackColor = true;
            this.nextButton.Click += new System.EventHandler(this.nextButton_Click);
            // 
            // exitButton
            // 
            this.exitButton.Location = new System.Drawing.Point(151, 229);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(75, 23);
            this.exitButton.TabIndex = 3;
            this.exitButton.Text = "Exit";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // backgroundTextLabel
            // 
            this.backgroundTextLabel.AutoSize = true;
            this.backgroundTextLabel.Font = new System.Drawing.Font("Maiandra GD", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.backgroundTextLabel.Location = new System.Drawing.Point(-2, 51);
            this.backgroundTextLabel.Name = "backgroundTextLabel";
            this.backgroundTextLabel.Size = new System.Drawing.Size(381, 162);
            this.backgroundTextLabel.TabIndex = 4;
            this.backgroundTextLabel.Text = resources.GetString("backgroundTextLabel.Text");
            this.backgroundTextLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // controlTextLabel
            // 
            this.controlTextLabel.AutoSize = true;
            this.controlTextLabel.Font = new System.Drawing.Font("Maiandra GD", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.controlTextLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.controlTextLabel.Location = new System.Drawing.Point(15, 60);
            this.controlTextLabel.Name = "controlTextLabel";
            this.controlTextLabel.Size = new System.Drawing.Size(346, 144);
            this.controlTextLabel.TabIndex = 5;
            this.controlTextLabel.Text = resources.GetString("controlTextLabel.Text");
            this.controlTextLabel.Visible = false;
            // 
            // monstersTextLabel
            // 
            this.monstersTextLabel.AutoSize = true;
            this.monstersTextLabel.Font = new System.Drawing.Font("Maiandra GD", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.monstersTextLabel.Location = new System.Drawing.Point(21, 69);
            this.monstersTextLabel.Name = "monstersTextLabel";
            this.monstersTextLabel.Size = new System.Drawing.Size(335, 126);
            this.monstersTextLabel.TabIndex = 6;
            this.monstersTextLabel.Text = resources.GetString("monstersTextLabel.Text");
            this.monstersTextLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.monstersTextLabel.Visible = false;
            // 
            // goodLuckTextLabel
            // 
            this.goodLuckTextLabel.AutoSize = true;
            this.goodLuckTextLabel.Font = new System.Drawing.Font("Maiandra GD", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.goodLuckTextLabel.Location = new System.Drawing.Point(70, 114);
            this.goodLuckTextLabel.Name = "goodLuckTextLabel";
            this.goodLuckTextLabel.Size = new System.Drawing.Size(236, 36);
            this.goodLuckTextLabel.TabIndex = 7;
            this.goodLuckTextLabel.Text = "Good luck, stalwart treasure-seeker!\r\n\r\n";
            this.goodLuckTextLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.goodLuckTextLabel.Visible = false;
            // 
            // Instructions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(377, 264);
            this.Controls.Add(this.goodLuckTextLabel);
            this.Controls.Add(this.monstersTextLabel);
            this.Controls.Add(this.controlTextLabel);
            this.Controls.Add(this.backgroundTextLabel);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.nextButton);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.instructionsLabel);
            this.Name = "Instructions";
            this.Text = "Instructions";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label instructionsLabel;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.Button nextButton;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Label backgroundTextLabel;
        private System.Windows.Forms.Label controlTextLabel;
        private System.Windows.Forms.Label monstersTextLabel;
        private System.Windows.Forms.Label goodLuckTextLabel;
    }
}