using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Dungeons.Models
{
    public class RegularExpressionListAttribute : RegularExpressionAttribute
    {
        public RegularExpressionListAttribute(string pattern) : base(pattern) { }

        public override bool IsValid(object value)
        {
            if(value is not IEnumerable<string>)
            {
                return false;
            }

            foreach (var val in value as IEnumerable<string>)
            {
                if (!Regex.IsMatch(val, Pattern))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
