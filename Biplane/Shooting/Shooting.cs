using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(BiPlaneController))]
public class Shooting : MonoBehaviour {

    public Gun GunType;
    Transform _gun;
    Bullet _bullet;
    float _coolDown;
    BiPlaneController _controller;

	void Start ()
    {
        _controller = GetComponent<BiPlaneController>();
        _gun = (Transform)Instantiate(GunType.transform, transform.position, transform.rotation);
        _gun.parent = transform;
        _bullet = GunType.BulletType;
	}//+
	
	void FixedUpdate () 
    {
        Shoot();
        CoolDown();
	}//+

    private void Shoot()
    {
        if (_controller.Shoot && _coolDown <= 0)
        {
            Transform ShellInstance = (Transform)Instantiate(_bullet.transform, _gun.position, _gun.rotation);
            ShellInstance.GetComponent<Rigidbody2D>().AddForce(transform.right * GunType.ShootingForce);
            _coolDown = GunType.ShootingCoolDown;
        }

        _controller.Shoot = false;
    }

    private void CoolDown()
    {
        if (_coolDown > 0)
        {
            _coolDown -= Time.deltaTime;
        }
    }//+
}
