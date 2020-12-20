namespace Apollo.Core.Services
{
    public abstract class Service
    {
        protected readonly DaoProvider DaoProvider;

        protected Service(DaoProvider daoProvider)
        {
            DaoProvider = daoProvider;
        }
    }
}
