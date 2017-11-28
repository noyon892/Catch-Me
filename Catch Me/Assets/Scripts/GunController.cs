using UnityEngine;

namespace Assets.Scripts
{
    public class GunController : MonoBehaviour
    {
        public Transform WeoponHold;
        public Gun StartingGun;
        private Gun _equippedGun;

        void Start()
        {
            if (StartingGun != null)
            {
                EquipGun(StartingGun);
            }

        }

        public void EquipGun(Gun startingGun)
        {
            if (_equippedGun != null)
            {
                Destroy(_equippedGun.gameObject);
            }
            _equippedGun = Instantiate(startingGun, WeoponHold.position, WeoponHold.rotation) as Gun;
            _equippedGun.transform.parent = WeoponHold;
        }

        public void Shoot()
        {
            if (_equippedGun != null)
            {
                _equippedGun.Shoot();
            }
        }
    }
}