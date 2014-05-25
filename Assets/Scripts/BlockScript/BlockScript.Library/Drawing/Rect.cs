using System;

namespace BlockScript.Library.Drawing
{
	/// <summary>
	/// For portability we are defining our own Rectangle.
	/// </summary>
	public class Rectangle
	{
		public int Left { get; set; }
		public int Top { get; set; }
		public int Width { get; set; }
		public int Height { get; set; }

		public Rectangle (int left, int top, int width, int height)
		{
			this.Left = left;
			this.Top = top;
			this.Width = width;
			this.Height = height;
		}
	}
}

