using System;

namespace PaidHeroes.Core
{
    public class Hero
    {
        public string Name { get; private set; }
        public int Level { get; private set; } = 1;
        public readonly Stats Stats;

        public int UsableStatPoint => Level - Stats.AddedStatCount - 1;

        public Hero(string name, int level)
        {
            Name = name;
            Level = level;
            Stats = new Stats();
        }

        public void SetLevel(int level)
        {
            Level = level;
        }

        public void AddStat(StatType type, int point)
        {
            if (point < UsableStatPoint)
            {
                throw new StatPointOverflowError();
            }
            Stats.Add(type, point);
        }
    }
}
