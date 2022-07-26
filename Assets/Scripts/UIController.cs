using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private GameObject _loseScreen;
    [SerializeField] private GameObject _winScreen;

    public void ShowGameOverScreen(){
        if (GameManager.Instance.Winner){
            _winScreen.SetActive(true);
        }else {
            _loseScreen.SetActive(true);
        }
    }
}
