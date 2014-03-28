namespace TreasureCastle
{
    partial class quitAreYouSure
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
            this.areYouSureLabel = new System.Windows.Forms.Label();
            this.quitButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // areYouSureLabel
            // 
            this.areYouSureLabel.AutoSize = true;
            this.areYouSureLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.areYouSureLabel.Location = new System.Drawing.Point(51, 9);
            this.areYouSureLabel.Name = "areYouSureLabel";
            this.areYouSureLabel.Size = new System.Drawing.Size(227, 32);
            this.areYouSureLabel.TabIndex = 0;
            this.areYouSureLabel.Text = "Are you sure you want to quit?  \r\nAll data will be lost if you do not save.";
            this.areYouSureLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // quitButton
            // 
            this.quitButton.Location = new System.Drawing.Point(86, 57);
            this.quitButton.Name = "quitButton";
            this.quitButton.Size = new System.Drawing.Size(75, 23);
            this.quitButton.TabIndex = 1;
            this.quitButton.Text = "Quit";
            this.quitButton.UseVisualStyleBackColor = true;
            this.quitButton.Click += new System.EventHandler(this.quitButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(167, 57);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 2;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // quitAreYouSure
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(328, 97);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.quitButton);
            this.Controls.Add(this.areYouSureLabel);
            this.Name = "quitAreYouSure";
            this.Text = "Are You Sure?";
            this.Load += new System.EventHandler(this.quitAreYouSure_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label areYouSureLabel;
        private System.Windows.Forms.Button quitButton;
        private System.Windows.Forms.Button cancelButton;
    }
}