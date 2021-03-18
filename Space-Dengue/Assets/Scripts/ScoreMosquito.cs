using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreMosquito : MonoBehaviour
{

    public TextMesh pontuacaoMosquito;
    private static int pontosMosquito;
    int morte, consulta;
   // ScoreMosquito mosquito = new ScoreMosquito();

    void Start()
    {
        pontosMosquito = 0;
    }
    void Update()
    {
        
        pontuacaoMosquito.text = "Mosquitos Invasores:" + pontosMosquito.ToString();
        consulta = 2;//Verifica quantos mosquitos morreram
        morte = AddScoreMosquito(consulta);

        if (morte >= 10)
        {

            Destroy(gameObject);
        }
    }

   //Essa função é chamada quando um mosquito passa pela nave
    public int AddScoreMosquito(int teste)
    {
        if (teste == 1)
        {
            pontosMosquito = pontosMosquito + 1;
        }
        return pontosMosquito;
    }
}
