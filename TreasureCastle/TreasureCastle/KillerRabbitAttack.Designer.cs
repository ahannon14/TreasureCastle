namespace TreasureCastle
{
    partial class KillerRabbitAttack
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
            this.killerRabbitAttackLabel = new System.Windows.Forms.Label();
            this.heroCombatPictureBox = new System.Windows.Forms.PictureBox();
            this.killerRabbitPictureBox = new System.Windows.Forms.PictureBox();
            this.updateLabel = new System.Windows.Forms.Label();
            this.heroHealthLabel = new System.Windows.Forms.Label();
            this.killerRabbitHealthLabel = new System.Windows.Forms.Label();
            this.attackButton = new System.Windows.Forms.Button();
            this.fleeButton = new System.Windows.Forms.Button();
            this.bribeButton = new System.Windows.Forms.Button();
            this.continueButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.heroCombatPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.killerRabbitPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // killerRabbitAttackLabel
            // 
            this.killerRabbitAttackLabel.AutoSize = true;
            this.killerRabbitAttackLabel.Location = new System.Drawing.Point(13, 13);
            this.killerRabbitAttackLabel.Name = "killerRabbitAttackLabel";
            this.killerRabbitAttackLabel.Size = new System.Drawing.Size(204, 13);
            this.killerRabbitAttackLabel.TabIndex = 0;
            this.killerRabbitAttackLabel.Text = "You have been attacked by a killer rabbit!";
            // 
            // heroCombatPictureBox
            // 
            this.heroCombatPictureBox.InitialImage = global::TreasureCastle.Properties.Resources.HeroCombat;
            this.heroCombatPictureBox.Location = new System.Drawing.Point(61, 65);
            this.heroCombatPictureBox.Name = "heroCombatPictureBox";
            this.heroCombatPictureBox.Size = new System.Drawing.Size(50, 50);
            this.heroCombatPictureBox.TabIndex = 1;
            this.heroCombatPictureBox.TabStop = false;
            // 
            // killerRabbitPictureBox
            // 
            this.killerRabbitPictureBox.InitialImage = global::TreasureCastle.Properties.Resources.KillerRabbit;
            this.killerRabbitPictureBox.Location = new System.Drawing.Point(168, 65);
            this.killerRabbitPictureBox.Name = "killerRabbitPictureBox";
            this.killerRabbitPictureBox.Size = new System.Drawing.Size(50, 50);
            this.killerRabbitPictureBox.TabIndex = 2;
            this.killerRabbitPictureBox.TabStop = false;
            // 
            // updateLabel
            // 
            this.updateLabel.AutoSize = true;
            this.updateLabel.Location = new System.Drawing.Point(13, 30);
            this.updateLabel.Name = "updateLabel";
            this.updateLabel.Size = new System.Drawing.Size(126, 13);
            this.updateLabel.TabIndex = 3;
            this.updateLabel.Text = "Actually, there\'s no hope.";
            // 
            // heroHealthLabel
            // 
            this.heroHealthLabel.AutoSize = true;
            this.heroHealthLabel.Location = new System.Drawing.Point(58, 118);
            this.heroHealthLabel.Name = "heroHealthLabel";
            this.heroHealthLabel.Size = new System.Drawing.Size(44, 13);
            this.heroHealthLabel.TabIndex = 4;
            this.heroHealthLabel.Text = "Health: ";
            // 
            // killerRabbitHealthLabel
            // 
            this.killerRabbitHealthLabel.AutoSize = true;
            this.killerRabbitHealthLabel.Location = new System.Drawing.Point(165, 118);
            this.killerRabbitHealthLabel.Name = "killerRabbitHealthLabel";
            this.killerRabbitHealthLabel.Size = new System.Drawing.Size(44, 13);
            this.killerRabbitHealthLabel.TabIndex = 5;
            this.killerRabbitHealthLabel.Text = "Health: ";
            // 
            // attackButton
            // 
            this.attackButton.Location = new System.Drawing.Point(61, 138);
            this.attackButton.Name = "attackButton";
            this.attackButton.Size = new System.Drawing.Size(75, 23);
            this.attackButton.TabIndex = 6;
            this.attackButton.Text = "Attack";
            this.attackButton.UseVisualStyleBackColor = true;
            this.attackButton.Click += new System.EventHandler(this.attackButton_Click);
            // 
            // fleeButton
            // 
            this.fleeButton.Location = new System.Drawing.Point(61, 167);
            this.fleeButton.Name = "fleeButton";
            this.fleeButton.Size = new System.Drawing.Size(75, 23);
            this.fleeButton.TabIndex = 7;
            this.fleeButton.Text = "Flee";
            this.fleeButton.UseVisualStyleBackColor = true;
            this.fleeButton.Click += new System.EventHandler(this.fleeButton_Click);
            // 
            // bribeButton
            // 
            this.bribeButton.Location = new System.Drawing.Point(143, 138);
            this.bribeButton.Name = "bribeButton";
            this.bribeButton.Size = new System.Drawing.Size(75, 23);
            this.bribeButton.TabIndex = 8;
            this.bribeButton.Text = "Bribe";
            this.bribeButton.UseVisualStyleBackColor = true;
            this.bribeButton.Click += new System.EventHandler(this.bribeButton_Click);
            // 
            // continueButton
            // 
            this.continueButton.Enabled = false;
            this.continueButton.Location = new System.Drawing.Point(142, 167);
            this.continueButton.Name = "continueButton";
            this.continueButton.Size = new System.Drawing.Size(75, 23);
            this.continueButton.TabIndex = 9;
            this.continueButton.Text = "Continue";
            this.continueButton.UseVisualStyleBackColor = true;
            this.continueButton.Click += new System.EventHandler(this.continueButton_Click);
            // 
            // KillerRabbitAttack
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(276, 202);
            this.Controls.Add(this.continueButton);
            this.Controls.Add(this.bribeButton);
            this.Controls.Add(this.fleeButton);
            this.Controls.Add(this.attackButton);
            this.Controls.Add(this.killerRabbitHealthLabel);
            this.Controls.Add(this.heroHealthLabel);
            this.Controls.Add(this.updateLabel);
            this.Controls.Add(this.killerRabbitPictureBox);
            this.Controls.Add(this.heroCombatPictureBox);
            this.Controls.Add(this.killerRabbitAttackLabel);
            this.Name = "KillerRabbitAttack";
            this.Text = "KillerRabbitAttack";
            ((System.ComponentModel.ISupportInitialize)(this.heroCombatPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.killerRabbitPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label killerRabbitAttackLabel;
        private System.Windows.Forms.PictureBox heroCombatPictureBox;
        private System.Windows.Forms.PictureBox killerRabbitPictureBox;
        private System.Windows.Forms.Label updateLabel;
        private System.Windows.Forms.Label heroHealthLabel;
        private System.Windows.Forms.Label killerRabbitHealthLabel;
        private System.Windows.Forms.Button attackButton;
        private System.Windows.Forms.Button fleeButton;
        private System.Windows.Forms.Button bribeButton;
        private System.Windows.Forms.Button continueButton;
    }
}