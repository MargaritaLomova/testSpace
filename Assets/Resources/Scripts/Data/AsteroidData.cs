using UnityEngine;

[CreateAssetMenu(menuName = "Data/AsteroidData")]
public class AsteroidData : ScriptableObject
{
    [SerializeField]
    private int speed;
    [SerializeField]
    private AudioClip hitSound;

    public void Move(Transform asteroid)
    {
        asteroid.Translate(Vector3.down * speed * Time.deltaTime);
    }
    public void HitPlayer(GameObject asteroid)
    {
        Destroy(asteroid);
    }
    public void HitBullet(GameObject asteroid, AudioSource audioSource)
    {
        audioSource.PlayOneShot(hitSound);
        Destroy(asteroid, 0.2f);
    }
    public void SelfDestroy(GameObject asteroid, Transform asteroidTransform, Transform playerTransform)
    {
        if (Time.timeScale == 0 || asteroidTransform.position.y < playerTransform.position.y - 11)
            Destroy(asteroid);
    }
}
