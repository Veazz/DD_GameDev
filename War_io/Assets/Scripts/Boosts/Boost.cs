using UnityEngine;

namespace War_io.Boosts
{
    public abstract class Boost : MonoBehaviour
    {
        [SerializeField]
        protected float _boostDuration;

        public abstract void Boosting(BaseCharacter character);
    }
}