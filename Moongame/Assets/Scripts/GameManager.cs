using System.Collections;
using System.Collections.Generic;
using TMPro;
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
    public TextMeshProUGUI startButtonText;
    public TextMeshProUGUI titleText;
    public TextMeshProUGUI attributions;
    public TextMeshProUGUI how;
    public TextMeshProUGUI score;

    [Header("Hackey code stuff")]
    public string[] levelList;

    private float scoreNum;
    private float scoreMem;

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
        titleText.gameObject.SetActive(false);
        attrButton.SetActive(false);
        howButton.SetActive(false);
        backButton.SetActive(false);
        score.gameObject.SetActive(true);
        StartCoroutine(LoadYourAsyncScene("MainGame"));
        scoreMem = 0;
        scoreNum = 0;
    }

    public void howToPlay()
    {
        startButton.SetActive(false);
        titleText.gameObject.SetActive(false);
        howButton.SetActive(false);
        attrButton.SetActive(false);
        how.gameObject.SetActive(true);

    }

    public void attribute()
    {
        startButton.SetActive(false);
        titleText.gameObject.SetActive(false);
        howButton.SetActive(false);
        attrButton.SetActive(false);
        attributions.gameObject.SetActive(true);
    }

    public void back()
    {
        startButton.SetActive(true);
        titleText.gameObject.SetActive(true);
        howButton.SetActive(true);
        attrButton.SetActive(true);
        attributions.gameObject.SetActive(false);
        how.gameObject.SetActive(false);
    }

    public void increaseScore(Vector2 pos)
    {
        if (scoreMem < pos.y)
        {
            scoreMem = pos.y;
        }
        scoreNum += scoreMem;
        score.text = "Score: " + System.Math.Round((decimal)scoreNum, 3);
    }

    //can load previous or next level
    public void LoadNextLevel(int x)
    {
        //StartCoroutine(LoadYourAsyncScene(levelList[x]));
        SceneManager.LoadScene(x);
    }

    public void GameOver()
    {
        StopAllCoroutines();
        startButton.SetActive(true);
        score.gameObject.SetActive(false);
        startButtonText.SetText("Try again?");
    }

    // Start is called before the first frame update
    void Start()
    {
        scoreNum = 0;
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
