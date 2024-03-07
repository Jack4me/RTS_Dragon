using System.Collections.Generic;
using Level;
using UnityEngine;

namespace Configuration.LevelConfiguration.Data {
    [CreateAssetMenu(menuName = "Dragoncraft/New Level")]
    public class LevelData : ScriptableObject {
        public List<LevelSlot> Slots = new List<LevelSlot>();
        public int Columns;
        public int Rows;
        public global::Level.LevelConfiguration Configuration;
    }
}