using System.Collections.Generic;
using UnityEngine;
using War_io.Boosts;

namespace War_io.PickUp
{
    public class PickUpBoost : PickUpItem
    {
        [SerializeField]
        public Boost _boostPrefab;

        public override void OnPickedUp(BaseCharacter character)
        {
            base.OnPickedUp(character);
            _boostPrefab.Boosting(character);
        }
    }
}