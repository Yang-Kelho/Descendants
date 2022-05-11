using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LootChest : Interactable
{
    [SerializeField]
    private SpriteRenderer spriteRenderer;

    [SerializeField]
    private Sprite openSprite, closedSprite;

    private bool isOpen, playerInRange;

    public GameObject item1;
    public GameObject item2;
    public GameObject item3;
    public GameObject item4;

    public override void Interact()
    {
        base.Interact();
        if (!isOpen && playerInRange)
        {
            GetComponent<SpriteRenderer>().sprite = openSprite;
            isOpen = true;
            DropItem();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger && !isOpen)
        {
            Debug.Log("opened chest");
            playerInRange = true;
            Interact();
        }
    }


    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger && !isOpen)
        {
            playerInRange = false;
        }
    }

    public void DropItem()
    {
        Scene scene = SceneManager.GetActiveScene();
        Vector2 position = transform.position;
        switch (scene.name)
        {
            case "Floor3":
                Instantiate(item4, position - new Vector2(0, 10), transform.rotation);
                break;
            case "Floor2":
                if (Random.Range(0f, 1.0f) < 0.75)
                    Instantiate(item3, position - new Vector2(0, 10), transform.rotation);
                else
                    Instantiate(item4, position - new Vector2(0, 10), transform.rotation);
                break;
            default:
                Instantiate(item2, position - new Vector2(0, 10), transform.rotation);
                break;
        }
    }
}
