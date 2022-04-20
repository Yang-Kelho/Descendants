using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Realms;
using Realms.Sync;

public class RegisterPanelCtrl : MonoBehaviour
{
    GameObject panel_login;
    Button btn_register;
    Button btn_back;
    private Realm _realm;

    // Start is called before the first frame update
    void Start()
    {
        _realm = Realm.GetInstance();
        btn_register = transform.Find("btn_back").GetComponent<Button>();
        btn_back = transform.Find("btn_back").GetComponent<Button>();

        //add listener and events:
        btn_register.onClick.AddListener(RegisterEvent);
        btn_back.onClick.AddListener(BackEvent);

    }

    private void RegisterEvent()
    {
        // trigger when you click the register button:
        var userName = transform.Find("vertical_layout").Find("Input_userName").Find("Text").GetComponent<Text>().text;
        var password = transform.Find("vertical_layout").Find("Input_password").Find("Text").GetComponent<Text>().text;
        var realmApp = App.Create(new AppConfiguration("descendants-qsppj")
        {
            MetadataPersistenceMode = MetadataPersistenceMode.NotEncrypted
        });

        var currentUser = realmApp.CurrentUser;

        if (currentUser == null)
        {
           
        }

        BackEvent();
    }

    private void BackEvent()
    {
        panel_login = transform.parent.Find("panel_login").gameObject;
        panel_login.SetActive(true);
        gameObject.SetActive(false);
    }
}
