using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainPanelCtrl : MonoBehaviour
{
    public SaveLoad sl;
    GameObject panel_setting;
    GameObject panel_history;
    GameObject panel_start;
    Button btn_setting;
    Button btn_history;
    Button btn_back;
    Button btn_continue;
    // Start is called before the first frame update
    void Start()
    {
        btn_setting = transform.Find("Image").Find("btn_setting").GetComponent<Button>();
        btn_history = transform.Find("Image").Find("btn_history").GetComponent<Button>();
        btn_back = transform.Find("Image").Find("btn_back").GetComponent<Button>();
        btn_continue = transform.Find("Image").Find("btn_continue").GetComponent<Button>();

        btn_setting.onClick.AddListener(SettingEvent);
        btn_history.onClick.AddListener(HistoryEvent);
        btn_back.onClick.AddListener(BackEvent);
        btn_continue.onClick.AddListener(ContinueEvent);
    }

    private void SettingEvent()
    {
        panel_setting = transform.parent.Find("panel_setting").gameObject;
        panel_setting.SetActive(true);
        gameObject.SetActive(false);
    }
    private void ContinueEvent()
    {
        sl.Load();
    }

    private void HistoryEvent()
    {
        panel_history = transform.parent.Find("panel_history").gameObject;
        panel_history.SetActive(true);
        gameObject.SetActive(false);
    }

    private void BackEvent()
    {
        panel_start = transform.parent.Find("panel_start").gameObject;
        panel_start.SetActive(true);
        gameObject.SetActive(false);
    }
}
