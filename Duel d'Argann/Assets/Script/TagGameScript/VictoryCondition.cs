using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryCondition : MonoBehaviour
{
    [SerializeField] Chrono _chrono;
    [SerializeField] GameObject _player1Tag;
    [SerializeField] GameObject _player2Tag;
    [SerializeField] Sprite _playerExplosion;
    [SerializeField] TMP_Text _playerWinText;
    void Update()
    {
        if (_chrono.Timer <= 0 && _player1Tag.activeInHierarchy)
        {
            Instantiate(_playerExplosion, _player1Tag.transform);
            Destroy(_player1Tag.transform.parent.gameObject);
            _playerWinText.text = "Player 2 Win !";
            StartCoroutine(ChangeSceneAfterWin());
        }
        else if (_chrono.Timer <= 0 && _player2Tag.activeInHierarchy)
        {
            Instantiate(_playerExplosion, _player2Tag.transform);
            Destroy(_player2Tag.transform.parent.gameObject);
            _playerWinText.text = "Player 1 Win !";
            StartCoroutine(ChangeSceneAfterWin());
        }

       
    }
    public IEnumerator ChangeSceneAfterWin()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("SampleScene");
    }
}
