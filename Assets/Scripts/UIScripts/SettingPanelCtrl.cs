using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SettingPanelCtrl : MonoBehaviour
{
    GameObject panel_main;
    Button btn_back;
    // Start is called before the first frame update
    void Start()
    {
        btn_back = transform.Find("btn_back").GetComponent<Button>();
        btn_back.onClick.AddListener(BackEvent);
    }

    private void BackEvent()
    {
        panel_main = transform.parent.Find("panel_main").gameObject;
        panel_main.SetActive(true);
        gameObject.SetActive(false);
    }
}
