using System.Security.Cryptography;
using UnityEngine;

public class ControladorJogador : MonoBehaviour
{
    public float taxaMovimentacao;
    public Geral juizDoJogo;

   

    // Update is called once per frame
    void Update()
    {
        float altX, altY;

        // Para cima e para baixo - mexe no Y
        if (Input.GetKey(KeyCode.UpArrow) && transform.position.y < 467.6)
            altY = 60 * Time.deltaTime * taxaMovimentacao;
        else if (Input.GetKey(KeyCode.DownArrow) && transform.position.y > 32.2)
            altY = -60 * Time.deltaTime * taxaMovimentacao;
        else
            altY = 0;

        // Para os lados
        if (Input.GetKey(KeyCode.LeftArrow) && transform.position.x > 31.9)
            altX = -60 * Time.deltaTime * taxaMovimentacao;
        else if (Input.GetKey(KeyCode.RightArrow) && transform.position.x < 927.8)
            altX = 60 * Time.deltaTime * taxaMovimentacao;
        else
            altX = 0;

        // Modificar posição:

        Vector3 novaPos = new Vector3(altX, altY, 0);
        transform.position += novaPos;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Voador")
        {
            // Marcando um ponto no placar
            juizDoJogo.MarcarPonto();

            // Volta o objeto para a posição horizontal original
            collision.GetComponent<ControladorVoador>().posicaoObj.x =
                collision.GetComponent<ControladorVoador>().posInicialX;

            // Atualizar a posição vertical do objeto
            float posicaoY = Random.value * 467;
            collision.GetComponent<ControladorVoador>().posicaoObj.y = posicaoY;

            // trocar a imagem do objeto a ser coletado
            collision.GetComponent<ControladorVoador>().MudarImagem();

        }
    }
}