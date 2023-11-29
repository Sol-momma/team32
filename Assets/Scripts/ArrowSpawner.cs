using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowSpawner : MonoBehaviour
{
    [SerializeField] private GameObject arrowPrefab;
    private bool canShoot = true;
    private AudioSource shootArrow;
    private System.Action<int> AddScore;
    // Start is called before the first frame update
    void Start()
    {
        shootArrow = GetComponent<AudioSource>();
    }

    public void Initialize(System.Action<int> AddScore)
    {
        this.AddScore = AddScore;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && canShoot)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject arrow = Instantiate(arrowPrefab, new Vector3(0, 20, 0), Quaternion.identity);
        var arrowController = arrow.GetComponent<ArrowController>();
        arrowController.Initialize(AddScore);

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Vector3 world_direction = ray.direction;

        arrow.transform.rotation = Quaternion.LookRotation(world_direction);
        arrow.transform.Rotate(0, 90, 0);
        arrowController.Shoot(world_direction.normalized * 20000f);

        canShoot = false;
        StartCoroutine(EnableShootingAfterSeconds(1f));

        shootArrow.pitch = Random.Range(0.8f, 1.2f);
        shootArrow.Play();
    }

    IEnumerator EnableShootingAfterSeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        canShoot = true;
    }

    public void OnGameOver()
    {
        enabled = false;
    }

    public void OnRestart()
    {
        enabled = true;
    }
}
