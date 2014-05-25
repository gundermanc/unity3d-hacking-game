/// <summary>
/// The base class for BlockScript Viewports. Any viewports (Unity, etc) must extend this class and implement
/// the methods.
/// </summary>
using System;

namespace BlockScript.Library.Drawing
{
	public abstract class ViewportBase
	{
		public DrawableBase[] Drawables { get; set; }
		public Rectangle ViewportDimensions { get; set; }
		public int LineHeight { get; set; }
		public int Margin { get; set; }
		public int TabWidth { get; set; }  // width of the "tab" used when indenting blocks

		public ViewportBase (DrawableBase[] drawables, Rectangle viewportDimensions, 
			int lineHeight, int margin)
		{
			this.Drawables = drawables;
			this.ViewportDimensions = viewportDimensions;
			this.LineHeight = lineHeight;
			this.Margin = margin;
		}

		/// <summary>
		/// Method should be implemented by specific platform viewport. Rectangle is the coordinates of the 
		/// rectangle (or rounded rectangle) to draw.
		/// </summary>
		/// <param name="rectangle">Rectangle.</param>
		/// <param name="color">Color.</param>
		public abstract void DrawRectangle (Rectangle rectangle, Color color, ContextHint contextHint);

		public abstract void DrawText (Rectangle rectangle, string Text);

		public void Paint ()
		{
			DrawRectangle (this.ViewportDimensions, null, ContextHint.ViewportBackground);

			int verticalOffset = 0;
			PaintDrawables (this.Drawables, 0, ref verticalOffset);
		}

		/// <summary>
		/// Paints the drawables.
		/// </summary>
		/// <param name="drawables">Drawables.</param>
		/// <param name="tabs">Number of tabs before the current drawable.</param>
		/// <param name="line">Line we are on...0 for line 1...</param>
		private void PaintDrawables (DrawableBase[] drawables, int tabs, ref int verticalOffset)
		{
			foreach (DrawableBase drawable in drawables)
			{
				// no fields, this is a single line drawable
				if (drawable.Fields.Length == 0) 
				{
					DrawSingleLineDrawable (drawable, tabs, ref verticalOffset);
				}
				else
				{
					DrawContainerDrawable (drawable, tabs, ref verticalOffset);
				}
			}
		}

		private void DrawSingleLineDrawable (DrawableBase drawable, int tabs, ref int verticalOffset)
		{
			Rectangle rectangle = new Rectangle (
				                      left: this.ViewportDimensions.Left + this.Margin + (tabs * this.TabWidth),
				                      top: this.ViewportDimensions.Top + this.Margin + verticalOffset, 
				                      width: this.ViewportDimensions.Width - (2 * this.Margin) - (tabs * this.TabWidth),
				                      height: this.LineHeight);
			DrawRectangle (rectangle, drawable.Color, ContextHint.SingleLine);
			verticalOffset += this.LineHeight + this.Margin;
		}

		private void DrawContainerDrawable (DrawableBase drawable, int tabs, ref int verticalOffset)
		{
			Rectangle rectangle = new Rectangle (
				                      left: this.ViewportDimensions.Left + this.Margin + (tabs * this.TabWidth),
				                      top: this.ViewportDimensions.Top + this.Margin + verticalOffset, 
				                      width: this.ViewportDimensions.Width - (2 * this.Margin) - (tabs * this.TabWidth),
				                      height: this.LineHeight);
			DrawRectangle (rectangle, drawable.Color, ContextHint.SingleLine);
			verticalOffset += this.LineHeight + this.Margin;

		}
	}

	/// <summary>
	/// Provides a hint to the implementer of a viewport as to what context a rectangle is being
	/// drawn so that they can change the pattern of the fill if desired.
	/// </summary>
	public enum ContextHint
	{
		SingleLine,
		Container,
		ViewportBackground
	}
}

