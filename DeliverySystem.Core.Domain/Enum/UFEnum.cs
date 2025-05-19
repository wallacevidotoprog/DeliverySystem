﻿using System.ComponentModel.DataAnnotations;

namespace DeliverySystem.Core.Domain.Enum
{
	public enum UF
	{
		AC, AL, AP, AM, BA, CE, DF, ES, GO, MA, MT,
		MS, MG, PA, PB, PR, PE, PI, RJ, RN, RS, RO,
		RR, SC, SP, SE, TO
	}

	public enum BrazilianState
	{
		[Display(Name = "Acre")] AC,
		[Display(Name = "Alagoas")] AL,
		[Display(Name = "Amapá")] AP,
		[Display(Name = "Amazonas")] AM,
		[Display(Name = "Bahia")] BA,
		[Display(Name = "Ceará")] CE,
		[Display(Name = "Distrito Federal")] DF,
		[Display(Name = "Espírito Santo")] ES,
		[Display(Name = "Goiás")] GO,
		[Display(Name = "Maranhão")] MA,
		[Display(Name = "Mato Grosso")] MT,
		[Display(Name = "Mato Grosso do Sul")] MS,
		[Display(Name = "Minas Gerais")] MG,
		[Display(Name = "Pará")] PA,
		[Display(Name = "Paraíba")] PB,
		[Display(Name = "Paraná")] PR,
		[Display(Name = "Pernambuco")] PE,
		[Display(Name = "Piauí")] PI,
		[Display(Name = "Rio de Janeiro")] RJ,
		[Display(Name = "Rio Grande do Norte")] RN,
		[Display(Name = "Rio Grande do Sul")] RS,
		[Display(Name = "Rondônia")] RO,
		[Display(Name = "Roraima")] RR,
		[Display(Name = "Santa Catarina")] SC,
		[Display(Name = "São Paulo")] SP,
		[Display(Name = "Sergipe")] SE,
		[Display(Name = "Tocantins")] TO
	}
}
