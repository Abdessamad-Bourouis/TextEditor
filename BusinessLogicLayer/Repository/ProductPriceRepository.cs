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
    public class ProductPriceRepository: IProductPriceRepository
    {
        private readonly AppDBContext _dBContext;
        private readonly IMapper _mapper;
        public ProductPriceRepository(AppDBContext dBContext, IMapper mapper)
        {
            _dBContext = dBContext;
            _mapper = mapper;
        }

        public async Task<ProductPriceDTO> Create(ProductPriceDTO productPriceDTO)
        {
            try
            {
                var Obj = _mapper.Map<ProductPriceDTO, ProductPrice>(productPriceDTO);

                var AddedObj= _dBContext.ProductPrices.Add(Obj);
                await _dBContext.SaveChangesAsync();

                return _mapper.Map<ProductPrice, ProductPriceDTO> (AddedObj.Entity);
            }
            catch (Exception)
            {
                return new ProductPriceDTO();
            }
            
        }

        public async Task<bool> Delete(int id)
        {
           var Obj=await _dBContext.ProductPrices.FirstOrDefaultAsync(x => x.id == id);
            if(Obj != null)
            {
                _dBContext.ProductPrices.Remove(Obj);
                await _dBContext.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<List<ProductPriceDTO>> GetAll(int? id = null)
        {
            if(id!=null && id > 0)
            {
                return _mapper.Map<List<ProductPrice>,List<ProductPriceDTO>>(_dBContext.ProductPrices.Where(p=>p.ProductId==id).ToList());
            }
            else
            {
                return _mapper.Map<List<ProductPrice>, List<ProductPriceDTO>>(_dBContext.ProductPrices.ToList());
            }
        }

        public async Task<ProductPriceDTO> GetById(int id)
        {
            var Obj = await _dBContext.ProductPrices.FirstOrDefaultAsync(x => x.id == id);
            if (Obj != null)
            {
                return _mapper.Map<ProductPrice, ProductPriceDTO>(Obj);
            }
            return new ProductPriceDTO();
        }

        public async Task<ProductPriceDTO> Update(ProductPriceDTO productPriceDTO)
        {
            var Obj = await _dBContext.ProductPrices.FirstOrDefaultAsync(x => x.id == productPriceDTO.id);
            if (Obj != null)
            {
                Obj.Price = productPriceDTO.Price;
                Obj.Size = productPriceDTO.Size;
                Obj.ProductId = productPriceDTO.ProductId;
                _dBContext.ProductPrices.Update(Obj);
                await _dBContext.SaveChangesAsync();

                return _mapper.Map<ProductPrice, ProductPriceDTO>(Obj);
            }
            return new ProductPriceDTO();
        }
    }
}
