using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public GameObject player;
    public float posY = 4;
    public float posZ = -5;
    void LateUpdate()
    {
        Follow();
    }
    void Follow()
    {
        Vector3 distance = new Vector3(0, posY, posZ);
        transform.position = Vector3.Lerp(transform.position, player.transform.position + distance, Time.deltaTime * 10);
    }
}
