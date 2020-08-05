using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/PlayerBulletData")]
public class PlayerBulletData : ScriptableObject
{
    [SerializeField]
    private int speed;
    [SerializeField]
    private AudioClip shootSound;

    public AudioClip ShootSound
    {
        get { return shootSound; }
    }
    public void Move(Transform bullet)
    {
        bullet.Translate(Vector3.up * speed * Time.deltaTime);
    }
    public void SelfDestroy(GameObject bullet)
    {
        Destroy(bullet, 5);
    }
    public void Hit(GameObject bullet)
    {
        GameObject.Find("GameController").GetComponent<GameController>().nowAsteroidDeadCount++;
        Destroy(bullet);
    }
}
