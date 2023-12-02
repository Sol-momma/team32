using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowSpawner : MonoBehaviour
{
    [SerializeField] private GameObject arrowPrefab;
    //private bool canShoot = true;
    private AudioSource shootArrow;
    // Start is called before the first frame update
    void Start()
    {
        shootArrow = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) /*&& canShoot*/)
        {
            GameObject arrow = Instantiate(arrowPrefab, new Vector3(0, 20, 0), Quaternion.identity);
               
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 world_direction = ray.direction;

            arrow.transform.rotation = Quaternion.LookRotation(world_direction);
            // rotate 90 degrees around the x axis
            arrow.transform.Rotate(0, 90, 0);
            arrow.GetComponent<ArrowController>().Shoot(world_direction.normalized * 50000f);
            //canShoot = false;
            //StartCoroutine(enableShooting());
            shootArrow.pitch = Random.Range(0.8f, 1.2f);
            shootArrow.Play();
        }
    }

    IEnumerator enableShooting()
    {
        yield return new WaitForSeconds(1f);
        //canShoot = true;
    }
}
