using System;
using System.Collections.Generic;

namespace PaidHeroes.Core
{
    public class Hero
    {
        public string Name { get; private set; }
        public int Level { get; private set; } = 1;
        private readonly Stats _stats;
        private readonly Abilities _abilities;

        public int UsableStatPoint => Level - _stats.AddedStatCount - 1;
        public int UsableAbilityPoint => Level - _abilities.AddedAbilityCount - 1;

        public Hero(string name, int level)
        {
            Name = name;
            Level = level;
            _stats = new Stats();
            _abilities = new Abilities();
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
            _stats.Add(type, point);
        }

        public void AddAbility(string ability, int point)
        {
            if (point < UsableAbilityPoint)
            {
                throw new AbilityPointOverflowError();
            }
            _abilities.Add(ability, point);
        }
    }
}
