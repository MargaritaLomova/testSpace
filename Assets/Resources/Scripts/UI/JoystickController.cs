using UnityEngine;

public class JoystickController : MonoBehaviour
{
    /// <summary>
    /// Маркер для передвижения игрока
    /// </summary>
    [SerializeField] private GameObject touchMarker;
    /// <summary>
    /// Вектор перемещения маркера
    /// </summary>
    public Vector3 targetVector;
    private void Start()
    {
        //Устанавливаем маркер в центр джостика
        touchMarker.transform.position = transform.position;
    }
    private void Update()
    {
        //Если игра запущена в Editor-е или на компьютере
#if UNITY_EDITOR || UNITY_STANDALONE
        //Если нажата правая кнопка мыши
        if (Input.GetMouseButton(0))
#endif
        //Если игра запущена на android или ios
#if UNITY_IOS || UNITY_ANDROID
            //Если количество тачей больше 0
            if (Input.touchCount > 0)
#endif
        {
            //Если игра запущена в Editor-е или на компьютере
#if UNITY_EDITOR || UNITY_STANDALONE
            //Запоминаем место нажатие мыши
            Vector3 touchPos = Input.mousePosition;
#endif
            //Если игра запущена на android или ios
#if UNITY_IOS || UNITY_ANDROID
            //Запоминаем место тача
            Vector3 touchPos = Input.GetTouch(0).position;
#endif
            //Вычисляем вектор перемещения маркера
            targetVector = touchPos - transform.position;
            //Если магнитуда перемещения больше 100
            if (targetVector.magnitude < 100)
                //Оставляем маркер на месте
                touchMarker.transform.position = touchPos;
        }
        else
        {
            //Перемещаем маркер в центр джойстика
            touchMarker.transform.position = transform.position;
            //Вектор перемещения приравниваем к нулю
            targetVector = Vector3.zero;
        }
    }
}