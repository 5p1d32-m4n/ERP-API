using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ERP_API.Models.Assets
{
    public class Asset
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public string AssetType { get; set; }
        
        public string Description { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public int CategoryId { get; set; }

        public string Brand { get; set; }

        public string Model { get; set; }

        public string Unit {get; set;}

        public decimal Cost { get; set; }

        public int Inventory {get; set;}

        public String Storage {get; set;}

        public int MinStockLevel {get; set;} = 0;
        
        [Required(ErrorMessage = "This field is required")]
        
        public bool Active { get; set; }

        public string Notes { get; set; }

        public AssetCategory Category { get; set; }

        public DateTime CreatedDate { get; set; }

        public String CreatedBy { get; set; }

        public bool LowLevelFlag { get; set; }

        public string GetLevelColor() {
            return "avatar-title border-success rounded-circle ";
        }

        public Asset()
        {
            this.Active = true;
        }
    }
}

