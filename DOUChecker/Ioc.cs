using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;

namespace DOUChecker
{
    public class Ioc
    {
        private static Lazy<IKernel> _kernel = new Lazy<IKernel>(() => new StandardKernel());

        private static IKernel Kernel
        {
            get { return _kernel.Value; }
        }

        public static object Get(Type objectType)
        {
            return Kernel.Get(objectType);
        }

        public static T Get<T>()
        {
            return Kernel.Get<T>();
        }

        public static void Init(Action<IKernel> initLogic)
        {
            if (initLogic != null)
                initLogic(Kernel);
        }

        public static void Reset()
        {
            _kernel = new Lazy<IKernel>(() => new StandardKernel());
        }
    }
}