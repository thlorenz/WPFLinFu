using System;
using LinFu.AOP.Interfaces;

namespace LinFuInterceptorTools
{
    public class MethodInterceptor : IInterceptor
    {
        public object Intercept(IInvocationInfo info)
        {
            var methodName = info.TargetMethod.Name;

            Console.WriteLine("method '{0}' called", methodName);

            return info.TargetMethod;
        }
    }
}