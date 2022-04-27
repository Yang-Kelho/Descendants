using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPickup : MonoBehaviour
{
    bool canPickUp;
    WeaponObjects pickUpWeapon, droppedWeapon;
    WeaponInventory weaponInv;
    Collider2D collision;

    public void Start()
    {
        weaponInv = GetComponent<PlayerAtkController>().weaponInv;

    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("weapon"))
        {
            canPickUp = true;
            pickUpWeapon = collision.GetComponent<GroundWeaponObj>().weapon;
            this.collision = collision;
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        canPickUp = false;
        pickUpWeapon = null;
        this.collision = null;
    }

    IEnumerator dropWeapon(GameObject drop)
    {
        drop.GetComponent<Collider2D>().enabled = false;
        yield return new WaitForSeconds(1);
        drop.GetComponent<Collider2D>().enabled = true;
    }

    public void pickUp()
    {
        if (canPickUp == true && collision.GetComponent<Collider2D>().enabled == true)
        {
            var slotsBeforePickUp = weaponInv.CheckEmptySlot();
            weaponInv.AddWeapon(pickUpWeapon);
            Destroy(collision.gameObject);
            if(slotsBeforePickUp == 2 )
                SpawnWeapon();
        }
    }
    public void Update()
    {
        droppedWeapon = weaponInv.GetCurrentWeapon();
    }
    public void SpawnWeapon()
    {
        var dropped = Instantiate(droppedWeapon.weaponPrefab, transform.position, Quaternion.identity);
        StartCoroutine(dropWeapon(dropped));
    }
}
