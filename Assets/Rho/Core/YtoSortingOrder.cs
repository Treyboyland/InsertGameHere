using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace rho
{	
	[RequireComponent(typeof(SpriteRenderer)), ExecuteInEditMode]
	public class YtoSortingOrder : MonoBehaviour
	{
		SpriteRenderer sprite;

		void Start()
		{
			sprite = GetComponent<SpriteRenderer>();
		}

		// Update is called once per frame
		void Update ()
		{
			sprite.sortingOrder = -Mathf.RoundToInt(transform.position.y * 100);
		}
	}
}