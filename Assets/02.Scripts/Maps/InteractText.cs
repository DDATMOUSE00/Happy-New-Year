using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InteractText : MonoBehaviour
{
    public GameObject textObject;
    private TextMeshProUGUI TMPText;


    private void Start()
    {
        TMPText = textObject.GetComponentInChildren<TextMeshProUGUI>();
        textObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (gameObject.CompareTag("Shop"))
            {
                TMPText.text = "Press 'E' to use the shop";
            }
            else if (gameObject.CompareTag("Well"))
            {
                TMPText.text = "Press 'E' to use the Well" + "\r\n" + "Well can help your Health";
            }
            else if (gameObject.CompareTag("FirstTable"))
            {
                TMPText.text = "Jump to hole, You can start your Adventure";
            }
            else if (gameObject.CompareTag("Table"))
            {
                TMPText.text = "Go Right side" + "\r\n" + "You can proceed to the next level";
            }
            else if (gameObject.CompareTag("RightTable"))
            {
                TMPText.text = "You find right way" + "\r\n" + "Keep Going!!";
            }
            else if (gameObject.CompareTag("WrongTable"))
            {
                TMPText.text = "You are reached the Wrong direction" + "\r\n" + "Find another way";
            }
            else if (gameObject.CompareTag("14Table"))
            {
                TMPText.text = "Hurry Up" + "\r\n" + "Someone chasing you!";
            }
            else if (gameObject.CompareTag("15Table"))
            {
                TMPText.text = "This is the final stage" + "\r\n" + "Can you Defeat him?";
            }

            textObject.SetActive(true);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (gameObject.CompareTag("Shop"))
        {
            if (Input.GetKey(KeyCode.E))
            {
                textObject.SetActive(false);

                // Todo -> 상점 관련 작업
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            textObject.SetActive(false);
        }
    }
}
