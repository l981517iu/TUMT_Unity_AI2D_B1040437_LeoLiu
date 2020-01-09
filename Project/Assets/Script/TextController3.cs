using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TextController3 : MonoBehaviour
{
    public string say = "擊殺對手，活到最後";
    public float speed = 1.5f;

    public GameObject objCanvas;
    public Text testSay;

    // Start is called before the first frame update

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player1")
        {
            objCanvas.SetActive(true);
            testSay.text = say;
           
        }
         if (Input.GetKeyDown(KeyCode.E))
            {
                SceneManager.LoadScene("Level1");
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
