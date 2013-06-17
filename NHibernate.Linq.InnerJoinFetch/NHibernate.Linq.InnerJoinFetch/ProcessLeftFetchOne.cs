using NHibernate.Linq.Visitors;
using NHibernate.Linq.Visitors.ResultOperatorProcessors;
using Remotion.Linq.EagerFetching;

namespace NHibernate.Linq.InnerJoinFetch
{
    public class ProcessLeftFetchOne : ProcessFetch, IResultOperatorProcessor<FetchOneRequest>
    {
        public void Process(FetchOneRequest resultOperator, QueryModelVisitor queryModelVisitor, IntermediateHqlTree tree)
        {
            base.Process(resultOperator, queryModelVisitor, tree, false);
        }
    }
}
