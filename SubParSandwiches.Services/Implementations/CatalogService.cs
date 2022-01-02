using SubParSandwiches.Entities;
using SubParSandwiches.Repositories.Interfaces;
using SubParSandwiches.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace SubParSandwiches.Services.Implementations
{
    public class CatalogService : ICatalogService
    {
        private readonly IRepository<Item> _itemRepository;
        private readonly IRepository<Category> _categoryRepository;
        private readonly IRepository<ItemType> _itemTypeRepository;

        public CatalogService(IRepository<Item> itemRepository, IRepository<Category> categoryRepository,
            IRepository<ItemType> itemTypeRepository)
        {
            _itemRepository = itemRepository;
            _categoryRepository = categoryRepository;
            _itemTypeRepository = itemTypeRepository;
        }

        public void AddItem(Item item)
        {
            _itemRepository.Add(item);
            _itemRepository.SaveChanges();
        }

        public void DeleteItem(int id)
        {
            _itemRepository.Delete(id);
            _itemRepository.SaveChanges();
        }

        public IEnumerable<Category> GetCategories()
        {
            return _categoryRepository.GetAll();
        }

        public Item GetItem(int id)
        {
            return _itemRepository.Find(id);
        }

        public IEnumerable<Item> GetItems()
        {
            return _itemRepository.GetAll()
                .OrderBy(item => item.CategoryId)
                .ThenBy(item => item.ItemTypeId);
        }

        public IEnumerable<ItemType> GetItemTypes()
        {
            return _itemTypeRepository.GetAll();
        }

        public void UpdateItem(Item item)
        {
            _itemRepository.Update(item);
            _itemRepository.SaveChanges();
        }
    }
}
