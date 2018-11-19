using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonEvents : MonoBehaviour {

    [HideInInspector]public MenuAudio audio;

    private void Start()
    {
        audio = FindObjectOfType<MenuAudio>();
    }

    public void ShowPanel(RectTransform Panel)
    {
        audio.play(0);
        gameObject.transform.parent.gameObject.SetActive(false);
        Panel.gameObject.SetActive(true);

    }

    public void ClosePanel(){
        audio.play(0);
        gameObject.transform.parent.gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    public void LoadSceneByIndex(int sceneIndex)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(sceneIndex);
        audio.play(1);

    }

    public void leaveGame(){
        Time.timeScale = 1;
        audio.play(2);
        EditorApplication.isPlaying = false;
    }
}
