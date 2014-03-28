using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TreasureCastle
{
    public partial class KillerRabbitAttack : Form
    {
        public KillerRabbitAttack()
        {
            InitializeComponent();
        }

        private CastleExplorer parent;
        public KillerRabbitAttack(CastleExplorer CE)
        {
            InitializeComponent();
            parent = CE;
            heroHealthLabel.Text += parent.maze.hero.Health;
            killerRabbitHealthLabel.Text += 9001;

            heroCombatPictureBox.Image =
                (Image)Properties.Resources.ResourceManager.GetObject(string.Format("HeroCombat"));
            killerRabbitPictureBox.Image =
                (Image)Properties.Resources.ResourceManager.GetObject(string.Format("KillerRabbit"));
        }

        private void attackButton_Click(object sender, EventArgs e)
        {
            updateLabel.Text = "Unfortunately, you didn't bring " +
                "a Holy Hand Grenade.\n  And now he's mad.";
            parent.maze.hero.Health = 0;

            if (parent.maze.hero.Health <= 0)
            {
                attackButton.Enabled = false;
                fleeButton.Enabled = false;
                bribeButton.Enabled = false;
                continueButton.Enabled = false;
                MessageBox.Show("You have died!", "Sucks!", MessageBoxButtons.OK);
                Close();

                // go back to the main menu, and reset all
                // hero's values
                parent.callMainMenu();
                parent.maze.hero.Health = 100;
                parent.maze.hero.Money = 50;
                parent.maze.hero.Level = 1;

                // move the hero back to the starting place
                parent.heroPictureBox.Left = 150;
                parent.heroPictureBox.Top = 325;
                // set the hero up-facing again
                parent.heroPictureBox.Image =
                    (Image)Properties.Resources.ResourceManager.GetObject(string.Format("HeroBMP"));
            }

            heroHealthLabel.Text = "Health: " + parent.maze.hero.Health;
        }

        private void fleeButton_Click(object sender, EventArgs e)
        {
            updateLabel.Text = "HAHA. That's not going to work.";
            parent.maze.hero.Health = 0;

            if (parent.maze.hero.Health <= 0)
            {
                attackButton.Enabled = false;
                fleeButton.Enabled = false;
                bribeButton.Enabled = false;
                continueButton.Enabled = false;
                MessageBox.Show("You have died!", "Sucks!", MessageBoxButtons.OK);
                Close();

                // go back to the main menu, and reset all
                // hero's values
                parent.callMainMenu();
                parent.maze.hero.Health = 100;
                parent.maze.hero.Money = 50;
                parent.maze.hero.Level = 1;

                // move the hero back to the starting place
                parent.heroPictureBox.Left = 150;
                parent.heroPictureBox.Top = 325;
                // set the hero up-facing again
                parent.heroPictureBox.Image =
                    (Image)Properties.Resources.ResourceManager.GetObject(string.Format("HeroBMP"));
            }
            heroHealthLabel.Text = "Health: " + parent.maze.hero.Health;
        }

        private void bribeButton_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure that you want to bribe him?" +
                " How do you know that'll work on a dumb animal?", "Uh... what are you doing?",
                MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes &&
                parent.maze.hero.Money >= 50)
            {
                updateLabel.Text = "You have successfully bribed the killer rabbit!";
                parent.maze.hero.Money -= 50;
                attackButton.Enabled = false;
                fleeButton.Enabled = false;
                bribeButton.Enabled = false;
                continueButton.Enabled = true;
                continueButton.Select();
            }
            else if (result == DialogResult.Yes &&
                parent.maze.hero.Money < 50)
            {
                MessageBox.Show("You don't have enough money to bribe the rabbit!", "You're just screwed now.");
            }

            parent.moneyLabel.Text = "Money: " + parent.maze.hero.Money;
        }

        private void continueButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
