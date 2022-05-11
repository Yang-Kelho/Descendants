using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shopkeeper : MonoBehaviour
{
    private int anger = 0;
    private Vector2[] shopItemPositions;
    private GameObject[] shopItemPrefabs;
    private int[] itemPrices;
    private GameObject[] shopItems;

    public GameObject baseShopItem;
    public GameObject HeartPickup;
    public GameObject HealthUpgrade;
    public GameObject SpeedUpgrade;
    public GameObject DamageUpgrade;

    private void Awake()
    {
        shopItemPrefabs = new GameObject[4] { HeartPickup, 
                                              HealthUpgrade, 
                                              SpeedUpgrade, 
                                              DamageUpgrade };
        itemPrices = new int[4] { 50, 150, 75, 200};
        float rand = Random.Range(0, 1.0f);
        if (rand < 0.5f)
        {
            this.transform.position += new Vector3(0, 100);
            shopItems = new GameObject[3];
            shopItemPositions = new Vector2[3] { new Vector2(-180, -150),
                                                 new Vector2(   0, -150),
                                                 new Vector2( 180, -150) };
        }
        else
        {
            shopItems = new GameObject[4];
            shopItemPositions = new Vector2[4] { new Vector2(-180,  150),
                                                 new Vector2( 180,  150),
                                                 new Vector2(-180, -150),
                                                 new Vector2( 180, -150) };
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < shopItemPositions.Length; i++)
        {
            // instantiate shop items
            GameObject item = Instantiate(baseShopItem);
            shopItems[i] = item;
            item.GetComponent<ShopItem>().SetFields(shopItemPrefabs[i], itemPrices[i]);
            item.transform.SetParent(transform);
            item.transform.position = (Vector2)transform.position + shopItemPositions[i];
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Projectile>().projectile.type == ProjectileObjects.Type.player)
        {
            switch (anger)
            {
                case 0:
                    anger++;
                    GetComponent<SpriteRenderer>().color = new Color(1.0f, 0.64f, 0.0f);
                    break;
                case 1:
                    anger++;
                    PriceHike();
                    break;
                case 2:
                    anger++;
                    ClosingTime();
                    break;
                default:
                    break;
            }
        }
    }

    private void PriceHike()
    {
        ShopItem[] shopItems = GetComponentsInChildren<ShopItem>();
        foreach (ShopItem item in shopItems)
        {
            item.PriceHike();
        }
        GetComponent<SpriteRenderer>().color = Color.red;
    }

    private void ClosingTime()
    {
        for (int i = 0; i < shopItems.Length; i++)
        {
            Destroy(shopItems[i]);
        }
    }
}
