using Persons.Abstractions.Entities;
using System;

namespace Persons.Entities
{
	public class Person: BaseEntity<Guid>
	{
		public DateTime BirthDate { get; set; }
		public string Name { get; set; }

		private static int GetAge(DateTime birthDate)
		{
			var today = DateTime.Today;
			var age = today.Year - birthDate.Year;
			if (birthDate > today.AddYears(-age))
				age--;

			return age;
		}

		public int Age
		{
			get
			{
				return GetAge(BirthDate);
			}
		}

		public static Person Create(DateTime birthDate, string name)
		{
			var age = GetAge(birthDate);
			if (age >= 200)
				return null;

			if(String.IsNullOrWhiteSpace(name))
				return null;

			return new Person
			{
				BirthDate = birthDate.Date,
				Name = name,
				Id = Guid.NewGuid()
			};
		}
	}
}
