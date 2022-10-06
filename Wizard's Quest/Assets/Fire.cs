using UnityEngine;

public class Fire : MonoBehaviour
{

    public GameObject projectile;
    public float projectileSpeed;
    public float projectileRange;
    public float startTimeBetweenShots;
    public float timeBetweenShots;


    public static Camera mainCamera;

    // Use this for initialization

    void Start()
    {
        timeBetweenShots = 0;
    }

    // Update is called once per frame

    void Update()
    {

       if (Input.GetMouseButtonDown(0) && timeBetweenShots <= 0)
        {
            timeBetweenShots = startTimeBetweenShots;
            timeBetweenShots -= Time.deltaTime;
            FireSelectedProjectile();
        }
        if (timeBetweenShots > 0) {
            timeBetweenShots -= Time.deltaTime;
        }

    }


   void FireSelectedProjectile()
    {

        //Fire the selected projectile
        GameObject projectile_instance = Instantiate(projectile, transform.position, transform.rotation);
        //Add velocity to the projectile
        Rigidbody2D rb = projectile_instance.GetComponent<Rigidbody2D>();

        Vector3 mousePos = GetMouseWorldPosition();
        mousePos.z = transform.position.z;
        Vector2 mousePos2d = new Vector2(mousePos.x, mousePos.y);
        rb.velocity = mousePos2d * projectileSpeed;
        rb.velocity = transform.right * projectileSpeed;


        //deltatime add somewhere
        GameObject.Destroy(projectile_instance, projectileRange);
    }


    public static Vector3 GetMouseWorldPosition()
    {
        if (mainCamera == null) mainCamera = Camera.main; //check if mainCamera variable has been assigned

        Vector3 mouseScreenPosition = Input.mousePosition; //Input.mousePosition returns the screen position of the mouse

        // Clamp mouse position to screen size
        mouseScreenPosition.x = Mathf.Clamp(mouseScreenPosition.x, 0f, Screen.width); //will clamp mouse position between zero and screen width
        mouseScreenPosition.y = Mathf.Clamp(mouseScreenPosition.y, 0f, Screen.height); //will clamp mouse position between zero and screen height

        Vector3 worldPosition = mainCamera.ScreenToWorldPoint(mouseScreenPosition); //Convert screen position to world position ScreenToWorldPoint

        worldPosition.z = 0f; //Set z position to zero

        return worldPosition.normalized;

    }
}