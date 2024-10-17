using System.ComponentModel.DataAnnotations;

namespace efcoreapp.Data{

    public class Bootcamp{

        [Key]
        public int BootcampId {get;set;}
        public string? Baslik {get;set;}
        public int OgretmenId {get;set;}
        public Ogretmen Ogretmen {get;set;} = null!;
        public ICollection<BootcampKayit> KursKayitlari {get;set;} = new List<BootcampKayit>();
    }
}