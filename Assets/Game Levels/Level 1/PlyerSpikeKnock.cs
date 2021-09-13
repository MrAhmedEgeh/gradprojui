using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlyerSpikeKnock : MonoBehaviour
{
	public static PlyerSpikeKnock instance;
	private Rigidbody2D rb2d;

    private void Awake()
    {
		instance = this;
    }
    private void Start()
    {
		rb2d = gameObject.GetComponent<Rigidbody2D>();
		
	}
    public IEnumerator Knockback(float knockDur, float knockbackPwr, Vector3 knockbackDir)
	{

		float timer = 0;

		while (knockDur > timer)
		{

			timer += Time.deltaTime;
			
			rb2d.AddForce(new Vector3(knockbackDir.x * -100, Mathf.Abs(knockbackDir.y * knockbackPwr), transform.position.z));

		}

		yield return 0;

	}
}
