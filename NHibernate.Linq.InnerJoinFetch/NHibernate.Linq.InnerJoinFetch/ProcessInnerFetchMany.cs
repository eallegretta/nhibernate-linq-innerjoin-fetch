using NHibernate.Linq.Visitors;
using NHibernate.Linq.Visitors.ResultOperatorProcessors;

namespace NHibernate.Linq.InnerJoinFetch
{
    public class ProcessInnerFetchMany : ProcessFetch, IResultOperatorProcessor<InnerFetchManyRequest>
    {
        public void Process(InnerFetchManyRequest resultOperator, QueryModelVisitor queryModelVisitor, IntermediateHqlTree tree)
        {
            base.Process(resultOperator, queryModelVisitor, tree, true);
        }
    }
}
