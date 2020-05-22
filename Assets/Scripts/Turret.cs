﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{

  private Transform target;

  [Header("Attributes")]
  public float range = 15f;
  public float turnSpeed = 10f;
  public float fireRate = 1f;
  private float fireCountDown = 0.5f;

  [Header("Unity Setup Fields")]
  public Transform partToRotate;
  public string enemyTag = "Enemy"; //What our turret will target.
  public GameObject bulletPrefab;
  public Transform firePoint;

  // Start is called before the first frame update
  void Start()
  {
    //This function can setup another function to be called repeatedly based on time parameters given.
    InvokeRepeating("UpdateTarget", 0f, 0.5f);
  }

  void UpdateTarget()
  {
    GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
    GameObject nearestEnemy = null;
    float shortestDistance = Mathf.Infinity;


    foreach (GameObject enemy in enemies)
    {
      //Finds distance between two objects. Take their transform.position and subtract in A-B fashion.
      float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);

      if (shortestDistance > distanceToEnemy)
      {
        shortestDistance = distanceToEnemy;
        nearestEnemy = enemy;
      }
    }

    if (nearestEnemy != null && shortestDistance <= range)
    {
      target = nearestEnemy.transform;
    }
    else
    {
      target = null;
    }

  }

  // Update is called once per frame
  void Update()
  {
    if (target == null)
    {
      return;
    }

    /*-------------------------Target Lock on-------------------------*/
    Vector3 dir = target.position - transform.position;

    //Quaternion deals with rotation, with this line we're taking our direction and giving ourselves a rotation variable to use to look that way.
    Quaternion lookRotation = Quaternion.LookRotation(dir);

    //We convert the direction into euler angles (x,y,z) to prepare it for use.
    //Lerp is used in general as a smooth transition between two states, colors, positions, in this case rotations.
    Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;

    //Since we only want to rotate along one axis, we set other rotations to 0 and take only the y component of our rotation variable.
    //Ex. if we wanted to also rotate up and down, we would take the z component of our rotation variable.
    partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);

    /*-------------------------Shooting-------------------------*/
    if (fireCountDown <= 0f)
    {
      Shoot();
      fireCountDown = 1f / fireRate;
    }

    fireCountDown -= Time.deltaTime;
  }

  void Shoot()
  {
    //We're storing our instantiated bullet into a temporary variable so we can call the functions within it.
    //We need variable casting when we instantiate objects and want to store them.
    GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

    //Will grab the component called "Bullet" from our GameObject, in this case it'll grab the script.
    Bullet bullet = bulletGO.GetComponent<Bullet>();

    if (bullet != null)
    {
      //Will pass on turret's target to the bullet.
      bullet.Seek(target);
    }
  }

  //Draws turret range for us in scene view.
  private void OnDrawGizmosSelected()
  {
    Gizmos.color = Color.red;
    Gizmos.DrawWireSphere(transform.position, range);
  }
}