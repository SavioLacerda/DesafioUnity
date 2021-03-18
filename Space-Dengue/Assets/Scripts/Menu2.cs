using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Menu2 : MonoBehaviour {

    private GUISkin newSkin;
    void Start()
    {
        
        newSkin = Resources.Load("Skin") as GUISkin;
    }
    void OnGUI()
    {
        const int largurabotao = 100;
        const int alturabotao = 80;
        GUI.skin = newSkin;
        if (GUI.Button(new Rect((Screen.width) / 2 - (largurabotao / 2), (9*Screen.height / 10) - (largurabotao / 2), largurabotao, alturabotao), "Voltar"))
        {
            SceneManager.LoadScene("Menu");
        }
        
    }
}
