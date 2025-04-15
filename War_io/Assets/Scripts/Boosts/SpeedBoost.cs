using System.Collections;
using UnityEngine;
using War_io;
using War_io.Boosts;

namespace Assets.Scripts.Boosts
{
    public class SpeedBoost : Boost
    {
        [SerializeField]
        private float _speedBoostCoefficient = 2f;

        public override void Boosting(BaseCharacter character)
        {
            character.SpeedBoosting(_boostDuration, _speedBoostCoefficient);
        }
    }
}