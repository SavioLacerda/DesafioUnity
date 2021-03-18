using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameOver2 : MonoBehaviour {

    private GUISkin newSkin;
    void Start()
    {
        newSkin = Resources.Load("Skin") as GUISkin;
        Time.timeScale = 0;
        Camera.main.GetComponent<AudioSource>().Pause();
    }
    private void OnGUI()
    {
        const int largurabotao = 200;
        const int largurabotao1 = 300;
        const int alturabotao = 100;
        GUI.skin = newSkin;
        if (GUI.Button(new Rect((Screen.width) / 2 - (largurabotao / 2), (3 * Screen.height / 8) - (largurabotao / 2), largurabotao, alturabotao), "Menu"))
        {
            SceneManager.LoadScene("Menu");

        }

        if (GUI.Button(new Rect((Screen.width) / 2 - (largurabotao1 / 2), (5 * Screen.height / 8) - (largurabotao / 2), largurabotao1, alturabotao), "Tentar Novamente"))
        {
            SceneManager.LoadScene("Fase2");

        }
        if (GUI.Button(new Rect((Screen.width) / 2 - (largurabotao / 2), (7 * Screen.height / 8) - (largurabotao / 2), largurabotao, alturabotao), "Sair"))
        {
            Application.Quit();

        }
    }
}
