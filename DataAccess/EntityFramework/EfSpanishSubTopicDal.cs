using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.Repositories;
using EntityLayer;
using EntityLayer.RequestFeatures;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace DataAccess.EntityFramework
{
    public class EfSpanishSubTopicDal : Repository<SpanishSubTopic>, ISpanishSubTopicDal
    {
        public async Task<PagedList<SpanishSubTopic>> GetAllWithPagination(SpanishSubTopicParameters spanishSubTopicParameters)
        {
            using(Context context = new Context())
            {
                var values = await context.SpanishSubTopics.ToListAsync();
                   
                values = values.OrderBy(b => b.SpanishTopicId)
                    .ToList();

                return PagedList<SpanishSubTopic>
                    .ToPagedList(values,
                                spanishSubTopicParameters.PageNumber,
                                spanishSubTopicParameters.PageSize);
            }
        }

        public async Task<IEnumerable<SpanishSubTopic>> GetSpanishSubTopicWithSpanishTopicId(int id)
        {
            using (Context context = new Context())
            {
               return await context.SpanishSubTopics.Where(x => x.SpanishTopicId == id).ToListAsync();
                
            }
        }
    }
}
