using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PaidHeroes.Core
{
    [Flags]
    public enum Row
    {
        Front = 1,
        Back = 2,

        // MASK
        Invalid = -1,
        None = 0,
        All = 3,
    }

    [Flags]
    public enum Position
    {
        Left = 1,
        Middle = 2,
        Right = 4,

        // MASK
        Invalid = -1,
        None = 0,
        All = 7
    }

    public struct Location
    {
        Row r;
        Position p;

        static Location FrontRow = new Location(Row.Front, Position.All);
        static Location BackRow = new Location(Row.Back, Position.All);
        static Location All = new Location(Row.All, Position.All);

        public Location(Row r, Position p)
        {
            this.r = r;
            this.p = p;
        }

        public bool IsTarget(Location mask)
        {
            return ((r & mask.r) != 0) && ((p & mask.p) != 0);
        }

        public bool IsValid()
        {
            return (r == Row.Front || r == Row.Back) && (p == Position.Left || p == Position.Middle || p == Position.Right);
        }
    }

    class Team
    {
        public string Name { get; private set; }
        private readonly Dictionary<Location, Hero> _heroes = new Dictionary<Location, Hero>();

        public Team(string name)
        {
            Name = name;
        }

        public bool Add(Hero hero, Location location)
        {
            if (location.IsValid())
            {
                throw new ArgumentException();
            }

            if (GetHero(hero.Name) != null)
            {
                return false;
            }

            _heroes.Add(location, hero);
            return true;
        }

        public Hero Remove(string heroName)
        {
            // default for location is (Row.none, Position.none)
            var location = (from pair in _heroes where pair.Value.Name == heroName select pair.Key).FirstOrDefault();
            if (!location.IsValid()) return null;
            return Remove(location);
        }

        public Hero Remove(Location location)
        {
            _heroes.Remove(location, out var hero);
            return hero;
        }
        public IEnumerable<Hero> Heroes(Func<Hero, bool> filter = null)
        {
            filter = filter != null ? filter : (h) => true;
            return from pair in _heroes where filter(pair.Value) select pair.Value;
        }

        public Hero GetHero(string name)
        {
            return Heroes(hero => hero.Name == name).FirstOrDefault();
        }

        public Dictionary<Location, BattleStatus> InitialBattleStatus()
        {
            var status = new Dictionary<Location, BattleStatus>();
            foreach (var pair in _heroes)
            {
                status.Add(pair.Key, new BattleStatus(pair.Value));
            }
            return status;
        }
    }
}
