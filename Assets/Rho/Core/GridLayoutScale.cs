using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace rho
{
	// This makes sure the cell size is always 1:1 and the inital spacing is kept
	// and is also 1:1 I thing.  Will shrink the children and then add padding if
	// needed to keep the children 1:1 without going outside the boundaries of the
	// parent rect
	public class GridLayoutScale : MonoBehaviour
	{
		void Start ()
		{
			var rect = GetComponent<RectTransform>().rect;
			var gridLayoutgroup = GetComponent<GridLayoutGroup>();

			//int cellCount = GetComponentsInChildren<RectTransform>().Length;
			int cellCount = GetComponent<RectTransform>().childCount;

			// Assumes we constraed the columns
			int numColumns = gridLayoutgroup.constraintCount;

			int numRows = (int) Mathf.Ceil(cellCount / (float) numColumns);

			// Get how big the thing should be
			var targetHeight = numRows * gridLayoutgroup.cellSize.y + gridLayoutgroup.spacing.y * (numRows - 1);
			var targetWidth = numColumns * gridLayoutgroup.cellSize.x + gridLayoutgroup.spacing.x * (numColumns - 1);

			// now scale everything to fit within the actual size
			var actualHeight = rect.height;
			var actualWidth = rect.width;

			float widthRatio = actualWidth / targetWidth;
			float heightRatio = actualHeight / targetHeight;

			var newCellSize = new Vector2(widthRatio * gridLayoutgroup.cellSize.x, heightRatio * gridLayoutgroup.cellSize.y);
			var newSpacing = new Vector2(widthRatio * gridLayoutgroup.spacing.x, heightRatio * gridLayoutgroup.spacing.y);

			// We need to add more padding to X to make sure the cellSizes are the same
			if (newCellSize.x > newCellSize.y)
			{
				var diff = actualWidth - (numColumns * newCellSize.y + newSpacing.y * (numColumns - 1));

				int padding = (int) diff / 2;
				gridLayoutgroup.padding.left = padding;
				gridLayoutgroup.padding.right = padding;

				// Change over the things
				newCellSize.x = newCellSize.y;
				newSpacing.x = newSpacing.y;
			}
			else if (newCellSize.x < newCellSize.y)
			{
				var diff = actualWidth - (numRows * newCellSize.x + newSpacing.x * (numRows - 1));

				int padding = (int) diff / 2;
				gridLayoutgroup.padding.top = padding;
				gridLayoutgroup.padding.bottom = padding;

				// Change over the things
				newCellSize.y = newCellSize.x;
				newSpacing.y = newSpacing.x;
			}

			// Set new sizes
			gridLayoutgroup.cellSize = newCellSize;
			gridLayoutgroup.spacing = newSpacing;
		}

		void Update()
		{
		}
	}
}
