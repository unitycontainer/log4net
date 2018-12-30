using log4net;
using System;
using System.Runtime.CompilerServices;
using System.Security;
using Unity.Builder;
using Unity.Extension;
using Unity.Policy;

namespace Unity.log4net
{
    [SecuritySafeCritical]
    public class Log4NetExtension : UnityContainerExtension
    {
        private static readonly Func<Type, string> _defaultGetName = (t) => t.FullName;

        public Func<Type, string> GetName { get; set; }

        protected override void Initialize()
        {
            Context.Policies.Set(typeof(ILog), string.Empty, typeof(ResolveDelegateFactory), (ResolveDelegateFactory)GetResolver);
        }

        public ResolveDelegate<BuilderContext> GetResolver(ref BuilderContext context)
        {
            var method = GetName ?? _defaultGetName;
            Type declaringType;

            unsafe
            {
                var parenContext = Unsafe.AsRef<BuilderContext>(context.Parent.ToPointer());
                declaringType = parenContext.RegistrationType;
            }

            return (ref BuilderContext c) => LogManager.GetLogger(method(declaringType));
        }
    }
}
