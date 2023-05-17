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
    public class ProductRepository: IProductRepository
    {
        private readonly AppDBContext _dBContext;
        private readonly IMapper _mapper;
        public ProductRepository(AppDBContext dBContext, IMapper mapper) 
        {
            _dBContext = dBContext;
            _mapper = mapper;
        }

        public async Task<ProductDTO> Create(ProductDTO productDTO)
        {
            try
            {
               var Obj = _mapper.Map<ProductDTO, Product>(productDTO);

                
                var AddedObj = _dBContext.Products.Add(Obj);
                await _dBContext.SaveChangesAsync();

                return productDTO;
            }
            catch (Exception)
            {
                return new ProductDTO();
            }
        }

        public async Task<bool> Delete(int id)
        {
            var Obj = await _dBContext.Products.FirstOrDefaultAsync(x => x.Id == id);
            if (Obj != null)
            {
                _dBContext.Products.Remove(Obj);
                await _dBContext.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<List<ProductDTO>> GetAll()
        {
            return _mapper.Map<List<Product>, List<ProductDTO>>(_dBContext.Products.Include(u => u.Category).Include(x => x.ProductPrices).ToList());
        }

        public async Task<ProductDTO> GetById(int id)
        {
            var Obj = await _dBContext.Products.Include(u=>u.Category).Include(u=>u.ProductPrices).FirstOrDefaultAsync(x => x.Id == id);
            if (Obj != null)
            {
                return _mapper.Map<Product, ProductDTO>(Obj);
            }
            return new ProductDTO();
        }

        public async Task<ProductDTO> Update(ProductDTO productDTO)
        {
            var Obj = await _dBContext.Products.FirstOrDefaultAsync(x => x.Id == productDTO.Id);
            if (Obj != null)
            {
                Obj.Name = productDTO.Name;
                Obj.Description = productDTO.Description;
                Obj.ImageUrl= productDTO.ImageUrl;
                Obj.CategoryId = productDTO.CategoryId;
                Obj.Color= productDTO.Color;
                Obj.Shopfavorites = productDTO.Shopfavorites;
                Obj.CustomerFavorites = productDTO.CustomerFavorites;
                _dBContext.Products.Update(Obj);
                await _dBContext.SaveChangesAsync();

                return _mapper.Map<Product, ProductDTO>(Obj);
            }
            return new ProductDTO();
        }
    }
}
