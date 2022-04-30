using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{
    public Image cubeSkor;
    float forwardSpeed;
    float cubeCount;
    public bool gameOver = false;
    public Animator animator;
    public Button restart;
    public Collect collect;
    public Scene scene;
    public Text levelName;
    void Start()
    {
        scene = GameObject.Find("SceneManager").GetComponent<Scene>();
        animator = GetComponentInChildren<Animator>();
        collect = GetComponentInChildren<Collect>();
        gameOver = false;
        forwardSpeed = 2.0f;
        cubeSkor.fillAmount=0;
    }
    void Update()
    {
        ScoreInc();
        Move();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            gameOver = true;
            animator.SetBool("Stumble", true);
            restart.gameObject.SetActive(true);
            AudioSource.PlayClipAtPoint(collect.audios[1], transform.position);
        }
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    void ScoreInc()
    {
        cubeCount = gameObject.GetComponentsInChildren<CollectableCube>().Length;
        if (transform.position.z > 130.0f)
        {
            if (cubeSkor.fillAmount * 10 < cubeCount)
            {
                cubeSkor.fillAmount += Time.deltaTime;
            }
            gameOver = true;
            animator.SetBool("Victory", true);
            if (levelName.text == "Level 1")
            {
                scene.SceneMan();
            }
        }
    }
    private void Move()
    {
        if (gameOver == false)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * forwardSpeed);
        }
        float xPos = Mathf.Clamp(transform.position.x, -4.5f, 4.5f);
        transform.position = new Vector3(xPos, transform.position.y, transform.position.z);
    }
}
