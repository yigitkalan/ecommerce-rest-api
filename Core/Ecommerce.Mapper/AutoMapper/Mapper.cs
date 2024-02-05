using AutoMapper;

namespace Ecommerce.Mapper;
public class Mapper : Application.IMapper
{
    public static List<TypePair> typePairs = new();
    private IMapper MapperContainer;
    public TDestination Map<TDestination, TSource>(TSource source, string? ignore = null)
    {
        throw new NotImplementedException();
    }

    public IList<TDestination> Map<TDestination, TSource>(List<TSource> source, string? ignore = null)
    {
        throw new NotImplementedException();
    }

    public TDestination Map<TDestination>(object source, string? ignore = null)
    {
        throw new NotImplementedException();
    }

    public IList<TDestination> Map<TDestination>(IList<object> source, string? ignore = null)
    {
        throw new NotImplementedException();
    }

    protected void Config<TDestination, TSource>(int depth = 5, string? ignore = null)
    {
        var typePair = new TypePair(typeof(TDestination), typeof(TSource));
    }
}