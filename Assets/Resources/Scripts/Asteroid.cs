using UnityEngine;

public class Asteroid : MonoBehaviour
{
    /// <summary>
    /// Data астероида
    /// </summary>
    [SerializeField] private AsteroidData data;
    /// <summary>
    /// Источник звука астероида
    /// </summary>
    [SerializeField] private AudioSource audioSource;
    private void Update()
    {
        //Двигаем астериод
        data.Move(transform);
        //Самоуничтожение через определённый промежуток времени
        data.SelfDestroy(gameObject, transform, GameObject.Find("Player").transform);
    }
    private void OnTriggerEnter2D(Collider2D coll)
    {
        //Если астероид столкнулся с игроком
        if (coll.gameObject.tag == "Player")
            //Запускаем метод столкновения с игроком
            data.HitPlayer(gameObject);
        //Если астероид столкнулся с пулей игрока
        else if (coll.gameObject.tag == "PlayerBullet")
            //Запускаем метод столкновения с пулей игрока
            data.HitBullet(gameObject,audioSource);
    }
}
