using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireProjectile : MonoBehaviour
{
    // This script launches a projectile prefab by instantiating it at the position
    // of the GameObject on which it is placed, then setting the velocity
    // in the forward direction of the same GameObject.

    [SerializeField] private AudioClip sndNewDamage;
    [SerializeField] private AudioClip sndCrashWarning;
    [SerializeField] private AudioClip sndHasDamageWarning;
    [SerializeField] private AudioClip sndFueldLow;
    public GameObject projectilePrefab; // เปลี่ยนจาก Rigidbody เป็น GameObject
    public Transform shootPoint;
    public float speed = 20;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            // สร้างโปรเจกไทล์จาก prefab
            GameObject projectileInstance = Instantiate(projectilePrefab, shootPoint.position, shootPoint.rotation);
            
            // เพิ่ม Rigidbody ให้กับโปรเจกไทล์ที่สร้าง
            Rigidbody rb = projectileInstance.AddComponent<Rigidbody>();

            // ตั้งค่า Rigidbody
            rb.mass = 1; // ตั้งค่ามวลของโปรเจกไทล์
            rb.drag = 0; // ตั้งค่าการต้านทานการเคลื่อนที่ในอากาศ
            rb.angularDrag = 0.05f; // ตั้งค่าการต้านทานการหมุน
            rb.useGravity = true; // ตั้งค่าให้ใช้แรงโน้มถ่วง

            // ตั้งค่าความเร็วของโปรเจกไทล์
            rb.velocity = shootPoint.forward * speed;
        }
    }
    
}
