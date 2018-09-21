using System;

namespace Persons.Abstractions.Commands
{
	public class CreatePersonCommand : Command
	{

		public class CreatePersonResult
		{
			public ResultType Type { get; set; }
			public Guid Id { get; set; }
		}

		public DateTime BirthDate { get; set; }
		public string Name { get; set; }

		public override string ToString()
		{
			return $"BirthDate={BirthDate.ToShortDateString()}, Name={Name}";
		}
	}
}
