﻿using System.Collections;
using UnityEngine;

namespace War_io.Shooting
{
    public class ShootingController : MonoBehaviour
    {
        public bool HasTarget => _target != null;
        public Vector3 TargetPosition => _target.transform.position;

        private Weapons _weapon;
        private float _nextShotTimeSec;

        private GameObject _target;
        private Collider[] _colliders = new Collider[2];

        void Update()
        {
            _target = GetTarget();

            _nextShotTimeSec -= Time.deltaTime;
            if (_nextShotTimeSec < 0)
            {
                if (HasTarget)
                    _weapon.Shoot(TargetPosition);

                _nextShotTimeSec = _weapon.ShootFrequencySec;
            }
        }

        public GameObject GetTarget()
        {
            GameObject target = null;

            var position = _weapon.transform.position;
            var radius = _weapon.ShootRadius;
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
            _weapon = Instantiate(weaponPrefab, hand);
            _weapon.transform.localPosition = Vector3.zero;
            _weapon.transform.localRotation = Quaternion.identity;
        }
    }
}