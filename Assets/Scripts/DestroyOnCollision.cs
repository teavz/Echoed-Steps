using UnityEngine;

public class DestroyOnCollision : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision) {
        // Destroy both objects on collision
        if ((gameObject.CompareTag("Player") && collision.gameObject.CompareTag("Enemy")) || ((gameObject.CompareTag("Enemy") && collision.gameObject.CompareTag("Player")))) {
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }
}
