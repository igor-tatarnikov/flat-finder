using FlatFinder.Contracts;

namespace FlatFinder.Init.Creators
{
    internal abstract class BaseCreator
    {
        private bool _initialized;
        protected IFlatFinderUow Uow;

        protected int CreatorUserId
        {
            get
            {
                return 2;
            }
        }

        public virtual void Initialize(IFlatFinderUow flatFinderUow)
        {
            if (_initialized) return;

            Uow = flatFinderUow;
            _initialized = true;
        }
    }
}
