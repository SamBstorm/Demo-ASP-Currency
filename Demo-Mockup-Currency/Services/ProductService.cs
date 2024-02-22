using Demo_Mockup_Currency.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo_Mockup_Currency.Services
{
    public class ProductService
    {
        private static Dictionary<Guid,Product> _products= new Dictionary<Guid, Product>();

        public ProductService()
        {
        }

        public IEnumerable<Product> Get()
        {
            return _products.Values;
        }
        public Product Get(Guid id)
        {
            return _products[id];
        }

        public Guid Insert(Product entity) {
            
            if (entity is null) throw new ArgumentNullException(nameof(entity));
            entity.ProductId = Guid.NewGuid();
            _products.Add(entity.ProductId, entity);
            return entity.ProductId;
        }

        public void Update(Product entity)
        {
            if(entity is null) throw new ArgumentNullException( nameof(entity));
            if (!_products.ContainsKey(entity.ProductId)) throw new ArgumentOutOfRangeException(nameof(entity.ProductId));
            _products[entity.ProductId] = entity;
        }

        public void Delete(Guid id)
        {
            if (!_products.ContainsKey(id)) throw new ArgumentOutOfRangeException(nameof(id));
            _products.Remove(id);
        }
    }
}
