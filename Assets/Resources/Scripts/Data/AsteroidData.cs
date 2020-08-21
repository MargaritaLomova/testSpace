using UnityEngine;

[CreateAssetMenu(menuName = "Data/AsteroidData")]
public class AsteroidData : ScriptableObject
{
    /// <summary>
    /// Скорость астероида
    /// </summary>
    [SerializeField]
    private int speed;
    /// <summary>
    /// Звук повреждения
    /// </summary>
    [SerializeField]
    private AudioClip hitSound;
    /// <summary>
    /// Метод перемещения
    /// </summary>
    /// <param name="asteroid"></param>
    public void Move(Transform asteroid)
    {
        //Перемещаем астероид вниз
        asteroid.Translate(Vector3.down * speed * Time.deltaTime);
    }
    /// <summary>
    /// Метод столкновения с игроком
    /// </summary>
    /// <param name="asteroid"></param>
    public void HitPlayer(GameObject asteroid)
    {
        //Уничтожаем астероид
        Destroy(asteroid);
    }
    /// <summary>
    /// Метод столкновения с пулей
    /// </summary>
    /// <param name="asteroid"></param>
    /// <param name="audioSource"></param>
    public void HitBullet(GameObject asteroid, AudioSource audioSource)
    {
        //Проигрываем звук повреждения
        audioSource.PlayOneShot(hitSound);
        //Уничтожаем астероид через 0.2 секунды
        Destroy(asteroid, 0.2f);
    }
    /// <summary>
    /// Метод самоуничтожения
    /// </summary>
    /// <param name="asteroid"></param>
    /// <param name="asteroidTransform"></param>
    /// <param name="playerTransform"></param>
    public void SelfDestroy(GameObject asteroid, Transform asteroidTransform, Transform playerTransform)
    {
        //Если время остановлено или астероид ниже игрока на 11 единиц
        if (Time.timeScale == 0 || asteroidTransform.position.y < playerTransform.position.y - 11)
            //Уничтожаем астероид
            Destroy(asteroid);
    }
}
