using UnityEngine;
using System.Collections;

public class BiPlanePlayerController : BiPlaneController
{
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
