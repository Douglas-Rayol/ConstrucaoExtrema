using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class GeradorDeCubo : MonoBehaviour
{
    [SerializeField] private GameObject _cuboPrefab;
    [SerializeField] private UnityEvent _OnSaltarCubo;
    private GameObject _ultimoCuboGerado;
    private AlturaConstrucao _alturaConstrucao;
    private Transform _myCamera;
    private Vector3 _entradasJogador;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _myCamera = Camera.main.transform;
        _alturaConstrucao = GetComponent<AlturaConstrucao>();
        GeraCubo();
    }

    // Update is called once per frame
    void Update()
    {
        if (_ultimoCuboGerado == null) return;

        Vector3 _direcaoCamera = _myCamera.TransformDirection(_entradasJogador);
        _direcaoCamera.y = 0;
        _ultimoCuboGerado.transform.position += _direcaoCamera.normalized * Time.deltaTime * 4;

    }

    private void GeraCubo()
    {
        _ultimoCuboGerado = Instantiate(_cuboPrefab, new Vector3(Random.Range(-3, 4), _alturaConstrucao.AlturaAtual() + 2, Random.Range(-3, 4)), Quaternion.identity);
        int _tamanhoX = Random.Range(1, 7);
        int _tamanhoY = Random.Range(1, 5);
        int _tamanhoZ = Random.Range(1, 7);

        _ultimoCuboGerado.transform.localScale = new Vector3(_tamanhoX, _tamanhoY, _tamanhoZ);
        _ultimoCuboGerado.GetComponent<MeshRenderer>().material.color = Random.ColorHSV();
    }

    public void SoltarCubo()
    {
        _ultimoCuboGerado.GetComponent<Rigidbody>().useGravity = true;
        _ultimoCuboGerado.transform.GetChild(0).gameObject.SetActive(false);

        _ultimoCuboGerado = null;
        _OnSaltarCubo.Invoke();

        Invoke(nameof(GeraCubo), 2);
    }

    public void MoverCubo(InputAction.CallbackContext value)
    {
        Vector2 _input = value.ReadValue<Vector2>();
        _entradasJogador = new Vector3(_input.x, 0, _input.y);
    }

    public void SoltarCubo(InputAction.CallbackContext value)
    {
        if(value.started)
        {
            SoltarCubo();
        }
    }
}
