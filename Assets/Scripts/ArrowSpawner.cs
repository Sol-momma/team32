using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowSpawner : MonoBehaviour
{
    [SerializeField] private GameObject arrowPrefab;
    private bool canShoot = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && canShoot)
        {
            GameObject arrow = Instantiate(arrowPrefab);
               
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 world_direction = ray.direction;

            arrow.GetComponent<ArrowController>().Shoot(world_direction.normalized * 20000f);
            canShoot = false;
            StartCoroutine(enableShooting());
        }
    }

    IEnumerator enableShooting()
    {
        yield return new WaitForSeconds(1f);
        canShoot = true;
    }
}
