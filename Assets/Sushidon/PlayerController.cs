using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    // 入力
    private Vector2 inputMovement;

    // スコープ
    private Vector3 scopePosition;
    private float scopeSpeed = 0.05f;

    // 発射
    [SerializeField] private float fireRate = 0.25f;
    [SerializeField] private float weaponRange = 50f;
    private bool isFire = false;
    private float nextFire;


    private void Start()
    {
        scopePosition = Vector3.zero;
    }

    public void OnLook(InputAction.CallbackContext value)
    {
        inputMovement = value.ReadValue<Vector2>();
    }

    public void OnFire(InputAction.CallbackContext value)
    {
        if (value.started)
        {
            isFire = true;
        }
    }

    private void Update()
    {
        transform.position = MoveTheScope();

        if (isFire && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;

            RaycastHit hit;

            Ray ray = Camera.main.ScreenPointToRay(transform.position);
            Debug.DrawRay(ray.origin, ray.direction * weaponRange, Color.red, 1f);

            if (Physics.Raycast(ray, out hit, weaponRange))
            {
                TargetsController health  = hit.collider.GetComponent<TargetsController>();

                if (health != null)
                {
                    health.OnHit();
                }
            }
            isFire = false;
        }
    }

    Vector3 MoveTheScope()
    {
        scopePosition += new Vector3(inputMovement.x * scopeSpeed, inputMovement.y * scopeSpeed, 0);

        scopePosition.x = Mathf.Clamp(scopePosition.x, -10f, 10f);
        scopePosition.y = Mathf.Clamp(scopePosition.y, -4.5f, 6.5f);

        return scopePosition;
    }
}
