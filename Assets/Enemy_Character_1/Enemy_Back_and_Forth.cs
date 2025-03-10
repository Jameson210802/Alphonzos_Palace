using UnityEngine;

public class Enemy_Back_and_Forth : MonoBehaviour
{
    public float movement_speed = 3.0f;
    public bool going_right = true;

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


        //CheckForWalls();
    }
}
