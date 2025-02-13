using UnityEngine;
using UnityEngine.UI;

public class ControladorVoador : MonoBehaviour
{
    public float deslocamentoObjeto; // Determinar a velocidade inicial do obj
    public float incrementoVelocidade; // Determinar o aumento da velocidade por segundo
    public Sprite[] imagensObjetos;

    internal int sentidoV; // Para qual "lado" o objeto vai na vertical.
    internal Vector3 posicaoObj;
    internal float deslocamentoAbs;
    internal int numImagemAtual = 0;

    public float posInicialX;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sentidoV = 1;
        posicaoObj = transform.position;
        posInicialX = transform.position.x;

        deslocamentoAbs = deslocamentoObjeto;
    }

    // Update is called once per frame
    void Update()
    {
        // Movimentação do objeto: Velocidade do deslocamento do objeto, vezes
        // sentido (vertical), vezes "Time.deltaTime", vezes velocidade
        posicaoObj.y += (deslocamentoAbs * sentidoV * Time.deltaTime);
        posicaoObj.x += deslocamentoAbs * Time.deltaTime;

        deslocamentoAbs += incrementoVelocidade * Time.deltaTime;
        
        transform.position = posicaoObj;

        //limitadores verticais
        if (transform.position.y > 467.6)
            sentidoV = -1;
        else if (transform.position.y < 32.2)
            sentidoV = 1;

      
    }

    public void MudarImagem()
    {
        numImagemAtual += 1;

        if (numImagemAtual == imagensObjetos.Length)
            numImagemAtual = 0;

        GetComponent<Image>().sprite = imagensObjetos[numImagemAtual];
    }

}
