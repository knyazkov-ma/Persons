using System;

namespace Persons.Commands.Parameters
{
	public enum CreatePersonResultType
	{
		OK,
		UncorrectEntity
	}

	public class CreatePersonResult
	{
		public CreatePersonResultType Type { get; set; }
		public Guid Id { get; set; }
	}
}
