using System;
using Unit;
using UnityEngine;


namespace Store {
    [Serializable]
    public class UnitStoreItem : StoreItem
    {
    public UnitType Unit;
    public bool IsUpgrade;
    }
}
