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
    public partial class Instructions : Form
    {
        // indicates which page the instructions are on
        public int pageNum = 1;


        public Instructions()
        {
            InitializeComponent();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            switch (pageNum)
            {
                case 2:
                    backgroundTextLabel.Visible = true;
                    controlTextLabel.Visible = false;
                    monstersTextLabel.Visible = false;
                    goodLuckTextLabel.Visible = false;
                    break;
                case 3:
                    backgroundTextLabel.Visible = false;
                    controlTextLabel.Visible = true;
                    monstersTextLabel.Visible = false;
                    goodLuckTextLabel.Visible = false;
                    break;
                case 4:
                    backgroundTextLabel.Visible = false;
                    controlTextLabel.Visible = false;
                    monstersTextLabel.Visible = true;
                    goodLuckTextLabel.Visible = false;
                    nextButton.Enabled = true;
                    break;
                default:
                    backgroundTextLabel.Text =
                        "Welcome to the instructions page.\n";
                    break;
            }    

            --pageNum;
            
            if (pageNum == 1)
            {
                backButton.Enabled = false;
            }
        }

        private void nextButton_Click(object sender, EventArgs e)
        {
            switch (pageNum)
            {
                case 1:
                    backgroundTextLabel.Visible = false;
                    controlTextLabel.Visible = true;
                    monstersTextLabel.Visible = false;
                    goodLuckTextLabel.Visible = false;
                    backButton.Enabled = true;
                    break;
                case 2:
                    backgroundTextLabel.Visible = false;
                    controlTextLabel.Visible = false;
                    monstersTextLabel.Visible = true;
                    goodLuckTextLabel.Visible = false;
                    break;
                case 3:
                    backgroundTextLabel.Visible = false;
                    controlTextLabel.Visible = false;
                    monstersTextLabel.Visible = false;
                    goodLuckTextLabel.Visible = true;
                    break;
                default:
                    backgroundTextLabel.Text =
                        "Welcome to the instructions page.\n";
                    break;
            }

            pageNum++;

            if (pageNum == 4)
            {
                nextButton.Enabled = false;
            }
        }
    }
}
