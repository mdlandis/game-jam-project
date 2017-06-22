using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Play : MonoBehaviour
{

    private float timer;
    public Text timerText;
    private bool GameEnd;
    public GameObject overlayWin;

    // Use this for initialization
    void Start()
    {

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

        


        if (GameEnd && Time.timeScale != 0) { return; }

        timer += Time.deltaTime;

        int ms = (int)(((float)(timer - (int)timer)) * 1000);
        int m = (int)timer / 60;
        int s = (int)(timer - m * 60);

        string timeString = m.ToString("D2") + ":" + s.ToString("D2") + ":" + ms.ToString("D3");

        timerText.text = timeString;

        if (GameEnd)
        {
            Time.timeScale = 0;

            overlayWin.SetActive(true);
        }

    }
}