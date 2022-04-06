using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LootChest : Interactable
{
    [SerializeField]
    private SpriteRenderer spriteRenderer;

    [SerializeField]
    private Sprite openSprite, closedSprite;

    private bool isOpen, playerInRange;

    [SerializeField]
    private GameObject item;

    public override void Interact()
    {
        base.Interact();
        if (!isOpen && playerInRange)
        {
            GetComponent<SpriteRenderer>().sprite = openSprite;
            isOpen = true;
            dropItem();
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

    public void dropItem()
    {
        GameObject droppedItem;
        droppedItem = Instantiate(item, transform.position, transform.rotation);
        Debug.Log("dropped item");
    }
}
