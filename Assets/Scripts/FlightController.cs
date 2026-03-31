// FlightController.cs
// CENG 454 HW1: Sky-High Prototype
// Author: [Kendi Adın Soyadın] | Student ID: [Kendi Öğrenci Numaran]
using UnityEngine;

public class FlightController : MonoBehaviour
{
    [SerializeField] private float pitchSpeed = 45f; // degrees/second
    [SerializeField] private float yawSpeed = 45f;   // degrees/second
    [SerializeField] private float rollSpeed = 45f;  // degrees/second
    [SerializeField] private float thrustSpeed = 25f; // units/second

    // TODO (Task 3-A): Declare a private Rigidbody field named 'rb'
    private Rigidbody rb;

    void Start()
    {
        // TODO (Task 3-B): Cache GetComponent<Rigidbody>() into 'rb'.
        rb = GetComponent<Rigidbody>();
        
        // Then set rb.freezeRotation = true.
        // Neden gerekli? (PDF'e yazacaksın): Fizik motorunun uçağı yerçekimi veya çarpmalarla 
        // kendi kafasına göre döndürmesini engellemek için. Rotasyonu tamamen biz kodla kontrol edeceğiz.
        rb.freezeRotation = true;
    }

    void Update()
    {
        HandleRotation();
        HandleThrust();
    }

    private void HandleRotation()
    {
        // TODO (Task 3-C): Pitch, Yaw, Roll

        // Pitch (Aşağı/Yukarı): Arrow Up/Down
        float pitchInput = Input.GetAxis("Vertical");
        transform.Rotate(Vector3.right * pitchInput * pitchSpeed * Time.deltaTime);

        // Yaw (Sağa/Sola): Arrow Left/Right
        float yawInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up * yawInput * yawSpeed * Time.deltaTime);

        // Roll (Kendi etrafında dönme): Q / E
        float rollInput = 0f;
        if (Input.GetKey(KeyCode.Q)) rollInput = 1f;
        if (Input.GetKey(KeyCode.E)) rollInput = -1f;
        transform.Rotate(Vector3.forward * rollInput * rollSpeed * Time.deltaTime);
    }

    private void HandleThrust()
    {
        // TODO (Task 3-D): İleri itki
        if (Input.GetKey(KeyCode.Space))
        {
            transform.Translate(Vector3.forward * thrustSpeed * Time.deltaTime);
        }
    }
}