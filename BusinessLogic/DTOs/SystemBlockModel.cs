using BusinessLogic.Services;
using Data_Access.Entities;

namespace BusinessLogic.DTOs
{
    public class SystemBlockModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImagePath { get; set; }
        public decimal Price { get; set; }
        public int[] ProductIds { get; set; }

        //public int ProcessorId { get; set; }
        //public int CoolerId { get; set; }
        //public int MotherboardId { get; set; }
        //public int RAMId { get; set; }
        //public int VideoCardId { get; set; }
        //public int SSDId { get; set; }
        //public int HDDId { get; set; }
        //public int WiFiAdapterId { get; set; }
        //public int PowerSupplyId { get; set; }
        //public int CablesId { get; set; }
        //public int VentilatorsId { get; set; }
        //public int CaseId { get; set; }
        //public int SoftwareId { get; set; }



        //public SystemBlock ConvertToSystemBlock(List<Product> products)
        //{
        //    SystemBlock systemBlock = new SystemBlock();
        //    systemBlock.Name = this.Name;
        //    systemBlock.Price = this.Price;
        //    systemBlock.ImagePath = this.ImagePath;

        //    //systemBlock.Products.Add(productsService.Get(this.ProcessorId)!);
        //    //systemBlock.Products.Add(productsService.Get(this.CoolerId)!);
        //    //systemBlock.Products.Add(productsService.Get(this.MotherboardId)!);
        //    //systemBlock.Products.Add(productsService.Get(this.RAMId)!);
        //    //systemBlock.Products.Add(productsService.Get(this.VideoCardId)!);
        //    //systemBlock.Products.Add(productsService.Get(this.SSDId)!);
        //    //systemBlock.Products.Add(productsService.Get(this.HDDId)!);
        //    //systemBlock.Products.Add(productsService.Get(this.WiFiAdapterId)!);
        //    //systemBlock.Products.Add(productsService.Get(this.PowerSupplyId)!);
        //    //systemBlock.Products.Add(productsService.Get(this.CablesId)!);
        //    //systemBlock.Products.Add(productsService.Get(this.VentilatorsId)!);
        //    //systemBlock.Products.Add(productsService.Get(this.CaseId)!);
        //    //systemBlock.Products.Add(productsService.Get(this.SoftwareId)!);

        //    systemBlock.Products = new List<Product>
        //    {
        //        products.Where(p => p.Id == this.ProcessorId).First(),
        //        products.Where(p => p.Id == this.CoolerId).First(),
        //        products.Where(p => p.Id == this.MotherboardId).First(),
        //        products.Where(p => p.Id == this.RAMId).First(),
        //        products.Where(p => p.Id == this.VideoCardId).First(),
        //        products.Where(p => p.Id == this.SSDId).First(),
        //        products.Where(p => p.Id == this.HDDId).First(),
        //        products.Where(p => p.Id == this.WiFiAdapterId).First(),
        //        products.Where(p => p.Id == this.PowerSupplyId).First(),
        //        products.Where(p => p.Id == this.CablesId).First(),
        //        products.Where(p => p.Id == this.VentilatorsId).First(),
        //        products.Where(p => p.Id == this.CaseId).First(),
        //        products.Where(p => p.Id == this.SoftwareId).First()
        //    };

        //    return systemBlock;
        //}
    }
}
