using UnityEngine;

public class Coin : MonoBehaviour
{

  [SerializeField] private float rotationSpeed = 500;

  void Update()
  {
    transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
  }
}
