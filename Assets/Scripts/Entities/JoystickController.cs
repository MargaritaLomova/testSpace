using UnityEngine;

public class JoystickController : MonoBehaviour
{
    [Header("Components"), SerializeField]
    private RectTransform touchMarker;

    private Vector2 targetVector;

    private void Start()
    {
        touchMarker.transform.position = transform.position;
    }

    public Vector2 GetTargetVector()
    {
#if UNITY_EDITOR || UNITY_STANDALONE
        if (Input.GetMouseButton(0))
        {
            Vector2 touchPos = Input.mousePosition;
            targetVector = touchPos - new Vector2(transform.position.x, transform.position.y);
            if (targetVector.magnitude > 100)
            {
                touchMarker.position = touchPos;
            }
            return targetVector;
        }
#elif UNITY_IOS || UNITY_ANDROID
        if (Input.touchCount > 0)
        {
            Vector2 touchPos = Input.GetTouch(0).position;
            targetVector = touchPos - new Vector2(transform.position.x, transform.position.y);
            if (targetVector.magnitude > 100)
            {
                touchMarker.position = touchPos;
            }
            return targetVector;
        }
#endif
        else
        {
            touchMarker.position = transform.position;
            return Vector2.zero;
        }

    }
}