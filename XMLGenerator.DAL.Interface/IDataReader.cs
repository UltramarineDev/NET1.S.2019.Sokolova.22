using System.Collections.Generic;

namespace XMLGenerator.DAL.Interface
{
    public interface IDataReader
    {
        IEnumerable<string> GetData();
    }
}
