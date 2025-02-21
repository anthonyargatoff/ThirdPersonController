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
  private int jumpStatus = 0;
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
    if (jumpStatus >= 2)
    {
      return;
    }
    rb.AddForce(new Vector3(0, jumpHeight, 0));
    jumpStatus += 1;
  }

  void Update()
  {
    transform.forward = freeLookCamera.transform.forward;
    transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);
  }

  void OnCollisionEnter(Collision collision)
  {
    if (collision.gameObject.CompareTag("Ground"))
    {
      Debug.Log("Collision with ground");
      jumpStatus = 0;
    }
  }
}
