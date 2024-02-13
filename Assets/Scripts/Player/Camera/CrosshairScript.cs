using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrosshairScript : MonoBehaviour
{
    [SerializeField] private GameObject[] Crosshairs;
    private int state = 0;
    private float targetOffset;
    // 0 = no crosshair, 1 = normal crosshair, 2 = shoot, 3 = aiming

    public void setState(int newState)
    {
        state = newState;

        switch (state)
        {
            case 0:
                for (int i = 0; i < Crosshairs.Length; i++)
                {
                    Crosshairs[i].SetActive(false);
                }
                targetOffset = 0;
                break;

            case 1:
                for (int i = 0; i < Crosshairs.Length; i++)
                {
                    Crosshairs[i].SetActive(false);
                }
                targetOffset = 0;
                break;

        }
    }
    private void Update()
    {
        Crosshairs[0].transform.localPosition = Vector3.Slerp(Crosshairs[0].transform.localPosition, new Vector3(targetOffset, 0, 0), 2* Time.deltaTime);
        Crosshairs[1].transform.localPosition = Vector3.Slerp(Crosshairs[1].transform.localPosition, new Vector3(-targetOffset, 0, 0), 2 * Time.deltaTime);
        Crosshairs[2].transform.localPosition = Vector3.Slerp(Crosshairs[2].transform.localPosition, new Vector3(0, targetOffset, 0), 2 * Time.deltaTime);
        Crosshairs[3].transform.localPosition = Vector3.Slerp(Crosshairs[3].transform.localPosition, new Vector3(0, -targetOffset, 0), 2 * Time.deltaTime);
    }
}
