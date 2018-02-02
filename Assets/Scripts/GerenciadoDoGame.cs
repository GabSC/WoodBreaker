using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; // necessário para usar os objetos e classes para a inteface e imagens

public class GerenciadoDoGame : MonoBehaviour {


    public static int numeroDeBlocos;

    public static int numeroDeBlocosDestruidos;

    public Image estrelas;

    public  GameObject canvasGo;

    public Bola maca;

    public Plataforma plataforma;

    public static GerenciadoDoGame instancia;

    public void Awake()
    {
        instancia = this;
    }

    public void Start()
    {
        if(Application.loadedLevel == 1)
        {
            canvasGo.SetActive(false);
            numeroDeBlocosDestruidos = 0;

        }
        

    }

    public void Update()
    {
        estrelas.fillAmount = (float)numeroDeBlocosDestruidos / (float)numeroDeBlocos;
        
    }


    public void JogarNovamente(){

        SceneManager.LoadScene("Scene1");

    }

    public void AlterarCena(string cena)
    {

        SceneManager.LoadScene(cena);

    }

    public void FecharJogo()
    {

        Application.Quit();
    }

    public void FinalizarGame()
    {

       // Application.LoadLevel("scene1"); método obsoleto!

      //  SceneManager.LoadScene("scene1");
        canvasGo.SetActive(true); // setActive funciona em GameObjects!
        estrelas.fillAmount = (float)numeroDeBlocosDestruidos / (float)numeroDeBlocos;
        plataforma.enabled = false; //enabled funciona em scripts!
        Destroy(maca.gameObject); //vai destuir o objeto a partido do script chamado 
    }
}
