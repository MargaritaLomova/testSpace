using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField] private AsteroidData data;
    [SerializeField] private AudioSource audioSource;
    private void Update()
    {
        data.Move(transform);
        data.SelfDestroy(gameObject, transform, GameObject.Find("Player").transform);
    }
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
            data.HitPlayer(gameObject);
        else if (coll.gameObject.tag == "PlayerBullet")
            data.HitBullet(gameObject,audioSource);
    }
}
