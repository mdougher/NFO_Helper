using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFO_Helper
{
    class DataProviderException : System.Exception
    {
        public DataProviderException( string text ) :
            base( text )
        {
        }
    }
    class NfoReadWriteException : System.Exception
    {
        public NfoReadWriteException( string text ) :
            base( text )
        {

        }
    }
}
