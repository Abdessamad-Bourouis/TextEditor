using AutoMapper;
using BusinessLogicLayer.Repository.IRepository;
using DataAccessLayer;
using DataAccessLayer.Data;
using DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Repository
{
    public class CategoryRepository: ICategoryRepository
    {
        private readonly AppDBContext _dBContext;
        private readonly IMapper _mapper;
        public CategoryRepository(AppDBContext dBContext, IMapper mapper)
        {
            _dBContext = dBContext;
            _mapper = mapper;
        }

        public async Task<CategoryDTO> Create(CategoryDTO categoryDTO)
        {

                //M1)
                //Category category = new Category 
                //{
                //    Id = categoryDTO.Id,
                //    Name = categoryDTO.Name,
                //    CeatedDate = DateTime.Now
                //};
            try
            {
                //M2)
                var Obj = _mapper.Map<CategoryDTO, Category>(categoryDTO);
                Obj.CeatedDate= DateTime.Now;
                var AddedObj= _dBContext.Categories.Add(Obj);
                await _dBContext.SaveChangesAsync();

                return _mapper.Map<Category,CategoryDTO > (AddedObj.Entity);
                //return categoryDTO;
            }
            catch (Exception)
            {
                return new CategoryDTO();
            }
            
        }

        public async Task<bool> Delete(int id)
        {
           var Obj=await _dBContext.Categories.FirstOrDefaultAsync(x => x.Id == id);
            if(Obj != null)
            {
                _dBContext.Categories.Remove(Obj);
                await _dBContext.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<List<CategoryDTO>> GetAll()
        {
            return _mapper.Map<List<Category>,List<CategoryDTO>>(_dBContext.Categories.ToList());
        }

        public async Task<CategoryDTO> GetById(int id)
        {
            var Obj = await _dBContext.Categories.FirstOrDefaultAsync(x => x.Id == id);
            if (Obj != null)
            {
                return _mapper.Map<Category, CategoryDTO>(Obj);
            }
            return new CategoryDTO ();
        }

        public async Task<CategoryDTO> Update(CategoryDTO categoryDTO)
        {
            var Obj = await _dBContext.Categories.FirstOrDefaultAsync(x => x.Id == categoryDTO.Id);
            if (Obj != null)
            {
                Obj.Name = categoryDTO.Name;
                _dBContext.Categories.Update(Obj);
                await _dBContext.SaveChangesAsync();

                return _mapper.Map<Category, CategoryDTO>(Obj);
            }
            return new CategoryDTO();
        }
    }
}
