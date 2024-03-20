using blockBackend.Models;
using blockBackend.Services;
using Microsoft.AspNetCore.Mvc;

namespace blockBackend.Controllers;

[ApiController]
[Route("[controller]")]
public class BlogController : ControllerBase
{

    private readonly BlogService _data;

    public BlogController(BlogService data)
    {
        _data = data;
    }


    [HttpPost]
    [Route("AddBlogItem")]
    public bool AddBlogItem(BlogItemModel newBlogItem)
    {
        return _data.AddBlogItem(newBlogItem);
    }

    [HttpGet]
    [Route("GetAllBlogitems")]
    public IEnumerable<BlogItemModel> GetAllBlogItems()
    {
        return _data.GetAllBlogItems();
    }

    [HttpGet]
    [Route("GetItemsByUserId/{userId}")]
    public IEnumerable<BlogItemModel> GetItemsByUserId(int userId)
    {
        return _data.GetItemsByUserId(userId);
    }

    [HttpGet]
    [Route("GetItemsByCategory/{category}")]
    public IEnumerable<BlogItemModel> GetItemsByCategory(string category)
    {
        return _data.GetItemsByCategory(category);
    }

    [HttpGet]
    [Route("GetPublishedItems")]
    public IEnumerable<BlogItemModel> GetPublishedItems()
    {
        return _data.GetPublishedItems();
    }

    [HttpGet]
    [Route("GetAllItemsByTags/{tag}")]
    public List<BlogItemModel> GetAllItemsByTags(string tag)
    {
        return _data.GetAllItemsByTags(tag);
    }

    [HttpGet]
    [Route("GetBlogItemById/{id}")]
    public BlogItemModel GetBlogItemById(int id)
    {
        return _data.GetBlogItemById(id);
    }

    [HttpPut]
    [Route("UpdateBlogItem")]
    public bool UpdateBlogItem(BlogItemModel blogUpdate)
    {
        return _data.UpdateBlogItem(blogUpdate);
    }

    [HttpDelete]
    [Route("DeleteBlogItem")]
    public bool DeleteBlog(BlogItemModel blogToDelete)
    {
        return _data.DeleteBlogItem(blogToDelete);
    }

}
