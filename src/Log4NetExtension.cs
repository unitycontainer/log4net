using log4net;
using System;
using Unity.Builder;
using Unity.Extension;
using Unity.Policy;

namespace Unity.log4net
{
    public class Log4NetExtension : UnityContainerExtension, IBuildPlanPolicy
    {
        private static readonly Func<Type, string> _defaultGetName = (t) => t.FullName;

        public Func<Type, string> GetName { get; set; }

        protected override void Initialize()
        {
            Context.Policies.Set(typeof(ILog), null, typeof(IBuildPlanPolicy), this);
        }

        public void BuildUp(ref BuilderContext context)
        {
            Func<Type, string> method = GetName ?? _defaultGetName;
#if NETSTANDARD1_3
            context.Existing = LogManager.GetLogger(context.DeclaringType);
#else
            context.Existing = LogManager.GetLogger(method(context.DeclaringType));
#endif
            context.BuildComplete = true;
        }

    }
}
