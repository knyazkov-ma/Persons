using System;

namespace Persons.Abstractions.Commands.Parameters
{
	public class CreatePersonParameter
	{
		public DateTime BirthDate { get; set; }
		public string Name { get; set; }
	}
}
