using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swerve : MonoBehaviour
{
    SwerveControl swerveControl;
    float swerveSpeed = 1f;
    public GameObject playerObject;
    public PlayerControl control;
    private void Awake()
    {
        swerveControl = GetComponent<SwerveControl>();
    }
    private void Update()
    {
        Move();
    }
    public void Move()
    {
        if (control.gameOver == false)
        {
            float swerveAmount = Time.deltaTime * swerveSpeed * swerveControl.MoveFactorX;
            playerObject.transform.Translate(x: swerveAmount, y: 0, z: 0);
        }
    }
}
