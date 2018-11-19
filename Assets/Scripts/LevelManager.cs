using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour {

    public int level = 1;

    public Transform coins;
    [HideInInspector] public int maxCoins;
    [HideInInspector] public int pickedupCoins = 0;

    public Transform enemies;
    [HideInInspector] public int enemiesCount;
    [HideInInspector] public int killedEnemies = 0;

    [HideInInspector] public MenuAudio audio;

    public Player player;
    public int startAmmo = 0;
    public Vector2 playerCheckpoint;
    public int playerLifesLeft = 3;

    public RectTransform pausePanel;
    public RectTransform winPanel;
    public RectTransform lifesPanel;
    public Text winPanelCaption;
    public Text bulletText;
    public Text scoreText;
    public Text scorePauseText;
    public Text scoreWinText;


    void Start () {
        player.startAmmo = startAmmo;
        maxCoins = coins.childCount;
        playerCheckpoint = player.transform.position;
        audio = FindObjectOfType<MenuAudio>();
    }
	
	void Update () {
        if(Input.GetButtonDown("Stop")){
            if (Time.timeScale > 0){
                pausePanel.gameObject.SetActive(true);
                GamePaused();
            }
            else GameResume();
        }
	}

    void GamePaused(){
        scorePauseText.text = pickedupCoins.ToString() + " - " + maxCoins.ToString();
        Time.timeScale = 0;
    }

    void GameResume(){
        pausePanel.gameObject.SetActive(false);
        Time.timeScale = 1f;
    }

   public void CoinPickedUp(){
        pickedupCoins++;
        scoreText.text = pickedupCoins.ToString();
        audio.play(2);
    }

    public void EnemyKilled(){
        killedEnemies++;
    }

    public void OnPlayerDead(){
        if (player.transform.position != new Vector3(playerCheckpoint.x, playerCheckpoint.y, 0)){
            audio.play(5);
            player.transform.position = playerCheckpoint;
            playerLifesLeft--;
            lifesPanel.GetChild(playerLifesLeft).GetComponent<Image>().color = new Color32(0, 0, 0, 1);

            if (playerLifesLeft<=0){
                Time.timeScale = 0;
                winPanelCaption.text = "YOU DIED!";
                scoreWinText.text = pickedupCoins.ToString() + " - " + maxCoins.ToString();
                winPanel.gameObject.SetActive(true);
            }
        }
    }

    public void Win(){
        GamePaused();
        scoreWinText.text = pickedupCoins.ToString() + " - " + maxCoins.ToString();
        winPanel.gameObject.SetActive(true);
    }
}
