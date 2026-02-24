using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ItemsManager
{
    internal class PeopleManager : EntityManager<Person>
    {
        protected override Person CreateEntity()
        {
            return new Person();
        }

        protected override void ExtraCreate(Person entity)
        {
            entity.BirthDate = ReadDate("Enter birth date (yyyy-MM-dd): ");
        }

        protected override void ExtraEdit(Person current, Person edited)
        {
            edited.BirthDate = ReadDate($"Enter birth date ({current.BirthDate:yyyy-MM-dd}): ", current.BirthDate);
        }
    }
}
