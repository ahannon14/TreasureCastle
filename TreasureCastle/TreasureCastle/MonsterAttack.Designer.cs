namespace TreasureCastle
{
    partial class MonsterAttack
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
            this.monsterAttackLabel = new System.Windows.Forms.Label();
            this.updateLabel = new System.Windows.Forms.Label();
            this.heroHealthLabel = new System.Windows.Forms.Label();
            this.monsterHealthLabel = new System.Windows.Forms.Label();
            this.attackButton = new System.Windows.Forms.Button();
            this.fleeButton = new System.Windows.Forms.Button();
            this.continueButton = new System.Windows.Forms.Button();
            this.bribeButton = new System.Windows.Forms.Button();
            this.monsterPictureBox = new System.Windows.Forms.PictureBox();
            this.heroCombatPictureBox = new System.Windows.Forms.PictureBox();
            this.heroDeadPictureBox = new System.Windows.Forms.PictureBox();
            this.monsterDeadPictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.monsterPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.heroCombatPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.heroDeadPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.monsterDeadPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // monsterAttackLabel
            // 
            this.monsterAttackLabel.AutoSize = true;
            this.monsterAttackLabel.Location = new System.Drawing.Point(13, 13);
            this.monsterAttackLabel.Name = "monsterAttackLabel";
            this.monsterAttackLabel.Size = new System.Drawing.Size(151, 13);
            this.monsterAttackLabel.TabIndex = 0;
            this.monsterAttackLabel.Text = "You have been attacked by a ";
            // 
            // updateLabel
            // 
            this.updateLabel.AutoSize = true;
            this.updateLabel.Location = new System.Drawing.Point(13, 26);
            this.updateLabel.Name = "updateLabel";
            this.updateLabel.Size = new System.Drawing.Size(0, 13);
            this.updateLabel.TabIndex = 1;
            // 
            // heroHealthLabel
            // 
            this.heroHealthLabel.AutoSize = true;
            this.heroHealthLabel.Location = new System.Drawing.Point(58, 115);
            this.heroHealthLabel.Name = "heroHealthLabel";
            this.heroHealthLabel.Size = new System.Drawing.Size(44, 13);
            this.heroHealthLabel.TabIndex = 4;
            this.heroHealthLabel.Text = "Health: ";
            // 
            // monsterHealthLabel
            // 
            this.monsterHealthLabel.AutoSize = true;
            this.monsterHealthLabel.Location = new System.Drawing.Point(165, 115);
            this.monsterHealthLabel.Name = "monsterHealthLabel";
            this.monsterHealthLabel.Size = new System.Drawing.Size(44, 13);
            this.monsterHealthLabel.TabIndex = 5;
            this.monsterHealthLabel.Text = "Health: ";
            // 
            // attackButton
            // 
            this.attackButton.Location = new System.Drawing.Point(61, 131);
            this.attackButton.Name = "attackButton";
            this.attackButton.Size = new System.Drawing.Size(75, 23);
            this.attackButton.TabIndex = 6;
            this.attackButton.Text = "Attack";
            this.attackButton.UseVisualStyleBackColor = true;
            this.attackButton.Click += new System.EventHandler(this.attackButton_Click);
            // 
            // fleeButton
            // 
            this.fleeButton.Location = new System.Drawing.Point(60, 160);
            this.fleeButton.Name = "fleeButton";
            this.fleeButton.Size = new System.Drawing.Size(75, 23);
            this.fleeButton.TabIndex = 7;
            this.fleeButton.Text = "Flee";
            this.fleeButton.UseVisualStyleBackColor = true;
            this.fleeButton.Click += new System.EventHandler(this.fleeButton_Click);
            // 
            // continueButton
            // 
            this.continueButton.Enabled = false;
            this.continueButton.Location = new System.Drawing.Point(143, 160);
            this.continueButton.Name = "continueButton";
            this.continueButton.Size = new System.Drawing.Size(75, 23);
            this.continueButton.TabIndex = 8;
            this.continueButton.Text = "Continue";
            this.continueButton.UseVisualStyleBackColor = true;
            this.continueButton.Click += new System.EventHandler(this.continueButton_Click);
            // 
            // bribeButton
            // 
            this.bribeButton.Location = new System.Drawing.Point(143, 131);
            this.bribeButton.Name = "bribeButton";
            this.bribeButton.Size = new System.Drawing.Size(75, 23);
            this.bribeButton.TabIndex = 9;
            this.bribeButton.Text = "Bribe";
            this.bribeButton.UseVisualStyleBackColor = true;
            this.bribeButton.Click += new System.EventHandler(this.bribeButton_Click);
            // 
            // monsterPictureBox
            // 
            this.monsterPictureBox.Location = new System.Drawing.Point(168, 62);
            this.monsterPictureBox.Name = "monsterPictureBox";
            this.monsterPictureBox.Size = new System.Drawing.Size(50, 50);
            this.monsterPictureBox.TabIndex = 3;
            this.monsterPictureBox.TabStop = false;
            // 
            // heroCombatPictureBox
            // 
            this.heroCombatPictureBox.Image = global::TreasureCastle.Properties.Resources.HeroCombat;
            this.heroCombatPictureBox.Location = new System.Drawing.Point(61, 62);
            this.heroCombatPictureBox.Name = "heroCombatPictureBox";
            this.heroCombatPictureBox.Size = new System.Drawing.Size(50, 50);
            this.heroCombatPictureBox.TabIndex = 2;
            this.heroCombatPictureBox.TabStop = false;
            // 
            // heroDeadPictureBox
            // 
            this.heroDeadPictureBox.Image = global::TreasureCastle.Properties.Resources.DeadHeroCombat;
            this.heroDeadPictureBox.InitialImage = global::TreasureCastle.Properties.Resources.DeadHeroCombat;
            this.heroDeadPictureBox.Location = new System.Drawing.Point(61, 62);
            this.heroDeadPictureBox.Name = "heroDeadPictureBox";
            this.heroDeadPictureBox.Size = new System.Drawing.Size(50, 50);
            this.heroDeadPictureBox.TabIndex = 10;
            this.heroDeadPictureBox.TabStop = false;
            this.heroDeadPictureBox.Visible = false;
            // 
            // monsterDeadPictureBox
            // 
            this.monsterDeadPictureBox.InitialImage = null;
            this.monsterDeadPictureBox.Location = new System.Drawing.Point(168, 62);
            this.monsterDeadPictureBox.Name = "monsterDeadPictureBox";
            this.monsterDeadPictureBox.Size = new System.Drawing.Size(50, 50);
            this.monsterDeadPictureBox.TabIndex = 11;
            this.monsterDeadPictureBox.TabStop = false;
            this.monsterDeadPictureBox.Visible = false;
            // 
            // MonsterAttack
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(276, 202);
            this.Controls.Add(this.monsterDeadPictureBox);
            this.Controls.Add(this.heroDeadPictureBox);
            this.Controls.Add(this.bribeButton);
            this.Controls.Add(this.continueButton);
            this.Controls.Add(this.fleeButton);
            this.Controls.Add(this.attackButton);
            this.Controls.Add(this.monsterHealthLabel);
            this.Controls.Add(this.heroHealthLabel);
            this.Controls.Add(this.monsterPictureBox);
            this.Controls.Add(this.heroCombatPictureBox);
            this.Controls.Add(this.updateLabel);
            this.Controls.Add(this.monsterAttackLabel);
            this.Name = "MonsterAttack";
            this.Text = "MonsterAttack";
            this.Load += new System.EventHandler(this.MonsterAttack_Load);
            ((System.ComponentModel.ISupportInitialize)(this.monsterPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.heroCombatPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.heroDeadPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.monsterDeadPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label monsterAttackLabel;
        private System.Windows.Forms.Label updateLabel;
        private System.Windows.Forms.PictureBox heroCombatPictureBox;
        public System.Windows.Forms.PictureBox monsterPictureBox;
        public System.Windows.Forms.Label heroHealthLabel;
        private System.Windows.Forms.Label monsterHealthLabel;
        private System.Windows.Forms.Button attackButton;
        private System.Windows.Forms.Button fleeButton;
        private System.Windows.Forms.Button continueButton;
        private System.Windows.Forms.Button bribeButton;
        private System.Windows.Forms.PictureBox heroDeadPictureBox;
        private System.Windows.Forms.PictureBox monsterDeadPictureBox;
    }
}