using UnityEngine;
using System.Collections;

public class BiPlaneAIController : BiPlaneController
{
    Transform _transform, target;

    void Start()
    {
        _transform = GetComponent<Transform>();
        addForce = true;
        removeForce = false;
    }

    void FixedUpdate()
    {
        UpdateParams();
        Rotate();
        if (target == null) FindTarget();
        if (target == null) return;
        if (CanShot()) shoot = true;
    }

    void FindTarget()
    {
    }

    void UpdateParams()
    {
        rotationUp = false;
        rotationDown = false;
        shoot = false;
    }

    void Rotate()
    {
        Vector2 velocity = Vector2.up;
        Vector2 dir = Vector2.right; //Vector3.Normalize(target.position - _transform.position);
        float angle = Vector2.Angle(velocity, dir);
        //Vector2.

        //Debug.Log(angle);
    }

    bool CanShot()
    {
        RaycastHit2D hit = Physics2D.Raycast(_transform.position, target.position - _transform.position);
        return hit != null && hit.collider.tag == "BiPlane";
    }
}
