using UnityEngine.SceneManagement;
using UnityEngine;

public class ButtonsController : MonoBehaviour
{
    /// <summary>
    /// Метод перезагрузки уровня
    /// </summary>
    public void Restart()
    {
        //Находим индекс текущей сцены
        int currentLevelIndex = SceneManager.GetActiveScene().buildIndex;
        //Загружаем текущую сцену
        SceneManager.LoadScene(currentLevelIndex);
    }
    /// <summary>
    /// Метод возврата к меню
    /// </summary>
    public void ToMenu()
    {
        //Загружаем сцену с нулевым индексом
        SceneManager.LoadScene(0);
    }
}
