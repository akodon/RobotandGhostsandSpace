using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject waitPanel;
    public GameObject rulePanel;
    private bool waitswitch;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        

        if (waitPanel != null)
        {
            waitPanel.SetActive(false);
            waitswitch = false;
        }
        else if (waitPanel == null)
        {
            return;
        }

        if (rulePanel != null)
        {
            rulePanel.SetActive(false);
        }
        else if (rulePanel == null)
        {
            return;
        }
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            waitswitch = !waitswitch;

            if (waitswitch == true)
            {
                waitPanel.SetActive(true);
                Time.timeScale = 0;
            }
            else if (waitswitch == false)
            {
                waitPanel.SetActive(false);
                Time.timeScale = 1;
            }
            
        }
    }

    public void titleScene()
    {
        SceneManager.LoadScene("titleScene");
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GoalScene()
    {
        SceneManager.LoadScene("GoalScene");
    }


    public void EasyScene()
    {
        SceneManager.LoadScene("EasyScene");
    }

    public void NormalScene()
    {
        SceneManager.LoadScene("NormalScene");
    }

    public void HardScene()
    {
        SceneManager.LoadScene("HardScene");
    }

    public void closeGame()
    {
        #if UNITY_EDITOR    //エディターでの動作
        UnityEditor.EditorApplication.isPlaying = false;
        #else       //実際のゲーム終了
        Application.Quit();
        #endif
    }


}
