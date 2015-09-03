using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ShootingGun : Gun {

    public float ShootingForce { set; get; }
    Transform _transform;

    void Start()
    {
        _transform = GetComponent<Transform>();
    }

    public override void Shoot()
    {
        Transform BulletInstance = (Transform)Instantiate(Bullet.transform, _transform.position, _transform.rotation);
        BulletInstance.GetComponent<Rigidbody2D>().AddForce(transform.right * ShootingForce);
    }
}
