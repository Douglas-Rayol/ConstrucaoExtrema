using TMPro;
using UnityEngine;

public class GerenciadorDepontuacao : MonoBehaviour
{
    [SerializeField] private TMP_Text _pontuacaoText;
    [SerializeField] private TMP_Text _pontuacaoGameOverText;
    [SerializeField] private CloudServices _cloudServices;
    private int _pontuacao;

    public void AdicionarPontuacao()
    {
        _pontuacao++;
        _pontuacaoText.text = _pontuacao.ToString();
        _pontuacaoGameOverText.text = "SCORE: " + _pontuacao;
    }

    public async void RegistrarPontuacao()
    {
        await _cloudServices.SalvarPontuacao(_pontuacao);
    }
}
