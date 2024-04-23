using System.Collections.Generic;
using Enemy;
using UnityEngine;

namespace Level {
    [CreateAssetMenu(menuName = "DragonCraft/New Level")]
    public class LevelData : ScriptableObject {
        public List<LevelSlot> Slots = new ();
        public int Columns;
        public int Rows;
        public Configuration.LevelConfigurations.Data.LevelConfiguration Configuration;
        public List<EnemyGroupConfiguration> EnemyGroups = new List<EnemyGroupConfiguration>();
    }
}