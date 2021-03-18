using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GerandoInimigo2 : MonoBehaviour {

    public Transform InimigoPrefab;
    public Transform InimigoPrefab2;
    private float duracao1 = 15.0f;
    private float duracao2 = 5.0f;
    private Transform espaçonave_posicao, fase2_posicao;
    private bool posicaoJogador = false;

    void Start()
    {
        InvokeRepeating("Aleatorio", duracao1, duracao1);
       InvokeRepeating("Aleatorio2", duracao2, duracao2);
        espaçonave_posicao = GameObject.FindGameObjectWithTag("Espaconave").transform;
        fase2_posicao = GameObject.FindGameObjectWithTag("Fase2").transform;

    }

    private void Aleatorio()
    {
        posicaoJogador = !posicaoJogador;
        Vector2 posicaoAleatoria;

        if (posicaoJogador && espaçonave_posicao != null)
        {

            posicaoAleatoria = new Vector2(espaçonave_posicao.position.x, 3.53f);

        }
        else posicaoAleatoria = new Vector2(Random.Range(-5, 9), 3.53f);
        var posicaoInimigo = Instantiate(InimigoPrefab) as Transform;
        posicaoInimigo.position = posicaoAleatoria;
    }

    private void Aleatorio2()
       {
       Vector2 posicaoAleatoria;
     
          if (fase2_posicao != null)
          {

      posicaoAleatoria = new Vector2(fase2_posicao.position.x, fase2_posicao.position.y);
      var posicaoInimigo2 = Instantiate(InimigoPrefab2) as Transform;
      posicaoInimigo2.position = posicaoAleatoria;
     }

     }

}
