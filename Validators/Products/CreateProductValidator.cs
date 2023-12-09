namespace CleanArchitecture.Validators.Products
{
    public class CreateProductValidator
    {
        public string name {  get; set; }
        public string description { get; set; }
        public decimal price { get; set; }
        public int idCategory { get; set; }
    }
}
