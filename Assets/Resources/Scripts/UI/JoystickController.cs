using UnityEngine;

public class JoystickController : MonoBehaviour
{
    [SerializeField] private GameObject touchMarker;
    public Vector3 targetVector;
    void Start()
    {
        touchMarker.transform.position = transform.position;
    }
    void Update()
    {
        //if(Input.GetMouseButton(0))
        if(Input.touchCount > 0)
        {
            //Vector3 touchPos = Input.mousePosition;
            Vector3 touchPos = Input.GetTouch(0).position;
            targetVector = touchPos - transform.position;
            if (targetVector.magnitude < 100)
                touchMarker.transform.position = touchPos;
        }
        else
        {
            touchMarker.transform.position = transform.position;
            targetVector = new Vector3(0, 0, 0);
        }
    }
}