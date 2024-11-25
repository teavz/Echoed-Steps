using UnityEngine;

public class ShadowMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D body;
    private bool grounded;
    private void Awake() {
        body = GetComponent<Rigidbody2D>();
    }
    
    private void Update() {
        float horizontalInput = -Input.GetAxis("Horizontal");
        body.linearVelocity = new Vector2(horizontalInput * speed, body.linearVelocity.y);
        
        if(Input.GetKey(KeyCode.Space) && grounded)
            Jump();

    }
    private void OnTriggerResetLevel(Collider2D collision) {
        if (collision.CompareTag("Player"))
        {
            //reset level
            SceneController.instance.CurrentLevel();
        }
    }
    private void Jump() {
        body.linearVelocity = new Vector2(body.linearVelocity.x, speed * 3 / 2);
        grounded = false;
    }
    
     private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Ground")
            grounded = true;
    } 
}
