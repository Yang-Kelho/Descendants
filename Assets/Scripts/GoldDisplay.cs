using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoldDisplay : MonoBehaviour
{
    [SerializeField] private Sprite goldSprite;
    public static GoldSystem goldSystem;

    void Awake()
    {
        GameObject goldIcon = new GameObject("Gold", typeof(Image));
        goldIcon.transform.SetParent(transform);
        goldIcon.transform.localPosition = Vector3.zero;

        goldIcon.GetComponent<RectTransform>().anchoredPosition = new Vector2(-30, 0);
        goldIcon.GetComponent<RectTransform>().sizeDelta = new Vector2(32, 32);
        goldIcon.GetComponent<Image>().sprite = goldSprite;
        GetComponent<Text>().text = "0";
    }

    private void Start()
    {
        goldSystem = GetComponent<GoldSystem>();
        goldSystem.OnGoldUpdated += GoldSystem_OnGoldUpdated;
        UpdateGoldDisplay();
    }

    private void GoldSystem_OnGoldUpdated(object sender, EventArgs e)
    {
        UpdateGoldDisplay();
    }

    private void UpdateGoldDisplay()
    {
        this.GetComponent<Text>().text = "" + goldSystem.GetCurrentGold();
    }
}
