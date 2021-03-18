using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scoreponto : MonoBehaviour {

    public TextMesh potuaçao;
    private static int score;

     void Start()
    {
        score = 0;
    }
    void Update () {
        potuaçao.text ="Seus Pontos:" + score.ToString();
	}

    public int AddScore(int teste)
    {
        if (teste == 1)
        {
            score = score + 1;
        }
        return score;
    }
}
