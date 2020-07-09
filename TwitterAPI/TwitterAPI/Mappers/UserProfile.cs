using AutoMapper;
using TwitterAPI.Models;
using TwitterAPI.ViewModels;

namespace TwitterAPI.Mappers
{
    /// <summary>
    /// A class for mapping from UserVM to User.
    /// </summary>
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserVM, User>();
            CreateMap<User, IdentityVM>();

            CreateMap<Post, PostVM>();
            CreateMap<PostVM, Post>();
        }
    }
}
