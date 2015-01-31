using UnityEngine;
using System.Collections;

public class BiPlane : MonoBehaviour
{
    public BiPlaneController controller;
    public Engine engine;

    void Start()
    {
        engine.enabled = true;
    }

    void Update()
    {
        if (controller.AddForce) engine.AddForce();
        if (controller.RemoveForce) engine.RemoveForce();
    }
}
