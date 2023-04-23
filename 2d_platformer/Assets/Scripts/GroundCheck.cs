using UnityEngine;
public class GroundCheck : MonoBehaviour
{
    public float distanceToCheck = 0.5f;
    public bool isGrounded;
    [SerializeField] private LayerMask groundLayer;

    private void Update()
    {
        RaycastHit2D raycastHit2D = Physics2D.Raycast(transform.position, Vector2.down, distanceToCheck, groundLayer);
        Color rayColor;
        if (raycastHit2D.collider != null)
        {
            rayColor = Color.green;
        }
        else
        {
            rayColor = Color.red;
        }
        Debug.DrawRay(transform.position, Vector2.down * distanceToCheck, rayColor);
        isGrounded = raycastHit2D.collider != null;
    }
}