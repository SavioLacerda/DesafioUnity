using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovMissil : MonoBehaviour {

    private Vector2 velocidade = new Vector2(0, 5);
    private Vector2 move,entrada;

    void Update()
    {
        entrada=new Vector2(0, 1);
        move = new Vector2(entrada.x = velocidade.x, entrada.y = velocidade.y);

    }

    void FixedUpdate()
    {
        GetComponent<Rigidbody2D>().velocity = move;
    }
}
