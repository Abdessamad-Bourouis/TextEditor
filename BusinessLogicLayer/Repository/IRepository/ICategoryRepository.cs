using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Repository.IRepository
{
    public interface ICategoryRepository
    {
        public  Task<CategoryDTO> Create(CategoryDTO categoryDTO);
        public  Task<CategoryDTO> Update(CategoryDTO categoryDTO);
        public  Task<bool> Delete(int id);  
        public  Task<CategoryDTO> GetById(int id);
        public  Task<List<CategoryDTO>> GetAll();
    }
}
