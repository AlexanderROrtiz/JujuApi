﻿using Business;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using PostEntity = DataAccess.Data.Post;

namespace API.Controllers.Post
{
    [Route("[controller]")]
    public class PostController : ControllerBase
    {
        private BaseService<PostEntity> PostService;
        public PostController(BaseService<PostEntity> postService)
        {
            PostService = postService;
        }

        [HttpGet()]
        public IQueryable<PostEntity> GetAll()
        {
            return PostService.GetAll();
        }

        [HttpPost()]
        public PostEntity Create([FromBodyAttribute]  PostEntity entity)
        {
            return PostService.Create(entity);
        }

        [HttpPut()]
        public PostEntity Update(PostEntity entity)
        {
            return PostService.Update(entity.PostId, entity, out bool changed);
        }

        [HttpDelete()]
        public PostEntity Delete([FromBodyAttribute] PostEntity entity)
        {
            return PostService.Delete(entity);
        }


    }
}
