using AutoMapper;
using ManagementProductProject.Services.IServices.IConvertToDTOService;

namespace ManagementProductProject.Services.Service.ConvertToDTOService
{
    public class ConvertToDTOService<TEntity, TEntityDTO> : 
        IConvertToDTOService<TEntity, TEntityDTO> 
        where TEntityDTO : class
        where TEntity : class 
    {

        protected readonly IMapper _Mapper;

        public ConvertToDTOService(IMapper mapper)
        {
            _Mapper = mapper;
        }
    

        public TEntityDTO Convert(TEntity entity)
        {

            var DtoObj = _Mapper.Map<TEntityDTO>(entity);
            return DtoObj; 

        }

        public IEnumerable<TEntityDTO> Convert(IEnumerable<TEntity> entity)
        {

            List<TEntityDTO> DtoObjs = new List<TEntityDTO>(); 
            foreach (var item in entity)
            {
                DtoObjs.Add(_Mapper.Map<TEntityDTO>(item)); 
            }

            return DtoObjs;  

        }
    }
}
