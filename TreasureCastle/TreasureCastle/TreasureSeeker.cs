using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TreasureCastle
{
    public class TreasureSeeker
    {
        public int Health
        { get; set; }

        public int Money
        { get; set; }

        public int Level
        { get; set; }

        public TreasureSeeker(int health, int money, int level)
        {
            Health = health;
            Money = money;
            Level = level;
        }

        public void AddHealth()
        {
            /*ADD 20 HEALTH TO HERO WHEN EXTRAHEALTH
             * BONUS OCCURS
             * */
            Health += 20;
            
        }

        public void AddMoney()
        {
            /*ADD 10 MONEY TO HERO WHEN EXTRAMONEY
             * BONUS OCCURS
             * */
            Money += 10;
        }

        public void AddLevel()
        {
            /*INCREMENT A LEVEL AND TAKE
             * HERO TO NEXT LEVEL
             * */
            Level += 1;
        }

        public void MinusLevel()
        {
            /*DECREMENT A LEVEL AND TAKE
             * HERO TO PREVIOUS LEVEL
             * */
            Level -= 1;
        }
    }
}
