using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class NPC : MonoBehaviour
{
    public enum state
    {
        normal,notComplete,complete
    }

    public state _state;

    public string sayStart = "從怪物手中拿回鑰匙打開寶藏吧!";
    public string sayNotComplete = "怎麼沒鑰匙呢!你這廢物!";
    public string sayComplete = "在這裡的寶藏都是我的!";

    public float speed = 1.5f;

    public bool complete;
    public int countPlayer;
    public int countFinish = 1;
    public GameObject objCanvas;
    public Text textSay;




    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player1") Say();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "Player1") SayClose();
    }

    private void Say()
    {
        objCanvas.SetActive(true);
        StopAllCoroutines();

        if (countPlayer >= countFinish)
        {
            _state = state.complete;
        }

        switch (_state)
        {
            case state.normal:
                StartCoroutine(ShowDialog(sayStart));
                _state = state.notComplete;
                break;
            case state.notComplete:
                StartCoroutine(ShowDialog(sayNotComplete));
                break;
            case state.complete:
                StartCoroutine(ShowDialog(sayComplete));
                break;
           
        }
    }

    private IEnumerator ShowDialog(string say)
    {
        textSay.text = "";

        for (int i = 0; i < say.Length; i++)
        {
            textSay.text += say[i].ToString();
            yield return new WaitForSeconds(speed);
        }
    }

    private void SayClose()
    {
        objCanvas.SetActive(false);
        StopAllCoroutines();
    }

    public void PlayerGet()
    {
        countPlayer++;
    }

}
