namespace DeliverySystem.Core.Domain.Utils
{
	public class DisplayValue
	{
		public object Value { get; private set; }
		public string Display { get; private set; }

		public DisplayValue(object value, string display)
		{
			this.Value = value;
			this.Display = display;
		}
		public override string ToString() => Display?.ToString() ?? string.Empty;
	}
}
