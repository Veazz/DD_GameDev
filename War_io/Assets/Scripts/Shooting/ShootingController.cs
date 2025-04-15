using System.Collections;
using UnityEngine;

namespace War_io.Shooting
{
    public class ShootingController : MonoBehaviour
    {
        public bool HasTarget => _target != null;
        public Vector3 TargetPosition => _target.transform.position;
        public Weapons weapon { get; private set; }
        private float _nextShotTimeSec;

        private GameObject _target;
        private Collider[] _colliders = new Collider[3];

        void Update()
        {
            _target = GetTarget();

            _nextShotTimeSec -= Time.deltaTime;
            if (_nextShotTimeSec < 0)
            {
                if (HasTarget)
                    weapon.Shoot(TargetPosition);

                _nextShotTimeSec = 1 / weapon.ShootFrequencySec;
            }
        }

        public GameObject GetTarget()
        {
            GameObject target = null;

            var position = weapon.transform.position;
            var radius = weapon.ShootRadius;
            var mask = LayerUtils.EnemyMask;

            var size = Physics.OverlapSphereNonAlloc(position, radius, _colliders, mask);
            if (size > 0)
            {
                for (int i = 0; i < size; i++)
                {
                    if ( _colliders[i].gameObject != gameObject)
                    {
                        target = _colliders[i].gameObject;
                        break;
                    }
                }
            }

            return target;
        }

        public void SetWeapon(Weapons weaponPrefab, Transform hand)
        {
            if (weapon != null)
                Destroy(weapon.gameObject);
            weapon = Instantiate(weaponPrefab, hand);
            weapon.transform.localPosition = Vector3.zero;
            weapon.transform.localRotation = Quaternion.identity;
        }
    }
}