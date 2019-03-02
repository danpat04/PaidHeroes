﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PaidHeroes.Core
{
    public enum StatType
    {
        Strength = 1,
        Agility = 2,
        Intelligence = 3,
    };

    public class Stats
    {
        private readonly Dictionary<StatType, int> _baseStats;
        private readonly Dictionary<StatType, int> _addedStats;
        private int _addedStatCount = -1;

        public int AddedStatCount
        {
            get
            {
                if (_addedStatCount < 0)
                {
                    _addedStatCount = _addedStats.Select(x => x.Value).Sum();
                }
                return _addedStatCount;
            }
        }

        public Stats()
        {
            _baseStats = GenerateRandomBaseStats();
            _addedStats = new Dictionary<StatType, int>();
        }

        public Stats(Dictionary<StatType, int> baseStats, Dictionary<StatType, int> addedStats)
        {
            _baseStats = baseStats;
            _addedStats = addedStats;
        }

        private static Dictionary<StatType, int> GenerateRandomBaseStats()
        {
            throw new NotImplementedException();
        }

        public void Add(StatType type, int point)
        {
            if (_addedStats.TryGetValue(type, out int prev))
            {
                _addedStats[type] = point + prev;
            }
            else
            {
                _addedStats.Add(type, point);
            }
        }

        public int Get(StatType type)
        {
            var baseStat = 0;
            _baseStats.TryGetValue(type, out baseStat);

            var addedStat = 0;
            _addedStats.TryGetValue(type, out addedStat);

            return baseStat + addedStat;
        }
    }
}