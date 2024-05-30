using System;
using System.Collections.Generic;
using Unit;
using UnityEngine;

namespace UI {
    public class SeleectedUIPortrait : MonoBehaviour {
        
        public static SeleectedUIPortrait Instance { get; private set; }
        public Transform portraitContainer;
        private List<UnitComponent> unitList;
        public List<GameObject> _units;
        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        public void ShowIUFrame(List<UnitComponent> units) {
            unitList = units;
           UnitComponent unit = unitList[0];
           
           if (unit.Type == UnitType.Warrior) {
               _units[0].gameObject.SetActive(true); 
               _units[1].gameObject.SetActive(false); 
           } else if (unit.Type == UnitType.Mage) {
               _units[1].gameObject.SetActive(true); 
               _units[0].gameObject.SetActive(false);
           }
           else {
               _units[0].gameObject.SetActive(false);
               _units[1].gameObject.SetActive(false); 


           }
            
       }
    }
}
