using UnityEngine;

namespace Nokobot.Assets.Crossbow
{
    public class CrossbowShoot : MonoBehaviour
    {
        public GameObject arrowPrefab;
        public Transform arrowLocation;

        public float shotPower = 100f;

        void Start()
        {
            if (arrowLocation == null)
                arrowLocation = transform;
        }

        void Update()
        {
            if (Input.GetButtonDown("Fire1"))
            {
                if (SaveScript.inventoryOpen == false && SaveScript.optionsOpen == false)
                {
                    if (SaveScript.arrows > 0)
                    {
                        {
                            Instantiate(arrowPrefab, arrowLocation.position, arrowLocation.rotation).GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * shotPower);
                        }
                    }
                }
            }
        }
    }
}
