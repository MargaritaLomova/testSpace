using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] private Button level2;
    [SerializeField] private Button level3;
    private int levelComplete;
    void Start()
    {
        levelComplete = PlayerPrefs.GetInt("PlayerComplete");
        level2.interactable = false;
        level3.interactable = false;
        switch(levelComplete)
        {
            case 1:
                level2.interactable = true;
                break;
            case 2:
                level2.interactable = true;
                level3.interactable = true;
                break;
        }
    }
    public void LoadTo(int level)
    {
        SceneManager.LoadScene(level);
    }
    public void Reset()
    {
        level2.interactable = false;
        level3.interactable = false;
        PlayerPrefs.DeleteAll();
    }
}