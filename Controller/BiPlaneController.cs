using UnityEngine;
using System.Collections;

public class BiPlaneController : MonoBehaviour
{
    Transform _transform;

    public bool AddForce, RemoveForce;

    Vector3 rot;

    void Start()
    {
        _transform = transform;
    }

    void Update()
    {
        rot = Vector3.zero;

        if (Input.GetKey(KeyCode.D)) rot.z -= 100 * Time.deltaTime;
        if (Input.GetKey(KeyCode.A)) rot.z += 100 * Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.W)) AddForce = true;
        if (Input.GetKeyDown(KeyCode.S)) RemoveForce = true;
        if (Input.GetKeyUp(KeyCode.W)) AddForce = false;
        if (Input.GetKeyUp(KeyCode.S)) RemoveForce = false;

        _transform.localEulerAngles += rot;
    }
}
