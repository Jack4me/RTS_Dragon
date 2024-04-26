using Enemy;
using Unit;
using UnityEditor;
using UnityEngine;

namespace Tests {
    public class BaseTest {
        protected UnitData LoadUnit(string unit) {
            return AssetDatabase.LoadAssetAtPath<UnitData>($"Assets/Data/Unit/{unit}.asset");
        }
        protected EnemyData LoadEnemy(string enemy)
        {
            return AssetDatabase.LoadAssetAtPath<EnemyData>($"Assets/Data/Enemy/{enemy}.asset");
        }
        protected EnemyGroupData LoadEnemyGroup(string enemyGroup)
        {
            return AssetDatabase.LoadAssetAtPath<EnemyGroupData>($"Assets/Data/EnemyGroup/{enemyGroup}.asset");
        }
    }
}