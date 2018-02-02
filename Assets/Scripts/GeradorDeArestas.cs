using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeradorDeArestas : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Camera cam = Camera.main; // retorna uma referencia da camera principal,ou com tag de Main

        EdgeCollider2D colisor = GetComponent<EdgeCollider2D>(); //pegar o componente EdgeColider do objeto ons o scrpit esta associado

        Vector2 pontoInferiorEsquerdo = cam.ScreenToWorldPoint(new Vector3(0,0,0));
        Vector2 pontoSuperiorEsquerdo = cam.ScreenToWorldPoint(new Vector3(0,Screen.height, 0));
        Vector2 pontoInferiorDireito = cam.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0));
        Vector2 pontoSuperiorDireiro = cam.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        colisor.points = new Vector2[5] { pontoInferiorEsquerdo,pontoSuperiorEsquerdo,pontoSuperiorDireiro,pontoInferiorDireito,pontoInferiorEsquerdo }; // necessario para ligar os pontos no colisor de forma dinamica independente d o tamanho da tela
      


    }

	
	// Update is called once per frame
	void Update () {
		
	}
}
