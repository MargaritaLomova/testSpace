using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    /// <summary>
    /// Астероид
    /// </summary>
    private GameObject asteroid;
    /// <summary>
    /// Таймер
    /// </summary>
    private int timer;
    private void Start()
    {
        //Находим астероид в ресурсах
        asteroid = Resources.Load("Prefabs/Asteroid") as GameObject;
    }
    private void Update()
    {
        //Прибавляем таймер
        timer += 1;
        //Если таймер достиг 150 и время не остановлено
        if (timer == 150 && Time.timeScale != 0)
        {
            //Устанавливаем таймер на 0
            timer = 0;
            //Спавним астероид
            SpawnAsteroid();            
        }
    }
    /// <summary>
    /// Метод спавна астероида
    /// </summary>
    private void SpawnAsteroid()
    {
        //Вычисляем рандомную позицию в пределах экрана
        Vector3 randPos = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(0, Screen.width), Random.Range(0, Screen.height), transform.position.z));
        //Устанавливаем рандомную позицию появления астероида (сверху экрана)
        Vector3 pos = new Vector3(randPos.x, transform.position.y, transform.position.z);
        //Вызываем астероид
        Instantiate(asteroid, pos, Quaternion.identity);
    }
}