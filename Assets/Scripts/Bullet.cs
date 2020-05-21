using UnityEngine;

public class Bullet : MonoBehaviour
{
  private Transform target;

  [Header("Bullet Characteristics")]
  public float bulletSpeed = 70f;
  public GameObject impactEffect;

  public void Seek(Transform _target)
  {
    target = _target;
  }

  // Update is called once per frame
  void Update()
  {
    //If target reaches end of stage and is destroyed before bullet reaches it, destroy bullet.
    if (target == null)
    {
      Destroy(gameObject);
      return;
    }

    Vector3 dir = target.position - transform.position;

    //How far our bullet will travel this frame.
    float distanceThisFrame = bulletSpeed * Time.deltaTime;

    //If our bullet will travel further than its target.
    if (dir.magnitude <= distanceThisFrame)
    {
      HitTarget();
      return;
    }

    transform.Translate(dir.normalized * distanceThisFrame, Space.World);
  }
  void HitTarget()
  {
    Instantiate(impactEffect, transform.position, transform.rotation);
    Destroy(gameObject);
    Destroy(target.gameObject);
  }
}