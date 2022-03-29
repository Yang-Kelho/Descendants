using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RegisterPanelCtrl : MonoBehaviour
{
    GameObject panel_login;
    Button btn_register;
    Button btn_back;

    // Start is called before the first frame update
    void Start()
    {
        btn_register = transform.Find("btn_back").GetComponent<Button>();
        btn_back = transform.Find("btn_back").GetComponent<Button>();

        //add listener and events:
        btn_register.onClick.AddListener(RegisterEvent);
        btn_back.onClick.AddListener(BackEvent);

    }

    private void RegisterEvent()
    {
        // trigger when you click the register button:
    }

    private void BackEvent()
    {
        panel_login = transform.parent.Find("panel_login").gameObject;
        panel_login.SetActive(true);
        gameObject.SetActive(false);
    }
}
