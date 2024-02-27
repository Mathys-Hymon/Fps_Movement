
using TMPro;
using UnityEngine;

public class DamageScript : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI distanceText;
    private void Start()
    {
        gameObject.SetActive(false);
    }

    public void SetDamages(int damage)
    {
        distanceText.text = damage.ToString();
    }

    void Update()
    {
        transform.LookAt(Playermovement.instance.transform.position);
        float distance = Vector3.Distance(transform.position, Playermovement.instance.transform.position);
        transform.localScale = new Vector3(0.001f * distance / 10f, 0.001f * distance / 10f, 0.001f * distance / 10f);
        if (distance < 3)
        {
            gameObject.SetActive(false);
        }
    }
}
