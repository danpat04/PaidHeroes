using System;
using System.Collections.Generic;
using System.Text;

namespace PaidHeroes.Core
{
    public class Abilities
    {
        private readonly Dictionary<string, int> _baseAbilities;
        private readonly Dictionary<string, int> _addedAbilities;

        public int AddedAbilityCount { get; private set; } = 0;

        public Abilities()
        {
            _baseAbilities = GenerateRandomAbilities();
            _addedAbilities = new Dictionary<string, int>();
        }

        public static Dictionary<string, int> GenerateRandomAbilities()
        {
            throw new NotImplementedException();
        }

        public void Add(string ability, int point)
        {
            int prev;
            if (_baseAbilities.TryGetValue(ability, out prev))
            {
                _baseAbilities[ability] = prev + point;
            }
            else if(_addedAbilities.TryGetValue(ability, out prev))
            {
                _addedAbilities[ability] = prev + point;
            }
            else
            {
                _addedAbilities.Add(ability, point);
            }
            AddedAbilityCount += point;
        }
    }
}
