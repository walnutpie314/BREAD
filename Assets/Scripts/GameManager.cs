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
        //player.gameObject.SetActive(true); //�÷��̾� Ȱ��ȭ
        //Resume();

        //SceneManager.LoadScene(1);
    }


    //���� �ɼ�â ����
    public void OpenOptionWindow()
    {
        gameOption.SetActive(true);
        Time.timeScale = 0f;
        gState = GameState.Pause;
    }

    //����ϱ�
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

    //�ٽ��ϱ�
    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(1); //���Ӿ� �ҷ���
    }

    //�����ϱ�
    public void QuitGame()
    {
        Application.Quit(); // �����ߵǴµ�..?
    }

    // Update is called once per frame
    void Update()
    {
        //�÷��̾ ��� ��ҿ� �����ϸ� ���� ǥ��
    }
}

