﻿using System;

namespace Persons.Queries.Dto
{
	public class PersonDto
	{
		public Guid Id { get; set; }
		public DateTime BirthDate { get; set; }
		public string Name { get; set; }
		public int Age { get; set; }
	}
}