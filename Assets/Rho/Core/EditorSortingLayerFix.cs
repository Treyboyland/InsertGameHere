using UnityEngine;

namespace rho
{
	[ExecuteInEditMode]
	[RequireComponent(typeof(Renderer))]
	public class EditorSortingLayerFix : MonoBehaviour 
	{
		public string sortingLayerName = "Players";
		public int sortingOrder = 0;

		// Update is called once per frame
		void Update () 
		{
			GetComponent<Renderer>().sortingLayerName = sortingLayerName;
			GetComponent<Renderer>().sortingOrder = sortingOrder;
		}
	}
}
