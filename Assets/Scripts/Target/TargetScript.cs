using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetScript : MonoBehaviour
{
    [SerializeField] private float GoBackDelay = 15;
    [SerializeField] private float impactForce = 15;
    [SerializeField] private GameObject impactText;
    private Quaternion initialRotation, targetRotation;
    private bool hit;
    private float delay;

    private void Start()
    {
        initialRotation = transform.localRotation;
    }
    private void Update()
    {
         if(hit)
        {
            if(delay <= GoBackDelay/1.5f)
            {
                delay++;
                targetRotation = Quaternion.Euler(impactForce*100, 0, 0);
            }
            else
            {
                targetRotation = initialRotation;
                hit = false;
                delay = 0;
            }
        }

         transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation, (GoBackDelay /3)* Time.deltaTime);
    }

    public void getHit(float damages, Vector3 ImpactPoint)
    {
        hit = true;
        GameObject text = Instantiate(impactText, transform.position, Quaternion.identity);
        text.transform.position = ImpactPoint;
        text.SetActive(true);
        print(damages);
        text.GetComponent<DamageScript>().SetDamages(damages);
    }
}
