using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WOL : MonoBehaviour
{
    public bool player1Win;
    public bool player1Lose;

    public GameObject Button;
    public GameObject BackGroundWin;
    public GameObject BackGroundLose;

    // Start is called before the first frame update
    void Start()
    {
        player1Win = false;
        player1Lose = false;
        Button.SetActive(false);
        BackGroundWin.SetActive(false);
        BackGroundLose.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        if (player1Win == false && player1Lose == true)
        {
            Debug.Log("player1Lose");
            Button.SetActive(true);
            BackGroundWin.SetActive(false);
            BackGroundLose.SetActive(true);

        }

        if (player1Win == true && player1Lose == false)
        {
            Debug.Log("player1Win");
            Button.SetActive(true);
            BackGroundWin.SetActive(true);
            BackGroundLose.SetActive(false);

        }

    }

    public void Player1Win()
    {
        player1Win = true;
    }

    public void Player2Lose()
    {
        player1Lose = true;
    }
}
