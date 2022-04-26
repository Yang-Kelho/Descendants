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
    Button btn_register;
    Button btn_back;
    Button btn_OK_success;
    Button btn_OK_fail;
    private Realm _realm;

    // Start is called before the first frame update
    void Start()
    {

        // retrieve the panels:
        panel_notification_success = transform.Find("panel_notification_success").gameObject;
        panel_notification_fail = transform.Find("panel_notification_fail").gameObject;

        // retrieve the buttons:
        btn_register = transform.Find("btn_register").GetComponent<Button>();
        btn_back = transform.Find("btn_back").GetComponent<Button>();
        btn_OK_fail = panel_notification_fail.transform.Find("btn_OK").GetComponent<Button>();
        btn_OK_success = panel_notification_success.transform.Find("btn_OK").GetComponent<Button>();


        //add listener and events:
        btn_register.onClick.AddListener(RegisterEvent);
        btn_back.onClick.AddListener(BackEvent);
        btn_OK_success.onClick.AddListener(OKEvent_Success);
        btn_OK_fail.onClick.AddListener(OKEvent_Fail);

    }

    private async void RegisterEvent()
    {
        // trigger when you click the register button:
        var userName = transform.Find("vertical_layout").Find("Input_userName").Find("Text").GetComponent<Text>().text;
        var password = transform.Find("vertical_layout").Find("Input_password").Find("Text").GetComponent<Text>().text;
        var regi = 0;
        var payload = new
        {
            name = userName,
            password = password
        };
        var realmApp = App.Create(new AppConfiguration("descandants-upzrf")
        {
            MetadataPersistenceMode = MetadataPersistenceMode.NotEncrypted
        });

        var currentUser = realmApp.CurrentUser;

        if (currentUser == null)
        {
            currentUser = await realmApp.LogInAsync(Credentials.Anonymous());
            regi = await realmApp.CurrentUser.Functions.CallAsync<int>("Register", payload);
        }

        if (regi == 0)
        {
            //if return value = 0. Register failed
            await realmApp.CurrentUser.LogOutAsync();
            _realm.Dispose();
            panel_notification_fail.SetActive(true);
            Debug.Log("Reigster failed, duplicated id exists");
        }
        else
        {
            await realmApp.CurrentUser.LogOutAsync();
            _realm.Dispose();
            panel_notification_success.SetActive(true);
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
}
