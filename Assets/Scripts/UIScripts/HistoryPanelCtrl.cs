using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using MongoDB.Bson;
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

    private void LeaderboardEvent()
    {
        realmApp = App.Create(new AppConfiguration("descandants-upzrf")
        {
            MetadataPersistenceMode = MetadataPersistenceMode.NotEncrypted
        });
        var currentUser = realmApp.CurrentUser;
        _realm = Realm.GetInstance(new PartitionSyncConfiguration("Password", currentUser));
        var sortedStats = _realm.All<PlayerData>();
        var test = sortedStats.First().ToString();

        Debug.Log(test);

        //            = new BsonArray
        //        {
        //            new BsonDocument("$group",
        //            new BsonDocument
        //                {
        //                    { "_id", "$_id" },
        //                    { "Score",
        //            new BsonDocument("$first", "$Score") }
        //                }),
        //            new BsonDocument("$sort",
        //           new BsonDocument("Score", -1))
        //        };

    }

    private void BackEvent()
    {
        panel_main = transform.parent.Find("panel_main").gameObject;
        panel_main.SetActive(true);
        gameObject.SetActive(false);
    }

}
