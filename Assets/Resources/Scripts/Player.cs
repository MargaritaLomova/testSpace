using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerData data;
    [SerializeField] private AudioSource audioSource;
    private void Update()
    {
        data.Move(transform, GameObject.Find("Joystick").GetComponent<JoystickController>().targetVector);
    }
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Enemy")
            data.Hit(gameObject, audioSource);
    }
}
