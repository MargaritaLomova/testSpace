using UnityEngine;

public class Player : MonoBehaviour
{
    /// <summary>
    /// Data игрока
    /// </summary>
    [SerializeField] private PlayerData data;
    /// <summary>
    /// Источник звука игрока
    /// </summary>
    [SerializeField] private AudioSource audioSource;
    private void Update()
    {
        //Перемещаем игрока
        data.Move(transform, GameObject.Find("Joystick").GetComponent<JoystickController>().targetVector);
    }
    private void OnTriggerEnter2D(Collider2D coll)
    {
        //Если игрок столкнулся со врагом
        if (coll.gameObject.tag == "Enemy")
            //Вызываем метод столкновения
            data.Hit(gameObject, audioSource);
    }
}
