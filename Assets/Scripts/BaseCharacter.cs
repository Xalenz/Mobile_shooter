using Game.Movement;
using Game.Shooting;
using UnityEngine;

namespace Game
{
    [RequireComponent(typeof(CharacterMovementController), typeof(ShootingController))]
    public class BaseCharacter : MonoBehaviour
    {
        [SerializeField]
        private Weapon _baseWeaponPrefab;

        [SerializeField]
        private Transform _hand;

        [SerializeField]
        private float _health = 2f;

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
            _shootingController.SetWeapon(_baseWeaponPrefab, _hand);
        }

        protected void Update()
        {
            var direction = _movementDirectionSource.MovementDirection;
            var lookDirection = direction;
            if (_shootingController.HasTarget)
                lookDirection = (_shootingController.TargetPosition - transform.position).normalized;

            _characterMovementController.MovementDirection = direction;
            _characterMovementController.LookDirection = lookDirection;

            if (_health <= 0f)
                Destroy(gameObject);
        }

        protected void OnTriggerEnter(Collider other)
        {
            if (LayerUtils.IsBullet(other.gameObject))
            {
                var bullet = other.GetComponent<Bullet>();

                _health -= bullet.Damage;

                Destroy(other.gameObject);
            }
        }
    }
}

