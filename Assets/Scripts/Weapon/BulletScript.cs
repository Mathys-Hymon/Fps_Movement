using UnityEngine;

public class BulletScript : MonoBehaviour
{
    [SerializeField] private float bulletSpeed;
    [SerializeField] private AudioSource ASRef;
    [SerializeField] private GameObject bulletImpact;
    private Vector3 position;
    private bool spawnParticles;
    private GameObject hitActor;


    void Update()
    {
        transform.position += transform.up * bulletSpeed* Time.deltaTime;

        if(transform.position == position)
        {
            if(spawnParticles && hitActor != null)
            {
                GameObject impact = Instantiate(bulletImpact, transform.position, transform.rotation);
                impact.transform.parent = hitActor.transform;
            }
            DestroyBullet();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject impact = Instantiate(bulletImpact, transform.position, transform.rotation);
        impact.transform.parent = collision.gameObject.transform;
        Destroy(gameObject);
    }

    private void DestroyBullet()
    {
        Destroy(gameObject);
    }

    public void setTargetPos(Vector3 newPosition, bool newSpawnParticles, GameObject newHit)
    {
        hitActor = newHit;
        position = newPosition;
        spawnParticles = newSpawnParticles;
    }
}
