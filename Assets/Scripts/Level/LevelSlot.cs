using System;
using Configuration;
using UnityEngine;

namespace Level {
    [Serializable]
    public class LevelSlot  {
        public LevelItemType ItemType;
        public Vector2Int Coordinates;

        public LevelSlot(LevelItemType type, Vector2Int coordinates) {
            ItemType = type;
            Coordinates = coordinates;
        }
    }
}