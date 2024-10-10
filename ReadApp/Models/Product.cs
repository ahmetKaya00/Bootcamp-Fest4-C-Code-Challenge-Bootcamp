using System.ComponentModel.DataAnnotations;

namespace ReadApp.Models{

    public class Product{

        public int ProductId {get;set;}

        [Display(Name = "Ürün Adı")]
        [Required]
        public string Name {get;set;} = string.Empty;

        [Display(Name = "Sayfa Sayısı")]
        public decimal Pages {get;set;}

        [Display(Name = "Görsel")]
        public string Image {get;set;} = string.Empty;
        public bool IsActive {get;set;}

        [Display(Name = "Categori")]
        public int CategoryId{get;set;}

    }
}