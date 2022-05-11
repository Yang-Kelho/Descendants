using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Realms;
using System.Linq;
using System.Threading.Tasks;
using Realms.Sync;

[CreateAssetMenu(fileName = "RealmController", menuName = "RCSO")]
public class RealmController : ScriptableObject
{
    public App realmApp;
    public Realm realm;
    public User user;
    public int logi;
    public int regi;
    public string userName = "anon";

    public async Task<int> RealmAppInit(string _userName, string _password)
    {
        try
        {
            var payload = new
            {
                name = _userName,
                password = _password
            };
            realmApp = App.Create(new AppConfiguration("descandants-upzrf"));

            user = realmApp.CurrentUser;
            if (user == null)
            {
                user = await realmApp.LogInAsync(Credentials.Function(payload));
                realm = await Realm.GetInstanceAsync(new PartitionSyncConfiguration("partition", user));
                logi = 1;
                userName = _userName;
            }
            else
                realm = Realm.GetInstance(new PartitionSyncConfiguration("partition", user));
        }
        catch
        {
            logi = 0;
        }

        return logi;
    }

    public async Task<int> Register(string _userName, string _password)
    {
        var payload = new
        {
            name = _userName,
            password = _password
        };
        realmApp = App.Create(new AppConfiguration("descandants-upzrf"));
        
        user = realmApp.CurrentUser;

        if (user == null)
        {
            user = await realmApp.LogInAsync(Credentials.Anonymous());
            realm = await Realm.GetInstanceAsync(new PartitionSyncConfiguration("partition", user));
            regi = await realmApp.CurrentUser.Functions.CallAsync<int>("Register", payload);

            if (regi == 1)
            {
                AddNewUser(_userName, _password);
            }

            LogOut();
        }
        else
        {
            regi = 0;
            LogOut();
        }
        return regi;
    }

    public async void LogOut()
    {
        logi = 0;
        regi = 0;
        userName = "anon";
        await user.LogOutAsync();
        realm.Dispose();
        realm = null;
        user = null;
    }

    public IOrderedQueryable<PlayerData> GetLeaderBoradData()
    {
        IOrderedQueryable<PlayerData> stats = realm.All<PlayerData>().OrderByDescending(p => p.highestScore);
        return stats;
    }

    public void OnApplicationQuit()
    {
        LogOut();
    }

    public long GetHighestScore()
    {
        if (realm != null)
        {
            var highestScore = realm.Find<PlayerData>(userName).highestScore;
            return highestScore;
        }
        else
            return 0;
    }

    public void UpdateHighestScore(long score)
    {
        if (realm != null)
        {
            realm.Write(() =>
            {
                realm.Find<PlayerData>(userName).highestScore = score;
            });
        }
    }

    private void AddNewUser(string name, string password)
    {
        realm.Write(() =>
        {
            var newPlayer = new PlayerData(name, password, 0);
            realm.Add(newPlayer);
        });
    }

    public string GetUserName()
    {
        if (userName == "anon")
            return "anonymous";
        else
            return userName;
    }
}
