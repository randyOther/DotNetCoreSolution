//using PostSharp.Aspects;
//using PostSharp.Serialization;
using Autofac.Core;
using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Randy.FrameworkCore.aspects
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface, AllowMultiple = true)]
    public sealed class InterceptAttribute : Attribute
    {
        /// <summary>
        /// Gets the interceptor service.
        /// </summary>
        public Service InterceptorService { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="InterceptAttribute"/> class.
        /// </summary>
        /// <param name="interceptorService">The interceptor service.</param>
        /// <exception cref="System.ArgumentNullException">interceptorService</exception>
        public InterceptAttribute(Service interceptorService)
        {
            if (interceptorService == null)
                throw new ArgumentNullException("interceptorService");

            InterceptorService = interceptorService;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InterceptAttribute"/> class.
        /// </summary>
        /// <param name="interceptorServiceName">Name of the interceptor service.</param>
        public InterceptAttribute(string interceptorServiceName)
            : this(new KeyedService(interceptorServiceName, typeof(IInterceptor)))
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InterceptAttribute"/> class.
        /// </summary>
        /// <param name="interceptorServiceType">The typed interceptor service.</param>
        public InterceptAttribute(Type interceptorServiceType)
            : this(new TypedService(interceptorServiceType))
        {
        }
    }
}
