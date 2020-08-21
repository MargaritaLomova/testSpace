using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    /// <summary>
    /// Data игрока
    /// </summary>
    [SerializeField] private PlayerData player;
    /// <summary>
    /// Источник звука
    /// </summary>
    [SerializeField] private AudioSource audioSource;
    /// <summary>
    /// Звук выигрыша
    /// </summary>
    [SerializeField] private AudioClip winMusic;
    /// <summary>
    /// Звук проигрыша
    /// </summary>
    [SerializeField] private AudioClip loseMusic;
    /// <summary>
    /// Меню смерти
    /// </summary>
    [SerializeField] private GameObject deathMenu;
    /// <summary>
    /// Меню выигрыша
    /// </summary>
    [SerializeField] private GameObject winMenu;
    /// <summary>
    /// Количество астероидов, которое нужно убить на данном уровне
    /// </summary>
    private int asteroidDeadCount;
    /// <summary>
    /// Количество убитых астероидов
    /// </summary>
    public int nowAsteroidDeadCount;
    /// <summary>
    /// Переменная, показывающая сколько открыто уровней
    /// </summary>
    private int levelComplete;
    private void Start()
    {
        //Запускаем время в обычном режиме
        Time.timeScale = 1;
        //Берём значение пройденных уровней из PlayerPrefs
        levelComplete = PlayerPrefs.GetInt("PlayerComplete");
        //Скрываем меню смерти
        deathMenu.SetActive(false);
        //Скрываем меню выигрыша
        winMenu.SetActive(false);
        //Устанавливаем значение количества астероидов которое нужно убить
        asteroidDeadCount = SceneManager.GetActiveScene().buildIndex * 6;
    }
    private void Update()
    {
        //Если здоровье игрока 0 или меньше
        if (player.Health <= 0)
            //Вызываем метод смерти
            Death();
        //Если мгрок убил нужное количество астероидов и у него больше 0 жизней
        if (nowAsteroidDeadCount >= asteroidDeadCount && player.Health > 0)
            //Вызываем метод выигрыша
            Win();
    }
    /// <summary>
    /// Метод смети
    /// </summary>
    private void Death()
    {
        //Если сейчас не играет никакой звук
        if(!audioSource.isPlaying)
            //Проигрываем звук смерти
            audioSource.PlayOneShot(loseMusic);
        //Останавливаем время
        Time.timeScale = 0;
        //Если меню смерти скрыто
        if (!deathMenu.activeInHierarchy)
            //Выводим меню смерти на экран
            deathMenu.SetActive(true);
    }
    /// <summary>
    /// Метод выигрыша
    /// </summary>
    private void Win()
    {
        //Передаем в PlayerPrefs количество пройденных уровней
        PlayerPrefs.SetInt("PlayerComplete", SceneManager.GetActiveScene().buildIndex);
        //Если не играет никакой звук
        if (!audioSource.isPlaying)
            //Проигрываем звук выигрыша
            audioSource.PlayOneShot(winMusic);
        //Останавливаем время
        Time.timeScale = 0;
        //Если меню выигрыша скрыто
        if (!winMenu.activeInHierarchy)
            //Выводим на экран меню выигрыша
            winMenu.SetActive(true);
    }
}