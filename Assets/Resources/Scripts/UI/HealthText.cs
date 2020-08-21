using UnityEngine.UI;
using UnityEngine;

public class HealthText : MonoBehaviour
{
    /// <summary>
    /// Data игрока
    /// </summary>
    [SerializeField] PlayerData player;
    private void Update()
    {
        //Выводим здоровье игрока на экран
        GetComponent<Text>().text = player.Health.ToString();
    }
}