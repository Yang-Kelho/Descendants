using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Realms.Sync;
using Realms;

public class HistoryPanelCtrl : MonoBehaviour
{

    GameObject panel_main;
    Button btn_my_history;
    Button btn_leaderboard;
    Button btn_back;
    Font defaultFont;
    private Realm _realm;
    App realmApp;

    // Start is called before the first frame update
    void Start()
    {
        btn_my_history = transform.Find("horizontal_layout").Find("btn_my_history").GetComponent<Button>();
        btn_leaderboard = transform.Find("horizontal_layout").Find("btn_leaderboard").GetComponent<Button>();
        btn_back = transform.Find("btn_back").GetComponent<Button>();
        

        btn_my_history.onClick.AddListener(MyHistoryEvent);
        btn_leaderboard.onClick.AddListener(LeaderboardEvent);
        btn_back.onClick.AddListener(BackEvent);

        defaultFont = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;
        //trigger the my history content panel first (by default):

    }

    private void MyHistoryEvent()
    {
        // activate the scrow view that contains my historoy info:
    }

    private async void LeaderboardEvent()
    {
        
        realmApp = App.Create("descandants-upzrf");
        var currentUser = realmApp.CurrentUser;
        _realm = await Realm.GetInstanceAsync(new PartitionSyncConfiguration("partition", currentUser));

        var sortedStats = _realm.All<PlayerData>().OrderByDescending(p => p.highestScore);
        Debug.Log(sortedStats);

        // initialize parent object:
        GameObject contentPanel = this.transform.Find("Scroll View").Find("Viewport").Find("Content").gameObject;
        int index = 0;
        foreach (var playerData in sortedStats)
        {
            // create an game object
            GameObject go = new GameObject("record"+index);
            // add text component to it
            go.AddComponent<Text>();
            // modify the spec of the component
            go.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(400, 50);
            Text textComponent = go.transform.GetComponent<Text>();
            textComponent.text = "ID: " + playerData.playerId + "          "+"Score: " + playerData.highestScore;
            textComponent.GetComponent<Text>().font = defaultFont;
            textComponent.fontSize = 30;
            // set the location of the component
            go.transform.SetParent(contentPanel.transform, false);
            index++;

            // test debug:
            Debug.Log("ID:" + playerData.playerId);
            Debug.Log("Score:" + playerData.highestScore);
        }
    }

    private void BackEvent()
    {
        panel_main = transform.parent.Find("panel_main").gameObject;
        panel_main.SetActive(true);
        gameObject.SetActive(false);
    }

}
