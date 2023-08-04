using UnityEditor;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UnityEditor.ShaderGraph.Internal.KeywordDependentCollection;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header(" # Player Info")]
    public int playerid;
    [Header(" # Game Object")]
    public Player player;
    
    public GameState gState;
    public GameObject gameOption;

    //게임오버 관련
    public bool isGameover = false;
    public GameObject gameoverUI;

    //[System.Serializable]
    //public struct GameOverMenu
    //{
    //    public GameObject Button;
    //}
    //public GameOverMenu gameOverMenu;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);

        //cvs = FindFirstObjectByType<Canvas>();
    }

    void Update()
    {
        //게임오버상태에서 버튼 클릭시 
        if(isGameover && Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene(2);//캐릭터선택창으로 돌아감
        }
    }

    public class Player
    {
        internal object gameObject;
    }

    public enum GameState
    {
        Run,
        Pause,
        //GameOver
    }

    public void GameStart(int id)
    {
        playerid = id;
        gState = GameState.Run;

        gameObject.SetActive(true);
        //player.gameObject.SetActive(true); //플레이어 활성화
        //Resume();

        //SceneManager.LoadScene(1);
    }


    //게임 옵션창 열기
    public void OpenOptionWindow()
    {
        gameOption.SetActive(true);
        Time.timeScale = 0f;
        gState = GameState.Pause;
    }

    //계속하기
    public void CloseOptionWindow()
    {
        gameOption.SetActive(false);
        Time.timeScale = 1f;
        gState = GameState.Run;
    }

    //게임오버 코루틴
    //public void GameOver()
    //{
    //    StartCoroutine(GameOverRoutine());
    //}

    //private void StartCoroutine(IEnumerable enumerable)
    //{
    //    throw new NotImplementedException();
    //}

    //IEnumerable GameOverRoutine()
    //{
    //    gState = GameState.GameOver;
    //    yield return new WaitForSeconds(0.5f);
    //    Time.timeScale = 0f;

    //    Transform button = GetComponentInChildren<Transform>();
    //    button.gameObject.SetActive(true);
    //}

    //다시하기
    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(1); //게임씬 불러옴
    }

     //종료하기
     public void QuitGame()
    {
        Application.Quit(); // 꺼져야되는데..?
    }

    //플레이어 도착시 게임오버
    public void OnPlayerArrived()
    { 
        isGameover = true;
        Time.timeScale = 0f;
        //cvs = FindObjectOfType < Canvas > ();
        GameObject cvs = GameObject.Find("Canvas");
        Instantiate(gameoverUI, cvs.transform);
        
        //gameoverUI.SetActive(true);
        Debug.Log("야호");

        

    }


}

