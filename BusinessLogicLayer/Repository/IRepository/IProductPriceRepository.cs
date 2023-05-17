using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Repository.IRepository
{
    public interface IProductPriceRepository
    {
        public Task<ProductPriceDTO> Create(ProductPriceDTO categoryDTO);
        public Task<ProductPriceDTO> Update(ProductPriceDTO categoryDTO);
        public Task<bool> Delete(int id);
        public Task<ProductPriceDTO> GetById(int id);
        public Task<List<ProductPriceDTO>> GetAll(int? id=null);
    }
}
