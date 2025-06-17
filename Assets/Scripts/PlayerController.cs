using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed = 8f;
    [SerializeField] float limitPosX = 5f;
    [SerializeField] float limitPosZ = 2f;
    Vector2 movement;
    Rigidbody rbPlayer;



    void Start()
    {
        rbPlayer = GetComponent<Rigidbody>();
    }

    public void Move(InputAction.CallbackContext context)
    {
        movement = context.ReadValue<Vector2>();
        Debug.Log(movement);
    }

    private void FixedUpdate()
    {
        // PosX
        Vector3 currentPosition = rbPlayer.position;
        Vector3 direction = new Vector3(movement.x, 0f, movement.y);

        Vector3 newPosition = currentPosition + direction * (speed * Time.fixedDeltaTime);
        newPosition.x = Mathf.Clamp(newPosition.x, -limitPosX, limitPosX);
        newPosition.z = Mathf.Clamp(newPosition.z, -limitPosZ, limitPosZ);

        rbPlayer.MovePosition(newPosition);

    }



}
