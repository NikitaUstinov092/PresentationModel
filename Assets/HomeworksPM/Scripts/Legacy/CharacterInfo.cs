using System;
using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;


namespace Lessons.Architecture.PM
{
    public sealed class CharacterInfo 
    {
        public event Action<CharacterStat> OnStatAdded;
        public event Action<CharacterStat> OnStatRemoved;

        [ShowInInspector]
        private readonly HashSet<CharacterStat> stats = new HashSet<CharacterStat>();

        [Button]
        public void AddStat(CharacterStat stat)
        {
            if (stats.Add(stat))
            {
                OnStatAdded?.Invoke(stat);
            }
        }

        [Button]
        public void RemoveStat(CharacterStat stat)
        {
            if (stats.Remove(stat))
            {
                OnStatRemoved?.Invoke(stat);
            }
        }

        public CharacterStat GetStat(string name)
        {
            foreach (var stat in stats.Where(stat => stat.Name == name))
            {
                return stat;
            }

            throw new Exception($"Stat {name} is not found!");
        }

        public CharacterStat[] GetStats()
        {
            return stats.ToArray();
        }

        public void ClearStat()
        {
            stats.Clear();
        }
    }
}