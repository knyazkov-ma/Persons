using Persons.Service.Entities;
using System;

namespace Persons.Service.Repositories.Interfaces
{
	public interface IPersonRepository
	{
		Person Find(Guid id);
		void Insert(Person entity);
	}
}
