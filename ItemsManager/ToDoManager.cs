using Models;

namespace ItemsManager
{
    internal class ToDoManager : EntityManager<ToDo>
    {
        protected override ToDo CreateEntity()
        {
            return new ToDo();
        }

        protected override void ExtraCreate(ToDo entity)
        {
        }

        protected override void ExtraEdit(ToDo current, ToDo edited)
        {
        }
    }
}
