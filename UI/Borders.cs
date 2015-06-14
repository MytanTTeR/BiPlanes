using UnityEngine;
using System.Collections;

public class Borders : MonoBehaviour
{
    public Camera MainCamera;
    int _screenWidth, _screenHeight;
    Vector2 _objectPos;
    Transform _transform;

    void Start()
    {
        _transform = transform;
    }

    void Update()
    {
        _screenWidth = Screen.width;
        _screenHeight = Screen.height;

        _objectPos = MainCamera.WorldToScreenPoint(transform.position);

        CriticalPosition();
    }

    void CriticalPosition()
    {
        if (_objectPos.x >= _screenWidth)
        {
            _transform.position = MainCamera.ScreenToWorldPoint(new Vector3(0, _objectPos.y, _transform.position.z));
        }
        else if (_objectPos.x <= 0)
        {
            _transform.position = MainCamera.ScreenToWorldPoint(new Vector3(_screenWidth, _objectPos.y, _transform.position.z));
        }
    } 
}
