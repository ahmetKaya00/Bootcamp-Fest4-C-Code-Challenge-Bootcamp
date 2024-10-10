namespace basics.Models{
    public class Repository{

        private static readonly List<Bootcamp> _bootcamps = new();

        static Repository(){
            _bootcamps = new List<Bootcamp>(){
            new Bootcamp(){Id = 1, Title = ".Net Core Bootcamp", Description = "Güzel bir bootcamp", Image = "1.png"},
            new Bootcamp(){Id = 2, Title = "Game Bootcamp", Description = "Güzel bir bootcamp", Image = "2.png"},
            new Bootcamp(){Id = 3, Title = "Frouned Bootcamp", Description = "Güzel bir bootcamp", Image = "3.png"},
            };
        }

        public static List<Bootcamp> Bootcamps{get{return _bootcamps;}}

        public static Bootcamp? GetById(int? id){
            return _bootcamps.FirstOrDefault(b=>b.Id == id);
        }
    }
}