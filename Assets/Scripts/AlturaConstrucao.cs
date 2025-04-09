using UnityEngine;

public class AlturaConstrucao : MonoBehaviour
{
    public float AlturaAtual()
    {
        bool _alturaEncontrada = false;

        while (!_alturaEncontrada)
        {
            if(Physics.CheckBox(transform.position, new Vector3(15, 1, 15)))
            {
                transform.position += Vector3.up;
            }
            else
            {
                _alturaEncontrada = true;
            }
        }

        return transform.position.y;
    }
}
