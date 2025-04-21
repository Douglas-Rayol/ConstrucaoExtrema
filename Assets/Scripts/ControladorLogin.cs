using System.Threading.Tasks;
using TMPro;
using Unity.Services.Core;
using UnityEngine;


public class ControladorLogin : MonoBehaviour
{
    [SerializeField] private CloudServices _cloudServices;
    [SerializeField] private TMP_Text _usernameText;
    [SerializeField] private TMP_InputField _usernameInputField;
    [SerializeField] private TMP_Text _recordeText;
    [SerializeField] private RemoverAnuncios _removedorDeAnuncios;
    private async void Awake()
    {
        try
        {
            await UnityServices.InitializeAsync();
            await _cloudServices.SignUpAnonymouslyAsync();
            _removedorDeAnuncios.LoadCloudData();

            AtualizarUsernameUI();
            AtualizarRecordeUI();
        }
        catch (System.Exception e)
        {
            Debug.LogException(e);
        }
    }

    private void AtualizarUsernameUI()
    {
        string username = _cloudServices.GetUsername();
        _usernameText.text = username;
        _usernameInputField.text = username.Substring(0, username.IndexOf("#"));
    }

    public async void SalvarNovoUsername()
    {
        await _cloudServices.AtulazarUsername(_usernameInputField.text);
        AtualizarUsernameUI();
    }

    public async void AtualizarRecordeUI()
    {
        int recorde = await _cloudServices.GetPontuacaoJogador();
        _recordeText.text = "MEU RECORDE: " + recorde;
    }
}
