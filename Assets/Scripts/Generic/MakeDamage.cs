using UnityEngine;
using UnityEngine.Events;

public class MakeDamage : MonoBehaviour
{
    [SerializeField] private int _damagePower = 10;
    [SerializeField] private string _tagCompare = "Player";
    [SerializeField] private UnityEvent OnTrigger;
    private void OnTriggerEnter(Collider other) {

        if(other.CompareTag(_tagCompare)){
            Health health = other.GetComponent<Health>();
            if(health != null){
                health.ReceiveDamage(_damagePower);
                OnTrigger?.Invoke();
            }
        }
    }
}
