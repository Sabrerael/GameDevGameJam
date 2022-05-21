using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour {
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float moveForce = 10f;
    [SerializeField] float jumpSpeed = 10f;

    private Vector2 velocity = new Vector2();
    private bool movementButton = false;
    private float xValue;

    private void FixedUpdate() {
        if (movementButton) {
            rb.AddRelativeForce(xValue * (Vector2.right * moveForce - rb.velocity));
        }
    }

    private void OnMove(InputValue value) {
        if (Mathf.Abs(value.Get<Vector2>().x) >= Mathf.Epsilon) {
            xValue = value.Get<Vector2>().x; 
            movementButton = true;
        } else {
            movementButton = false;
        }
    }

    private void OnJump(InputValue value) {
        if (value.isPressed) {
            rb.velocity = new Vector2(0, jumpSpeed);
        }
    }
}
