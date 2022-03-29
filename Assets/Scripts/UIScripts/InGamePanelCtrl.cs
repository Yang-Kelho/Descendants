using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGamePanelCtrl : MonoBehaviour
{
    GameObject panel_backpack;
    GameObject panel_setting;
    Button btn_setting;
    Button btn_backpack;
    Button btn_close;
    Button btn_cancel;
    Button btn_exit;
    // Start is called before the first frame update
    void Start()
    {
        // initialize the buttons
        btn_backpack = transform.Find("btn_backpack").GetComponent<Button>();
        btn_setting = transform.Find("btn_setting").GetComponent<Button>();
        btn_close = transform.Find("panel_backpack").Find("btn_close").GetComponent<Button>();
        
        // initialize the panels:
        panel_backpack = transform.Find("panel_backpack").gameObject;
        panel_setting = transform.Find("panel_setting").gameObject;

        //initialize the button for cancel and exit:
        btn_cancel = panel_setting.transform.Find("btn_cancel").GetComponent<Button>();
        btn_exit = panel_setting.transform.Find("btn_exit").GetComponent<Button>();

        // add listener and event:
        btn_backpack.onClick.AddListener(BackpackEvent);
        btn_setting.onClick.AddListener(SettingEvent);
        btn_close.onClick.AddListener(CloseEvent);
        btn_cancel.onClick.AddListener(CancelEvent);

    }

    private void SettingEvent()
    {
        panel_setting.SetActive(true);
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

    }
}
