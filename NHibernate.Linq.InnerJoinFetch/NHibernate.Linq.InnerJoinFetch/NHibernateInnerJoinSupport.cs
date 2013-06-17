using System;
using System.Collections.Generic;
using System.Reflection;
using NHibernate.Linq.InnerJoinFetch.Parsing;
using NHibernate.Linq.Visitors;
using NHibernate.Linq.Visitors.ResultOperatorProcessors;
using Remotion.Linq.EagerFetching;
using Remotion.Linq.Parsing.Structure;
using Remotion.Linq.Parsing.Structure.NodeTypeProviders;

namespace NHibernate.Linq.InnerJoinFetch
{
    public static class NHibernateInnerJoinSupport
    {
        public static void Enable()
        {
            var queryParser = typeof(NhRelinqQueryParser).GetField("QueryParser", BindingFlags.Static | BindingFlags.NonPublic).GetValue(null) as QueryParser;

            if (queryParser == null)
            {
                throw new NullReferenceException("The QueryParser field was not found");
            }

            var nhNodeTypeProvider = queryParser.NodeTypeProvider as NHibernateNodeTypeProvider;

            var nodeTypeProvider = nhNodeTypeProvider.GetType().GetField("defaultNodeTypeProvider", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(nhNodeTypeProvider) as CompoundNodeTypeProvider;

            var methodInfoRegistry = new MethodInfoBasedNodeTypeRegistry();

            methodInfoRegistry.Register(new[] { typeof(EagerFetchingExtensionMethods).GetMethod("InnerFetch") }, typeof(InnerFetchOneExpressionNode));
            methodInfoRegistry.Register(new[] { typeof(EagerFetchingExtensionMethods).GetMethod("InnerFetchMany") }, typeof(InnerFetchManyExpressionNode));
            methodInfoRegistry.Register(new[] { typeof(EagerFetchingExtensionMethods).GetMethod("ThenInnerFetch") }, typeof(ThenInnerFetchOneExpressionNode));
            methodInfoRegistry.Register(new[] { typeof(EagerFetchingExtensionMethods).GetMethod("ThenInnerFetchMany") }, typeof(ThenInnerFetchManyExpressionNode));

            nodeTypeProvider.InnerProviders.Add(methodInfoRegistry);

            var resultOperatorMap = typeof(QueryModelVisitor).GetField("ResultOperatorMap", BindingFlags.Static | BindingFlags.NonPublic).GetValue(null) as ResultOperatorMap;

            if (resultOperatorMap == null)
            {
                throw new NullReferenceException("The ResultOperatorMap field was not found");
            }

            var innerMap = typeof(ResultOperatorMap).GetField("_map", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(resultOperatorMap) as Dictionary<System.Type, ResultOperatorProcessorBase>;

            if (innerMap == null)
            {
                throw new NullReferenceException("The _map field was not found");
            }

            innerMap.Remove(typeof(FetchOneRequest));
            innerMap.Remove(typeof(FetchManyRequest));


            resultOperatorMap.Add<FetchOneRequest, ProcessLeftFetchOne>();
            resultOperatorMap.Add<FetchManyRequest, ProcessLeftFetchMany>();
            resultOperatorMap.Add<InnerFetchOneRequest, ProcessInnerFetchOne>();
            resultOperatorMap.Add<InnerFetchManyRequest, ProcessInnerFetchMany>();
        }
    }
}
