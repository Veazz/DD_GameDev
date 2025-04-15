using UnityEngine;
using War_io.Movement;
using War_io.PickUp;
using War_io.Shooting;

namespace War_io
{
    [RequireComponent(typeof(CharacterMovementController), typeof(ShootingController))]
    public abstract class BaseCharacter : MonoBehaviour
    {
        [SerializeField]
        private Weapons _baseWeaponPrefab;

        [SerializeField]
        private Transform _hand;

        [SerializeField]
        private float _health = 10f;

        private IMovementDirectionSource _movementDirectionSource;
        private CharacterMovementController _characterMovementController;
        private ShootingController _shootingController;

        protected void Awake()
        {
            _movementDirectionSource = GetComponent<IMovementDirectionSource>();
            _characterMovementController = GetComponent<CharacterMovementController>();
            _shootingController = GetComponent<ShootingController>();
        }

        protected void Start()
        {
            SetWeapon(_baseWeaponPrefab);
        }

        protected void Update()
        {
            if (_health <= 0f)
                Destroy(gameObject);
            else
            {
                var direction = _movementDirectionSource.MovementDirection;
                var lookDirection = direction;
                if (_shootingController.HasTarget)
                    lookDirection = (_shootingController.TargetPosition - transform.position).normalized;

                _characterMovementController.MovemantDirection = direction;
                _characterMovementController.LookDirection = lookDirection;
            }
        }

        protected void OnTriggerEnter(Collider other)
        {
            if (LayerUtils.IsBullet(other.gameObject))
            {
                var bullet = other.gameObject.GetComponent<Bullet>();
                _health -= bullet.Damage;
                Destroy(other.gameObject);
            }
            else if(LayerUtils.IsWeaponPickUp(other.gameObject))
            {
                var weapon = other.gameObject.GetComponent<PickUpWeapon>();
                weapon.OnPickedUp(this);

                Destroy(other.gameObject);
                
            }
            else if (LayerUtils.IsBoostPickUp(other.gameObject))
            {
                var boost = other.gameObject.GetComponent<PickUpBoost>();
                boost.OnPickedUp(this);

                Destroy(other.gameObject);

            }
        }


        public void SetWeapon(Weapons weapon)
        {
            _shootingController.SetWeapon(weapon, _hand);
        }

        public void SpeedBoosting(float duration,  float speedBoostCoefficient)
        {
            _characterMovementController.SetSpeedBoost(duration, speedBoostCoefficient);
        }
    }
}