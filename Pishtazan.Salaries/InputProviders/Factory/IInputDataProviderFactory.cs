namespace Pishtazan.Salaries.InputProviders.Factory
{
    public interface IInputDataProviderFactory
    {
        IInputProvider[] InputProviders { get; }

        IInputProvider Get(string providerName);
    }
}