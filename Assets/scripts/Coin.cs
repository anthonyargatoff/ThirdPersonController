using UnityEngine;
using UnityEngine.Events;

public class Coin : MonoBehaviour
{

  public UnityEvent CollectCoin = new();
  [SerializeField] private float rotationSpeed = 500;

  void Update()
  {
    transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
  }

  void OnTriggerEnter(Collider other)
  {
    Debug.Log($"{gameObject.name} has been collected");
    CollectCoin?.Invoke();
    Destroy(gameObject);
  }
}
