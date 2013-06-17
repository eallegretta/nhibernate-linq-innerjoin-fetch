using System.Linq.Expressions;
using Remotion.Linq.EagerFetching;
using Remotion.Linq.EagerFetching.Parsing;
using Remotion.Linq.Parsing.Structure.IntermediateModel;

namespace NHibernate.Linq.InnerJoinFetch.Parsing
{
    public class ThenInnerFetchManyExpressionNode : ThenFetchExpressionNodeBase
    {
        public ThenInnerFetchManyExpressionNode(MethodCallExpressionParseInfo parseInfo, LambdaExpression relatedObjectSelector)
            : base(parseInfo, relatedObjectSelector)
        {
        }

        protected override FetchRequestBase CreateFetchRequest()
        {
            return new InnerFetchManyRequest(base.RelationMember);
        }
    }
}
