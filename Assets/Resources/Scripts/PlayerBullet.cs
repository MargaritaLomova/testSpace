using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    /// <summary>
    /// Data пули игрока
    /// </summary>
    [SerializeField] private PlayerBulletData data;
    /// <summary>
    /// Источник звука пули
    /// </summary>
    [SerializeField] private AudioSource audioSource;
    private void Start()
    {
        //Проигрываем звук выстрела
        audioSource.PlayOneShot(data.ShootSound);
    }
    private void Update()
    {
        //Двигаем пулю
        data.Move(transform);
        //Самоуничтожение через определённый промежуток времени
        data.SelfDestroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D coll)
    {
        //Если пуля столкнулась со врагом
        if (coll.gameObject.tag == "Enemy")
            //Вызываем метод столкновения
            data.Hit(gameObject);
    }
}
