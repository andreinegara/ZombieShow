using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public Animator animator;
    public int bulletSpeed;
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;
    private int bulletLifetime;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Fire()
    {
        GameObject bullet = Instantiate(bulletPrefab);
        //Physics.IgnoreCollision(bullet.GetComponent<Collider>(), bulletSpawnPoint.parent.GetComponent<Collider>());
        bullet.transform.position = bulletSpawnPoint.position;

        //records its rotation
        Vector3 rotation = bullet.transform.rotation.eulerAngles;

        //gives the bullet the players rotation in Y axis, maintaining the remaining
        bullet.transform.rotation = Quaternion.Euler(rotation.x, transform.rotation.y, rotation.z);

        bullet.GetComponent<Rigidbody>().AddForce(bulletSpawnPoint.forward * bulletSpeed, ForceMode.Impulse);

        StartCoroutine(DestroyBullet(bullet, 1));
        animator.SetBool("isShooting", false);

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.H))
        {
            animator.SetBool("isShooting", true);

            Invoke("Fire", 0.5f);
         
     
        }
    }

  

    //Method that destroys the bullet after the Lifetime has passed

    private  IEnumerator DestroyBullet(GameObject bullet, int delay)
    {
        yield return new WaitForSeconds(delay);

        Destroy(bullet);
    }
}
