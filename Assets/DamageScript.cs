
using TMPro;
using UnityEngine;

public class DamageScript : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI distanceText;
    private float time = 0;
    public void SetDamages(int damage)
    {
        distanceText.text = damage.ToString();
        GetComponent<Rigidbody>().AddForce((transform.up + transform.right)*10);
    }

    void Update()
    {
        transform.LookAt(Playermovement.instance.transform.position);
        transform.localPosition = 180*
        float distance = Vector3.Distance(transform.position, Playermovement.instance.transform.position);


        if(time < 5)
        {
            transform.localScale -= new Vector3(time / 5, time / 5, time / 5);
            //time += Time.deltaTime;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
