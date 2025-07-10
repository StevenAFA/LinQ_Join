var products = new List<(string Name, int IdBrand)>
{
    ("Apple Watch", 1),
    ("Earphones", 1),
    ("Mobile phone", 2),
    ("Laptop", 2)
};
var brand = new List<(int IdBrand, string Name)>
{
    (1, "Apple"),
    (2, "Samsung")
};
var inventory = new List<(string ProductName, int Stock)>
{
    ("Apple Watch", 10),
    ("Earphones", 25),
    ("Mobile phone", 15),
    ("Laptop", 5)
};

var productsWithBrand = products.Join(brand, p => p.IdBrand, b => b.IdBrand,(p, b) => new{ProductName = p.Name,
                                                                                            BrandName = b.Name});

var productsDetail = productsWithBrand.Join(inventory,pb => pb.ProductName, i => i.ProductName,(pb, i) => 
                                                        new{pb.ProductName, pb.BrandName,Stock = i.Stock});
productsDetail.ToList().ForEach(p =>
{Console.WriteLine($"Producto: {p.ProductName}, Marca: {p.BrandName}, Inventario: {p.Stock}");});