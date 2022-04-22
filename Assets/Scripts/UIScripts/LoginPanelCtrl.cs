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
    Button btn_login;
    Button btn_back;
    Button btn_register_transfer;
    Button btn_Logout;
    App realmApp;
    private Realm _realm;

    // Start is called before the first frame update
    void Start()
    {
        // retrieve the buttons:
        btn_login = transform.Find("btn_login").GetComponent<Button>();
        btn_back = transform.Find("btn_back").GetComponent<Button>();
        btn_Logout = transform.Find("btn_Logout").GetComponent<Button>();
        btn_register_transfer = transform.Find("btn_register_transfer").GetComponent<Button>();

        // add listener and events:
        btn_login.onClick.AddListener(LoginEvent);
        btn_back.onClick.AddListener(BackEvent);
        btn_Logout.onClick.AddListener(LogoutEvent);
        btn_register_transfer.onClick.AddListener(RegisterTransferEvent);
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

        realmApp = App.Create(new AppConfiguration("descendants-qsppj")
        {
            MetadataPersistenceMode = MetadataPersistenceMode.NotEncrypted
        });
        var currentUser = realmApp.CurrentUser;

        try
        {
            if (currentUser == null)
            {
                currentUser = await realmApp.LogInAsync(Credentials.Function(payload));
                Debug.Log(currentUser);
                _realm = await Realm.GetInstanceAsync(new PartitionSyncConfiguration("PlayerID", currentUser));
            }
            else
                _realm = Realm.GetInstance(new PartitionSyncConfiguration("PlayerID", currentUser));
        }
        catch
        {
            //if error catched, login failed
            Debug.Log("Login failed, invaild Credential");
        }
    }

    private async void LogoutEvent()
    {
        var currentUser = realmApp.CurrentUser;
        if (currentUser != null)
        {
            await realmApp.CurrentUser.LogOutAsync();
        }
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
        var currentUser = realmApp.CurrentUser;
        if (currentUser != null)
        {
            await realmApp.CurrentUser.LogOutAsync();
        }
        _realm.Dispose();
    }

}
