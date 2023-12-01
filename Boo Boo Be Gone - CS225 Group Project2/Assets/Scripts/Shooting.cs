using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    private Camera _camera;
    public Transform bulletSpawnPoint;

    Vector3 mouseDirection;

    public GameObject bulletPrefab;
    public float bulletSpeed = 10;

    private void Start()
    {
        _camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }
    private void Update()
    {
        mouseDirection = _camera.ScreenToWorldPoint(Input.mousePosition);

        Vector3 rotation = mouseDirection - transform.position;

        float rotationZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg; //Atan2 returns the principal value of the arc tangent of y/x, expressed in radians. Rad2Deg returns radians to degrees.

        transform.rotation = Quaternion.Euler(0, 0, rotationZ); //a rotation around "rotationz" around the z axis, not the x or y

        if (Input.GetMouseButtonDown(0)) //if player left clicks...
        {
            var bulletClone = Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity); //will spawn the bullet wherever the gun is pointing

            bulletClone.GetComponent<Rigidbody2D>().velocity = bulletSpawnPoint.right * bulletSpeed; //sends bullet flying
        }

        // I know this code isn't very clean, but I really wanted to keep my thought process haha

        //mouseDirection = Camera.main.WorldToScreenPoint(Input.mousePosition);
        //lookAngle = Mathf.Atan2(mouseDirection.y, mouseDirection.x) * Mathf.Rad2Deg;

        //mouseDirection = new Vector2(mouseDirection.x - transform.position.x, mouseDirection.y - transform.position.y);
        //bulletSpawnPoint.rotation = Quaternion.Euler(0, 0, lookAngle);

        //if (Input.GetMouseButtonDown(0))
        //{
        //    //var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        //    //bullet.GetComponent<Rigidbody2D>().velocity = bulletSpawnPoint.up * bulletSpeed;

        //    //OLD
        //    GameObject bullet = Instantiate(bulletPrefab);
        //    bullet.transform.position = bulletSpawnPoint.position;
        //    bullet.transform.rotation = Quaternion.Euler(0,0, lookAngle);

        //    //Velocity of bullet
        //    //OLD
        //    bullet.GetComponent<Rigidbody2D>().velocity = bulletSpawnPoint.right * bulletSpeed;
        //}
    }

}
