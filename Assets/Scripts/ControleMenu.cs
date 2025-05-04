using UnityEngine;
using UnityEngine.SceneManagement;

public class ControleMenu : MonoBehaviour
{
    public void Jogar()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }

    public void VoltarHome()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    public void AbrirRanking()
    {

    }

    public void RemoverAnuncios()
    {

    }
}
