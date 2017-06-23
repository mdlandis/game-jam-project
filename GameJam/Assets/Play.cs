using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Play : MonoBehaviour
{

    [SerializeField] private GameObject player;
    [SerializeField] private Text remainingEnemiesLabel;

    private float timer;
    public Text timerText;
    private bool GameEnd;
    public GameObject overlayWin;

    private bool timerStarted;

    // Use this for initialization
    void Start()
    {
        timer = 0;
        overlayWin.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0;
            overlayPause.SetActive(true);

            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene("StartLevel");
            }
        }*/


        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("StartLevel");
        }

        if (GameEnd)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                SceneManager.LoadScene("Title");
            }
        }

        if (timerStarted)
        {
            int ms = (int)(((float)(timer - (int)timer)) * 1000);
            int m = (int)timer / 60;
            int s = (int)(timer - m * 60);

            string timeString = m.ToString("D2") + ":" + s.ToString("D2") + ":" + ms.ToString("D3");

            timerText.text = timeString;

            timer += Time.deltaTime;
        }




        if (GameEnd)
        {
            overlayWin.SetActive(true);
        }

    }

    private void StartGame()
    {
        if (!GameEnd)
        {
            timerStarted = true;
        }

    }

    private void EndGame()
    {
        GameObject[] remainingEnemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (remainingEnemies.Length == 0)
        {
            GameEnd = true;
            timerStarted = false;
        }

    }
}