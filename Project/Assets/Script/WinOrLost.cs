using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinOrLost : MonoBehaviour
{
    
    public bool player1Dead;
    public bool player2Dead;

    public GameObject Button;
    public GameObject BackGround1;
    public GameObject BackGround2;

    // Start is called before the first frame update
    void Start()
    {
        player1Dead = false;
        player2Dead = false;
        Button.SetActive(false);
        BackGround1.SetActive(false);
        BackGround2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
        if(player1Dead == false && player2Dead == true)
        {
            Debug.Log("player2Win");
            Button.SetActive(true);
            BackGround1.SetActive(true);
            BackGround2.SetActive(false);
            
        }

        if (player1Dead == true && player2Dead == false)
        {
            Debug.Log("player2Win");
            Button.SetActive(true);
            BackGround1.SetActive(false);
            BackGround2.SetActive(true);
            
        }

    }

    public void Player1Dead()
    {
        player1Dead = true;
    }

    public void Player2Dead()
    {
        player2Dead = true;
    }
}
