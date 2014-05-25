/// <summary>
/// Utilities for conversion between BlockScript and Unity Types.
/// 
/// By: Christian Gunderman
/// </summary>
using System;
using UnityEngine;
using BlockScript.Library.Drawing;

namespace BlockScript.Unity
{
	public static class Utilities
	{
		public static Rect RectangleToRect (Rectangle rectangle)
		{
			return new Rect (rectangle.Left, rectangle.Top, rectangle.Width, rectangle.Height);
		}
	}
}

