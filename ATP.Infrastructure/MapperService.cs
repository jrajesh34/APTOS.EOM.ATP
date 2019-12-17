using System;
using ATP.Infrastructure.Interfaces;
using AutoMapper;

namespace ATP.Infrastructure
{
    public class MapperService : IMapperService
    {
        private MapperConfiguration MapperConfig { get; }

        public MapperService(IMapperConfigurator mapperConfigurator)
        {
            MapperConfig = new MapperConfiguration(mapperConfigurator.Configure);
        }

        public TTo Map<TFrom, TTo>(TFrom toMap)
        {
            var mapper = MapperConfig.CreateMapper();
            return mapper.Map<TTo>(toMap);
        }

        /// <summary>
        /// Execute a mapping from the source object to the existing destination object.
        /// </summary>
        /// <typeparam name="TSource">Source type to use</typeparam>
        /// <typeparam name="TDestination">Dsetination type</typeparam>
        /// <param name="source">Source object to map from</param>
        /// <param name="destination">Destination object to map into</param>
        /// <returns>The mapped destination object, same instance as the <paramref name="destination" /> object</returns>
        public TDestination Map<TSource, TDestination>(TSource source, TDestination destination)
        {
            var mapper = MapperConfig.CreateMapper();
            return mapper.Map(source, destination);
        }

        /// <summary>
        /// Not as optimized as creating mappings in the CreateMappins and using the map function
        /// </summary>
        /// <typeparam name="TFrom"></typeparam>
        /// <typeparam name="TTo"></typeparam>
        /// <param name="toMap"></param>
        /// <returns></returns>
        public object MapGeneric<TFrom, TTo>(TFrom toMap)
        {
            var tempMapperConfig = new MapperConfiguration((x) =>
            {
                x.CreateMap(typeof(TFrom), typeof(TTo));
            });
            var mapper = tempMapperConfig.CreateMapper();
            return mapper.Map(toMap, typeof(TFrom), typeof(TTo));
        }

        /// <summary>
        /// Not as optimized as creating mappings in the CreateMappins and using the map function
        /// </summary>
        /// <typeparam name="TFrom"></typeparam>
        /// <param name="toMap"></param>
        /// <param name="destinationType"></param>
        /// <returns></returns>
        public object MapGenericAndType<TFrom>(TFrom toMap, Type destinationType)
        {
            var tempMapperConfig = new MapperConfiguration(x =>
            {
                x.CreateMap(typeof(TFrom), destinationType);
            });
            var mapper = tempMapperConfig.CreateMapper();
            return mapper.Map(toMap, typeof(TFrom), destinationType);
        }
    }
}
