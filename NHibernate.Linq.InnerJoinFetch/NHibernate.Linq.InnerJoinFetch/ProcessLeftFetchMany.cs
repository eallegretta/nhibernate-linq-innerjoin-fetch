using NHibernate.Linq.Visitors;
using NHibernate.Linq.Visitors.ResultOperatorProcessors;
using Remotion.Linq.EagerFetching;

namespace NHibernate.Linq.InnerJoinFetch
{
    public class ProcessLeftFetchMany : ProcessFetch, IResultOperatorProcessor<FetchManyRequest>
    {
        public void Process(FetchManyRequest resultOperator, QueryModelVisitor queryModelVisitor, IntermediateHqlTree tree)
        {
            base.Process(resultOperator, queryModelVisitor, tree, false);
        }
    }
}
