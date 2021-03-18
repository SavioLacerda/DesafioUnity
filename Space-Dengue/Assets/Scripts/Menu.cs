using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Menu: MonoBehaviour {

    private GUISkin newSkin;
    public TextMesh potuaçaomax;

    void Start()
    {
        
        newSkin = Resources.Load("Skin") as GUISkin;
        potuaçaomax.text = PlayerPrefs.GetInt("record1").ToString();
        Time.timeScale = 1;
    }
    void OnGUI()
    {
        const int largurabotao = 100;
        const int largurabotao1 = 200;
        const int alturabotao = 100;
        GUI.skin = newSkin;
        if(GUI.Button(new Rect((Screen.width)/2 - (largurabotao/2), (4*Screen.height/8) - (largurabotao/2), largurabotao, alturabotao), "Start!"))
        {
            SceneManager.LoadScene("Fase1");

                }
        if (GUI.Button(new Rect((Screen.width) / 2 - (largurabotao1 / 2), (5 * Screen.height / 8) - (largurabotao / 2), largurabotao1, alturabotao), "Instruções"))
        {
            SceneManager.LoadScene("Instruçoes");

        }
        if (GUI.Button(new Rect((Screen.width) / 2 - (largurabotao / 2), (6 * Screen.height / 8) - (largurabotao / 2), largurabotao, alturabotao), "Sair"))
        {
            Application.Quit();

        }
    }
}
