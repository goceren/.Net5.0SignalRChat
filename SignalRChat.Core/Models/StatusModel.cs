using SignalRChat.Core.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRChat.Core.Models
{
    public class StatusModel<T>
    {
        public T Entity { get; set; }

        public StatusModel Status { get; set; }

        public StatusModel()
        {
            Status = new StatusModel();
        }
    }

    public class StatusModel
    {
        private Enums.StatusEnum _status;

        public string Message { get; set; }


        public Enums.StatusEnum Status
        {
            get { return _status; }
            set
            {
                _status = value;
            }
        }

        public dynamic CustomData { get; set; }
    }
}
