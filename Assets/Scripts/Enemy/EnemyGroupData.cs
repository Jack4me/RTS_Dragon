using System.Collections.Generic;
using UnityEngine;

namespace Enemy {
    [CreateAssetMenu(menuName = "Dragoncraft/New Enemy Group")]
    public class EnemyGroupData : ScriptableObject {
        public string Name; 
        public List<EnemyData> Enemies = new List<EnemyData>();
    }
}