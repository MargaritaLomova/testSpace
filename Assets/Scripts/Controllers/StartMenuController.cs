using UnityEngine.UI;
using UnityEngine;
using System.Collections.Generic;

public class StartMenuController : MonoBehaviour
{
    [Header("Objects From Scene"), SerializeField]
    private GameController gameController;

    [Header("Variables To Level Control"), SerializeField]
    private List<Button> levelButtons;

    private void Start()
    {
        Time.timeScale = 0;
        SetLockedLevelButtonInactive();
    }

    #region Custom Methods

    public void SetLockedLevelButtonInactive()
    {
        var levelComplete = PlayerPrefs.GetInt("PlayerComplete") + 1;

        for (int i = levelComplete; i < levelButtons.Count; i++)
        {
            levelButtons[i].interactable = false;
        }
        for(int i = 0; i < levelComplete; i++)
        {
            levelButtons[i].interactable = true;
        }
    }

    #endregion
}