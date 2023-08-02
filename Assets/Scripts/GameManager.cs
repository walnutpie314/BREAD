using UnityEditor;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header(" # Player Info")]
    public int playerid;
    [Header(" # Game Object")]
    public Player player;


    public static GameManager gm;

    public GameState gState;
    public GameObject gameOption;


    private void Awake()
    {
        if (gm == null)
        {
            gm = this;
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
        GameOver
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

    // Update is called once per frame
    void Update()
    {
        //플레이어가 어느 장소에 도착하면 승자 표시
    }
}

