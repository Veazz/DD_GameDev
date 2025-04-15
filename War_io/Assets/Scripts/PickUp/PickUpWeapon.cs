using UnityEngine;
using War_io.Shooting;

namespace War_io.PickUp
{
    [System.Serializable]
    public class PickUpWeapon : PickUpItem
    {
        [SerializeField]
        public Weapons _weaponPrefab;

        public override void OnPickedUp(BaseCharacter character)
        {
            base.OnPickedUp(character);
            character.SetWeapon(_weaponPrefab);
        }
    }
}