using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Persistence;

namespace API.Controllers{
  [ApiController]
  [Route("api/[controller]")]
  public class PostsController : ControllerBase{
    private readonly DataContext context;
    public PostsController(DataContext context){
      this.context = context;
    }

    // Get api/posts
    [HttpGet(Name = "GetPosts")]
    public ActionResult<List<Post>> Get(){
      return this.context.Posts.ToList();
    }

    // <summary>
    // Get api/post[id]
    // </summary>
    // parm nam = id
    // returns single post
    [HttpGet("{id}", Name = "GetById")]
    public ActionResult<Post> GetById(Guid id){
      var post = this.context.Posts.Find(id);
      if(post is null){
        return NotFound();
      }

      return Ok(post);
    }
      
    [HttpPost(Name = "Create")]
    public ActionResult<Post> Create([FromBody]Post request){
      var post = new Post{
        Id = request.Id,
        Title = request.Title,
        Body = request.Body,
        Date = request.Date
      };

      context.Posts.Add(post);
      var success = context.SaveChanges() > 0;
      if(success){
        return Ok(post);
      }

      throw new Exception("Error creating post");
    }
  }
}