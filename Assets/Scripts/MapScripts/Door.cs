using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    GameObject atk_stick;
    GameObject mov_stick;
    GameObject player;
    Vector2 direction = Vector2.zero;
    void Start()
    {
        atk_stick = GameObject.Find("atk_stick");
        mov_stick = GameObject.Find("mov_stick");
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        // Transition
        if (collision.CompareTag("Player")) {
            player = collision.gameObject;
            switch (this.name[this.name.Length - 1])
            {
                case 'B':
                    direction = new Vector2(0, 3);
                    break;
                case 'T':
                    direction = new Vector2(0, -3);
                    break;
                case 'L':
                    direction = new Vector2(3, 0);
                    break;
                case 'R':
                    direction = new Vector2(-3, 0);
                    break;
                default:
                    break;
            }

            if (this.name[this.name.Length - 1] == 'B') {
                Debug.Log("Works");
                // Disable Joysticks
                atk_stick.SetActive(false);
                mov_stick.SetActive(false);
                
                atk_stick.SetActive(true);
                mov_stick.SetActive(true);
            }
        }
    }

    void OnTriggerStay2D()
    {
        atk_stick.SetActive(false);
        mov_stick.SetActive(false);
        player.GetComponent<Transform>().Translate(direction);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        atk_stick.SetActive(true);
        mov_stick.SetActive(true);
        gameObject.GetComponent<BoxCollider2D>().enabled = true;
    }

    public void open()
    {
        gameObject.SetActive(false);
    }
}
