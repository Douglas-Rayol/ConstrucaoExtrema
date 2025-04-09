using UnityEngine;

public class CuboColisao : MonoBehaviour
{
    [SerializeField] private AudioSource _colisaoAudio;
    private bool _primeiraColisao;

    private void OnCollisionEnter(Collision collision)
    {
        _colisaoAudio.PlayOneShot(_colisaoAudio.clip);

        if (!_primeiraColisao)
        {
            _primeiraColisao = true;
            Invoke(nameof(DesativarComponente), 5);
        }
    }

    private void DesativarComponente()
    {
        enabled = false;
    }
}
