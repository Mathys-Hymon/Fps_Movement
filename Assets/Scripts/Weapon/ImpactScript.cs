using UnityEngine;

public class ImpactScript : MonoBehaviour
{
    [SerializeField] private GameObject bulletText;
    void Start()
    {
        GameObject score = Instantiate(bulletText, transform.position, transform.rotation);
        score.GetComponent<DamageScript>().SetDamages(Random.Range(12,14));
        Invoke(nameof(DestroyActor), 4f);
    }

private void DestroyActor()
    {
        Destroy(gameObject);
    }
}
