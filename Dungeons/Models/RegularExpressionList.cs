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

        public override bool IsValid(object list)
        {
            if(list is not IEnumerable<string>)
            {
                return false;
            }

            foreach (var item in list as IEnumerable<string>)
            {
                if (!Regex.IsMatch(item, Pattern))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
