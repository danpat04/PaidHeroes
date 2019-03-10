using System;
using System.Collections.Generic;
using System.Text;

namespace PaidHeroes.Core
{
    public enum StatusType
    {
        HP = 1,
        MP = 2,
    }

    class BattleStatus
    {
        private readonly Hero _hero;
        private readonly Dictionary<StatusType, float> _status = new Dictionary<StatusType, float>();

        public BattleStatus(Hero hero)
        {
            _hero = hero;
        }

        public void Initialize()
        {
            _status.Clear();
            var stats = _hero.GetStats();

            var hp = 100;
            if (stats.TryGetValue(StatType.Strength, out var str))
            {
                hp += str * 10;
            }
            _status.Add(StatusType.HP, hp);

            var mp = 100;
            if (stats.TryGetValue(StatType.Intelligence, out var i))
            {
                mp += i * 10;
            }
            _status.Add(StatusType.MP, mp);
        }
    }
}
