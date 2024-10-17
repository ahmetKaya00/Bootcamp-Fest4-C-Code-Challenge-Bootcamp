using System.ComponentModel.DataAnnotations;
using efcoreapp.Data;

namespace efcoreapp.Models
{

    public class BootcampViewModel
    {
        public int BootcampId { get; set; }

        [Required(ErrorMessage = "Bootcamp Başlığı zorunlu")]
        [StringLength(70)]
        public string? Baslik { get; set; }
        public int OgretmenId { get; set; }
        public ICollection<BootcampKayit> KursKayitlari { get; set; } = new List<BootcampKayit>();

    }
}