using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GunSystem : MonoBehaviour {

    public BiPlane Owner;
    public Gun CurrentGun;
    float _coolDown;

	void Start ()
    {
        if (CurrentGun != null) SwitchGun(Owner.owner.Gun);
	}

    void SwitchGun(GameObject gun)
    {
        Gun _gun = gun.GetComponent<Gun>();
        if (_gun != null)
        {
            CurrentGun = _gun;
            if (CurrentGun != null) Destroy(CurrentGun.gameObject);
            Transform gunTransform = (Transform)Instantiate(gun, transform.position, transform.rotation);
            gunTransform.parent = transform;
        }
    }
	
	void FixedUpdate () 
    {
        Shoot();
        CoolDown();
	}//+

    public void Shoot()
    {
        if (_coolDown <= 0)
        {
            CurrentGun.Shoot();
            _coolDown = CurrentGun.ShootingCoolDown;
        }
    }//?+

    void CoolDown()
    {
        if (_coolDown > 0)_coolDown -= Time.deltaTime;
    }//+
}
