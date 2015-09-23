using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalstreamUIComponents.Models
{
    public class InputListParam : InputParam
    {
        public InputListParam(string title, IEnumerable<string> values) : base(title, values)
        {
        }

        public override InputType InputType
        {
            get { return InputType.List; }
        }
    }
}
