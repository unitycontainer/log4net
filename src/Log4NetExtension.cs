using log4net;
using System;
using System.Security;
using Unity.Builder;
using Unity.Extension;
using Unity.Policy;
using Unity.Resolution;

namespace Unity.log4net
{
    [SecuritySafeCritical]
    public class Log4NetExtension : UnityContainerExtension
    {
        protected override void Initialize()
        {
            Context.Policies.Set(typeof(ILog), typeof(ResolveDelegateFactory), (ResolveDelegateFactory)GetResolver);
        }

        public ResolveDelegate<BuilderContext> GetResolver(ref BuilderContext context)
        {
            Type declaringType = context.DeclaringType;

            return (ref BuilderContext c) => LogManager.GetLogger(c.DeclaringType);
        }
    }
}
