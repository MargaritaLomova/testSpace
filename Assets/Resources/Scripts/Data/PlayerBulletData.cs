using UnityEngine;

[CreateAssetMenu(menuName = "Data/PlayerBulletData")]
public class PlayerBulletData : ScriptableObject
{
    /// <summary>
    /// Скорость пули
    /// </summary>
    [SerializeField]
    private int speed;
    /// <summary>
    /// ЗВук выстрела
    /// </summary>
    [SerializeField]
    private AudioClip shootSound;
    /// <summary>
    /// Звук выстрела
    /// </summary>
    public AudioClip ShootSound
    {
        get { return shootSound; }
    }
    /// <summary>
    /// Метод передвижения
    /// </summary>
    /// <param name="bullet"></param>
    public void Move(Transform bullet)
    {
        //Двигаем пулю вверх
        bullet.Translate(Vector3.up * speed * Time.deltaTime);
    }
    /// <summary>
    /// Метод самоуничтожения
    /// </summary>
    /// <param name="bullet"></param>
    public void SelfDestroy(GameObject bullet)
    {
        //Уничтожаем пулю через 5 секунд после появления
        Destroy(bullet, 5);
    }
    /// <summary>
    /// Метод столкновения
    /// </summary>
    /// <param name="bullet"></param>
    public void Hit(GameObject bullet)
    {
        //Увеличиваем количество убитых астероидов
        GameObject.Find("GameController").GetComponent<GameController>().nowAsteroidDeadCount++;
        //Уничтожаем пулю
        Destroy(bullet);
    }
}
