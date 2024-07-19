using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ring : MonoBehaviour
{
    public GameObject prefab; // ตัวแปรสำหรับ prefab ที่จะสร้าง
    public int numberOfObjects = 10; // จำนวนของ prefab ที่จะสร้าง
    public float radius = 7f; // รัศมีของวงกลม
    public Vector3 spawnOffset = new Vector3(6f, 4f, -8f); // ตัวแปรสำหรับตำแหน่งเริ่มต้น

    // Start is called before the first frame update
    void Start()
    {
        make_circle();
    }

    // สร้าง prefab เป็นรูปวงกลม
    void make_circle()
    {
        // Degrees-to-radians conversion constant (Read Only).
        // This is equal to (PI * 2) / 360.
        float angle = 360f / numberOfObjects;

        for (int i = 0; i < numberOfObjects; i++)
        {
            float x = Mathf.Sin(Mathf.Deg2Rad * angle * i) * radius;
            float z = Mathf.Cos(Mathf.Deg2Rad * angle * i) * radius;
            // ใช้ spawnOffset เพื่อเปลี่ยนตำแหน่งของวงกลมทั้งหมด
            Vector3 position = new Vector3(x, 3f, z) + spawnOffset;
            Instantiate(prefab, position, Quaternion.identity);
        }
    }
}
