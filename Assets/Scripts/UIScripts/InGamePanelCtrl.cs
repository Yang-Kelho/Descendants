using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InGamePanelCtrl : MonoBehaviour
{
    GameObject panel_backpack;
    GameObject panel_setting;
    GameObject slots;
    //GameObject panel_inventory;

    Button btn_setting;
    Button btn_backpack;
    Button btn_close;
    Button btn_cancel;
    Button btn_exit;
    Button btn_use;
    Button btn_remove;

    Button btn_selected;

    // retrieve total and current Score text component:
    Text text_currentScore;
    Text text_highestScore;

    // retrieve the images:
    

    string slotName;
    string slotName_selected;
    // Start is called before the first frame update
    void Start()
    {
        // initialize the panels:
        panel_backpack = transform.Find("panel_backpack").gameObject;
        panel_setting = transform.Find("panel_setting").gameObject;

        // initialize the buttons
        btn_backpack = transform.Find("btn_backpack").GetComponent<Button>();
        btn_setting = transform.Find("btn_setting").GetComponent<Button>();
        btn_close = transform.Find("panel_backpack").Find("btn_close").GetComponent<Button>();
        btn_use = transform.Find("panel_backpack").Find("btn_use").GetComponent<Button>();
        btn_remove = transform.Find("panel_backpack").Find("btn_remove").GetComponent<Button>();

        // initialize the texts:
        text_currentScore = panel_setting.transform.Find("text_currentScore").GetComponent<Text>();
        text_highestScore = panel_setting.transform.Find("text_highestScore").GetComponent<Text>();

        //initialize the button for cancel and exit:
        btn_cancel = panel_setting.transform.Find("btn_cancel").GetComponent<Button>();
        btn_exit = panel_setting.transform.Find("btn_exit").GetComponent<Button>();

        // add listener and event:
        btn_backpack.onClick.AddListener(BackpackEvent);
        btn_setting.onClick.AddListener(delegate { SettingEvent(0, 0); });
        btn_close.onClick.AddListener(CloseEvent);
        btn_cancel.onClick.AddListener(CancelEvent);
        btn_use.onClick.AddListener(UseEvent);
        btn_remove.onClick.AddListener(RemoveEvent);
        btn_exit.onClick.AddListener(ExitEvent);

        initBackpackSlots();
        getWeaponInventory();

    }

    private void initBackpackSlots()
    {
        // initialize the backpack slots and add onclick listener to them:
        slots = transform.Find("panel_backpack").Find("panel_backpack_slots").gameObject;
        // create a list of slots:
        List<Button> slotList = new List<Button>();
        for(int i = 0; i < 18; i++)
        {
            slotName = "slot_" + (i+1);
            // add the onclick to it first:
            btn_selected = slots.transform.Find(slotName).GetComponent<Button>();
            // add each button to the list
            slotList.Add(btn_selected);
        }
        // so we have a list of button, corresponding to each item slot in backpack

        slotList[0].onClick.AddListener(delegate { Selected(0); });
        slotList[1].onClick.AddListener(delegate { Selected(1); });
        slotList[2].onClick.AddListener(delegate { Selected(2); });
        slotList[3].onClick.AddListener(delegate { Selected(3); });
        slotList[4].onClick.AddListener(delegate { Selected(4); });
        slotList[5].onClick.AddListener(delegate { Selected(5); });
        slotList[6].onClick.AddListener(delegate { Selected(6); });
        slotList[7].onClick.AddListener(delegate { Selected(7); });
        slotList[8].onClick.AddListener(delegate { Selected(8); });
        slotList[9].onClick.AddListener(delegate { Selected(9); });
        slotList[10].onClick.AddListener(delegate { Selected(10); });
        slotList[11].onClick.AddListener(delegate { Selected(11); });
        slotList[12].onClick.AddListener(delegate { Selected(12); });
        slotList[13].onClick.AddListener(delegate { Selected(13); });
        slotList[14].onClick.AddListener(delegate { Selected(14); });
        slotList[15].onClick.AddListener(delegate { Selected(15); });
        slotList[16].onClick.AddListener(delegate { Selected(16); });
        slotList[17].onClick.AddListener(delegate { Selected(17); });
    }

    private void Selected(int k)
    {
        // activate the item being selected:
        slotName_selected = "slot_" + (k+1);
        slots.transform.Find(slotName_selected).Find("selected").gameObject.SetActive(true);
        // then, deactivate other selected:
        for(int i = 1; i < 19; i++)
        {
            string tempName = "slot_" + i;
            // deactivate all other selected:
            if(k != (i - 1))
            {
                slots.transform.Find(tempName).Find("selected").gameObject.SetActive(false);
            }
            
        }
        Debug.Log(k);
    }

    private void SettingEvent(int currentScore, int highestScore)
    {
        panel_setting.SetActive(true);
        // modify the number:
        text_currentScore.text = "Current Score: " + currentScore;
        text_highestScore.text = "Highest Score: " + highestScore;
    }

    private void BackpackEvent()
    {
        panel_backpack.SetActive(true);
    }

    private void CloseEvent()
    {
        panel_backpack.SetActive(false);
    }

    private void CancelEvent()
    {
        panel_setting.SetActive(false);
    }

    private void ExitEvent()
    {
        // Do the saving here:
            // save same files, code goes here:


        // transit back to the UI scene:

        SceneManager.LoadScene(sceneBuildIndex: 0);
    }

    private void UseEvent()
    {
        // use the selected item if it is not NULL:

    }

    private void RemoveEvent()
    {
        // remove the selected item if it is not NULL:

    }

    private void getWeaponInventory()
    {
        WeaponInventory.WeaponInventorySlots slot = GameObject.Find("PF Player").GetComponent<PlayerAtkController>().weaponInv.containers[0];
        Sprite weapon = slot.weapons.weaponPrefab.transform.GetComponent<SpriteRenderer>().sprite;
        this.transform.Find("sprite_currentWeapon").GetComponent<Image>().sprite = weapon;
    }
}
