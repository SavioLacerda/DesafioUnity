using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lançamento2 : MonoBehaviour {
    public Transform tiroPrefab;
    private float tiroinicio;
    private float tiroduracao = 0.30f;

    void Start()
    {
        tiroinicio = 0;
    }

    void Update()
    {
        if (tiroinicio > 0)
        {
            tiroinicio = tiroinicio - Time.deltaTime;
        }
    }

    public void ataque()
    {
        if (tiroinicio <= 0)
        {
            tiroinicio = tiroduracao;
            var tirotransform = Instantiate(tiroPrefab) as Transform;
            tirotransform.position = transform.position;
        }

    }
}
