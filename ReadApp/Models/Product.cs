using System.ComponentModel.DataAnnotations;

namespace ReadApp.Models{

    public class Product{

        public int ProductId {get;set;}

        [Display(Name = "Ürün Adı")]
        [Required(ErrorMessage = "Ürün adı zorunlu")]
        [StringLength(100)]
        public string Name {get;set;} = string.Empty;

        [Required(ErrorMessage = "Sayfa Sayısı adı zorunlu")]
        [Range(0,50000)]
        [Display(Name = "Sayfa Sayısı")]
        public decimal? Pages {get;set;}

        [Display(Name = "Görsel")]
        public string? Image {get;set;} = string.Empty;
        public bool IsActive {get;set;}

        [Required(ErrorMessage = "Categori adı zorunlu")]
        [Display(Name = "Categori")]
        public int? CategoryId{get;set;}

    }
}