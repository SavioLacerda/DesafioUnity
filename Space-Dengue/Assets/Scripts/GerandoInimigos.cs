using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GerandoInimigos : MonoBehaviour {
    public Transform InimigoPrefab;
    private float duracao = 1.0f;
    private Transform espaçonave_posicao;
    private bool posicaoJogador = false;
	
	void Start () {
        InvokeRepeating("Aleatorio", duracao, duracao);
        espaçonave_posicao = GameObject.FindGameObjectWithTag("Espaconave").transform;
       
	}
	
    private void Aleatorio()
    {
        posicaoJogador = !posicaoJogador;
        Vector2 posicaoAleatoria;

        if (posicaoJogador && espaçonave_posicao != null)
        {
            
                posicaoAleatoria = new Vector2(espaçonave_posicao.position.x, transform.position.y);
            
        }
        else posicaoAleatoria = new Vector2(Random.Range(-5, 9), transform.position.y);
        var posicaoInimigo = Instantiate(InimigoPrefab) as Transform;
        posicaoInimigo.position = posicaoAleatoria;
    }
	
	}
