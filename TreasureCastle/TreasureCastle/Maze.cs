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
    public class Maze
    {
        public Random rand = new Random();

        public TreasureSeeker hero;
        public Monster[] monsters;
        public Bonus[] bonuses;

        public Maze(int health, int money, int level)
        {            
            hero = new TreasureSeeker(health, money, level);
            monsters = new Monster[4];
            bonuses = new Bonus[5];

            for (int i = 0; i < 4; i++)
            {
                if (rand.Next(0,4) == 0)
                {
                    monsters[i] = new Gremlin();
                }
                else if (rand.Next(0, 4) == 1)
                {
                    monsters[i] = new LadyBug();
                }
                else if (rand.Next(0, 4) == 2)
                {
                    monsters[i] = new Bat();
                }
                else
                {
                    monsters[i] = new Liger();
                }
            }

            bonuses[0] = new ExtraHealth();

            for (int i = 1; i < 5; i++)
            {
                if (rand.Next(0,3) == 0)
                {
                    bonuses[i] = new ExtraHealth();
                }
                else if (rand.Next(0,3) == 1)
                {
                    bonuses[i] = new ExtraMoney();
                }
                else
                {
                    bonuses[i] = new ExtraSecretPassageWay();
                }
            }


        }
    }
}
