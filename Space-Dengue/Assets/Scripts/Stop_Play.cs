using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stop_Play : MonoBehaviour {

    private bool esta_parado = false;
    public Texture2D pause;
    public Texture2D play;

        
    void OnGUI()
    {
        const int largurabotao = 70;
        const int alturabotao = 70;

       
        if (!esta_parado)
        {
            if (GUI.Button(new Rect(0, 0, largurabotao, alturabotao), pause))
            {
                Time.timeScale = 0;
                esta_parado = true;
                Camera.main.GetComponent<AudioSource>().Pause();
                
            }
        }
        else
        {
            if (GUI.Button(new Rect(0, 0, largurabotao, alturabotao), play))
            {
                Time.timeScale = 1;
                esta_parado = false;
                Camera.main.GetComponent<AudioSource>().UnPause();

            }

        }
              
        
    }
}
