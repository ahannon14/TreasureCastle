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
    public partial class MonsterAttack : Form
    {
        // random class to decide what happens
        public Random rand = new Random();

        public MonsterAttack()
        {
            InitializeComponent();
        }

        private CastleExplorer parent;
        public MonsterAttack(CastleExplorer CE)
        {
            InitializeComponent();
            parent = CE;
        }
        private void MonsterAttack_Load(object sender, EventArgs e)
        {
            // show the hero's and monster's health levels
            heroHealthLabel.Text += parent.maze.hero.Health;
            monsterHealthLabel.Text += parent.maze.monsters[parent.nMonsters].Health;
            attackButton.Select();
        }

        // attempt to run away
        private void fleeButton_Click(object sender, EventArgs e)
        {
            // there are three things that could
            // happen if you try to run away
            int runAway = rand.Next(0, 3);
            int healthLost = rand.Next(1, 10);
            
            switch(runAway){
                // you completely escape
                case 0:
                    MessageBox.Show("You fled the fight and got away without a scratch.");
                    break;
                // you escape but lose health points
                case 1:
                    MessageBox.Show("You fled, but the monster clawed your fleeing behind and you lost " + 
                        healthLost + " health.");
                    parent.maze.hero.Health -= healthLost;
                    break;
                // you escape but lose half of your health
                case 2:
                    MessageBox.Show("You tried to run away, but the monster beat you half to death before you managed to crawl out of reach!");
                    parent.maze.hero.Health /= 2;
                    break;
            }
            // the message box tells you when you die
            if (parent.maze.hero.Health <= 0)
            {
                attackButton.Enabled = false;
                fleeButton.Enabled = false;
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

                parent.isPast = false;
            }
            // close the MonsterAttack form
            Close();
        }

        private void attackButton_Click(object sender, EventArgs e)
        {
            // there are three outcomes for the attack button
            int occurance = rand.Next(0, 3);
            int healthLost = rand.Next(1, 10);
            int monsterDamage = rand.Next(1, parent.maze.monsters[parent.nMonsters].Health);

            switch (occurance)
            { 
                // you miss completely, and lose health
                case 0:
                    updateLabel.Text = "Your attack was not very effective, \nand you received " + 
                        healthLost + " damage!";
                    parent.maze.hero.Health -= healthLost;
                    heroHealthLabel.Text = "Health: " + parent.maze.hero.Health;
                    break;
                // or you take the monster's health
                case 1:
                    updateLabel.Text = "You took " + monsterDamage + " of the monster's health!";
                    parent.maze.monsters[parent.nMonsters].Health -= monsterDamage;
                    if (parent.maze.monsters[parent.nMonsters].Health > 0)
                        monsterHealthLabel.Text = "Health: " + parent.maze.monsters[parent.nMonsters].Health;
                    else
                        monsterHealthLabel.Text = "Health: 0";
                    break;
                // or you take all of the monster's health
                case 2:
                    updateLabel.Text = "You took all of the monster's health! Well done!";
                    parent.maze.monsters[parent.nMonsters].Health = 0;
                    monsterHealthLabel.Text = "Health: " + parent.maze.monsters[parent.nMonsters].Health;
                    break;
            }
            
            // the message box tells you when you die
            if (parent.maze.hero.Health <= 0)
            {
                attackButton.Enabled = false;
                fleeButton.Enabled = false;
                heroDeadPictureBox.Visible = true;
                heroDeadPictureBox.BringToFront();

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

                parent.isPast = false;
            }

            // your only option is to continue when the monster's health is 0
            else if (parent.maze.monsters[parent.nMonsters].Health <= 0)
            {
                continueButton.Enabled = true;
                attackButton.Enabled = false;
                fleeButton.Enabled = false;
                bribeButton.Enabled = false;

                // get the name of the dead picture of the monster
                string name = parent.maze.monsters[parent.nMonsters].deadName;
                // set the picture box to this image
                monsterDeadPictureBox.Image = 
                    (Image)Properties.Resources.ResourceManager.GetObject(string.Format(name));
                monsterDeadPictureBox.Visible = true;
                monsterDeadPictureBox.BringToFront();

                // reset the monster's health for next time
                if (parent.maze.monsters[parent.nMonsters] is Gremlin)
                {
                    parent.maze.monsters[parent.nMonsters].Health = 20;
                }
                else if (parent.maze.monsters[parent.nMonsters] is Liger)
                {
                    parent.maze.monsters[parent.nMonsters].Health = 40;
                }
                else if (parent.maze.monsters[parent.nMonsters] is LadyBug)
                {
                    parent.maze.monsters[parent.nMonsters].Health = 2;
                }
                else if (parent.maze.monsters[parent.nMonsters] is Bat)
                {
                    parent.maze.monsters[parent.nMonsters].Health = 10;
                }
            }
        }

        private void continueButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        // bribe the monster for 50 coins
        private void bribeButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Why would you think you can bribe a dumb animal? STUPID!",
                "You idiot.", MessageBoxButtons.OK);
        }
    }
}
