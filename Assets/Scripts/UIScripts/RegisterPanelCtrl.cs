using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Realms;
using Realms.Sync;

public class RegisterPanelCtrl : MonoBehaviour
{
    GameObject panel_login;
    GameObject panel_notification_success;
    GameObject panel_notification_fail;
    GameObject panel_notification_confirm;
    Button btn_register;
    Button btn_back;
    Button btn_OK_success;
    Button btn_OK_fail;
    Button btn_OK_confirm;
    public RealmController rc;

    // Start is called before the first frame update
    void Start()
    {

        // retrieve the panels:
        panel_notification_success = transform.Find("panel_notification_success").gameObject;
        panel_notification_fail = transform.Find("panel_notification_fail").gameObject;
        panel_notification_confirm = transform.Find("panel_notification_confirm").gameObject;

        // retrieve the buttons:
        btn_register = transform.Find("btn_register").GetComponent<Button>();
        btn_back = transform.Find("btn_back").GetComponent<Button>();
        btn_OK_success = panel_notification_success.transform.Find("btn_OK").GetComponent<Button>();
        btn_OK_fail = panel_notification_fail.transform.Find("btn_OK").GetComponent<Button>();
        btn_OK_confirm = panel_notification_confirm.transform.Find("btn_OK").GetComponent<Button>();


        //add listeners and events:
        btn_register.onClick.AddListener(RegisterEvent);
        btn_back.onClick.AddListener(BackEvent);
        btn_OK_success.onClick.AddListener(OKEvent_Success);
        btn_OK_fail.onClick.AddListener(OKEvent_Fail);
        btn_OK_confirm.onClick.AddListener(OKEvent_Confirm);

    }

    private async void RegisterEvent()
    {
        // trigger when you click the register button:
        var userName = transform.Find("vertical_layout").Find("Input_userName").GetComponent<InputField>().text;
        var password = transform.Find("vertical_layout").Find("Input_password").GetComponent<InputField>().text;
        var confirm = transform.Find("vertical_layout").Find("Input_confirm").GetComponent<InputField>().text;

        if (password != confirm)
        {
            panel_notification_confirm.SetActive(true);
            Debug.Log("Password fields do not match");
        }
        else
        {
            var regi = await rc.Register(userName, password);

            Debug.Log(rc.regi);
            if (regi == 0)
            {
                //if return value = 0. Register failed
                panel_notification_fail.SetActive(true);
                Debug.Log("Registration failed, duplicate id exists");
            }
            else
            {
                panel_notification_success.SetActive(true);
            }
        }
    }

    private void BackEvent()
    {
        panel_login = transform.parent.Find("panel_login").gameObject;
        panel_login.SetActive(true);
        gameObject.SetActive(false);
    }

    private void OKEvent_Success()
    {
        panel_notification_success.SetActive(false);
        BackEvent();
    }
    private void OKEvent_Fail()
    {
        panel_notification_fail.SetActive(false);
    }


    private void OKEvent_Confirm()
    {
        panel_notification_confirm.SetActive(false);
    }
}
