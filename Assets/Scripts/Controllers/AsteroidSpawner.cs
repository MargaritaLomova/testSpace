using System.Collections;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    [Header("Prefabs"), SerializeField]
    private AsteroidController asteroidPrefab;

    [Header("Objects From Scene"), SerializeField]
    private Transform canvas;


    private void Start()
    {
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        if (Time.timeScale != 0)
        {
            while (true)
            {
                Vector3 randPos = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(0, Screen.width), Random.Range(0, Screen.height), transform.position.z));
                Vector3 pos = new Vector3(randPos.x, transform.position.y, transform.position.z);

                var newAsteroid = Instantiate(asteroidPrefab, pos, Quaternion.identity);

                newAsteroid.transform.SetParent(canvas);
                newAsteroid.transform.SetSiblingIndex(newAsteroid.transform.GetSiblingIndex() + 1);

                newAsteroid.transform.localScale = new Vector3(1, 1, 1);

                yield return new WaitForSeconds(1f);
            }
        }
    }
}