using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Tenmetu : MonoBehaviour
{
	public float interval = 0.1f;

	void Start()
	{
		StartCoroutine("Blink");
	}

	IEnumerator Blink()
	{
		yield return new WaitForSeconds(3f);
		while (true)
		{
			var renderComponent = GetComponent<Renderer>();
			renderComponent.enabled = !renderComponent.enabled;
			yield return new WaitForSeconds(interval);
		}
	}
}
