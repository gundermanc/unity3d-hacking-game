/// <summary>
/// BlockScript Color type. This is used so that BlockScript retains its portabilty
/// and can be used again outside of Unity. Each system that implements drawing
/// capability (Unity, Android, etc) is expected to interpret this type.
/// 
/// Valid color values are 
/// </summary>
using BlockScript.Library.Exceptions;

namespace BlockScript.Library.Drawing
{
	public class Color
	{
		public int R { get; private set; }
		public int G { get; private set; }
		public int B { get; private set; }
		public int A { get; private set; }

		public Color (int red, int green, int blue, int alpha)
		{
			this.R = red;
			this.G = green;
			this.B = blue;
			this.A = alpha;
	
			ValidateValues ();
		}

		private void ValidateValues()
		{
			if(this.R < 0 || this.R > 255 ||
				this.G < 0 || this.G > 255 ||
				this.B < 0 || this.B > 255 ||
				this.A < 0 || this.A > 255)
			{
				throw new OutOfRangeException ("RGBA values must be between 0 and 255.");
			}
		}
	}
}

