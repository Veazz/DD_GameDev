using UnityEngine;

namespace War_io
{
    public class LayerUtils : MonoBehaviour
    {
        public const string BulletLayerName = "Bullet";
        public const string EnemyLayerName = "Enemy";
        public const string PlayerLayerName = "Player";
        public const string WeaponPickUpLayerName = "WeaponPickUp";
        public const string BoostPickUpLayerName = "BoostPickUp";
        
        public static readonly int BulletLayer = LayerMask.NameToLayer(BulletLayerName);
        public static readonly int WeaponPickUpLayer = LayerMask.NameToLayer(WeaponPickUpLayerName);
        public static readonly int BoostPickUpLayer = LayerMask.NameToLayer(BoostPickUpLayerName);
        public static readonly int EnemyMask = LayerMask.GetMask(EnemyLayerName, PlayerLayerName);

        public static bool IsBullet(GameObject other)
        {
            return other.layer == BulletLayer;
        }

        public static bool IsWeaponPickUp(GameObject other) => other.layer == WeaponPickUpLayer;
        public static bool IsBoostPickUp(GameObject other) => other.layer == BoostPickUpLayer;
    }
}