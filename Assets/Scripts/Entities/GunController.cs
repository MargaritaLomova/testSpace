using UnityEngine;

public class GunController : MonoBehaviour
{
    [Header("Prefabs"), SerializeField]
    private BulletController bulletPrefab;

    public void Attack()
    {
        Instantiate(bulletPrefab, transform.position, Quaternion.identity);
    }
}