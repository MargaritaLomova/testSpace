using UnityEngine;

public class GameController : MonoBehaviour
{
    [Header("Audioclips"), SerializeField] 
    private AudioClip winClip;
    [SerializeField]
    private AudioClip loseClip;

    [Header("Objects From Scene"), SerializeField]
    private UIController uiController;
    [SerializeField]
    private PlayerController player;

    private int asteroidsDestroyedCount;
    private int asteroidsNeedToDestoryCount;
    private int levelIndex;

    private bool isPlayerDead;

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        Time.timeScale = 0;
        player.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (asteroidsDestroyedCount >= asteroidsNeedToDestoryCount && !isPlayerDead && player.gameObject.activeInHierarchy)
        {
            PlayerWon();
        }
    }

    #region Custom Methods

    public void StartLevel(int currentLevelIndex)
    {
        Time.timeScale = 1;

        isPlayerDead = false;

        player.gameObject.SetActive(true);
        player.ResetHealth();

        levelIndex = currentLevelIndex;

        asteroidsNeedToDestoryCount = currentLevelIndex * 6;
        asteroidsDestroyedCount = 0;
        uiController.AsteroidTextUpdate(asteroidsDestroyedCount);
    }

    public void RestartLevel()
    {
        StartLevel(levelIndex);
    }

    public void DestroyAsteroid()
    {
        asteroidsDestroyedCount++;
        uiController.AsteroidTextUpdate(asteroidsDestroyedCount);
    }

    public void PlayerDied()
    {
        isPlayerDead = true;
        player.gameObject.SetActive(false);
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(loseClip);
        }
        Time.timeScale = 0;
        uiController.DeathMenuActive(true);
    }

    private void PlayerWon()
    {
        player.gameObject.SetActive(false);
        PlayerPrefs.SetInt("PlayerComplete", levelIndex);
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(winClip);
        }
        Time.timeScale = 0;
        uiController.WinMenuActive(true);
    }

    #endregion
}