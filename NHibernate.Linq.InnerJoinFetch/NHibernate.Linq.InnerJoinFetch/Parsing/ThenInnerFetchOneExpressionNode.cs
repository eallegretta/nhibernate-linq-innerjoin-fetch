using System.Linq.Expressions;
using Remotion.Linq.EagerFetching;
using Remotion.Linq.EagerFetching.Parsing;
using Remotion.Linq.Parsing.Structure.IntermediateModel;

namespace NHibernate.Linq.InnerJoinFetch.Parsing
{
    public class ThenInnerFetchOneExpressionNode : ThenFetchExpressionNodeBase
    {
        public ThenInnerFetchOneExpressionNode(MethodCallExpressionParseInfo parseInfo, LambdaExpression relatedObjectSelector)
            : base(parseInfo, relatedObjectSelector)
        {
        }

        protected override FetchRequestBase CreateFetchRequest()
        {
            return new InnerFetchOneRequest(base.RelationMember);
        }
    }
}
