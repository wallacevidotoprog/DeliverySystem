using DeliverySystem.Core.Domain.Utils;

namespace DeliverySystem.Core.Domain.Interfaces
{
	public interface IValidateValueObject
	{
		DisplayValue Validate(string value);
	}
}
