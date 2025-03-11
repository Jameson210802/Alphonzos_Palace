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
        _mSpriteRenderer.flipX = going_right;
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

        // Raycasting takes as parameters a Vector3 which is the point of origin, another Vector3 which gives the direction, and finally a float for the maximum distance of the raycast
        RaycastHit2D hit = Physics2D.Raycast(transform.position + raycastDirection * mRaycastingDistance - new Vector3(0f, 0.25f, 0f), raycastDirection, 0.075f);

        // if we hit something, check its tag and act accordingly
        if (hit.collider != null)
        {
            if (hit.transform.tag == "Terrain")
            {
                going_right = !going_right;
                _mSpriteRenderer.flipX = going_right;

            }
        }
    }
}

