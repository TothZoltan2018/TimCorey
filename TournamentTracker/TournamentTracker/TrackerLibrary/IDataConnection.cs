using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerLibrary
{
    public interface IDataConnection
    {
        /// <summary>
        /// Saves prizes. In the model input parameter the id field is empty. Wnen it is ouutput,
        /// the id is filled out.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        PrizeModel CreatePrize(PrizeModel model);
    }
}
