using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{

	void OnBecameInvisible()
	{
		Destroy(gameObject);
	}
}
