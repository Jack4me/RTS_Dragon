using Character;
using Configuration;
using UnityEngine;

namespace Unit {
    [CreateAssetMenu(menuName = "DragonCraft/New Unit")]
    public class UnitData : BaseCharacterData {
        public UnitType UnitType;
        public int Level;
        public float LevelMultiplier;
        public ActionType Actions;
    }
}
