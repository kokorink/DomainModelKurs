using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using DomainModel;

namespace WebApplication1.API
{
    public class QuestionsAPI : ApiController
    {
        // GET api/category
        public IEnumerable<Questions> Get()
        { 
            //var userId = await accountService.GetUserId(stamp.ToString());

            //var result = await categoryService.GetCategory(userId);
            //Mapper.Initialize(cfg => cfg.CreateMap<CategoryDTO, CategoryModel>()
            //       .ForMember(d => d.CategoryID, opt => opt.MapFrom(c => c.CategoryId))
            //       .ForMember(d => d.Name, opt => opt.MapFrom(c => c.CategoryName))
            //  );


            //IEnumerable<CategoryModel> allcategory = Mapper.Map<IEnumerable<CategoryDTO>, IEnumerable<CategoryModel>>(
            //    result.Item1.AsEnumerable()
            //    ); 
            IGenericRepository<Questions> RepQ = new GenericRepository<Questions>();
            List<Questions> ListQ = RepQ.GetAll().ToList();
            return ListQ;

           // return allcategory;
        }

    }
}