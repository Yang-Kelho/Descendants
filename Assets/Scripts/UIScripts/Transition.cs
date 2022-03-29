using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Transition : MonoBehaviour
{

    public GameObject cover; // cover object
    private RawImage rawImage;
    public float floatColorChangeSpeed = 1f;
    private bool isSceneToClear = true;
    private bool isSceneToBlack = false;

    private static Transition instance = null;
    
    public static Transition Instance
    {
        get
        {
            if(instance == null)
            {
                instance = new Transition();
            }
            return instance;
        }
    }
    private Transition() { }
    private void Awake()
    {
        if (cover)
        {
            rawImage = cover.GetComponent<RawImage>();
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isSceneToClear)
        {
            SceneToClear();
        }else if (isSceneToBlack)
        {
            ScenetoBlack();
        }
    }

    private void FadeToClear()
    {
        rawImage.color = Color.Lerp(rawImage.color, Color.clear, floatColorChangeSpeed * Time.deltaTime);

    }

    private void FadeToBlack()
    {
        rawImage.color = Color.Lerp(rawImage.color, Color.black, floatColorChangeSpeed * Time.deltaTime);
    }

    private void SceneToClear()
    {
        FadeToClear();
        if(rawImage.color.a <= 0.5f)
        {
            rawImage.color = Color.clear;
            rawImage.enabled = false;
            isSceneToClear = false;
        }
    }

    private void ScenetoBlack()
    {
        rawImage.enabled = true;
        FadeToBlack();
        if(rawImage.color.a >= 0.95f)
        {
            rawImage.color = Color.black;
            isSceneToBlack = false;
        }
    }

    public void SetScenetoClear()
    {
        isSceneToClear = true;
        isSceneToBlack = false;
    }

    public void SetSceneToBlack()
    {
        isSceneToClear = false;
        isSceneToBlack = true;
    }
}
