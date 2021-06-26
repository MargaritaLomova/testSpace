using UnityEngine;

public class AsteroidController : MonoBehaviour
{
    [Header("Variables To Control"), SerializeField]
    private int speed;

    [Header("Audio"), SerializeField]
    private AudioSource audioSource;
    [SerializeField]
    private AudioClip hitSound;

    private PlayerController player;

    private void Start()
    {
        player = FindObjectOfType<PlayerController>();
    }

    private void Update()
    {
        Move();
        SelfDestroy();
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            HitPlayer();
        }
        else if (coll.gameObject.tag == "Bullet")
        {
            HitByBullet();
        }
    }

    private void Move()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
    }

    private void HitPlayer()
    {
        Destroy(gameObject);
    }

    private void HitByBullet()
    {
        audioSource.PlayOneShot(hitSound);
        Destroy(gameObject, 0.2f);
    }

    private void SelfDestroy()
    {
        if (Time.timeScale == 0 || transform.position.y < player.transform.position.y - 11)
        {
            Destroy(gameObject);
        }
    }
}