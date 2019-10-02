using System.Collections.Generic;
using XMLGenerator.DAL.Interface;

namespace XMLGenerator.DAL
{
    public class DataReader
    {
        private readonly IDataReader reader;

        public DataReader(IDataReader dataReader)
        {
            reader = dataReader;
        }  
        
        public IEnumerable<string> ReadData()
        {
            return reader.GetData();
        }
    }
}
