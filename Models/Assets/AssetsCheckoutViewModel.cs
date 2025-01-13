﻿using STG_ERP.Models.Resources;
using System.ComponentModel.DataAnnotations;

namespace STG_ERP.Models.Assets
{
    public class AssetsCheckoutViewModel
    {
        public IEnumerable<Asset> ActiveAssets { get; set; }


        public IEnumerable<Resource> ActiveResources { get; set; }


        [Required(ErrorMessage = "This field is required")]
        public DateTime DateCreated { get; set; }

        [Required(ErrorMessage = "This field is required"), MinLength(1,ErrorMessage = "This field is required")]
        public List<String> SelResources { get; set; }


        [Required(ErrorMessage = "This field is required")]
        public List<AssetItem> SelAssetsItems { get; set; }
    }
}
