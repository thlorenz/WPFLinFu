using System;
using LinFu.AOP.Interfaces;

namespace LinFuInterceptorTools
{
    public class SimpleAroundInvokeWrapper<T> : IInvokeWrapper
    {
        public Action<IInvocationInfo, object> AfterInvokeDelegate = delegate { };
        public Action<IInvocationInfo> BeforeInvokeDelegate = delegate { };
        public Action<IInvocationInfo> DoInvokeDelegate = delegate { };
        T _target;

        public SimpleAroundInvokeWrapper(T target)
        {
            _target = target;
        }

        public void AfterInvoke(IInvocationInfo info, object returnValue)
        {
            AfterInvokeDelegate(info, returnValue);
        }

        public void BeforeInvoke(IInvocationInfo info)
        {
            BeforeInvokeDelegate(info);
        }

        public object DoInvoke(IInvocationInfo info)
        {
            DoInvokeDelegate(info);
            info.TargetMethod.Invoke(_target, info.Arguments);
        }
    }
}