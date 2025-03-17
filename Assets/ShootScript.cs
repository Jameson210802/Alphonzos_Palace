using UnityEngine;

public class ShootScript : MonoBehaviour
{
    public float fireRate = 0.2f;
    public Transform firingPoint;
    public GameObject bulletPrefab;
    private Animator animator;

    float timeUntilFire;
    Character_Physics playerMovement;

    private void Start()
    {
        playerMovement = gameObject.GetComponent<Character_Physics>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && timeUntilFire < Time.time)
        {
            
            Shoot();
            timeUntilFire = Time.time + fireRate;
        }
    }

    void Shoot()
    {
        Debug.Log("Triggering Attack Animation");
        animator.SetTrigger("player_attack");
        float angle = playerMovement.isFacingRight ? 0f : 180f;
        Instantiate(bulletPrefab, firingPoint.position, Quaternion.Euler(new Vector3(0f, 0f, angle)));
    }
}
