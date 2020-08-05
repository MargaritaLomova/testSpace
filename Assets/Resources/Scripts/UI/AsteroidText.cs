using UnityEngine.UI;
using UnityEngine;

public class AsteroidText : MonoBehaviour
{
    [SerializeField] GameController controller;
    void Update()
    {
        GetComponent<Text>().text = $"You kill {controller.nowAsteroidDeadCount} asteroids!";
    }
}