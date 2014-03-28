using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TreasureCastle
{
    public abstract class Monster
    {
        public int Health
        { get; set; }

        public string deadName
        { get; set; }

        public Monster()
        {
            Health = 1;
            deadName = "DeadMonster";
        }
    }
}
