using Character;
using Unit;
using UnityEngine;

namespace Enemy {
    [CreateAssetMenu(menuName = "Dragoncraft/New Enemy")]
    public class EnemyData : BaseCharacterData
    {
        public EnemyType Type;
        
    }
}
