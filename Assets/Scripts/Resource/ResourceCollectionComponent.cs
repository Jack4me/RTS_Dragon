using Configuration;
using Unit;
using UnityEngine;

namespace Resource {
    public class ResourceCollectionComponent : ResourceProductionComponent {
        protected override void Start() {
            base.Start();
            _productionType = ResourceProductionType.Manual;
        }
        private void OnCollisionEnter(Collision col)
        {
            if (col.gameObject.TryGetComponent<UnitComponent>(out UnitComponent unit))
            {
                if (unit.GetActionType() == ActionType.Collect)
                {
                    _productionType = ResourceProductionType.Automatic;
                }
            }
        }
        private void OnCollisionExit(Collision col)
        {
            if (col.gameObject.TryGetComponent<UnitComponent>(out var unit))
            {
                _productionType = ResourceProductionType.Manual;
            }
        }
    }
}