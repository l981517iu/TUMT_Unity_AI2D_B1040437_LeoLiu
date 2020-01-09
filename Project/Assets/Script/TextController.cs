using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour
{
    public string say = "A、D移動，Space跳躍，W射擊";
    public float speed = 1.5f;

    public GameObject objCanvas;
    public Text testSay;
    
    // Start is called before the first frame update
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "Player1")
        {
            objCanvas.SetActive(true);
            testSay.text = say;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "Player1")
        {
            objCanvas.SetActive(false);
        }
    }

}
