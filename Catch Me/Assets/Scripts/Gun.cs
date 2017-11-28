using UnityEngine;

namespace Assets.Scripts
{
    public class Gun : MonoBehaviour
    {

        public Transform Muzzle;
        public Projectile Projectile;
        public float MsBetweenShots = 100;
        public float MuzzleVelocity = 35;

        private float _nextShootTime;
        public void Shoot()
        {
            if (Time.time > _nextShootTime)
            {
                _nextShootTime = Time.time + MsBetweenShots / 1000;
                Projectile newProjectile = Instantiate(Projectile, Muzzle.position, Muzzle.rotation) as Projectile;
                newProjectile.SetSpeed(MuzzleVelocity);
            }

            
        }

    }
}
