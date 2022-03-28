using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableCube : MonoBehaviour
{
    public bool collectable;
    Collect collect;
    int index;
    void Start()
    {
        collectable = false;
        collect = GameObject.Find("AddCube").GetComponent<Collect>();
    }
    void Update()
    {
        if (collectable == true)
        {
            if (transform.parent != null)
            {
                transform.localPosition = new Vector3(0, -index, 0);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Obstacle")
        {
            collect.HeightReduce();
            transform.parent = null;
            other.gameObject.GetComponent<BoxCollider>().enabled = false;
            GetComponent<BoxCollider>().enabled = false;
            AudioSource.PlayClipAtPoint(collect.audios[2], transform.position);
        }
    }
    public bool GetCollectable()
    {
        return collectable;
    }
    public void Collectable()
    {
        collectable = true;
    }
    public void IndexSetting(int index)
    {
        this.index = index;
    }
}
