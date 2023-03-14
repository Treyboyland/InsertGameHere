using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace rho
{
	public class SpawnPrefab : MonoBehaviour
	{
		[SerializeField] GameObject prefab = null;

		public void Spawn()
		{
			Instantiate(prefab, transform.position, transform.rotation);
		}
	}
}
