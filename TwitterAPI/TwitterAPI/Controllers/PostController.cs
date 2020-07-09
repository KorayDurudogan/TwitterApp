using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TwitterAPI.DAO;
using TwitterAPI.Models;
using TwitterAPI.Models.Token;
using TwitterAPI.ViewModels;

namespace TwitterAPI.Controllers
{
    public class PostController : TwitterController
    {
        private readonly IMapper Mapper;
        private readonly IDAO<Post> PostDao;

        public PostController(ILogedInUserProvider<User> userProvider, IDAO<Post> postDao, IMapper mapper) : base(userProvider)
        {
            this.PostDao = postDao;
            this.Mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PostVM postVm)
        {
            Post post = Mapper.Map<Post>(postVm);
            post.Owner = this.CurrentUser;

            this.PostDao.Insert(post);
            return Ok();
        }

        [HttpGet]
        [Route("{hashtag:alpha?}")]
        public async Task<IEnumerable<PostVM>> Get([FromQuery]string hashtag)
        {
            IEnumerable<Post> posts = PostDao.Get().Where(p => p.Owner.Id == this.CurrentUser.Id);

            foreach (int id in this.CurrentUser.Following)
            {
                IEnumerable<Post> indexPost = PostDao.Get().Where(p => p.Owner.Id == id);
                posts = posts.Concat(indexPost);
            }

            if (!string.IsNullOrEmpty(hashtag))
                posts = posts.Where(p => p.Hasthtags != null && p.Hasthtags.Contains(hashtag));

            return posts.Select(p => Mapper.Map<PostVM>(p));
        }
    }
}
