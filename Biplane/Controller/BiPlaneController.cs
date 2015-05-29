using UnityEngine;
using System.Collections;

public class BiPlaneController : MonoBehaviour
{
    bool addForce, removeForce, rotationUp, rotationDown;

    public bool RotationDown
    {
        get { return rotationDown; }
    }

    public bool RotationUp
    {
        get { return rotationUp; }
    }

    public bool RemoveForce
    {
        get { return removeForce; }
    }

    public bool AddForce
    {
        get { return addForce; }
    }

    void FixedUpdate()
    {
        UpdateParams();
        if (Input.GetKey(KeyCode.D)) rotationUp = true;
        if (Input.GetKey(KeyCode.A)) rotationDown = true;
        if (Input.GetKey(KeyCode.W)) addForce = true;
        if (Input.GetKey(KeyCode.S)) removeForce = true;
    }

    private void UpdateParams()
    {
        rotationUp = false;
        rotationDown = false;
        addForce = false;
        removeForce = false;
    }
}
