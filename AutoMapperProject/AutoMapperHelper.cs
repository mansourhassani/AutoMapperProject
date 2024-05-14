using AutoMapper;

namespace AutoMapperProject
{
    public static class AutoMapperHelper<TEntity, TDto>
    {
        public static TEntity ConvertToEntity(TDto dto, IMapper mapper)
        {
            return mapper.Map<TEntity>(dto);
        }

        public static TDto ConvertToDto(TEntity entity, IMapper mapper)
        {
            return mapper.Map<TDto>(entity);
        }
    }
}
