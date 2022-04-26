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
        _realm = await Realm.GetInstanceAsync(new PartitionSyncConfiguration("Pid", currentUser));

        _realm.Write(() => 
        {
            var newPlayer = new PlayerData("Pid","555",0);
            _realm.Add(newPlayer);
            _realm.RemoveAll<PlayerData>();
        });


//        var sortedStats = _realm.Find<PlayerData>("test1");
//        Debug.Log(sortedStats.highestScore);        
//        foreach (var playerData in sortedStats)
//        {
//            Debug.Log("ID:" + playerData.playerId);
//            Debug.Log("Score:" + playerData.highestScore);
//        }

    }

    private void BackEvent()
    {
        panel_main = transform.parent.Find("panel_main").gameObject;
        panel_main.SetActive(true);
        gameObject.SetActive(false);
    }

}
