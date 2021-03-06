using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameClearCtrl : MonoBehaviour
{
    Text finalScore;
    Button btn_exit;
    public PlayerStats ps;
    public RealmController rc;
    public WeaponInventory inventory;
    // Start is called before the first frame update
    void Start()
    {

        // Exit button:
        btn_exit = this.transform.Find("btn_exit").GetComponent<Button>();
        btn_exit.onClick.AddListener(ExitEvent);

        // Score control:
        finalScore = this.transform.Find("txt_finalScore").GetComponent<Text>();
        finalScore.text = "Your score: " + ps.score;
        if (ps.score > rc.GetHighestScore())
        {
            rc.UpdateHighestScore(ps.score);
        }
    }
    private void ExitEvent()
    {
        inventory.Clear();
        ps.ReSet();
        // invoke the UI scene
        SceneManager.LoadScene(0); 
    }
}
