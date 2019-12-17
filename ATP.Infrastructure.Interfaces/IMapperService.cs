using System;

namespace ATP.Infrastructure.Interfaces
{
    public interface IMapperService
    {
        TTo Map<TFrom, TTo>(TFrom toMap);

        object MapGeneric<TFrom, TTo>(TFrom toMap);

        /// <summary>
        /// Execute a mapping from the source object to the existing destination object.
        /// </summary>
        /// <typeparam name="TSource">Source type to use</typeparam>
        /// <typeparam name="TDestination">Dsetination type</typeparam>
        /// <param name="source">Source object to map from</param>
        /// <param name="destination">Destination object to map into</param>
        /// <returns>The mapped destination object, same instance as the <paramref name="destination" /> object</returns>
        TDestination Map<TSource, TDestination>(TSource source, TDestination destination);

        object MapGenericAndType<TFrom>(TFrom toMap, Type destinationType);
    }
}
