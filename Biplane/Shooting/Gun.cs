using UnityEngine;
using System.Collections;

public abstract class Gun : MonoBehaviour {

    public Bullet Bullet { set; get; }

    public float ShootingCoolDown { set; get; }

    public abstract void Shoot();
}
