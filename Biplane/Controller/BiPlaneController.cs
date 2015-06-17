using UnityEngine;
using System.Collections;

public class BiPlaneController : MonoBehaviour
{
    bool addForce, removeForce, rotationUp, rotationDown, shoot;


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

    public bool Shoot
    {
        get { return shoot; }
    }

    void FixedUpdate()
    {
        UpdateParams();
        if (Input.GetKey(KeyCode.D)) rotationUp = true;
        if (Input.GetKey(KeyCode.A)) rotationDown = true;
        if (Input.GetKey(KeyCode.W)) addForce = true;
        if (Input.GetKey(KeyCode.S)) removeForce = true;
        if (Input.GetKey(KeyCode.Mouse0)) shoot = true;
    }

    private void UpdateParams()
    {
        rotationUp = false;
        rotationDown = false;
        addForce = false;
        removeForce = false;
        shoot = false;
    }
}
