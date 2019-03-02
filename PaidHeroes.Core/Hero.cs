using System;

namespace PaidHeroes.Core
{
    public class Hero
    {
        public string Name { get; private set; }
        public int Level { get; private set; } = 1;

        public Hero(string name, int level)
        {
            Name = name;
            Level = level;
        }
    }
}
