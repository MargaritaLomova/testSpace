using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    private GameObject asteroid;
    private int timer;
    private void Start()
    {
        asteroid = Resources.Load("Prefabs/Asteroid") as GameObject;
    }
    private void Update()
    {
        timer += 1;
        if (timer == 150 && Time.timeScale != 0)
        {
            timer = 0;
            SpawnAsteroid();            
        }
    }
    private void SpawnAsteroid()
    {
        Vector3 randPos = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(0, Screen.width), Random.Range(0, Screen.height), transform.position.z));
        Vector3 pos = new Vector3(randPos.x, transform.position.y, transform.position.z);
        Instantiate(asteroid, pos, Quaternion.identity);
    }
}
