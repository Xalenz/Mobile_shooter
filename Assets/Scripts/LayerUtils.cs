using UnityEngine;

namespace Game
{
    public static class LayerUtils
    {
        public const string BulletLayerName = "Bullet";
        public const string PlayerLayerName = "Player";
        public const string EnemyLayerName = "Enemy";

        public static readonly int BulletLayer = LayerMask.NameToLayer(BulletLayerName);
        public static readonly int PlayerLayer = LayerMask.NameToLayer(PlayerLayerName);
        public static readonly int EnemyLayer = LayerMask.NameToLayer(EnemyLayerName);

        public static readonly int EnemyMask = LayerMask.GetMask(EnemyLayerName, PlayerLayerName);
        public static bool IsBullet(GameObject other) => other.layer == BulletLayer;
    }
}
