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
    public partial class quitAreYouSure : Form
    {
        public quitAreYouSure()
        {
            InitializeComponent();
        }

        private void quitAreYouSure_Load(object sender, EventArgs e)
        {
            
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void quitButton_Click(object sender, EventArgs e)
        {
            // close the application
            Application.Exit();
        }

    }
}
