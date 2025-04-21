
using System.Collections.Generic;
using UnityEngine;

public class ControladorRanking : MonoBehaviour
{
    [SerializeField] private CloudServices _cloudServices;
    [SerializeField] private CardRanking _cardRankingPrefab;
    [SerializeField] private Transform _rankingContent;

    public async void CarregarRanking()
    {
        foreach (Transform child in _rankingContent)
        {
            Destroy(child.gameObject);
        }

        List<JogadorRanking> jogadores = await _cloudServices.GetPontuacoes();

        foreach (JogadorRanking jogadorRanking in jogadores)
        {
            CardRanking card = Instantiate(_cardRankingPrefab, _rankingContent);
            card.IniciarCard(jogadorRanking._posicao + 1, jogadorRanking._username, jogadorRanking._pontuacao);
        }

    }
}
