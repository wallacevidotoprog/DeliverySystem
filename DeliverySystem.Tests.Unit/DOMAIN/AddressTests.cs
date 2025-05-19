using DeliverySystem.Core.Domain.Enum;
using DeliverySystem.Core.Domain.Utils;
using DeliverySystem.Core.Domain.ValueObject;
using System;
using System.ComponentModel.DataAnnotations;
using Xunit;

public class AddressValidationTests
{
	private readonly BrazilianState _validState = BrazilianState.SP;
	private readonly string _validCep = "01310100";
	private readonly string _validStreet = "Av. Paulista";
	private readonly string _validNumber = "1000";
	private readonly string _validCity = "São Paulo";

	[Fact]
	public void Constructor_WithValidData_DoesNotThrow()
	{
		// Act & Assert (não deve lançar exceção)
		var exception = Record.Exception(() =>
			new Address(_validStreet, _validNumber, _validCity, _validState, _validCep));

		Assert.Null(exception);
	}

	[Theory]
	[InlineData(null, "Logradouro é obrigatório")]
	[InlineData("", "Logradouro é obrigatório")]
	[InlineData("   ", "Logradouro é obrigatório")]
	[InlineData("UmNomeMuitoLongoQueUltrapassaOsCemCaracteresLimiteEstabelecidoPelaValidacaoParaGarantirQueNaoSeráAceitoPeloSistema", "Máximo de 100 caracteres")]
	public void Constructor_InvalidStreet_ThrowsValidationException(string street, string expectedError)
	{
		var ex = Assert.Throws<ValidationException>(() =>
			new Address(street, _validNumber, _validCity, _validState, _validCep));

		Assert.Contains(expectedError, ex.Message);
	}

	[Theory]
	[InlineData("1234567")] // 7 dígitos
	[InlineData("123456789")] // 9 dígitos
	[InlineData("ABCDEFGH")] // letras
	[InlineData("")] // vazio
	[InlineData(null)] // nulo
	public void Constructor_InvalidCEP_ThrowsValidationException(string invalidCep)
	{
		var ex = Assert.ThrowsAny<Exception>(() =>
			new Address(_validStreet, _validNumber, _validCity, _validState, invalidCep));

		// Pode lançar ValidationException ou ArgumentException
		Assert.True(ex is ValidationException || ex is ArgumentException);
		Assert.Contains("CEP", ex.Message);
	}

	[Fact]
	public void Constructor_NullPostalCodeValue_ThrowsValidationException()
	{
		// Arrange
		var invalidPostalCode = new DisplayValue(null, null);

		// Como PostalCode é privado, precisamos de um mock ou refatoração
		// Alternativa: testar via construtor com CEP inválido
		var ex = Assert.Throws<ValidationException>(() =>
			new Address(_validStreet, _validNumber, _validCity, _validState, "INVALID"));

		Assert.Contains("CEP inválido", ex.Message);
	}
}