using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    public PlayerStats stats;
    public static HealthSystem HealthSystemStatic;
    [SerializeField] private Sprite fullHeartSprite;
    [SerializeField] private Sprite halfHeartSprite;
    [SerializeField] private Sprite emptyHeartSprite;

    private List<HeartImage> heartImageList;
    private HealthSystem healthSystem;

    private void Awake()
    {
        heartImageList = new List<HeartImage>();
    }
    private void Start()
    {
        HealthSystem healthSystem = new HealthSystem(3, stats);
        setHealthSystem(healthSystem);
        HealthSystemStatic = healthSystem;
    }

    public void setHealthSystem(HealthSystem healthSystem)
    {
        this.healthSystem = healthSystem;
        List<HealthSystem.Heart> heartList = healthSystem.GetHeartList();
        Vector2 heartAnchoredPosition = new Vector2(0, -64);

        for (int i = 0; i < heartList.Count; i++)
        {
            HealthSystem.Heart heart = heartList[i];
            CreateHeart(heartAnchoredPosition).SetHeartFragments(heart.GetFragmentNumber());
            heartAnchoredPosition.x += 32;
        }
        healthSystem.OnDamaged += HealthSystem_OnDamaged;
        healthSystem.OnHealed += HealthSystem_OnHealed;

    }

    private void HealthSystem_OnHealed(object sender, EventArgs e)
    {
        RefreshHealthDisplay();
    }

    private void HealthSystem_OnDamaged(object sender, EventArgs e)
    {
        RefreshHealthDisplay();
    }

    private void RefreshHealthDisplay()
    {
        List<HealthSystem.Heart> heartList = healthSystem.GetHeartList();
        for (int i = 0; i < heartList.Count; i++)
        {
            HeartImage heartImage = heartImageList[i];
            HealthSystem.Heart heart = heartList[i];
            heartImage.SetHeartFragments(heart.GetFragmentNumber());
        }
    }

    private HeartImage CreateHeart(Vector2 anchoredPosition)
    {
        GameObject heartObject = new GameObject("Heart", typeof(Image));
        heartObject.transform.SetParent(transform);
        heartObject.transform.localPosition = Vector3.zero;

        heartObject.GetComponent<RectTransform>().anchoredPosition = anchoredPosition;
        heartObject.GetComponent<RectTransform>().sizeDelta = new Vector2(32,32);

        Image heartImageUI = heartObject.GetComponent<Image>();
        heartImageUI.sprite = fullHeartSprite;

        HeartImage heartImage = new HeartImage(this, heartImageUI);
        heartImageList.Add(heartImage);
        return heartImage;
    }

    public class HeartImage
    {
        private Image heartImage;
        private HealthDisplay healthDisplay;
        public HeartImage(HealthDisplay healthDisplay, Image heartImage)
        {
            this.heartImage = heartImage;
            this.healthDisplay = healthDisplay;
        }

        public void SetHeartFragments(int fragments)
        {
            switch (fragments){
                case 0: heartImage.sprite = healthDisplay.emptyHeartSprite; break;
                case 1: heartImage.sprite = healthDisplay.halfHeartSprite; break;
                case 2: heartImage.sprite = healthDisplay.fullHeartSprite; break;
            }
        }
    }
}
