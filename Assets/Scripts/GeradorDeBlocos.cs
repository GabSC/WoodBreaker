using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeradorDeBlocos : MonoBehaviour {

    public GameObject[] blocos;
    public int linhas;

	// Use this for initialization
	void Start () {
        CriarGrupoDeblocos();

	}

   void CriarGrupoDeblocos()
    {
        Bounds limitesDoBloco = blocos[0].GetComponent<SpriteRenderer>().bounds; //obtem o perímetro ou contorno do bloco,ou seja ,os limites desse bloco
        float larguraDoBloco = limitesDoBloco.size.x;
        float alturaDoBloco = limitesDoBloco.size.y;
        float larguraDaTela, alturaDaTela, multiplicadorDaLargura;
        int colunas = 0 ;
        GerenciadoDoGame.numeroDeBlocos = linhas * colunas;
        ColetarInfoDosBlocos(larguraDoBloco, out larguraDaTela, out alturaDaTela, out colunas, out multiplicadorDaLargura);
        for (int i = 0; i < linhas; i++)
        {

            for (int y = 0; y < colunas; y++)
            {


                GameObject blocoAleatorio = blocos[Random.Range(0,blocos.Length)];
                GameObject blocoInstanciado = (GameObject)Instantiate(blocoAleatorio);
                blocoInstanciado.transform.position = new Vector3(-(larguraDaTela /2)+(y * larguraDoBloco * multiplicadorDaLargura),(alturaDaTela /2) -(i * alturaDoBloco),0);
                float novaLarguraDoBloco = blocoInstanciado.transform.localScale.x * multiplicadorDaLargura;
                blocoInstanciado.transform.localScale = new Vector3(novaLarguraDoBloco,blocoInstanciado.transform.localScale.y,1);
            }


        }
    }


    void ColetarInfoDosBlocos(float larguraDoBloco, out float larguraDaTela, out float alturaDaTela, out int colunas,
        out float multiplicadorDaLargura)
    {

        Camera cam = Camera.main;

         larguraDaTela = (cam.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)) - cam.ScreenToWorldPoint(new Vector3(0,0,0))).x;
        //no codigo acima converte a largura da tela real(Screen) em largura no mundo Unity,
        alturaDaTela = (cam.ScreenToWorldPoint(new Vector3(0, Screen.height, 0)) - cam.ScreenToWorldPoint(new Vector3(0, 0, 0))).y;
        colunas = (int)(larguraDaTela/larguraDoBloco);
        multiplicadorDaLargura = larguraDaTela / (colunas * larguraDoBloco);
    }

}
