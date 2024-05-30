using System.Collections.Generic;
using Unit;
using UnityEngine;
using UnityEngine.UI;

namespace UI {
    public class UIIconsUnits : MonoBehaviour
    {
        public static UIIconsUnits Instance { get; private set; }
        public Transform portraitContainer;
        private List<UnitComponent> unitList;
        public List<GameObject> _units;
        
        public Sprite orcSprite;
        public Sprite mageSprite;
        public GameObject unitUIPrefab; 
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

        public void ShowUnitUIPortrait(List<UnitComponent> units) {
            foreach (Transform child in portraitContainer) {
                Destroy(child.gameObject);
            }
            // unitList = units;
            // UnitComponent unit =unitList[0].gameObject.GetComponent<UnitComponent>();
            // if (unit.Type == UnitType.Warrior) {
            //     GameObject unitUI = Instantiate(unitUIPrefab, portraitContainer);
            //     Image unitUIImage = unitUI.GetComponent<Image>();
            //     unitUIImage.sprite = orcSprite;
            // }
            foreach (var unit in units) {
                GameObject unitUI = Instantiate(unitUIPrefab, portraitContainer);
            
                Image unitUIImage = unitUI.GetComponent<Image>();
            
                if (unit.Type == UnitType.Warrior) {
                    unitUIImage.sprite = orcSprite;
                } else if (unit.Type == UnitType.Mage) {
                    unitUIImage.sprite = mageSprite;
                }
            }
            
        }
    }
}

