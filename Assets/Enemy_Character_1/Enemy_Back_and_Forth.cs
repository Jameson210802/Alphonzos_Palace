using UnityEngine;

public class Enemy_Back_and_Forth : MonoBehaviour
{
    public float movement_speed = 3.0f;
    public bool going_right = true;
    public float mRaycastingDistance = 1f;

    private SpriteRenderer _mSpriteRenderer;

    void Start()
    {
        _mSpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        //_mSpriteRenderer.flipX = going_right; //need to check on later
    }

    void Update()
    {
        // if the ennemy is going right, get the vector pointing to its right
        Vector3 directionTranslation = (going_right) ? transform.right : -transform.right;
        directionTranslation *= Time.deltaTime * movement_speed;

        transform.Translate(directionTranslation);
        CheckForWalls();
    }


    private void CheckForWalls()
    {
        Vector3 raycastDirection = (going_right) ? Vector3.right : Vector3.left;

        // Wall detection raycast
        RaycastHit2D wallHit = Physics2D.Raycast(transform.position + raycastDirection * mRaycastingDistance - new Vector3(0f, 0.25f, 0f), raycastDirection, 0.075f);

        // Ledge detection raycast (cast downward slightly ahead of the enemy)
        Vector3 ledgeRaycastOrigin = transform.position + raycastDirection * mRaycastingDistance;
        RaycastHit2D ledgeHit = Physics2D.Raycast(ledgeRaycastOrigin, Vector2.down, 0.5f);

        // If a wall is hit or no ground is detected, turn around
        if (wallHit.collider != null && wallHit.transform.tag == "Terrain" || ledgeHit.collider == null)
        {
            going_right = !going_right;
            _mSpriteRenderer.flipX = !going_right;
        }
    }


}

