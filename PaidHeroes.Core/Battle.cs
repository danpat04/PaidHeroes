using System;
using System.Collections.Generic;
using System.Text;

namespace PaidHeroes.Core
{
    class BattleSquad
    {
        private readonly Team _team;
        public readonly Dictionary<Location, BattleStatus> _battleStatus;

        public BattleSquad(Team team)
        {
            _team = team;
            _battleStatus = team.InitialBattleStatus();
        }
    }

    class Battle
    {
        private readonly BattleSquad _a;
        private readonly BattleSquad _b;

        public Battle(Team a, Team b)
        {
            _a = new BattleSquad(a);
            _b = new BattleSquad(b);
        }
    }
}
