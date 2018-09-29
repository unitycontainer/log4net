using log4net;
using System;
using Unity.Builder;
using Unity.Extension;
using Unity.Policy;

namespace Unity.log4net
{
    public class Log4NetExtension : UnityContainerExtension, IBuildPlanPolicy
    {
        private static readonly Func<Type, string, string> _defaultGetName = (t, n) => t.FullName;

        public Func<Type, string, string> GetName { get; set; }

        protected override void Initialize()
        {
            Context.Policies.Set(typeof(ILog), null, typeof(IBuildPlanPolicy), this);
        }

        public void BuildUp<TBuilderContext>(ref TBuilderContext context)
            where TBuilderContext : IBuilderContext
        {
            Func<Type, string, string> method = GetName ?? _defaultGetName;
#if NETSTANDARD1_3
            context.Existing = LogManager.GetLogger(context.ParentContext?.BuildKey.Type);
#else
            context.Existing = LogManager.GetLogger(method(context.ParentContext?.BuildKey.Type,
                                                           context.ParentContext?.BuildKey.Name));
#endif
            context.BuildComplete = true;
        }

    }
}
