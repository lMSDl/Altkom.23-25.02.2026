using Models;

namespace ItemsManager
{
    internal class ToDoManager : EntityManager<ToDo>
    {
        public ToDoManager(string filePath) : base(filePath)
        {
        }

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
