using Persons.Abstractions.Commands.Parameters;

namespace Persons.Abstractions.Commands
{
	public interface ICreatePersonCommand
	{
		CreatePersonResult Run(CreatePersonParameter param);
	}
}
