namespace LinFuInterceptorTools
{
    public static class ObjectExtensions
    {
        public static T As<T>(this object original)
        {
            return (T)original;
        }
    }
}