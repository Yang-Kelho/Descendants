using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSaver : MonoBehaviour
{
    // Start is called before the first frame update
    public SaveLoad sl;

    public void Start()
    {
        sl.Save(); ;
    }

}
