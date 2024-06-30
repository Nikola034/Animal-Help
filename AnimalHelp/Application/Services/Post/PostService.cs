using AnimalHelp.Domain.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalHelp.Application.Services.Post
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;

        public PostService(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public void Add(Domain.Model.Post post)
        {
            _postRepository.Add(post);
        }

        public void Delete(string id)
        {
            _postRepository.Delete(id);
        }

        public List<Domain.Model.Post> GetAll()
        {
            return _postRepository.GetAll();
        }

        public Domain.Model.Post GetById(string id)
        {
            return _postRepository.Get(id);
        }

        public List<Domain.Model.Post> GetByIds(List<string> ids)
        {
            return _postRepository.Get(ids);
        }

        public Domain.Model.Post Update(string id, Domain.Model.Post post)
        {
            return _postRepository.Update(id, post);
        }
    }
}
