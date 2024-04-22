using System.Collections.Generic;
using Level;
using UnityEngine;

namespace Configuration.LevelConfigurations.Data {
    [CreateAssetMenu(menuName = "DragonCraft/New Level")]
    public class LevelData : ScriptableObject {
        public List<LevelSlot> Slots = new ();
        public int Columns;
        public int Rows;
        public LevelConfiguration Configuration;
    }
}