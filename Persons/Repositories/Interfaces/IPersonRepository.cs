using Persons.Entities;
using System;

namespace Persons.Repositories.Interfaces
{
	public interface IPersonRepository
	{
		Person Find(Guid id);
		void Insert(Person entity);
	}
}
