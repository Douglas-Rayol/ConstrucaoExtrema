using TMPro;
using UnityEngine;

public class GerenciadorDepontuacao : MonoBehaviour
{
    [SerializeField] private TMP_Text _pontuacaoText;
    [SerializeField] private TMP_Text _pontuacaoGameOverText;
    private int _pontuacao;

    public void AdicionarPontuacao()
    {
        _pontuacao++;
        _pontuacaoText.text = _pontuacao.ToString();
        _pontuacaoGameOverText.text = "SCORE: " + _pontuacao;
    }
}
