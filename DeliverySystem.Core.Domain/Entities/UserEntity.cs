using DeliverySystem.Core.Domain.ValueObject;
using System.ComponentModel.DataAnnotations;

namespace DeliverySystem.Core.Domain.Entities
{
	public class UserEntity : BaseEntity
	{
		[Required(ErrorMessage = "Indentificador é obrigatório")]
		public CpfCnpj Indentifier { get; private set; }

		[Required(ErrorMessage = "Nome é obrigatório")]
		public string Name { get; private set; }

		[Required(ErrorMessage = "Endereço é obrigatório")]
		public AddressEntity Address { get; private set; }


		public UserEntity( )
		{
				
		}
	}
}
