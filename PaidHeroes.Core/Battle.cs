using System;
using System.Collections.Generic;
using System.Linq;

namespace PaidHeroes.Core
{
    enum SquadType
    {
        Attacker,
        Defender,
    }

    struct Turn : IComparable<Turn>
    {
        public readonly SquadType SquadType;
        public readonly Guid HeroId;
        public readonly string ActionId;
        public readonly int Priority;
        public int At;

        private int _order;
        private static int MaxPriority = (int)Math.Pow(10, Stats.MaxStat.ToString().Length);

        public Turn(SquadType squadType, BattleStatus status, string actionId, int at)
        {
            SquadType = squadType;
            HeroId = status.Id;
            Priority = status.GetStat(StatType.Agility);
            ActionId = actionId;
            At = at;
            _order = At * MaxPriority + (MaxPriority - Priority);
        }

        private void Delayed(int dt)
        {
            At += dt;
            _order = At * MaxPriority + (MaxPriority - Priority);
        }

        public int CompareTo(Turn other)
        {
            // order가 클 수록 앞에 정렬된다.
            return other._order - _order;
        }
    }

    class BattleSquad
    {
        public readonly SquadType Type;
        private readonly Team _team;
        public readonly Dictionary<Location, BattleStatus> _battleStatus;

        public BattleSquad(SquadType type, Team team)
        {
            Type = type;
            _team = team;
            _battleStatus = team.InitialBattleStatus();
        }

        public IEnumerable<BattleStatus> IterBattleStatus()
        {
            return _battleStatus.Select(pair => pair.Value);
        }
    }

    class Battle
    {
        const int MaxBattleTime = 200 * 1000;

        private readonly BattleSquad _attacker;
        private readonly BattleSquad _defender;
        private readonly List<Turn> _turns;

        public Battle(Team attacker, Team defender)
        {
            _attacker = new BattleSquad(SquadType.Attacker, attacker);
            _defender = new BattleSquad(SquadType.Defender, defender);
            _turns = new List<Turn>();
        }

        private void InitializeTurns()
        {
            _turns.Clear();

            foreach (var status in _attacker.IterBattleStatus())
            {
                _turns.Add(new Turn(SquadType.Attacker, status, null, 0));
            }

            foreach (var status in _defender.IterBattleStatus())
            {
                _turns.Add(new Turn(SquadType.Defender, status, null, 0));
            }
        }
    }
}
