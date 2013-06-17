using NHibernate.Linq.Visitors;
using NHibernate.Linq.Visitors.ResultOperatorProcessors;

namespace NHibernate.Linq.InnerJoinFetch
{
    public class ProcessInnerFetchOne : ProcessFetch, IResultOperatorProcessor<InnerFetchOneRequest>
    {
        public void Process(InnerFetchOneRequest resultOperator, QueryModelVisitor queryModelVisitor, IntermediateHqlTree tree)
        {
            base.Process(resultOperator, queryModelVisitor, tree, true);
        }
    }
}
