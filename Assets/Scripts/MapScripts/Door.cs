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
        GameObject room = this.transform.parent.gameObject;

        // Doors are "opened" a.k.a. invisible upon start.
        gameObject.GetComponent<Renderer>().enabled = false;
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        // Transition
        if (collision.CompareTag("Player"))
        {
            player = collision.gameObject;
            switch (this.name[this.name.Length - 1])
            {
                case 'B':
                    direction = new Vector2(0, 5);
                    break;
                case 'T':
                    direction = new Vector2(0, -5);
                    break;
                case 'L':
                    direction = new Vector2(5, 0);
                    break;
                case 'R':
                    direction = new Vector2(-5, 0);
                    break;
                default:
                    break;
            }
            atk_stick.SetActive(false);
            mov_stick.SetActive(false);
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        // Translate Player
        if (collision.CompareTag("Player"))
        {
            player.GetComponent<Transform>().Translate(direction);
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        // Enable Joysticks & Prevent Player from walking through
        if (collision.CompareTag("Player"))
        {
            if (!this.transform.parent.parent.GetComponent<Room>().cleared)
            {
                this.transform.parent.parent.GetComponent<Room>().closeDoor();
            }
            atk_stick.SetActive(true);
            mov_stick.SetActive(true);
            gameObject.GetComponent<BoxCollider2D>().enabled = true;
        }
    }
}
