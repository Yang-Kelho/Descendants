using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopItem : MonoBehaviour
{
    public GameObject _item;
    public int _price;

    public void SetFields(GameObject item, int price)
    {
        _item = item;
        _price = price;

        SpriteRenderer sr = gameObject.GetComponent<SpriteRenderer>();
        sr.sprite = item.GetComponent<SpriteRenderer>().sprite;
        transform.localScale = item.transform.localScale;

        TextMeshPro text = gameObject.GetComponentInChildren<TextMeshPro>();
        text.text = price.ToString();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && GoldDisplay.goldSystem.GetCurrentGold() >= _price)
        {
            GoldDisplay.goldSystem.SpendGold(_price);
            Instantiate(_item, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    public void PriceHike()
    {
        _price *= 2;
        GetComponentInChildren<TextMeshPro>().text = _price.ToString();
        GetComponentInChildren<TextMeshPro>().color = new Color(1.0f, 0.64f, 0.0f);
    }
}
