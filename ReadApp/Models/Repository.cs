namespace ReadApp.Models{

    public class Repository{

        private static readonly List<Product> _products = new();
        private static readonly List<Category> _categories = new();

        static Repository(){
            _categories.Add(new Category{CategoryId = 1, Name = "Roman"});
            _categories.Add(new Category{CategoryId = 2, Name = "Hikaye"});

            _products.Add(new Product{ProductId = 1, Name= "Son Ayı",Pages=250,Image="1.png",IsActive=true,CategoryId=2});
            _products.Add(new Product{ProductId = 2, Name= "Tarık Buğra'nın Roman Dünyası",Pages=350,Image="2.png",IsActive=true,CategoryId=1});
            _products.Add(new Product{ProductId = 3, Name= "Cadı",Pages=350,Image="3.png",IsActive=true,CategoryId=1});
        }

        public static List<Product> Products{get{return _products;}}
        public static void CreateProduct(Product entity){
            _products.Add(entity);
        }

        public static void EditProduct(Product updateProduct){
            var entity = _products.FirstOrDefault(p=>p.ProductId == updateProduct.ProductId);
            if(entity != null){
                entity.Name = updateProduct.Name;
                entity.Pages = updateProduct.Pages;
                entity.Image = updateProduct.Image;
                entity.CategoryId = updateProduct.CategoryId;
                entity.IsActive = updateProduct.IsActive;
            }
        }

        public static void DeleteProduct(Product entity){
            var prdEntity = _products.FirstOrDefault(p=>p.ProductId == entity.ProductId);

            if(prdEntity != null){
                _products.Remove(prdEntity);
            }
        }
        public static List<Category> Categories{get{return _categories;}}
    }
}