using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    private Camera _camera;
    public Transform bulletSpawnPoint;

    Vector3 mouseDirection;
    float lookAngle;

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

        float rotationZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, rotationZ);

        if(Input.GetMouseButtonDown(0)) 
        {
            var bulletClone = Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity);

            bulletClone.GetComponent<Rigidbody2D>().velocity = bulletSpawnPoint.right * bulletSpeed;
        }

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
