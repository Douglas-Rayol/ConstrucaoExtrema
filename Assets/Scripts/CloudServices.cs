using System.Threading.Tasks;
using Unity.Services.Authentication;
using Unity.Services.Leaderboards;
using Unity.Services.Core;
using UnityEngine;
using Unity.Services.Leaderboards.Models;
using System.Collections.Generic;
public class CloudServices : MonoBehaviour
{
   [SerializeField] private GameObject _erroLoginPopup;

   public async Task SignUpAnonymouslyAsync()
   {
        if(AuthenticationService.Instance.IsSignedIn) return;

        try
        {
            await AuthenticationService.Instance.SignInAnonymouslyAsync();

            if(AuthenticationService.Instance.PlayerName == "" || AuthenticationService.Instance.PlayerName == null)
            {
                await AtulazarUsername("Player");
                Debug.Log(AuthenticationService.Instance.PlayerName);
            }
            Debug.Log("Sign in anonymously succeeded!");

            // Shows how to get the playerID
            Debug.Log($"PlayerID: {AuthenticationService.Instance.PlayerId}");

        }
        catch
        {
            _erroLoginPopup.SetActive(true);
        } 
   }

    public void TentarLoginNovamente()
    {
        _erroLoginPopup.SetActive(false);
        SignUpAnonymouslyAsync();
    }

    public async Task AtulazarUsername(string username)
    {
        await AuthenticationService.Instance.UpdatePlayerNameAsync(username);
    }

    public string GetUsername()
    {
        return AuthenticationService.Instance.PlayerName;
    }

    public async Task SalvarPontuacao(int pontuacao)
    {
        await LeaderboardsService.Instance.AddPlayerScoreAsync("pontuacoes", pontuacao);
    }

    public async Task<List<JogadorRanking>> GetPontuacoes()
    {
        var scoresResponse = await LeaderboardsService.Instance.GetScoresAsync("pontuacoes");

        List<JogadorRanking> jogadoresRanking = new List<JogadorRanking>();

        foreach (LeaderboardEntry entry in scoresResponse.Results)
        {
            JogadorRanking jogador = new JogadorRanking();
            jogador._posicao = entry.Rank;
            jogador._username = entry.PlayerName;
            jogador._pontuacao = (int) entry.Score;

            jogadoresRanking.Add(jogador);
        }

        return jogadoresRanking;
    }

    public async Task<int> GetPontuacaoJogador()
    {
        try
        {
            var result = await LeaderboardsService.Instance.GetPlayerScoreAsync("pontuacoes");
            return (int)result.Score;
        }
        catch
        {
            return 0;
        }
    }
}
