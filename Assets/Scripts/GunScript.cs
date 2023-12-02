using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    public ParticleSystem gunParticle;

    public GameObject gunLight;

    public Animator gunAnimator;

    private Vector3 initialPosition;
    private Quaternion initialRotation;

    public UnityChan.UnityChanControlScriptWithRgidBody zundamonControlScriptWithRgidBody;

    private bool isRotating = false;


    // Start is called before the first frame update
    void Start()
    {   

    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetMouseButtonDown(0)) // マウス左クリックを押した時
        {
            zundamonControlScriptWithRgidBody.DisableRotation();
            gunParticle.Play();
            if (!isRotating)
            {
                initialPosition = gameObject.transform.position;
                initialRotation = gameObject.transform.rotation;
                gameObject.transform.Rotate(0f, 0f, -20f);
            }
            isRotating = true;
            //gunAnimator.SetTrigger("Shoot");
            gameObject.transform.position = new Vector3(initialPosition.x, initialPosition.y + 1f, initialPosition.z - 0.5f);
            StartCoroutine(StopParticleAfterSeconds(0.1f));
        }
    }

    IEnumerator StopParticleAfterSeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        gunParticle.Stop();
        //gunAnimator.SetTrigger("Shoot");
        gameObject.transform.position = initialPosition;
        gameObject.transform.rotation = initialRotation;
        zundamonControlScriptWithRgidBody.EnableRotation();
        isRotating = false;
    }
}