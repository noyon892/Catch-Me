using UnityEngine;

namespace Assets.Scripts
{
    public class Projectile : MonoBehaviour
    {
        public LayerMask CollisionMask;
        private float _speed = 10;

        public void SetSpeed(float newSpeed)
        {
            _speed = newSpeed;
        }

        // Update is called once per frame
        void Update()
        {
            float moveDistance = _speed * Time.deltaTime;
            CheckCollisions(moveDistance);
            transform.Translate(Vector3.right * moveDistance);
        }

        void CheckCollisions(float moveDistance)
        {
            Ray ray = new Ray(transform.position,transform.right);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, moveDistance, CollisionMask, QueryTriggerInteraction.Collide))
            {
                OnHitObject(hit);
            }
        }

        void OnHitObject(RaycastHit hit)
        {
            print(hit.collider.gameObject.name);
            Destroy(gameObject);
        }
    }
}
