using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class SwitchBetweenCameras : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera[] cameras;
    int index = 0;


    public void ChangeCamera()
    {
        index++;
        if (index >= cameras.Length)
            index = 0;

        for (int i = 0; i < cameras.Length; i++)
        {
            if (i == index)
                cameras[i].Priority = 1;

            else
                cameras[i].Priority = 0;
        }

    }
}
