using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GunSystem : MonoBehaviour {

    public float ShootingCoolDown, ShootingForce;
    public Transform SpawnPoint;
    public Bullet Bullet;
    BiPlane owner;
    float _coolDown = 0f;

	
	void FixedUpdate () 
    {
        Shoot();
        CoolDown();
	}//+

    public void Shoot()
    {
        if (_coolDown <= 0)
        {
            Transform BulletInstance = (Transform)Instantiate(Bullet.transform, SpawnPoint.position, SpawnPoint.rotation);
            BulletInstance.GetComponent<Rigidbody2D>().AddForce(transform.right * ShootingForce);
            _coolDown = ShootingCoolDown;
        }
    }//?+

    void CoolDown()
    {
        if (_coolDown > 0)_coolDown -= Time.deltaTime;
    }//+
}
