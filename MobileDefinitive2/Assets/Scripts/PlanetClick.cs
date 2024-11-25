using UnityEngine;
using UnityEngine.UI;

public class PlanetClickHandler : MonoBehaviour
{
    public Text infoText;  // Referência à caixa de texto
    public GameObject panel;  // Referência ao painel
    private PlanetInfo currentPlanetInfo;  // Variável para armazenar o script do planeta clicado

    void Start()
    {
        panel.SetActive(false);  // Desativa o painel no começo
    }

    void Update()
    {
        // Verifica se o botão esquerdo do mouse foi pressionado
        if (Input.GetMouseButtonDown(0))
        {
            
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);  // Cria um raio a partir da posição do mouse

            if (Physics.Raycast(ray, out hit))
            {
                // Verifica se o objeto atingido é um planeta
                if (hit.transform.CompareTag("Planet"))
                {
                    // Acessa o script PlanetInfo do planeta clicado
                    currentPlanetInfo = hit.transform.GetComponent<PlanetInfo>();

                    // Exibe o texto informativo do planeta
                    if (currentPlanetInfo != null)
                    {
                        infoText.text = currentPlanetInfo.planetDescription;  // Atualiza com o texto do planeta
                    }

                    // Torna o painel visível
                    panel.SetActive(true);
                }
            }
            else
            {
                // Se o clique foi fora de qualquer planeta, desativa o painel
                panel.SetActive(false);

                // Limpa o texto (fazendo ele ficar em branco)
                infoText.text = "";
            }
        }
    }
}
