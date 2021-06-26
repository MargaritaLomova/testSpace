using System.Collections;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [Header("Variables To Control"), SerializeField]
    private int speed;
    [SerializeField]
    private AudioClip shootSound;

    private void Start()
    {
        GetComponent<AudioSource>().PlayOneShot(shootSound);
        StartCoroutine(DelayedSelfDestroy());
    }

    private void Update()
    {
        Move();
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Enemy")
        {
            DestructionAfterAsteroidImpact();
        }
    }

    private void Move()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }

    private IEnumerator DelayedSelfDestroy()
    {
        yield return new WaitForSecondsRealtime(4);

        Destroy(gameObject);
    }

    private void DestructionAfterAsteroidImpact()
    {
        FindObjectOfType<GameController>().DestroyAsteroid();
        Destroy(gameObject);
    }
}