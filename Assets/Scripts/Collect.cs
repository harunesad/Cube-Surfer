using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collect : MonoBehaviour
{
    GameObject player;
    CameraControl cameraControl;
    public Text coin;
    int coinAdd;
    int height;
    public AudioSource source;
    public AudioClip[] audios;
    void Start()
    {
        coinAdd = 0;
        coin.text = "" + coinAdd;
        height = 0;
        player = GameObject.Find("Player");
        cameraControl = GameObject.Find("Main Camera").GetComponent<CameraControl>();
    }
    void Update()
    {
        player.transform.position = new Vector3(transform.position.x, height + 1, transform.position.z);
        this.transform.localPosition = new Vector3(0, -height, 0);
    }
    public void HeightReduce()
    {
        StartCoroutine(Time());
    }
    IEnumerator Time()
    {
        yield return new WaitForSeconds(1);
        height--;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Add" && other.gameObject.GetComponent<CollectableCube>().GetCollectable() == false)
        {
            height ++;
            cameraControl.posZ -= 0.25f;
            other.gameObject.GetComponent<CollectableCube>().Collectable();
            other.gameObject.GetComponent<CollectableCube>().IndexSetting(height);
            other.gameObject.transform.parent = player.transform;
        }
        if (other.gameObject.tag == "Coin")
        {
            coinAdd++;
            coin.text = "" + coinAdd;
            Destroy(other.gameObject);
            AudioSource.PlayClipAtPoint(audios[0], transform.position);
        }
    }
}
