namespace LetsGoToVet.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork 
    {
        public LetsGoToVetDbContext DbContext { get; private set; }

        public UnitOfWork(LetsGoToVetDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public TRepository GetRepository<TRepository>() where TRepository : class
        {
            var type = typeof(TRepository);
            if (type.IsInterface)
            {
                throw new Exception("Cannot create instances of interfaces, use concrete class instead");
            }

            return Activator.CreateInstance(type, DbContext) as TRepository ??
                   throw new Exception();
        }

        public async Task SaveChangesAsync()
        {
            await DbContext.SaveChangesAsync();
        }


        #region Dispose Members

        private bool _disposed;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed || !disposing) return;

            DbContext?.Dispose();

            _disposed = true;
        }

        #endregion
    }
}
