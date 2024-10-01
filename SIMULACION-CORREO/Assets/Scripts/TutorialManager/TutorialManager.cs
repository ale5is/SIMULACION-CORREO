using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    public GameObject[] popUps;
    private int popUpIndex;
    //public PlayerMove playerController;
    private float intialJumpForce;
    public float waitTime = 2f;
    public bool pushedButton = false;

    private void Start()
    {
        //intialJumpForce = playerController.jumpForce;
        //playerController.jumpForce = 0;
    }

    void Update()
    {
        for (int i = 0; i < popUps.Length; i++)
        {
            if (i == popUpIndex)
            {
                popUps[i].SetActive(true);
            }
            else
            {
                popUps[i].SetActive(false);
            }
        }

        if (popUpIndex == 0)
        {
            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyUp(KeyCode.D) || Input.GetAxisRaw("Horizontal") != 0)
            {
                pushedButton = true;

            }
        }
        else if (popUpIndex == 1)
        {
            //playerController.jumpForce = intialJumpForce;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                pushedButton = true;
            }
        }
       

        if (pushedButton)
        {
            if (waitTime <= 0)
            {
                popUpIndex++;
                pushedButton = false;
                waitTime = 2;
            }
            waitTime -= Time.deltaTime;
        }
    }
}