using UnityEngine;

namespace War_io
{
    public class LayerUtils : MonoBehaviour
    {
        public const string BulletLayerName = "Bullet";
        public const string EnemyLayerName = "Enemy";
        public const string PlayerLayerName = "Player";
        
        public static readonly int BulletLayer = LayerMask.NameToLayer(BulletLayerName);
        public static readonly int EnemyMask = LayerMask.GetMask(EnemyLayerName, PlayerLayerName);

        public static bool IsBullet(GameObject other)
        {
            return other.layer == BulletLayer;
        }
    }
}