using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    GameObject player;
    public float posY = 4;
    public float posZ = -5;
    void Start()
    {
        player = GameObject.Find("Player");
    }
    void LateUpdate()
    {
        Vector3 distance = new Vector3(0, posY, posZ);
        //transform.position = player.transform.position - new Vector3(0, -4, 5);
        transform.position = Vector3.Lerp(transform.position, player.transform.position + distance, Time.deltaTime * 10);
    }
}
