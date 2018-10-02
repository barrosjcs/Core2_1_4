using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap01.TagHelpers
{
    public class EmailTagHelper : TagHelper
    {
        public string MaitTo { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "a";
            var address = $"{MaitTo}@fiap.com";
            output.Attributes.SetAttribute("href", $"mailto:{address}");
            output.Content.SetContent(address);
        }
    }
}
