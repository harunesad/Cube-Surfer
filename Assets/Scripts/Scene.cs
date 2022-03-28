using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene : MonoBehaviour
{
    void Start()
    {
        
    }
    void Update()
    {
        
    }
    public void SceneMan()
    {
        StartCoroutine(SceneManage());
    }
    IEnumerator SceneManage()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(1);
    }
}
