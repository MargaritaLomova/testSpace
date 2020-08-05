using UnityEngine;

[CreateAssetMenu(menuName = "Data/PlayerData")]
public class PlayerData : ScriptableObject
{
    [SerializeField]
    private int health;
    [SerializeField]
    private int speed;
    [SerializeField]
    private AudioClip collisionSound;

    public int Health
    {
        get { return health; }
    }
    public void Move(Transform player, Vector3 targetMove)
    {
        Vector3 pos = Camera.main.WorldToViewportPoint(player.position);
        pos.x = Mathf.Clamp(pos.x, 0.1f, 0.9f);
        pos.y = Mathf.Clamp(pos.y, 0.1f, 0.9f);
        player.position = Camera.main.ViewportToWorldPoint(pos);
#if UNITY_EDITOR
        if (Input.GetKey(KeyCode.D))
            player.Translate(Vector3.right * speed * Time.deltaTime);
        else if (Input.GetKey(KeyCode.A))
            player.Translate(Vector3.left * speed * Time.deltaTime);
        else if (Input.GetKey(KeyCode.W))
            player.Translate(Vector3.up * speed * Time.deltaTime);
        else if (Input.GetKey(KeyCode.S))
            player.Translate(Vector3.down * speed * Time.deltaTime);
#endif
#if UNITY_ANDROID || UNITY_IOS
        player.Translate(targetMove * speed/16 * Time.deltaTime);
#endif
    }
    public void Hit(GameObject player, AudioSource audioSource)
    {
        audioSource.PlayOneShot(collisionSound);
        if (health > 0)
            health--;
        else if (health <= 0)
            Destroy(player, 0.4f);
    }
    public void Attack(Transform gun)
    {
        GameObject bullet = Resources.Load("Prefabs/PlayerBullet") as GameObject;
        Instantiate(bullet, gun.position, Quaternion.identity);
    }
}
