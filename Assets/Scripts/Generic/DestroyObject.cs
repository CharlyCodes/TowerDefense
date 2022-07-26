using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    [SerializeField] private float _destroyDelay = 0.1f;
    public void DestroyWithDelay(){
        Destroy(gameObject, _destroyDelay);
    }
}
