using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    // 発射
    [SerializeField] private float fireRate = 0.25f;
    [SerializeField] private float weaponRange = 50f;
    private bool isFire = false;
    private float nextFire;

    [SerializeField] private Camera mainCamera;


    public void OnFire(InputAction.CallbackContext value)
    {
        if (value.started)
        {
            isFire = true;
        }
    }

    private void Update()
    {
        if (isFire && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;

            Vector3 rayOrigin = mainCamera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));
            RaycastHit hit;

            if (Physics.Raycast(rayOrigin, mainCamera.transform.forward, out hit, weaponRange))
            {
                TargetsController health = hit.collider.GetComponent<TargetsController>();

                if (health != null)
                {
                    health.OnHit();
                    UFOMovement ufoMovement = hit.collider.GetComponent<UFOMovement>();
                    if (ufoMovement != null)
                    {
                        ufoMovement.Land();
                    }
                }
            }
            isFire = false;
        }
    }
}
