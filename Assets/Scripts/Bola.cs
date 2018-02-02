using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bola : MonoBehaviour
{

    public Vector3 direcao;
    public float velocidade;
    public GameObject particulaBlocos;
    public ParticleSystem particulasFolhas;
    public LineRenderer guia;
    public int pontosDaGuia;
    // Use this for initialization
    void Start()
    {

        direcao.Normalize();

        guia.positionCount = pontosDaGuia; // ou trocar eplo obsoleto caso nãofuncione guia.setvertexcount
    }

    void AtualizarLineRenderer() // Vamos trabalhar com Raycast,que são raios que partem de um ponto par auma direção e caso encontre algum objeto 
        // no caminho ele irá retornar as informações desse objeto encontrado.
    {

        int pontoAtual = 1;
        Vector3 direcaoAtual = direcao;
        Vector3 ultimaPosicao = transform.position;
        guia.SetPosition(0, ultimaPosicao);

        while (pontoAtual < pontosDaGuia)
        {
            RaycastHit2D hit = Physics2D.Raycast(ultimaPosicao,direcaoAtual);
            ultimaPosicao = hit.point;
            guia.SetPosition(pontoAtual, ultimaPosicao);
            direcaoAtual = Vector3.Reflect(direcaoAtual, hit.normal);
            ultimaPosicao += direcaoAtual * 0.05F;
            pontoAtual++;

        }

       
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += direcao * velocidade * Time.deltaTime;
        AtualizarLineRenderer();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        bool colisaoInvalida = false;
        Vector2 normal = collision.contacts[0].normal;

        Plataforma plataforma = collision.transform.GetComponent<Plataforma>(); // aqui vai retornar uma referencia de plataforma onde a maçã colidiu
                                                                                // claro,se onde ela colidiu tiver ou for um componente chamado Plataforma

        GeradorDeArestas gda = collision.transform.GetComponent<GeradorDeArestas>(); // o mesmo aqui!

        if (plataforma != null) // se não for null significa que colidou com a plataforma
        {

            if (normal != Vector2.up) // ou seja ( se for diferente de (x 0 e y 1) seignifica que bateu em local proibido
            {
                colisaoInvalida = true;
                //game over

            }
            else
            {

                particulasFolhas.transform.position = plataforma.transform.position;
                particulasFolhas.Play();

            }


        }
        else if (gda != null)
        {

            if (normal == Vector2.up)
            {
                colisaoInvalida = true;
                //game over
            }

        }
        else // colidimos com um bloco
        {
            GerenciadoDoGame.numeroDeBlocosDestruidos++;
            colisaoInvalida = false;
            Bounds bordaColisor = collision.transform.GetComponent<SpriteRenderer>().bounds;
            Vector3 posicaoDeCriacao = new Vector3(collision.transform.position.x + bordaColisor.extents.x, collision.transform.position.y - bordaColisor.extents.y,collision.transform.position.z);
            GameObject particulas = (GameObject)Instantiate(particulaBlocos,posicaoDeCriacao,Quaternion.identity);

           
            ParticleSystem componenteParticulas = particulas.GetComponent<ParticleSystem>();
            Destroy(particulas,componenteParticulas.duration + componenteParticulas.startLifetime);
            Destroy(collision.gameObject); // o sefgundo param indica o tempo que vai destruir depos de x segs,o Desroy ,destroi o gameObject do jogo todo!
            
        }


        


        if (!colisaoInvalida)
        {

            direcao = Vector2.Reflect(direcao, normal);
            direcao.Normalize();
        }
        else{

            GerenciadoDoGame.instancia.FinalizarGame();
        }






    }
}
