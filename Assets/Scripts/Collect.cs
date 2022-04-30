using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collect : MonoBehaviour
{
    public GameObject player;
    public CameraControl cameraControl;
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
    }
    void Update()
    {
        Position();
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
            height++;
            CollectableCube collectableCube = other.gameObject.GetComponent<CollectableCube>();
            cameraControl.posZ -= 0.25f;
            other.gameObject.transform.parent = player.transform;
            collectableCube.Collectable();
            collectableCube.IndexSetting(height);
        }
        if (other.gameObject.tag == "Coin")
        {
            coinAdd++;
            coin.text = "" + coinAdd;
            Destroy(other.gameObject);
            AudioSource.PlayClipAtPoint(audios[0], transform.position);
        }
    }
    void Position()
    {
        player.transform.position = new Vector3(transform.position.x, height + 1, transform.position.z);
        this.transform.localPosition = new Vector3(0, -height, 0);
    }
}
