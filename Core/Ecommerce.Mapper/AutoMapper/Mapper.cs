using System.Diagnostics;
using AutoMapper;

namespace Ecommerce.Mapper;
public class Mapper : Application.IMapper
{
    public static List<TypePair> typePairs = new();
    private IMapper MapperContainer;
    public TDestination Map<TDestination, TSource>(TSource source, string? ignore = null)
    {
        Config<TDestination, TSource>(ignore: ignore);
        
        return MapperContainer.Map<TSource, TDestination>(source);
    }

    public IList<TDestination> Map<TDestination, TSource>(List<TSource> source, string? ignore = null)
    {
        Config<TDestination, TSource>(ignore: ignore);
        
        return MapperContainer.Map<IList<TDestination>>(source);
    }

    public TDestination Map<TDestination>(object source, string? ignore = null)
    {
        Config<TDestination, object>(ignore: ignore);
        
        return MapperContainer.Map<TDestination>(source);
    }

    public IList<TDestination> Map<TDestination>(IList<object> source, string? ignore = null)
    {
        Config<TDestination, object>(ignore: ignore);
        
        return MapperContainer.Map<IList<TDestination>>(source);
    }


    // Allows dynamic configuration on the fly
    public void Config<TDestination, TSource>(int depth = 5, string? ignore = null)
    {
        var typePair = new TypePair(typeof(TDestination), typeof(TSource));

        if (typePairs.Any(p => p.DestinationType == typePair.DestinationType
                && p.SourceType == typePair.SourceType) && ignore is null)
            return;

        typePairs.Add(typePair);



        var config = new MapperConfiguration(cfg =>
        {
            foreach (var item in typePairs)
            {
                if (ignore is not null)
                    cfg.CreateMap(item.SourceType, item.DestinationType).MaxDepth(depth).ForMember(ignore, opt => opt.Ignore()).ReverseMap();
                else
                    cfg.CreateMap(item.SourceType, item.DestinationType).MaxDepth(depth).ReverseMap();
            }
        });
        MapperContainer = config.CreateMapper();
    }
}