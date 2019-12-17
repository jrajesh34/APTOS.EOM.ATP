using AutoMapper;

namespace ATP.Infrastructure.Interfaces
{
    public interface IMapperConfigurator
    {
        void Configure(IMapperConfigurationExpression config);
    }
}
