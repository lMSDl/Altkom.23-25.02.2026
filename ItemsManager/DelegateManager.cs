using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ItemsManager
{
    internal class DelegateManager<T> : EntityManager<T> where T : Entity
    {
        private readonly Func<T> _createEntity;
        private readonly Action<T> _extraCreate;
        private readonly Action<T, T> _extraEdit;

        public DelegateManager(Func<T> createEntity, Action<T> extraCreate, Action<T, T> extraEdit, string filePath) : base(filePath)
        {
            _createEntity = createEntity;
            _extraCreate = extraCreate;
            _extraEdit = extraEdit;
        }

        protected override T CreateEntity()
        {
            return _createEntity.Invoke();
        }

        protected override void ExtraCreate(T entity)
        {
            _extraCreate.Invoke(entity);
        }

        protected override void ExtraEdit(T current, T edited)
        {
            _extraEdit.Invoke(current, edited);
        }
    }
}
