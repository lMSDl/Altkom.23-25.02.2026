using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ItemsManager
{
    internal class PeopleManager : EntityManager
    {
        protected override Entity CreateEntity()
        {
            return new Person();
        }

        protected override void ExtraCreate(Entity entity)
        {
            var person = (Person)entity;
            person.BirthDate = ReadDate("Enter birth date (yyyy-MM-dd): ");
        }

        protected override void ExtraEdit(Entity current, Entity edited)
        {
            var currentPerson = (Person)current;
            var editedPerson = (Person)edited;
            editedPerson.BirthDate = ReadDate($"Enter birth date ({currentPerson.BirthDate:yyyy-MM-dd}): ", currentPerson.BirthDate);
        }
    }
}
