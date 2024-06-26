using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using blockBackend.Models;
using blockBackend.Services.Context;

namespace blockBackend.Services
{
    public class BlogService
    {

        private readonly DataContext _context;

        public BlogService(DataContext context)
        {
            _context = context;
        }
        public bool AddBlogItem(BlogItemModel newBlogItem)
        {
            _context.Add(newBlogItem);
            return _context.SaveChanges() != 0;
        }

        // IEnumberable is a link method that enables iteration over a collection of objects (BlogItemModel). This allows access to each object one by one
        public IEnumerable<BlogItemModel> GetAllBlogItems()
        {
            return _context.BlogInfo;
        }

        public IEnumerable<BlogItemModel> GetItemsByUserId(int userId)
        {
            // Where is another link method to filter things
            return _context.BlogInfo.Where(item => item.UserID == userId);
        }

        public IEnumerable<BlogItemModel> GetItemsByCategory(string category)
        {
            return _context.BlogInfo.Where(item => item.Categories == category);
        }

        public IEnumerable<BlogItemModel> GetPublishedItems()
        {
            return _context.BlogInfo.Where(item => item.IsPublished);
        }

        public List<BlogItemModel> GetAllItemsByTags(string tag)
        {
            // if there are multiple things to filter and iterate through, use List instead of IEnumberable, because it will be faster
            // tags will come out like this: tag1, tag2, tag3
            var allItems = GetAllBlogItems().ToList();

            var filteredItems = allItems.Where(item => item.Tags.Split(",").Contains(tag)).ToList();

            return filteredItems;
        }

        public BlogItemModel GetBlogItemById(int id)
        {
            return _context.BlogInfo.SingleOrDefault(item => item.ID == id);
        }

        public bool UpdateBlogItem(BlogItemModel blogUpdate)
        {
            _context.Update<BlogItemModel>(blogUpdate);
            return _context.SaveChanges() != 0;
        }

        public bool DeleteBlogItem(BlogItemModel blogToDelete)
        {
            blogToDelete.IsDeleted = true;
            _context.Update<BlogItemModel>(blogToDelete);
            return _context.SaveChanges() != 0;
        }
    }
}