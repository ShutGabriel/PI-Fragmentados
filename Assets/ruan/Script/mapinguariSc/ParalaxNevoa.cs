using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParalaxNevoa : MonoBehaviour
{
    public Vector2 scrollSpeed;

    // O comprimento do sprite para fazer o loop
    public float spriteWidth;

    private void Start()
    {
        // Obtém o tamanho do sprite para saber quando ele saiu da tela
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        spriteWidth = spriteRenderer.bounds.size.x;
    }

    private void Update()
    {
        // Move o objeto com base na velocidade definida
        Vector2 offset = scrollSpeed * Time.deltaTime;
        transform.position = new Vector3(transform.position.x + offset.x, transform.position.y + offset.y, transform.position.z);

        // Verifica se o objeto saiu da tela (para a esquerda) e o reposiciona
        if (transform.position.x < -spriteWidth)
        {
            Reposition();
        }
    }

    private void Reposition()
    {
        // Reposiciona o objeto no início, criando um loop
        transform.position = new Vector3(transform.position.x + 2 * spriteWidth, transform.position.y, transform.position.z);
    }
}
