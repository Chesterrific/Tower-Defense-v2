using UnityEngine;

public class Bullet : MonoBehaviour
{
  private Transform target;

  [Header("Bullet Characteristics")]
  public float bulletSpeed = 70f;
  public float explosionRadius = 0f;
  public int bulletDamage = 1;
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
    transform.LookAt(target);
  }
  void HitTarget()
  {
    GameObject effectIns = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
    Destroy(effectIns, 5f);

    if (explosionRadius > 0)
    {
      Explode();
    }
    else
    {
      Damage(target);
    }

    Destroy(gameObject);

  }

  void Damage(Transform enemy)
  {
    Enemy e = enemy.GetComponent<Enemy>();

    if (e != null)
    {
      e.TakeDamage(bulletDamage);
    }
  }

  void Explode()
  {
    //Physics.OverlapSphere() will return colliders that are within the given position and radius.
    Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
    foreach (Collider collider in colliders)
    {
      if (collider.tag == "Enemy")
      {
        Damage(collider.transform);
      }
    }
  }

  //Draws explosion range for us in scene view.
  private void OnDrawGizmosSelected()
  {
    Gizmos.color = Color.red;
    Gizmos.DrawWireSphere(transform.position, explosionRadius);
  }
}