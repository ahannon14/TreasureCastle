using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace TreasureCastle
{
    public partial class CastleExplorer : Form
    {
        // random class to generate random occurences
        Random rand = new Random();
        // maze initializes the hero's health, wealth, and level
        public Maze maze = new Maze(100, 40, 1);
        // index numbers for the array of monsters and bonuses
        public int nMonsters = 0;
        public int nBonuses = 0;

        // levelArrays is an array of maze arrays
        // there are 4 mazes, and each one has
        // 13 rows and 13 columns of 25 x 25 squares
        public bool[, ,] levelArrays = new bool[4, 13, 13];

        // indicates whether or not the user has opted to 
        // load a previously played game
        private bool isLoaded = false;

        // indicates whether or not the hero has moved
        private bool isMoved = false;

        // indicates whether or not the hero has passed the killer rabbit
        public bool isPast = false;

        public CastleExplorer()
        {
            InitializeComponent();
        }

        // shut down the application
        private void quitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // if the users clicks the exit option on the toolbar, 
        // then it's likely that there is unsaved data.
        // Give the user the option to back out
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            quitAreYouSure page = new quitAreYouSure();
            page.ShowDialog();
        }

        // save the hero's health, wealth, and level in a .txt file
        // it is prefaced with CASTLE EXPLORER so that the load button
        // can confirm that a file is suitable for this game
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.InitialDirectory = "C:\\Users\\Amy\\Documents\\";
            dialog.RestoreDirectory = true;

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string filename = dialog.FileName;
                using (FileStream writer = new FileStream(filename, FileMode.OpenOrCreate))
                {
                    UTF8Encoding utf = new UTF8Encoding();
                    /*
                     * HERE WE SAVE THE LEVEL, HEALTH, AND MONEY
                     * PREFACED WITH THE KEYWORD CASTLE EXPLORER
                     * */
                    string text = "CASTLE EXPLORER" + "\r\n" +
                        maze.hero.Level + "\r\n" +
                        maze.hero.Health + "\r\n" +
                        maze.hero.Money + "\r\n";
                    writer.Seek(0, SeekOrigin.End);

                    writer.Write(utf.GetBytes(text),
                        0, utf.GetByteCount(text));
                }
            }
        }

        // change the interface and enter gameplay
        private void playButton_Click(object sender, EventArgs e)
        {
            // hide the title label and the main menu
            // buttons
            // disable the buttons as well
            titleLabel.Visible = false;
            playButton.Visible = false;
            playButton.Enabled = false;
            loadButton.Visible = false;
            loadButton.Enabled = false;
            instructionsButton.Visible = false;
            instructionsButton.Enabled = false;
            quitButton.Visible = false;
            quitButton.Enabled = false;

            // uncover the maze, the hero, and the stats
            mazePanel.Visible = true;
            heroPictureBox.Visible = true;
            healthLabel.Visible = true;
            moneyLabel.Visible = true;
            levelLabel.Visible = true;

            // initialize the hero image to up-facing
            heroPictureBox.Image =
                (Image)Properties.Resources.ResourceManager.GetObject(string.Format("HeroBMP"));
            heroPictureBox.BringToFront();

            // if the user has not previously loaded statistics from 
            // a .txt file, then fill the labels with the defaults
            if (!isLoaded)
            {

                healthLabel.Text = "Health: " + maze.hero.Health;

                moneyLabel.Text = "Money: " + maze.hero.Money;

                levelLabel.Text = "Level: " + maze.hero.Level;
            }

            // set the arrays tediously
            setArrays();

            // draw the maze!
            for (int x = 0; x < 13; x++)
            {
                for (int y = 0; y < 13; y++)
                {
                    using (Graphics graphics = mazePanel.CreateGraphics())
                    {

                       
                        // if the square in the maze in question is true,
                        // draw light gray.  It is a piece of the path
                        if (levelArrays[maze.hero.Level - 1, x, y])
                            graphics.FillRectangle(new SolidBrush(Color.LightGray), x * 25, y * 25,
                                25, 25);
                        // else draw the wall in dark gray
                        else
                            graphics.FillRectangle(new SolidBrush(Color.DarkGray), x * 25, y * 25,
                                25, 25);
                    }
                }
            }

            // draw the brown entryway and the green exit square
            using (Graphics graphics = mazePanel.CreateGraphics())
            {
                graphics.FillRectangle(new SolidBrush(Color.Green), 150, 0, 25, 25);
                graphics.FillRectangle(new SolidBrush(Color.Brown), 150, 300, 25, 25);
            }
            
            // if it's the final level, then draw the yellow treasure chest
            if (maze.hero.Level == 4)
            {
                using (Graphics graphics = mazePanel.CreateGraphics())
                {
                    graphics.FillRectangle(new SolidBrush(Color.Yellow), 125, 0,
                        75, 50);
                }
            }
        }

        // load statistics from a .txt file
        private void loadButton_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.InitialDirectory = "C:\\Users\\Amy\\Documents\\";
                dialog.RestoreDirectory = true;
                dialog.Filter = "Text File (*.txt)|*.txt|All Files (*.*)|*.*";
                dialog.FilterIndex = 2;

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    isLoaded = true;
                    string filename = dialog.FileName;
                    StreamReader reader = new StreamReader(filename);

                    if (reader.ReadLine() == "CASTLE EXPLORER")
                    {
                        // read the stats into the hero's properties
                        // and then change the stats labels
                        maze.hero.Level = Convert.ToInt32(reader.ReadLine());
                        levelLabel.Text = "Level: " + maze.hero.Level;
                        maze.hero.Health = Convert.ToInt32(reader.ReadLine());
                        healthLabel.Text = "Health: " + maze.hero.Health;
                        maze.hero.Money = Convert.ToInt32(reader.ReadLine());
                        moneyLabel.Text = "Money: " + maze.hero.Money;
                    }

                    reader.Dispose();

                    // after loading, move the hero back to his correct spot
                    // (just in case the user has already been playing a 
                    // different game
                    heroPictureBox.Left = 150;
                    heroPictureBox.Top = 325;
                }
            }
            catch (FileNotFoundException exc)
            {
                MessageBox.Show("File not found!" + exc.Message);
            }
        }

        // if the user opts to read the instructions, 
        // call an instructions child form
        private void instructionsButton_Click(object sender, EventArgs e)
        {
            Instructions page = new Instructions();
            page.ShowDialog();
        }

        // if the user wants to see the main menu, change interface
        private void mainMenuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            callMainMenu();
        }

        // when the user presses an arrow key,
        // move the hero around
        private void CastleExplorer_KeyDown(object sender, KeyEventArgs e)
        {                 
            // if the hero is below the upper limit
            // and if the square in question is true,
            // move somewhere
            if (heroPictureBox.Location.X >= 25 && 
            levelArrays[maze.hero.Level - 1, (heroPictureBox.Location.X - 25) / 25, 
            (heroPictureBox.Location.Y - 25) / 25])
            {
                // move the hero 25 to the LEFT
                if (e.KeyCode == Keys.Left)
                {  
                    heroPictureBox.Left -= 25;

                    //sets the image to left-facing
                    heroPictureBox.Image =
                        (Image)Properties.Resources.ResourceManager.GetObject(string.Format("HeroBMPLeft"));

                    isMoved = true;
                }
            }

            if (heroPictureBox.Location.Y >= 50 &&
                levelArrays[maze.hero.Level - 1, (heroPictureBox.Location.X / 25),
                ((heroPictureBox.Location.Y - 50) / 25)])
            {
                // move the hero 25 UP
                if (e.KeyCode == Keys.Up)
                {
                    heroPictureBox.Top -= 25;

                    // sets the image to up-facing
                    heroPictureBox.Image =
                        (Image)Properties.Resources.ResourceManager.GetObject(string.Format("HeroBMP"));

                    isMoved = true;
                }
            }

            if (heroPictureBox.Location.X <= 275 &&
            levelArrays[maze.hero.Level - 1, (heroPictureBox.Location.X + 25) / 25,
            (heroPictureBox.Location.Y - 25) / 25])
            {

                // move the hero 25 to the RIGHT
                if (e.KeyCode == Keys.Right)
                {
                    heroPictureBox.Left += 25;

                    // sets the imgage to right-facing
                    heroPictureBox.Image =
                        (Image)Properties.Resources.ResourceManager.GetObject(string.Format("HeroBMPRight"));

                    isMoved = true;
                }
            }

            if (heroPictureBox.Location.Y <= 300 &&
                levelArrays[maze.hero.Level - 1, (heroPictureBox.Location.X / 25),
                ((heroPictureBox.Location.Y) / 25)])
            {
                // move the hero 25 DOWN
                if (e.KeyCode == Keys.Down)
                {
                    heroPictureBox.Top += 25;

                    // sets the image to down-facing
                    heroPictureBox.Image =
                        (Image)Properties.Resources.ResourceManager.GetObject(string.Format("HeroBMPDown"));

                    isMoved = true;
                }
            }

            // if the hero is in the right spot, 
            // advance a level or decrement a level
            if (heroPictureBox.Left == 150 &&
                heroPictureBox.Top == 25)
            {
                advanceLevel();
            }
            else if (heroPictureBox.Left == 150 &&
                heroPictureBox.Top == 325 &&
                maze.hero.Level != 1)
            {
                decrementLevel();
            }
            // or show the killer rabbit!
            else if (maze.hero.Level == 4 &&
                heroPictureBox.Left == 150 &&
                heroPictureBox.Top == 100 &&
                isPast == false)
            {
                KillerRabbitAttack KR = new KillerRabbitAttack(this);
                KR.ShowDialog();

                healthLabel.Text = "Health: " + maze.hero.Health;
                isPast = true;
            }

            // or if the hero is right below the treasure chest,
            // prompt the You Have Won! schpeil
            else if (maze.hero.Level == 4 &&
                heroPictureBox.Left == 150 &&
                heroPictureBox.Top == 75)
            {
                MessageBox.Show("Congratulations!  You have found the treasure and " +
                    "you are now rich beyond your wildest dreams!", "Good times, eh?",
                    MessageBoxButtons.OK);

                // go back to the main menu, and reset all
                // hero's values
                callMainMenu();
                maze.hero.Health = 100;
                maze.hero.Money = 50;
                maze.hero.Level = 1;

                // move the hero back to the starting place
                heroPictureBox.Left = 150;
                heroPictureBox.Top = 325;
                // set the hero up-facing again
                heroPictureBox.Image =
                    (Image)Properties.Resources.ResourceManager.GetObject(string.Format("HeroBMP"));

                isPast = false;
            }

            // update levelLabel
           levelLabel.Text = "Level: " + maze.hero.Level;

            // draw the entryway and exit square
           using (Graphics graphics = mazePanel.CreateGraphics())
           {
               graphics.FillRectangle(new SolidBrush(Color.Green), 150, 0, 25, 25);
               graphics.FillRectangle(new SolidBrush(Color.Brown), 150, 300, 25, 25);
           }

            // if it's the last level, draw the treasure chest and the entryway
            if (maze.hero.Level == 4)
            {
                using (Graphics graphics = mazePanel.CreateGraphics())
                {
                    graphics.FillRectangle(new SolidBrush(Color.Yellow), 125, 0,
                        75, 50);
                    graphics.FillRectangle(new SolidBrush(Color.Brown), 150, 300, 25, 25);
                }
            }

            // if the hero has moved (and is not just
            // running against a wall), generate
            // a random event
            if (isMoved)
            {
                // randomly generate a number
                int isEvent = rand.Next(0, 20);

                // if the number is less than 1, spawn a monster
                if (isEvent <= 1)
                {
                    MonsterAttack();
                }
                // or if the number is a 10, spawn a bonus
                if (isEvent == 10)
                {
                    GetBonus();
                }
            }

            isMoved = false;
        }

        // generate a monster attack
        private void MonsterAttack()
        {
            // create a child form
            MonsterAttack mAttack = new MonsterAttack(this);

            // the array is initialized in maze
            if (maze.monsters[nMonsters] is Gremlin)
            {
                // change the mAttack appropriately
                mAttack.monsterAttackLabel.Text = "You have been attacked by a gremlin!";
                mAttack.monsterPictureBox.Image =
                    (Image)Properties.Resources.ResourceManager.GetObject(string.Format("Gremlin"));
            }
            else if (maze.monsters[nMonsters] is Liger)
            {
                mAttack.monsterAttackLabel.Text = "You have been attacked by a liger!";
                mAttack.monsterPictureBox.Image =
                    (Image)Properties.Resources.ResourceManager.GetObject(string.Format("Liger"));
            }
            else if (maze.monsters[nMonsters] is LadyBug)
            {
                mAttack.monsterAttackLabel.Text = "You have been attacked by a ladybug?";
                mAttack.monsterPictureBox.Image =
                    (Image)Properties.Resources.ResourceManager.GetObject(string.Format("Ladybug"));
            }
            else if (maze.monsters[nMonsters] is Bat)
            {
                mAttack.monsterAttackLabel.Text = "You have been attacked by a bat!";
                mAttack.monsterPictureBox.Image =
                    (Image)Properties.Resources.ResourceManager.GetObject(string.Format("Bat"));
            }
            else
            {
                mAttack.monsterAttackLabel.Text = "You have been attacked by a monster!";
            }

            mAttack.ShowDialog();

            // show the updated health
            healthLabel.Text = "Health: " + maze.hero.Health;
            // increment the array index counter
            nMonsters = ++nMonsters % 4;
        }

        // generate a bonus
        private void GetBonus()
        {
            try
            {
                // create a bonus child form
                FoundSomething fSomething = new FoundSomething();
                // change the form appropriately to the type
                // of bonus that it is
                if (maze.bonuses[nBonuses % 3] is ExtraHealth)
                {
                    fSomething.foundLabel.Text += "a health potion!";
                    maze.hero.AddHealth();
                    healthLabel.Text = "Health: " + maze.hero.Health;
                    fSomething.itemPictureBox.Image =
                        (Image)Properties.Resources.ResourceManager.GetObject(string.Format("HealthPotion"));
                    nBonuses = ++nBonuses % 3;
                }
                else if (maze.bonuses[nBonuses % 3] is ExtraMoney)
                {
                    fSomething.foundLabel.Text += "a bag of money!";
                    maze.hero.AddMoney();
                    moneyLabel.Text = "Money: " + maze.hero.Money;
                    fSomething.itemPictureBox.Image =
                        (Image)Properties.Resources.ResourceManager.GetObject(string.Format("MoneyBag"));
                    nBonuses = ++nBonuses % 3;
                }
                else if (maze.bonuses[nBonuses % 3] is ExtraSecretPassageWay &&
                    maze.hero.Level <= 3)
                {
                    fSomething.foundLabel.Text += "a secret passageway!";
                    advanceLevel();
                    fSomething.itemPictureBox.Image =
                    (Image)Properties.Resources.ResourceManager.GetObject(string.Format("SecretPassageWay"));
                    nBonuses = ++nBonuses % 3;
                }
                else
                {
                    fSomething.foundLabel.Text += "a bag of money!";
                    maze.hero.AddMoney();
                    moneyLabel.Text = "Money: " + maze.hero.Money;
                    fSomething.itemPictureBox.Image =
                        (Image)Properties.Resources.ResourceManager.GetObject(string.Format("MoneyBag"));
                    nBonuses = ++nBonuses % 3;
                }

                fSomething.ShowDialog();
            }

            // just in case that something goes awry
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            
        }

        // all the steps required to advance a level
        private void advanceLevel()
        {
            // add a level to the hero
            maze.hero.AddLevel();

            // move the hero back to the starting place
            heroPictureBox.Left = 150;
            heroPictureBox.Top = 325;
            // set the hero up-facing again
            heroPictureBox.Image =
                (Image)Properties.Resources.ResourceManager.GetObject(string.Format("HeroBMP"));

            //draw the next level
            for (int x = 0; x < 13; x++)
            {
                for (int y = 0; y < 13; y++)
                {
                    using (Graphics graphics = mazePanel.CreateGraphics())
                    {
                        if (levelArrays[maze.hero.Level - 1, x, y])
                            graphics.FillRectangle(new SolidBrush(Color.LightGray), x * 25, y * 25,
                                25, 25);
                        else
                            graphics.FillRectangle(new SolidBrush(Color.DarkGray), x * 25, y * 25,
                                25, 25);
                    }
                }
            }

            // re-draw the entryway and exit
            using (Graphics graphics = mazePanel.CreateGraphics())
            {
                graphics.FillRectangle(new SolidBrush(Color.Green), 150, 0, 25, 25);
                graphics.FillRectangle(new SolidBrush(Color.Brown), 150, 300, 25, 25);
            }

            // if it's the final level, then draw the yellow treasure chest
            if (maze.hero.Level == 4)
            {
                using (Graphics graphics = mazePanel.CreateGraphics())
                {
                    graphics.FillRectangle(new SolidBrush(Color.Yellow), 125, 0,
                        75, 50);
                }
            }

            // update the levelLabel
            levelLabel.Text = "Level: " + maze.hero.Level;
        }

        private void decrementLevel()
        {
            // add a level to the hero
            maze.hero.MinusLevel();

            // move the hero back to the starting place
            heroPictureBox.Left = 150;
            heroPictureBox.Top = 25;
            // set the hero up-facing again
            heroPictureBox.Image =
                (Image)Properties.Resources.ResourceManager.GetObject(string.Format("HeroBMPDown"));

            //draw the next level
            for (int x = 0; x < 13; x++)
            {
                for (int y = 0; y < 13; y++)
                {
                    using (Graphics graphics = mazePanel.CreateGraphics())
                    {
                        if (levelArrays[maze.hero.Level - 1, x, y])
                            graphics.FillRectangle(new SolidBrush(Color.LightGray), x * 25, y * 25,
                                25, 25);
                        else
                            graphics.FillRectangle(new SolidBrush(Color.DarkGray), x * 25, y * 25,
                                25, 25);
                    }
                }
            }

            // re-draw the entryway and exit
            using (Graphics graphics = mazePanel.CreateGraphics())
            {
                graphics.FillRectangle(new SolidBrush(Color.Green), 150, 0, 25, 25);
                graphics.FillRectangle(new SolidBrush(Color.Brown), 150, 300, 25, 25);
            }

            // update the levelLabel
            levelLabel.Text = "Level: " + maze.hero.Level;
        }

        public void callMainMenu()
        {
            // make the main menu options visible and
            // enabled
            titleLabel.Visible = true;
            playButton.Visible = true;
            playButton.Enabled = true;
            loadButton.Visible = true;
            loadButton.Enabled = true;
            instructionsButton.Visible = true;
            instructionsButton.Enabled = true;
            quitButton.Visible = true;
            quitButton.Enabled = true;

            // hide the maze, hero, and stats
            mazePanel.Visible = false;
            heroPictureBox.Visible = false;
            healthLabel.Visible = false;
            moneyLabel.Visible = false;
            levelLabel.Visible = false;
        }

        // tediously set every path-square to true
        // all other indexes are automatically false
        private void setArrays()
        { 
            //array 0
            // level9Array[column, row]
            levelArrays[0, 6, 0] = true;
            levelArrays[0, 7, 0] = true;
            levelArrays[0, 8, 0] = true;
            levelArrays[0, 9, 0] = true;

            levelArrays[0, 6, 1] = true;
            levelArrays[0, 7, 1] = true;
            levelArrays[0, 9, 1] = true;

            levelArrays[0, 9, 2] = true;
            levelArrays[0, 10, 2] = true;

            levelArrays[0, 9, 3] = true;
            levelArrays[0, 10, 3] = true;

            for (int i = 1; i < 13; i++)
                levelArrays[0, i, 4] = true;

            levelArrays[0, 1, 5] = true;
            levelArrays[0, 2, 5] = true;
            levelArrays[0, 6, 5] = true;
            levelArrays[0, 7, 5] = true;
            levelArrays[0, 11, 5] = true;
            levelArrays[0, 12, 5] = true;

            levelArrays[0, 0, 6] = true;
            levelArrays[0, 1, 6] = true;
            levelArrays[0, 3, 6] = true;
            levelArrays[0, 4, 6] = true;
            levelArrays[0, 5, 6] = true;
            levelArrays[0, 12, 6] = true;

            levelArrays[0, 0, 7] = true;
            levelArrays[0, 3, 7] = true;
            levelArrays[0, 8, 7] = true;
            levelArrays[0, 9, 7] = true;
            levelArrays[0, 10, 7] = true;
            levelArrays[0, 12, 7] = true;

            levelArrays[0, 0, 8] = true;
            levelArrays[0, 2, 8] = true;
            levelArrays[0, 3, 8] = true;
            levelArrays[0, 5, 8] = true;
            levelArrays[0, 6, 8] = true;
            levelArrays[0, 7, 8] = true;
            levelArrays[0, 8, 8] = true;
            levelArrays[0, 10, 8] = true;
            levelArrays[0, 11, 8] = true;
            levelArrays[0, 12, 8] = true;

            levelArrays[0, 0, 9] = true;
            levelArrays[0, 2, 9] = true;
            levelArrays[0, 3, 9] = true;
            levelArrays[0, 4, 9] = true;
            levelArrays[0, 5, 9] = true;
            levelArrays[0, 7, 9] = true;
            levelArrays[0, 8, 9] = true;
            levelArrays[0, 11, 9] = true;
            levelArrays[0, 12, 9] = true;

            levelArrays[0, 0, 10] = true;
            levelArrays[0, 4, 10] = true;
            levelArrays[0, 8, 10] = true;

            levelArrays[0, 0, 11] = true;
            levelArrays[0, 1, 11] = true;
            levelArrays[0, 2, 11] = true;
            levelArrays[0, 3, 11] = true;
            levelArrays[0, 4, 11] = true;
            levelArrays[0, 6, 11] = true;
            levelArrays[0, 7, 11] = true;
            levelArrays[0, 8, 11] = true;

            levelArrays[0, 4, 12] = true;
            levelArrays[0, 6, 12] = true;

            //array 1
            levelArrays[1, 2, 0] = true;
            levelArrays[1, 3, 0] = true;
            levelArrays[1, 4, 0] = true;
            levelArrays[1, 5, 0] = true;
            levelArrays[1, 6, 0] = true;

            levelArrays[1, 1, 1] = true;
            levelArrays[1, 2, 1] = true;
            levelArrays[1, 7, 1] = true;
            levelArrays[1, 8, 1] = true;
            levelArrays[1, 9, 1] = true;
            levelArrays[1, 10, 1] = true;

            levelArrays[1, 2, 2] = true;
            levelArrays[1, 3, 2] = true;
            levelArrays[1, 4, 2] = true;
            levelArrays[1, 5, 2] = true;
            levelArrays[1, 6, 2] = true;
            levelArrays[1, 7, 2] = true;
            levelArrays[1, 9, 2] = true;
            levelArrays[1, 10, 2] = true;
            levelArrays[1, 11, 2] = true;

            levelArrays[1, 5, 3] = true;
            levelArrays[1, 8, 3] = true;
            levelArrays[1, 11, 3] = true;

            levelArrays[1, 1, 4] = true;
            levelArrays[1, 2, 4] = true;
            levelArrays[1, 4, 4] = true;
            levelArrays[1, 5, 4] = true;
            levelArrays[1, 6, 4] = true;
            levelArrays[1, 7, 4] = true;
            levelArrays[1, 8, 4] = true;
            levelArrays[1, 11, 4] = true;

            levelArrays[1, 0, 5] = true;
            levelArrays[1, 1, 5] = true;
            levelArrays[1, 2, 5] = true;
            levelArrays[1, 4, 5] = true;
            levelArrays[1, 9, 5] = true;
            levelArrays[1, 10, 5] = true;
            levelArrays[1, 11, 5] = true;

            levelArrays[1, 0, 6] = true;
            levelArrays[1, 2, 6] = true;
            levelArrays[1, 3, 6] = true;
            levelArrays[1, 5, 6] = true;
            levelArrays[1, 6, 6] = true;
            levelArrays[1, 7, 6] = true;
            levelArrays[1, 11, 6] = true;

            levelArrays[1, 0, 7] = true;
            levelArrays[1, 5, 7] = true;
            for (int i = 7; i < 13; i++)
            {
                levelArrays[1, i, 7] = true;
            }

            for (int i = 0; i < 6; i++)
            {
                levelArrays[1, i, 8] = true;
            }
            levelArrays[1, 7, 8] = true;
            levelArrays[1, 12, 8] = true;

            levelArrays[1, 2, 9] = true;
            levelArrays[1, 3, 9] = true;
            levelArrays[1, 7, 9] = true;
            levelArrays[1, 8, 9] = true;
            levelArrays[1, 9, 9] = true;
            levelArrays[1, 11, 9] = true;
            levelArrays[1, 12, 9] = true;

            levelArrays[1, 1, 10] = true;
            levelArrays[1, 2, 10] = true;
            levelArrays[1, 3, 10] = true;
            levelArrays[1, 5, 10] = true;
            levelArrays[1, 6, 10] = true;
            levelArrays[1, 9, 10] = true;
            levelArrays[1, 10, 10] = true;
            levelArrays[1, 11, 10] = true;

            levelArrays[1, 1, 11] = true;
            levelArrays[1, 5, 11] = true;
            levelArrays[1, 6, 11] = true;

            for (int i = 0; i < 7; i++)
            {
                levelArrays[1, i, 12] = true;
            }

            //array 2
            levelArrays[2, 6, 0] = true;
            levelArrays[2, 7, 0] = true;

            levelArrays[2, 3, 1] = true;
            levelArrays[2, 4, 1] = true;
            levelArrays[2, 5, 1] = true;
            levelArrays[2, 7, 1] = true;
            levelArrays[2, 8, 1] = true;
            levelArrays[2, 9, 1] = true;
            levelArrays[2, 10, 1] = true;
            levelArrays[2, 11, 1] = true;

            levelArrays[2, 0, 2] = true;
            levelArrays[2, 1, 2] = true;
            levelArrays[2, 2, 2] = true;
            levelArrays[2, 3, 2] = true;
            levelArrays[2, 6, 2] = true;
            levelArrays[2, 11, 2] = true;

            levelArrays[2, 0, 3] = true;
            for (int i = 4; i < 12; i++)
            {
                levelArrays[2, i, 3] = true;
            }

            levelArrays[2, 0, 4] = true;
            levelArrays[2, 1, 4] = true;
            levelArrays[2, 2, 4] = true;
            levelArrays[2, 4, 4] = true;
            levelArrays[2, 5, 4] = true;
            levelArrays[2, 6, 4] = true;
            levelArrays[2, 7, 4] = true;

            levelArrays[2, 0, 5] = true;
            levelArrays[2, 2, 5] = true;
            levelArrays[2, 5, 5] = true;
            levelArrays[2, 8, 5] = true;

            levelArrays[2, 0, 6] = true;
            levelArrays[2, 1, 6] = true;
            levelArrays[2, 2, 6] = true;
            for (int i = 5; i < 12; i++)
            {
                levelArrays[2, i, 6] = true;
            }

            levelArrays[2, 2, 7] = true;
            levelArrays[2, 6, 7] = true;
            levelArrays[2, 10, 7] = true;
            levelArrays[2, 11, 7] = true;
            levelArrays[2, 12, 7] = true;

            levelArrays[2, 0, 8] = true;
            levelArrays[2, 1, 8] = true;
            levelArrays[2, 2, 8] = true;
            levelArrays[2, 3, 8] = true;
            levelArrays[2, 6, 8] = true;
            levelArrays[2, 8, 8] = true;
            levelArrays[2, 10, 8] = true;
            levelArrays[2, 12, 8] = true;

            levelArrays[2, 0, 9] = true;
            levelArrays[2, 3, 9] = true;
            levelArrays[2, 4, 9] = true;
            levelArrays[2, 8, 9] = true;
            levelArrays[2, 10, 9] = true;
            levelArrays[2, 12, 9] = true;

            levelArrays[2, 0, 10] = true;
            levelArrays[2, 1, 10] = true;
            levelArrays[2, 2, 10] = true;
            levelArrays[2, 4, 10] = true;
            levelArrays[2, 5, 10] = true;
            levelArrays[2, 6, 10] = true;
            levelArrays[2, 7, 10] = true;
            levelArrays[2, 8, 10] = true;
            levelArrays[2, 10, 10] = true;

            levelArrays[2, 2, 11] = true;
            levelArrays[2, 8, 11] = true;
            levelArrays[2, 10, 11] = true;

            for (int i = 2; i < 7; i++)
            {
                levelArrays[2, i, 12] = true;
            }
            levelArrays[2, 8, 12] = true; 
            levelArrays[2, 9, 12] = true;
            levelArrays[2, 10, 12] = true;

            //final array
            for (int i = 0; i < 13; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    levelArrays[3, i, j] = true;
                }
            }
            levelArrays[3, 5, 0] = false;
            levelArrays[3, 6, 0] = false;
            levelArrays[3, 7, 0] = false;
            levelArrays[3, 5, 1] = false;
            levelArrays[3, 6, 1] = false;
            levelArrays[3, 7, 1] = false;
            levelArrays[3, 6, 4] = true;
            levelArrays[3, 6, 5] = true;
            levelArrays[3, 6, 6] = true;
            levelArrays[3, 6, 7] = true;
            levelArrays[3, 6, 8] = true;
            levelArrays[3, 6, 9] = true;
            levelArrays[3, 6, 10] = true;
            levelArrays[3, 6, 11] = true;
            levelArrays[3, 6, 12] = true;
        }

        // tell a little about the author in the toolstrip menu item
        private void aboutTheAuthorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Amy Hannon wrote this program for a final project in CS 371" +
                " - Windows Application Development.  She took the class for January term of" +
                " 2012, at Whitworth University.  Amy is double-majoring in math and in " +
                "computer science.");
        }

    }
}
