using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    /// <summary>
    /// Кнопка для перехода на 2 уровень
    /// </summary>
    [SerializeField] private Button level2;
    /// <summary>
    /// Кнопка для перехода на 3 уровень
    /// </summary>
    [SerializeField] private Button level3;
    /// <summary>
    /// Переменная, показывающая сколько уровней открыто
    /// </summary>
    private int levelComplete;
    private void Start()
    {
        //Берём значение пройденных уровней из PlayerPrefs
        levelComplete = PlayerPrefs.GetInt("PlayerComplete");
        //В зависимости от количества пройденных уровней
        switch(levelComplete)
        {
            //Если 0
            case 0:
                //Делаем кнопку 2 уровня неактивной
                level2.interactable = false;
                //Делаем кнопку 3 уровня неактивной
                level3.interactable = false;
                break;
            //Если 1 
            case 1:
                //Делаем кнопку 2 уровня активной
                level2.interactable = true;
                //Делаем кнопку 3 уровня неактивной
                level3.interactable = false;
                break;
            //Если 2
            case 2:
                //Делаем кнопку 2 уровня активной
                level2.interactable = true;
                //Делаем кнопку 3 уровня активной
                level3.interactable = true;
                break;
        }
    }
    /// <summary>
    /// Метод загрузки выбранной сцены
    /// </summary>
    /// <param name="level"></param>
    public void LoadTo(int level)
    {
        //Загружаем выбранную сцену
        SceneManager.LoadScene(level);
    }
    /// <summary>
    /// Метод сброса пройденных уровней
    /// </summary>
    public void Reset()
    {
        //Делаем кнопку 2 уровня неактивной
        level2.interactable = false;
        //Делаем кнопку 3 уровня неактивной
        level3.interactable = false;
        //Удаляем знаения о пройденных уровнях из PlayerPrefs 
        PlayerPrefs.DeleteAll();
    }
}