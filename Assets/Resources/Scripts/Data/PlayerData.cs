using UnityEngine;

[CreateAssetMenu(menuName = "Data/PlayerData")]
public class PlayerData : ScriptableObject
{
    /// <summary>
    /// Здоровье игрока
    /// </summary>
    [SerializeField]
    private int health;
    /// <summary>
    /// Скорость игрока
    /// </summary>
    [SerializeField]
    private int speed;
    /// <summary>
    /// Звук при столкновении
    /// </summary>
    [SerializeField]
    private AudioClip collisionSound;
    /// <summary>
    /// Здоровье игрока
    /// </summary>
    public int Health
    {
        get { return health; }
    }
    /// <summary>
    /// Метод передвижения игрока
    /// </summary>
    /// <param name="player"></param>
    /// <param name="targetMove"></param>
    public void Move(Transform player, Vector3 targetMove)
    {
        //Вычисляем пределы экрана
        Vector3 pos = Camera.main.WorldToViewportPoint(player.position);
        //Ограничиваем игрока по оси х
        pos.x = Mathf.Clamp(pos.x, 0.1f, 0.9f);
        //Ограничиваем игрока по оси у
        pos.y = Mathf.Clamp(pos.y, 0.1f, 0.9f);
        //Применияем ограничения к игроку
        player.position = Camera.main.ViewportToWorldPoint(pos);
        //Если игра запущена на компьютере или в Editor-е
#if UNITY_EDITOR || UNITY_STANDALONE
        //При нажатии D 
        if (Input.GetKey(KeyCode.D))
            //Перемещаем игрока вправо
            player.Translate(Vector3.right * speed * Time.deltaTime);
        //При нажатии A
        else if (Input.GetKey(KeyCode.A))
            //Перемещаем игрока влево
            player.Translate(Vector3.left * speed * Time.deltaTime);
        //При нажатии W
        else if (Input.GetKey(KeyCode.W))
            //Перемещаем игрока вверх
            player.Translate(Vector3.up * speed * Time.deltaTime);
        //При нажатии S
        else if (Input.GetKey(KeyCode.S))
            //Перемещаем игрока вниз
            player.Translate(Vector3.down * speed * Time.deltaTime);
#endif
        //Если игра заупщена на android или ios
#if UNITY_ANDROID || UNITY_IOS
        //Перемещаем игрока по направлению вектора
        player.Translate(targetMove * speed/16 * Time.deltaTime);
#endif
    }
    /// <summary>
    /// Метод столкновения
    /// </summary>
    /// <param name="player"></param>
    /// <param name="audioSource"></param>
    public void Hit(GameObject player, AudioSource audioSource)
    {
        //Проигрываем звук столкновения
        audioSource.PlayOneShot(collisionSound);
        //Если здоровье больше 0
        if (health > 0)
            //Отнимаем 1 здоровья
            health--;
        //Если здоровье меньше или равно 0
        else if (health <= 0)
            //Уничтожаем игрока через 0.4 секунды
            Destroy(player, 0.4f);
    }
    /// <summary>
    /// Метод аттаки
    /// </summary>
    /// <param name="gun"></param>
    public void Attack(Transform gun)
    {
        //Находим пулю в ресурсах
        GameObject bullet = Resources.Load("Prefabs/PlayerBullet") as GameObject;
        //Вызываем пулю
        Instantiate(bullet, gun.position, Quaternion.identity);
    }
}
