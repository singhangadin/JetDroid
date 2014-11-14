using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour 
{	public GameObject target;

	void OnCollisionEnter2D(Collision2D target)
	{	Destroy(gameObject);
	}
}
