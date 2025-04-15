using System;
using UnityEngine;
using War_io.Shooting;

namespace War_io.PickUp
{
    public abstract class PickUpItem : MonoBehaviour
    {
        public event Action<PickUpItem> PickedUp;

        public virtual void OnPickedUp(BaseCharacter character)
        {
            PickedUp?.Invoke(this);
        }
    }
}