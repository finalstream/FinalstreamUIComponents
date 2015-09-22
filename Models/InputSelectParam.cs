using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalstreamUIComponents.Models
{
    public class InputSelectParam : InputParam
    {
        public InputSelectParam(string title, object value, IEnumerable<string> values) : base(title, value, values)
        {
        }

        public override InputType InputType
        {
            get { return InputType.Select; }
        }
    }
}
