using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace rho
{
	public class GoToScene : MonoBehaviour
	{
		[SerializeField, Scene] private string sceneName = null;

		public void OnButtonPressed()
		{
			if (sceneName != "")
			{
				SceneManager.LoadScene(sceneName);
			}
		}
	}
}
