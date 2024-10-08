using UnityEngine;

public class VictoryCondition : MonoBehaviour
{
    [SerializeField] Chrono _chrono;
    [SerializeField] GameObject _player1Tag;
    [SerializeField] GameObject _player2Tag;
    void Update()
    {
        if (_chrono.Timer <= 0 && _player1Tag.activeInHierarchy)
        {
            Destroy(_player1Tag.transform.parent.gameObject);
        }
        else if (_chrono.Timer <= 0 && _player2Tag.activeInHierarchy)
        {
            Destroy(_player2Tag.transform.parent.gameObject);
        }
    }
}
