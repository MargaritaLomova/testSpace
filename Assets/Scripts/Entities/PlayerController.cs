using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Variables To Control"), SerializeField]
    private int health = 10;
    [SerializeField]
    private int speed = 10;

    [Header("Audioclips"), SerializeField]
    private AudioClip collisionSound;

    [Header("Components"), SerializeField]
    private AudioSource audioSource;
    [SerializeField]
    private Transform gun;

    [Header("Objects From Scene"), SerializeField]
    private JoystickController joystick;
    [SerializeField]
    private GameController gameController;
    [SerializeField]
    private UIController uiController;

    private int currentHealth;

    private void Start()
    {
        ResetHealth();
        uiController.HealthTextUpdate(currentHealth);
        transform.position = new Vector3(0, -4.5f, 0);
    }

    private void Update()
    {
        Move();
    }
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Enemy")
        {
            GetDamage();
        }
    }

    public void ResetHealth()
    {
        currentHealth = health;
    }

    private void Move()
    {
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        pos.x = Mathf.Clamp(pos.x, 0.1f, 0.9f);
        pos.y = Mathf.Clamp(pos.y, 0.1f, 0.9f);

        transform.position = Camera.main.ViewportToWorldPoint(pos);
#if UNITY_EDITOR || UNITY_STANDALONE
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime);
        }
#elif UNITY_ANDROID || UNITY_IOS
        transform.Translate(joystick.GetTargetVector() * speed/16 * Time.deltaTime);
#endif

        if (transform.position.z != 0)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        }
    }

    private void GetDamage()
    {
        audioSource.PlayOneShot(collisionSound);

        if (currentHealth > 0)
        {
            currentHealth--;
            uiController.HealthTextUpdate(currentHealth);
        }
        else
        {
            gameController.PlayerDied();
            gameObject.SetActive(false);
        }
    }
}