using UnityEngine;
using UnityEngine.Events;

public class GamerOver : MonoBehaviour
{
    [SerializeField] private UnityEvent _OnGameOver;

    private void OnTriggerEnter(Collider other)
    {
        _OnGameOver.Invoke();
        Time.timeScale = 0;
    }
}
