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
        transform.position = Vector3.MoveTowards(transform.position, position, bulletSpeed* Time.deltaTime);

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
