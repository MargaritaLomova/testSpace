using UnityEngine.UI;
using UnityEngine;

public class HealthText : MonoBehaviour
{
    [SerializeField] PlayerData player;
    void Update()
    {
        GetComponent<Text>().text = player.Health.ToString();
    }
}