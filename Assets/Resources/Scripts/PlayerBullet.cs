using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    [SerializeField] private PlayerBulletData data;
    [SerializeField] private AudioSource audioSource;
    private void Start()
    {
        audioSource.PlayOneShot(data.ShootSound);
    }
    private void Update()
    {
        data.Move(transform);
        data.SelfDestroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Enemy")
            data.Hit(gameObject);
    }
}
