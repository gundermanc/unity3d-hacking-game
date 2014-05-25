/// <summary>
/// Blockscript Viewport implementation for Unity
/// </summary>
using System;
using UnityEngine;
using BlockScript.Library.Drawing;

namespace BlockScript.Unity
{
	public class UnityViewport : ViewportBase, MonoBehaviour
	{

		// Unity Script Parameters:
		public Texture BackgroundTexture { get; set; }
		public Texture SingleLineTexture { get; set; }
		public Texture MultipleLineTexture { get; set; }

		public UnityViewport (DrawableBase[] drawables, Rectangle viewportDimensions, 
		                      int lineHeight, int margin) : 
			base (drawables, viewportDimensions, lineHeight, margin)
		{
		}

		void OnGUI ()
		{
			base.Paint ();  // call the BlockScript framework's internal paint method
		}

		public override void DrawRectangle (Rectangle rectangle, Color color, ContextHint contextHint)
		{
			Texture texture;

			switch (contextHint)
			{
			case ContextHint.ViewportBackground:
				texture = this.BackgroundTexture;
				break;
			case ContextHint.SingleLine:
				texture = this.SingleLineTexture;
				break;
			case ContextHint.Container:
				texture = this.MultipleLineTexture;
				break;
			default:
				texture = this.MultipleLineTexture;
			}

			GUI.DrawTexture (Utilities.RectangleToRect (rectangle), texture);
		}

		public override void DrawText (Rectangle rectangle, string text)
		{
			GUI.Label (Utilities.RectangleToRect (rectangle, text));
		}
	}
}

