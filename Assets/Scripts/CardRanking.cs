using TMPro;
using UnityEngine;

public class CardRanking : MonoBehaviour
{
    [SerializeField] private TMP_Text _posicaoText;
    [SerializeField] private TMP_Text _usernameText;
    [SerializeField] private TMP_Text _pontuacaoText;

    public void IniciarCard(int posicao, string username, int pontuacao)
    {
        _posicaoText.text = posicao.ToString();
        _usernameText.text = username;
        _pontuacaoText.text = pontuacao.ToString();
    }
}
