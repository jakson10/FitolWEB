using FitOl.WebUI.ApiServices.Interfaces;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitOl.WebUI.TagHelpers
{
    [HtmlTargetElement("getfoodimage")]
    public class FoodImageTagHelper : TagHelper
    {
        private readonly IImageApiService _imageApiService;
        public FoodImageTagHelper(IImageApiService imageApiService)
        {
            _imageApiService = imageApiService;
        }
        public int Id { get; set; }
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var blob = await _imageApiService.GetFoodImageByIdAsync(Id);
            string html = string.Empty;

            html = $"<img src='{blob}' style='width: 50px; height: 50px; border-radius:50%; border:1px solid #999;  object-fit:cover; object-position: 50% 1%;'/>";

            output.Content.SetHtmlContent(html);
        }
    }
}
