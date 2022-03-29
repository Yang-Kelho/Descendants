using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartPanelCtrl : MonoBehaviour
{
    Button btn_start;
    Button btn_login;
    GameObject panel_main;
    GameObject panel_login;
    // Start is called before the first frame update
    void Start()
    {
        btn_start = transform.Find("vertical_layout").Find("btn_start").GetComponent<Button>();
        btn_login = transform.Find("vertical_layout").Find("btn_login").GetComponent<Button>();
        btn_start.onClick.AddListener(StartEvent);
        btn_login.onClick.AddListener(LoginEvent);

    }
    // method that you want to call on the button:
    private void StartEvent()
    {
        panel_main = transform.parent.Find("panel_main").gameObject;
        gameObject.SetActive(false);
        panel_main.SetActive(true);
    }

    private void LoginEvent()
    {
        panel_login = transform.parent.Find("panel_login").gameObject;
        gameObject.SetActive(false);
        panel_login.SetActive(true);
    }
    
}
