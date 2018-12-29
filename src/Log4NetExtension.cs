using log4net;
using System;
using Unity.Builder;
using Unity.Extension;
using Unity.Policy;

namespace Unity.log4net
{
    public class Log4NetExtension : UnityContainerExtension
    {
        private static readonly Func<Type, string> _defaultGetName = (t) => t.FullName;

        public Func<Type, string> GetName { get; set; }

        protected override void Initialize()
        {
            Context.Policies.Set(typeof(ILog), null, typeof(ResolveDelegateFactory), (ResolveDelegateFactory)GetResolver);
        }

        public ResolveDelegate<BuilderContext> GetResolver(ref BuilderContext context)
        {
            Func<Type, string> method = GetName ?? _defaultGetName;

            return (ref BuilderContext c) => LogManager.GetLogger(method(c.DeclaringType));
        }
    }
}
