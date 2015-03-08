using UnityEngine;
using System.Collections;

public class BiPlaneController : MonoBehaviour
{
    Transform _transform;

    public bool AddForce, RemoveForce;
    public Engine engine;

    Vector3 rotation;

    void Start()
    {
        _transform = transform;
    }

    void Update()
    {
        rotation = Vector3.zero;

        if (Input.GetKey(KeyCode.D))
        {
            engine.RotationFactor();
            rotation.z -= 100 * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            engine.RotationFactor();
            rotation.z += 100 * Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.W)) AddForce = true;
        if (Input.GetKeyDown(KeyCode.S)) RemoveForce = true;
        if (Input.GetKeyUp(KeyCode.W)) AddForce = false;
        if (Input.GetKeyUp(KeyCode.S)) RemoveForce = false;

        _transform.localEulerAngles += rotation;
    }
}
