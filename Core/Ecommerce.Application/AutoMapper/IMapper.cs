namespace Ecommerce.Application;
public interface IMapper
{
    TDestination Map<TDestination, TSource>(TSource source, string? ignore = null);

    IList<TDestination> Map<TDestination, TSource>(List<TSource> source, string? ignore = null);

    TDestination Map<TDestination>(object source, string? ignore = null);
    IList<TDestination> Map<TDestination>(IList<object> source, string? ignore = null);
}
