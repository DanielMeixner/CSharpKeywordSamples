using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VolatileKeywordSample
{
    public class GameStatus
    {
        private  volatile bool _stopFlag = false;

        public  bool StopFlag
        {
            get
            {
                return _stopFlag;
            }

            set
            {
                _stopFlag = value;
            }
        }
    }
}
