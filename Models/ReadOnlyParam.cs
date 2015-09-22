using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalstreamUIComponents.Models
{
    public class ReadOnlyParam : InputParam
    {
        public ReadOnlyParam(string title, object value) : base(title, value)
        {
        }

        public override InputType InputType
        {
            get { return InputType.ReadOnly; }
        }
    }
}
