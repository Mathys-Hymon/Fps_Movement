
using TMPro;
using UnityEngine;

public class DamageScript : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI distanceText;
    private float time = 0;
    private int damage;
    public void SetDamages(int _damage)
    {
        damage = _damage;
        distanceText.text = damage.ToString();
        gameObject.GetComponent<Rigidbody>().AddForceAtPosition((transform.up + transform.right) * 150, transform.position);
        transform.localScale = Vector3.one * + damage/10;
        distanceText.color = Color.Lerp(new Color(255, 255, 0, 255), new Color(255, 0, 35, 255),damage/20);
    }

    void Update()
    {
        transform.LookAt(Playermovement.instance.transform.position);
        float distance = Vector3.Distance(transform.position, Playermovement.instance.transform.position);


        if (transform.localScale.x > 0)
        {
            transform.localScale -= new Vector3(Time.deltaTime, Time.deltaTime, Time.deltaTime);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
