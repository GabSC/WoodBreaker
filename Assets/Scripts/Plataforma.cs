﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plataforma : MonoBehaviour {

     public float velocidadeDeMovimento;
    public float limiteDaTelaEmX;
	// Use this for initialization
	void Start () {

        limiteDaTelaEmX = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width,0,0)).x - GetComponent<SpriteRenderer>().bounds.extents.x; 
        // limite da tela(largura em x) - a metade da largura da plataforma,faz se isso para que a plataforma não fique com a metade fora da tela.

	}
	
	// Update is called once per frame
	void Update () {

        float direcaoHorizontalDoMouse = Input.GetAxis("Mouse X"); // -1 esquerda, 0 parado  e 1 direita
        GetComponent<Transform>().position += Vector3.right * direcaoHorizontalDoMouse * velocidadeDeMovimento * Time.deltaTime;
        // o time.deltatime é importante ,ele retorna o tempo que o u=ultimo frame levou para ser renderizado,assim baseado
        //em FPS de cada PC,devemos utilizar isso para que em PCs com alto FPS não execute muito rapido,e PCs com baixo FPS
        // não execute muito lento.

        float XAtual = transform.position.x;
        XAtual = Mathf.Clamp(XAtual,-limiteDaTelaEmX,limiteDaTelaEmX);
        transform.position = new Vector3(XAtual,transform.position.y,transform.position.z);

	}
}
