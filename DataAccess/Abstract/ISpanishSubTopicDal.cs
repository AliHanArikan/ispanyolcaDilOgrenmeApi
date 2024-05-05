using EntityLayer;
using EntityLayer.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface ISpanishSubTopicDal :IRepository<SpanishSubTopic>
    {
        public Task<IEnumerable<SpanishSubTopic>> GetSpanishSubTopicWithSpanishTopicId(int id); 

        public Task<PagedList<SpanishSubTopic>> GetAllWithPagination(SpanishSubTopicParameters spanishSubTopicParameters);
    }
}
