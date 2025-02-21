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
    inputManager.OnSpacePressed.AddListener(Jump);
    rb = GetComponent<Rigidbody>();
  }

  private void MovePlayer(Vector2 direction)
  {
    Vector3 moveDirection = new(direction.x, 0f, direction.y);
    rb.AddRelativeForce(speed * moveDirection);
  }

  private void Jump()
  {
    rb.AddForce(new Vector3(0, jumpHeight, 0));
  }

  void Update()
  {
    transform.forward = freeLookCamera.transform.forward;
    transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);
  }
}
