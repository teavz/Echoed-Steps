using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D body;
    private bool grounded;
    private void Awake() {
        body = GetComponent<Rigidbody2D>();
    }
    
    private void Update() {
        float horizontalInput = Input.GetAxis("Horizontal");
        body.linearVelocity = new Vector2(horizontalInput * speed, body.linearVelocity.y);
        
        
     
        //match player input with character orientation
        if (horizontalInput > 0.01f)
            transform.localScale = Vector3.one;
        else if (horizontalInput < -0.01f)
            transform.localScale = new Vector3(-1, 1, 1);
        
        if(Input.GetKey(KeyCode.Space) && grounded)
            Jump();
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
