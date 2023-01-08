using System;

namespace TwoWindowsMVVM;

internal class TextMessageModel
{
	public DateTime	 Time { get;  }
	public string  Text { get; }
	

	public TextMessageModel(string message) : this(DateTime.Now, message) { }

	public TextMessageModel(DateTime time, string message) => (this.Time, Text) = (time, message);
	
}
