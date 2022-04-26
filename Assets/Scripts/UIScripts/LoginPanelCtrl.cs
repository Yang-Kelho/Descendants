using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Realms;
using Realms.Sync;

public class LoginPanelCtrl : MonoBehaviour
{
    GameObject panel_register;
    GameObject panel_start;
    GameObject panel_notification_success;
    GameObject panel_notification_fail;
    Button btn_login;
    Button btn_back;
    Button btn_register_transfer;
    Button btn_Logout;
    Button btn_OK_success;
    Button btn_OK_fail;
    App realmApp;
    private Realm _realm;

    // Start is called before the first frame update
    void Start()
    {

        // retrieve the panels:
        panel_notification_success = transform.Find("panel_notification_success").gameObject;
        panel_notification_fail = transform.Find("panel_notification_fail").gameObject;

        // retrieve the buttons:
        btn_login = transform.Find("btn_login").GetComponent<Button>();
        btn_back = transform.Find("btn_back").GetComponent<Button>();
        btn_Logout = transform.Find("btn_Logout").GetComponent<Button>();
        btn_register_transfer = transform.Find("btn_register_transfer").GetComponent<Button>();
        btn_OK_fail = panel_notification_fail.transform.Find("btn_OK").GetComponent<Button>();
        btn_OK_success = panel_notification_success.transform.Find("btn_OK").GetComponent<Button>();
        


        // add listener and events:
        btn_login.onClick.AddListener(LoginEvent);
        btn_back.onClick.AddListener(BackEvent);
        btn_Logout.onClick.AddListener(LogoutEvent);
        btn_register_transfer.onClick.AddListener(RegisterTransferEvent);
        btn_OK_success.onClick.AddListener(OKEvent_Success);
        btn_OK_fail.onClick.AddListener(OKEvent_Fail);
    }

    private async void LoginEvent()
    {
        // What do you want to do when you click the login button?
        var userName = transform.Find("vertical_layout").Find("Input_userName").Find("Text").GetComponent<Text>().text;
        var password = transform.Find("vertical_layout").Find("Input_password").Find("Text").GetComponent<Text>().text;
        var payload = new
        {
            name = userName,
            password = password
        };

        realmApp = App.Create(new AppConfiguration("descandants-upzrf")
        {
            MetadataPersistenceMode = MetadataPersistenceMode.NotEncrypted
        });
        var currentUser = realmApp.CurrentUser;

        try
        {
            if (currentUser == null)
            {
                currentUser = await realmApp.LogInAsync(Credentials.Function(payload));
                //_realm = await Realm.GetInstanceAsync(new PartitionSyncConfiguration("Pid", currentUser));
            }
            else
                _realm = Realm.GetInstance(new PartitionSyncConfiguration("Pid", currentUser));
        }
        catch
        {
            //if error catched, login failed
            Debug.Log("Login failed, invaild Credential");
            // pop out the "login fail" panel
            panel_notification_fail.SetActive(true);
        }

        // pop out the "login success" panel
        if(panel_notification_fail.activeSelf == false)
        {
            panel_notification_success.SetActive(true);
        }
    }

    private async void LogoutEvent()
    {
        await realmApp.CurrentUser.LogOutAsync();
        _realm.Dispose();
    }
    private void RegisterTransferEvent()
    {
        // transfer to register page:
        panel_register = transform.parent.Find("panel_register").gameObject;
        panel_register.SetActive(true);
        gameObject.SetActive(false);
    }

    private void BackEvent()
    {
        // transfer back to start page:
        panel_start = transform.parent.Find("panel_start").gameObject;
        panel_start.SetActive(true);
        gameObject.SetActive(false);
    }

    private async void OnApplicationQuit()
    {
        await realmApp.CurrentUser.LogOutAsync();
        _realm.Dispose();
    }

    private void OKEvent_Success()
    {
        panel_notification_success.SetActive(false);
    }
    private void OKEvent_Fail()
    {
        panel_notification_fail.SetActive(false);
    }

}
