using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lançamento : MonoBehaviour {

   public Transform tiroPrefab1;
    public Transform tiroPrefab2;
    private  float tiroinicio;
   private  float tiroduracao = 0.50f;

	void Start () {
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

            var tirotransform1 = Instantiate(tiroPrefab1) as Transform;
            tirotransform1.position = new Vector2 (transform.position.x - 0.3f, transform.position.y);
            var tirotransform2 = Instantiate(tiroPrefab2) as Transform;
            tirotransform2.position = new Vector2(transform.position.x + 0.3f, transform.position.y);
        }

    }





}
