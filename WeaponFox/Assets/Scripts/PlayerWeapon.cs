using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    private Transform aimTransform;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform weapon;

    // Start is called before the first frame update
    private void Awake()
    {
        aimTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        AimHandler();
        ShootingHandler();
    }

    private void ShootingHandler()
    {
        if (aimTransform != null)
        {
            if (Input.GetButtonDown("Fire1")) 
            {
                Instantiate(bulletPrefab, weapon.position, weapon.rotation);
            }
        }
    }

    private void AimHandler()
    {
        Vector3 mousePosition = GetMousePosition();
        Vector3 aimDirection = (mousePosition - transform.position).normalized;
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        aimTransform.eulerAngles = new Vector3 (0, 0, angle);
    }

    private Vector3 GetMousePosition()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        mousePosition.z = 0f;
        return mousePosition;
    }

}
