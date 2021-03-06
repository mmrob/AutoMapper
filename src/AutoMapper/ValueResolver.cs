namespace AutoMapper
{
    /// <summary>
    /// Type-safe implementation of <see cref="IValueResolver"/>
    /// </summary>
    /// <typeparam name="TSource">Source type</typeparam>
    /// <typeparam name="TDestination">Destination type</typeparam>
    public abstract class ValueResolver<TSource, TDestination> : IValueResolver
    {
        public object Resolve(object source, ResolutionContext context)
        {
            if (source != null && !(source is TSource))
            {
                throw new AutoMapperMappingException(
                    $"Value supplied is of type {source.GetType()} but expected {typeof (TSource)}.\nChange the value resolver source type, or redirect the source value supplied to the value resolver using FromMember.");
            }

            return ResolveCore((TSource) source);
        }

        /// <summary>
        /// Implementors override this method to resolve the destination value based on the provided source value
        /// </summary>
        /// <param name="source">Source value</param>
        /// <returns>Destination</returns>
        protected abstract TDestination ResolveCore(TSource source);
    }
}