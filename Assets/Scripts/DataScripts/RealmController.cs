using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Realms;
using Realms.Sync;

public class RealmController
{
    public App realmApp;
    public Realm realm;
    public void RealmAppInit()
    {
        realmApp = App.Create(new AppConfiguration("descendants-qsppj")
        {
            MetadataPersistenceMode = MetadataPersistenceMode.NotEncrypted
        });
    }

}
