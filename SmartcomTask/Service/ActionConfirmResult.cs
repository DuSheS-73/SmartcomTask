using System.Collections.Generic;
using System.Linq;

namespace SmartcomTask.Service
{
    public class ActionConfirmResult
    {
        public bool Success { get { return Errors == null || !Errors.Any(); } }
        public List<string> Errors { get; set; }
    }
}
