using LinFu.AOP.Interfaces;

namespace LinFuInterceptorTools
{
    public class MethodReplacementProvider<T> : IMethodReplacementProvider where T : class 
    {
        public virtual bool CanReplace(object host, IInvocationInfo info)
        {
            return host is T;
        }

        public virtual IInterceptor GetMethodReplacement(object host, IInvocationInfo info)
        {
            return new MethodInterceptor();
        }
    }
}