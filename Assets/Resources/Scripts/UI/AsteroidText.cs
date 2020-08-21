using UnityEngine.UI;
using UnityEngine;

public class AsteroidText : MonoBehaviour
{
    /// <summary>
    /// Скрипт GameController
    /// </summary>
    [SerializeField] GameController controller;
    private void Update()
    {
        //Выводим количество убитых астероидов на экран
        GetComponent<Text>().text = $"You kill {controller.nowAsteroidDeadCount} asteroids!";
    }
}