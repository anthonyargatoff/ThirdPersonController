using Unity.Cinemachine;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
  [SerializeField] private InputManager inputManager;
  [SerializeField] private float speed;
  [SerializeField] private float jumpHeight;
  [SerializeField] private float dashSpeed;
  private Rigidbody rb;
  [SerializeField] private CinemachineCamera freeLookCamera;
  void Start()
  {
    inputManager.OnMove.AddListener(MovePlayer);
    rb = GetComponent<Rigidbody>();
  }

  private void MovePlayer(Vector2 direction)
  {
    Vector3 moveDirection = new(direction.x, 0f, direction.y);
    rb.AddRelativeForce(speed * moveDirection);
  }

  void Update()
  {
    transform.forward = freeLookCamera.transform.forward;
    transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);
  }
}
