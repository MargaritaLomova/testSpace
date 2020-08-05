using UnityEngine.SceneManagement;
using UnityEngine;

public class ButtonsController : MonoBehaviour
{
    public void Restart()
    {
        int currentLevelIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentLevelIndex);
    }
    public void ToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
