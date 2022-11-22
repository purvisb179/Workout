using App.Models;
using AutoMapper;

namespace App.Data.Repositories;

public class BaseRepository
{
    protected readonly AppDbContext Context;
    private readonly IMapper _mapper;
    
    public BaseRepository(AppDbContext context)
    {
        Context = context;
        _mapper = new Mapper(new MapperConfiguration(cfg => cfg
            .AddProfile(new OrganizationProfile())));
    }

    protected Task<TModel> Map<TEntity, TModel>(TEntity entity)
        where TModel : BaseModel 
        where TEntity : BaseEntity
    {
        return Task.FromResult(_mapper.Map<TEntity, TModel>(entity));
    }

    protected async Task<TModel> Set<TModel, TEntity>(TModel model)
        where TEntity : BaseEntity
        where TModel : BaseModel
    {
        var entity = _mapper.Map<TModel, TEntity>(model);
        await Context.Set<TEntity>().AddAsync(entity);
        await Context.SaveChangesAsync();
        return await Map<TEntity, TModel>(entity);
    }
}

public class OrganizationProfile : Profile
{
    public OrganizationProfile()
    {

    }
}