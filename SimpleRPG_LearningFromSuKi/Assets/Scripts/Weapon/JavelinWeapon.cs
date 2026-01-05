using Unity.Mathematics;
using UnityEngine;

public class JavelinWeapon : Weapon
{
    public float bulletSpeed;
    public GameObject bulletPrefab;
    private GameObject bulletGo;
    private void Start()
    {
        SpawnBullet();
    }
    public override void Attack()
    {
        if (bulletGo != null)
        {
            bulletGo.transform.parent = null;
            bulletGo.GetComponent<Rigidbody>().AddForce(transform.forward * bulletSpeed, ForceMode.VelocityChange);
            bulletGo = null;
            Invoke("SpawnBullet", 0.5f);
        }
        else
        {
            return;
        }
    }

    private void SpawnBullet()
    {
        bulletGo = Instantiate(bulletPrefab, transform.position, transform.rotation);
        bulletGo.transform.parent = transform;
    }
}
