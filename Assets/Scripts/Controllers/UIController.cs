using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [Header("Menu"), SerializeField]
    private GameObject startMenu;
    [SerializeField]
    private GameObject deathMenu;
    [SerializeField]
    private GameObject winMenu;

    [Header("Texts"), SerializeField]
    private TMP_Text asteroidText;
    [SerializeField]
    private TMP_Text healthText;

    [Header("Objects From Scene"), SerializeField]
    private GameController gameController;
    [SerializeField]
    private StartMenuController startMenuController;
    [SerializeField]
    private GameObject joystick;
    [SerializeField]
    private Button fireButton;

    private void Start()
    {
        OnMenuClicked();
    }

    #region Custom Methods

    public void AsteroidTextUpdate(int nowAsteroidDeadCount)
    {
        asteroidText.text = $"You kill {nowAsteroidDeadCount} asteroids!";
    }

    public void HealthTextUpdate(int healthCount)
    {
        healthText.text = healthCount.ToString();
    }

    public void DeathMenuActive(bool value)
    {
        deathMenu.SetActive(value);

        joystick.SetActive(!value);
        asteroidText.gameObject.SetActive(!value);
        healthText.gameObject.SetActive(!value);
        fireButton.gameObject.SetActive(!value);
    }

    public void WinMenuActive(bool value)
    {
        winMenu.SetActive(value);

        joystick.SetActive(!value);
        asteroidText.gameObject.SetActive(!value);
        healthText.gameObject.SetActive(!value);
        fireButton.gameObject.SetActive(!value);
    }

    #region On Buttons Clicked

    public void OnRestartClicked()
    {
        gameController.RestartLevel();

        startMenu.SetActive(false);
        deathMenu.SetActive(false);
        winMenu.SetActive(false);

        joystick.SetActive(true);
        asteroidText.gameObject.SetActive(true);
        healthText.gameObject.SetActive(true);
        fireButton.gameObject.SetActive(true);
    }

    public void OnMenuClicked()
    {
        startMenuController.SetLockedLevelButtonInactive();
        startMenu.SetActive(true);

        deathMenu.SetActive(false);
        winMenu.SetActive(false);
        joystick.SetActive(false);
        asteroidText.gameObject.SetActive(false);
        healthText.gameObject.SetActive(false);
        fireButton.gameObject.SetActive(false);
    }

    public void OnStartLevelButtonClicked(int level)
    {
        gameController.StartLevel(level);

        startMenu.SetActive(false);

        joystick.SetActive(true);
        asteroidText.gameObject.SetActive(true);
        healthText.gameObject.SetActive(true);
        fireButton.gameObject.SetActive(true);
    }

    public void OnResetStartLevelsClicked()
    {
        PlayerPrefs.DeleteAll();
        startMenuController.SetLockedLevelButtonInactive();
    }

    #endregion

    #endregion
}