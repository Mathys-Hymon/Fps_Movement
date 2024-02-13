using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrosshairScript : MonoBehaviour
{
    public static CrosshairScript instance;

    [SerializeField] private GameObject[] Crosshairs;
    private int state = 0;
    private float targetOffset, beforeOffset;

    private void Start()
    {
        instance = this;
        setState(0);
    }

    public void hitMarker()
    {

    }
    public void setState(int newState)
    {
        state = newState;
        for (int i = 0; i < Crosshairs.Length; i++)
        {
            Crosshairs[i].SetActive(true);
        }
        switch (state)  // 0 = no crosshair, 1 = normal crosshair, 2 = shoot, 3 = aiming
        {
            case 0:
                for (int i = 0; i < Crosshairs.Length; i++)
                {
                    Crosshairs[i].SetActive(false);
                }
                targetOffset = 15;
                break;

            case 1:

                targetOffset = 10;
                break;

            case 2:
                beforeOffset = targetOffset;
                targetOffset = 20;
                Invoke(nameof(ResetShoot), 0.1f);
                break;

            case 3:
                targetOffset = 0;
                break;

        }
    }

    private void ResetShoot()
    {
        targetOffset = beforeOffset;
    }
    private void Update()
    {
        Crosshairs[0].transform.localPosition = Vector3.Slerp(Crosshairs[0].transform.localPosition, new Vector3(0, targetOffset, 0), 10* Time.deltaTime);
        Crosshairs[1].transform.localPosition = Vector3.Slerp(Crosshairs[1].transform.localPosition, new Vector3(0, -targetOffset, 0), 10 * Time.deltaTime);
        Crosshairs[2].transform.localPosition = Vector3.Slerp(Crosshairs[2].transform.localPosition, new Vector3(targetOffset, 0, 0), 10 * Time.deltaTime);
        Crosshairs[3].transform.localPosition = Vector3.Slerp(Crosshairs[3].transform.localPosition, new Vector3(-targetOffset, 0, 0), 10 * Time.deltaTime);
    }
}
