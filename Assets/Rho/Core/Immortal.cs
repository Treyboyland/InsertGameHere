using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace rho
{
	// I CAN NEVER DIE!!
	public class Immortal : MonoBehaviour 
	{
		// Use this for initialization
		void Start () 
		{
			DontDestroyOnLoad(this.gameObject);
		}
	}
}
