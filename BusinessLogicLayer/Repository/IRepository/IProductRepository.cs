using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Repository.IRepository
{
    public interface IProductRepository
    {
        public Task<ProductDTO> Create(ProductDTO productDTO);
        public Task<ProductDTO> Update(ProductDTO productDTO);
        public Task<bool> Delete(int id);
        public Task<ProductDTO> GetById(int id);
        public Task<List<ProductDTO>> GetAll();
    }
}
