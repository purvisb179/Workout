using App.Data.Models;
using App.Enum;
using App.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace App.Data.Repositories;

public class BaseRepository
{
    protected readonly AppDbContext Context;
    private readonly IMapper _mapper;
    
    public BaseRepository(AppDbContext context)
    {
        Context = context;
        var config = new MapperConfiguration(cfg =>
        {
            cfg
                .CreateMap<WorkoutModel, Workout>()
                .ReverseMap();
            cfg
                .CreateMap<WorkoutMuscleModel, WorkoutMuscle>()
                .ReverseMap();
            cfg
                .CreateMap<Muscle, WorkoutMuscle>()
                .ForMember(entity => entity.Muscle, opt => opt.MapFrom(model => model))
                .ReverseMap();
            cfg.CreateMap<Muscle, Muscle>();
            // cfg
            //     .CreateMap<WorkoutMuscleModel, Muscle>()
            //     .ForMember(muscle => muscle , opt => opt.MapFrom(wm => wm.Muscle));
        });
        _mapper = new Mapper(config);
    }

    public Task<TModel> MapToModel<TEntity, TModel>(TEntity entity)
        where TModel : BaseModel 
        where TEntity : BaseEntity
    {
        return Task.FromResult(_mapper.Map<TEntity, TModel>(entity));
    }
    
    public Task<TEntity> MapToEntity<TModel, TEntity>(TModel model)
        where TModel : BaseModel 
        where TEntity : BaseEntity
    {
        return Task.FromResult(_mapper.Map<TModel, TEntity>(model));
    }

    public async Task<TModel> Set<TModel, TEntity>(TModel model)
        where TEntity : BaseEntity
        where TModel : BaseModel
    {
        var entity = await MapToEntity<TModel, TEntity>(model);
        await Context.Set<TEntity>().AddAsync(entity);
        await Context.SaveChangesAsync();
        return await MapToModel<TEntity, TModel>(entity);
    }

    public async Task<TModel> Get<TEntity, TModel>(Guid id)
        where TEntity : BaseEntity
        where TModel : BaseModel
    {
        var entity = await Context.FindAsync<TEntity>(id);
        return await MapToModel<TEntity, TModel>(entity);
    }
}