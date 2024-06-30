using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalHelp.Application.Services.Post
{
    public interface IPostService
    {
        public List<Domain.Model.Post> GetAll();

        public Domain.Model.Post GetById(string id);

        public List<Domain.Model.Post> GetByIds(List<string> ids);

        public void Add(Domain.Model.Post post);

        public void Delete(string id);

        public Domain.Model.Post Update(string id,  Domain.Model.Post post);
    }
}
