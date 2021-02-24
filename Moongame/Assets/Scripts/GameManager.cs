using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [Header("General stuff")]
    public GameObject canvas;
    public GameObject events;

    [Header("Buttons")]
    public GameObject startButton;
    public GameObject attrButton;
    public GameObject howButton;
    public GameObject backButton;

    [Header("UI stuff")]
    public GameObject backgroundImage;
    public GameObject titleText;
    public GameObject attributions;
    public GameObject how;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            DontDestroyOnLoad(canvas);
            DontDestroyOnLoad(events);
        }
    }

    public void startGame()
    {
        startButton.SetActive(false);
        titleText.SetActive(false);
        attrButton.SetActive(false);
        howButton.SetActive(false);
        backButton.SetActive(false);
        StartCoroutine(LoadYourAsyncScene("MainGame"));
    }

    public void howToPlay()
    {
        startButton.SetActive(false);
        titleText.SetActive(false);
        howButton.SetActive(false);
        attrButton.SetActive(false);
        how.SetActive(true);

    }

    public void attribute()
    {
        startButton.SetActive(false);
        titleText.SetActive(false);
        howButton.SetActive(false);
        attrButton.SetActive(false);
        attributions.SetActive(true);
    }

    public void back()
    {
        startButton.SetActive(true);
        titleText.SetActive(true);
        howButton.SetActive(true);
        attrButton.SetActive(true);
        attributions.SetActive(false);
        how.SetActive(false);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator ColorLerp (Color endValue, float duration)
    {
        float time = 0;
        Image sprite = backgroundImage.GetComponent<Image>();
        Color startValue = sprite.color;

        while(time < duration)
        {
            sprite.color = Color.Lerp(startValue, endValue, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        sprite.color = endValue;
    }

    IEnumerator LoadYourAsyncScene(string scene)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(scene);

        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        StartCoroutine(ColorLerp(new Color(0, 0, 0, 0), 2));
    }
}
