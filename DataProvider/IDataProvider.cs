using System.Collections.Generic;

namespace DataProvider
{
    public interface IDataProvider<T>
    {
        void Write(List<T> data);
        T Read();
    }
}
