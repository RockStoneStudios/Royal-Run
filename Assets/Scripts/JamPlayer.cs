using UnityEngine;
using UnityEngine.InputSystem;

public class JamPlayer : MonoBehaviour
{
    Vector2 movement;
    Rigidbody rbPlayer;
    [SerializeField] float speed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rbPlayer = GetComponent<Rigidbody>();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        movement = context.ReadValue<Vector2>();

    }

    void FixedUpdate()
    {
        MovementPlayer();
    }


    private void MovementPlayer()
    {
        Vector3 currentPosition = rbPlayer.position;
        Vector3 targetPosition = new Vector3(movement.x, movement.y, 0f);
        Vector3 newPosition = currentPosition + targetPosition * (speed * Time.fixedDeltaTime);

        rbPlayer.MovePosition(newPosition);
    }




}
