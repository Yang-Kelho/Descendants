using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HistoryPanelCtrl : MonoBehaviour
{

    GameObject panel_main;
    Button btn_my_history;
    Button btn_leaderboard;
    Button btn_back;
    // Start is called before the first frame update
    void Start()
    {
        btn_my_history = transform.Find("horizontal_layout").Find("btn_my_history").GetComponent<Button>();
        btn_leaderboard = transform.Find("horizontal_layout").Find("btn_leaderboard").GetComponent<Button>();
        btn_back = transform.Find("btn_back").GetComponent<Button>();
        

        btn_my_history.onClick.AddListener(MyHistoryEvent);
        btn_leaderboard.onClick.AddListener(LeaderboardEvent);
        btn_back.onClick.AddListener(BackEvent);

        //trigger the my history content panel first (by default):

    }

    private void MyHistoryEvent()
    {
        // activate the scrow view that contains my historoy info:
    }

    private void LeaderboardEvent()
    {
        // activate the scroll view that contains leaderboard info:
    }

    private void BackEvent()
    {
        panel_main = transform.parent.Find("panel_main").gameObject;
        panel_main.SetActive(true);
        gameObject.SetActive(false);
    }

}
