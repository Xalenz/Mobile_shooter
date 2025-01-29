using UnityEngine;

namespace Game.Shooting
{
    public class Bullet : MonoBehaviour
    {
        private Vector3 _direcion;
        private float _flySpeed;
        private float _maxFlyDistance;
        private float _currentFlyDistance;

        public void Initialize(Vector3 direction, float maxFlyDistance, float flySpeed)
        {
            _direcion = direction;
            _maxFlyDistance = maxFlyDistance;
            _flySpeed = flySpeed;
        }

        protected void Update()
        {
            var delta = _flySpeed * Time.deltaTime;
            _currentFlyDistance += delta;
            transform.Translate(_direcion * delta);

            if (_currentFlyDistance > _maxFlyDistance)
                Destroy(gameObject);
        }

    }
}

