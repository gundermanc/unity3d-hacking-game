using System;
using System.Collections;

namespace BlockScript.Library.Drawing
{
	public abstract class DrawableBase
	{
		public Color Color { get; private set; }
		public string Title { get; private set; }
		public DrawableField[] Fields { get; private set; }


		public DrawableBase (Color color, string title, DrawableField[] fields)
		{
			this.Color = color;
			this.Title = title;
			this.Fields = fields;
		}
	}

	/// <summary>
	/// Each drawable can have "fields" which can have other blocks placed inside of them.
	/// Think "if" statements.
	/// </summary>
	public class DrawableField
	{
		public string Title { get; protected set; }
		public DrawableBase[] Values { get; protected set; }
		public DrawableFieldType Type { get; protected set; }

		public DrawableField (string title, DrawableBase[] values, DrawableFieldType type)
		{
			this.Title = title;
			this.Values = values;
			this.Type = type;
		}
	}

	public enum DrawableFieldType
	{
		Parameter,
		Body,
	}
}

