namespace atividade_01.Models
{
  class Product
  {
    public int Id { get; set; }
    public string Name { get; set; }

    public Product(string name)
    {
      this.Id = 0;
      this.Name = name;
    }

    public void UpdateFrom(Product product)
    {
      this.Name = product.Name;
    }

    public override string ToString() {
      return $"Id: {this.Id}, Name: {this.Name}";
    }

    public string ToJson(){
      return $"{{\n  \"id\": {this.Id},\n  \"name\": \"{this.Name}\"\n}}";
    }
  }
}