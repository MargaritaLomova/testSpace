using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] private PlayerData player;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip winMusic;
    [SerializeField] private AudioClip loseMusic;
    [SerializeField] private GameObject deathMenu;
    [SerializeField] private GameObject winMenu;
    private int asteroidDeadCount;
    public int nowAsteroidDeadCount;
    private int levelComplete;
    void Start()
    {
        Time.timeScale = 1;
        levelComplete = PlayerPrefs.GetInt("PlayerComplete");
        deathMenu.SetActive(false);
        winMenu.SetActive(false);
        switch (SceneManager.GetActiveScene().buildIndex)
        {
            case 1:
                asteroidDeadCount = 6;
                break;
            case 2:
                asteroidDeadCount = 12;
                break;
            case 3:
                asteroidDeadCount = 18;
                break;
        }
    }
    void Update()
    {
        if (player.Health <= 0)
            Death();
        if (nowAsteroidDeadCount >= asteroidDeadCount && player.Health > 0)
            Win();
    }
    private void Death()
    {
        if(!audioSource.isPlaying)
            audioSource.PlayOneShot(loseMusic);
        Time.timeScale = 0;
        if (!deathMenu.activeInHierarchy)
            deathMenu.SetActive(true);
    }
    private void Win()
    {
        PlayerPrefs.SetInt("PlayerComplete", SceneManager.GetActiveScene().buildIndex);
        if (!audioSource.isPlaying)
            audioSource.PlayOneShot(winMusic);
        Time.timeScale = 0;
        if (!winMenu.activeInHierarchy)
            winMenu.SetActive(true);
    }
}