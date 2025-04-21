using System.Collections.Generic;
using Unity.Services.CloudSave;
using UnityEngine;
using UnityEngine.Events;

public class RemoverAnuncios : MonoBehaviour
{
   private bool _removerAnucios;
   [SerializeField] private UnityEvent _OnRemoverAnuncios;

   public bool GetRemoverAnucios()
   {
        return _removerAnucios;
   }
   public async void SaveCloudData()
   {
        var data = new Dictionary<string, object> { { "no_ads", true } };
        await CloudSaveService.Instance.Data.Player.SaveAsync(data);
        _removerAnucios = true;

        _OnRemoverAnuncios.Invoke();
   }
    public async void LoadCloudData()
    {
        try
        {
            var dadosSalvos = await CloudSaveService.Instance.Data.Player.LoadAsync(new HashSet<string> { "no_ads" });
            _removerAnucios = dadosSalvos["no_ads"].Value.GetAs<bool>();
            if (_removerAnucios )
            {
                _OnRemoverAnuncios.Invoke();
            }
        }
        catch
        {

        }
    }
}
