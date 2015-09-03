using UnityEngine;
using System.Collections;

public abstract class BiPlaneController : MonoBehaviour
{
    protected bool addForce, removeForce, rotationUp, rotationDown, shoot;


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
}
