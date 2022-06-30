using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.CustomTagHelpers
{
    public class EmailTagHelper : TagHelper
    {
        // if the custom tag you need is email  ie <emial></email>
        // then name the file as email taghelper.cs file

        // for email we need atleast an address and content
        public string Address { get; set; }
        public string content { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            // this is the method used to process the custom tag helper
            // we want following tags for email tag
            // a-anchor tag
            // atrributes- content, addresss, href
            //what happen is 
            ////<email  address ="" content ="">clcik here</a></email>
            /////the content and address will pass to anchor tag
            ///// here dymancally we are creating anchor tag  based on request
            
            output.TagName = "a";
            output.Attributes.SetAttribute("href", "mailto:" + Address);
            output.Content.SetContent(content);

        
        }
    }
}
