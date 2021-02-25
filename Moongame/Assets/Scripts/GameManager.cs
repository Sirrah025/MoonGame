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
    public TextMeshProUGUI titleText;
    public TextMeshProUGUI attributions;
    public TextMeshProUGUI how;
    public TextMeshProUGUI score;

    private float scoreNum;

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
        if (scoreNum < pos.y)
        {
            scoreNum = pos.y;
            score.text = "Score: " + scoreNum;
        }
    }

    public void LoadNextLevel(int x)
    {
        SceneManager.LoadScene(x);
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
