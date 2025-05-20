using DeliverySystem.Core.Domain.ValueObject;
using System.ComponentModel.DataAnnotations;

namespace DeliverySystem.Core.Domain.Entities
{
	public class StoreEntity : BaseEntity
	{
		[Required(ErrorMessage = "Indentificador é obrigatório")]
		public CpfCnpj Indentifier { get; private set; }

		[Required(ErrorMessage = "Nome é obrigatório")]
		public string Name { get; private set; }

		[Required(ErrorMessage = "Endereço é obrigatório")]
		public AddressEntity Address { get; private set; }


		public StoreEntity(string indentifier, string name, AddressEntity address)
		{
			if (!string.IsNullOrWhiteSpace(name))
			{
				throw new ArgumentException("Nome da loja é obrigatório");
			}
			this.Indentifier = new CpfCnpj(indentifier);
			this.Name = name;
			this.Address = address;
		}
	}
}
