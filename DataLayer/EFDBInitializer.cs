using System;
using BusinessLayer.Domain;
using System.Data.Entity;

namespace DataLayer
{
    public class EFDBInitializer :  DropCreateDatabaseIfModelChanges<EFDBContex>
    {   
        protected override void Seed(EFDBContex context)
        {
            context.Customers.Add(new Customer { CustomerId = Guid.Parse("a956f5a5-140f-4980-817f-c413cdeeeee1"), Address = "Москва", Code = "3696-2019", Discount = 3, Name = "Дмитрий", UserName = "Customer1@mail.ru" });
            context.Customers.Add(new Customer { CustomerId = Guid.Parse("d6fadd9f-8968-4fc1-b24e-2a6462f8411f"), Address = "Питер", Code = "7458-2019", Discount = 1, Name = "Олег", UserName = "Oleg@mail.ru" });
            context.Customers.Add(new Customer { CustomerId = Guid.Parse("c0fd27c4-26be-4a4f-8674-6a4df0977695"), Address = "Нижний", Code = "1259-2019", Discount = 4, Name = "Иван", UserName = "Ivan@mail.ru" });
            context.Customers.Add(new Customer { CustomerId = Guid.Parse("9f42ab46-99ca-4887-9a2a-b77324a8debb"), Address = "Верхний", Code = "3210-2019",  Name = "Толя", UserName = "Tolik@mail.ru" });

            context.Items.Add(new Item { ItemId = Guid.NewGuid(), Code = "92-1527-XB86", Name = "Колбаса сырокопченая РЕМИТ", Price = 88, CategoryId = Guid.Parse("147cb83f-7dc1-40f1-9137-88b48eebd9cf") });
            context.Items.Add(new Item { ItemId = Guid.NewGuid(), Code = "86-8025-VT91", Name = "Бисквит KINDER Delice шоколадный,", Price = 78954, CategoryId = Guid.Parse("75ae89be-06b0-459a-b929-ea2de0d2de68") });
            context.Items.Add(new Item { ItemId = Guid.NewGuid(), Code = "63-4184-OI22", Name = "Хлеб HARRY'S пшеничный", Price = 145, CategoryId = Guid.Parse("1ac7ab0b-aa28-437d-8ef3-170b22721b9e") });
            context.Items.Add(new Item { ItemId = Guid.NewGuid(), Code = "65-5095-PL32", Name = "САХАР ПЕСОК ARO", Price = 78954, CategoryId = Guid.Parse("67f7dc3a-59cc-48b1-9e28-6c4eb79afdf9") });

            context.Categories.Add(new Category { CategoryId = Guid.Parse("147cb83f-7dc1-40f1-9137-88b48eebd9cf"), Name= "Мясная гастрономия" });
            context.Categories.Add(new Category { CategoryId = Guid.Parse("75ae89be-06b0-459a-b929-ea2de0d2de68"), Name = "Молочные продукты" });
            context.Categories.Add(new Category { CategoryId = Guid.Parse("1ac7ab0b-aa28-437d-8ef3-170b22721b9e"), Name = "Хлеб" });
            context.Categories.Add(new Category { CategoryId = Guid.Parse("67f7dc3a-59cc-48b1-9e28-6c4eb79afdf9"), Name = "Бакалея" });

            context.Statuses.Add(new Status { StatusId = Guid.Parse("11a8a790-8c06-4b89-af04-e0c30322e31f"), Name = "Новый" });
            context.Statuses.Add(new Status { StatusId = Guid.Parse("7f2ed500-14f7-470a-a55f-cf929b843cbd"), Name = "Выполняется" });
            context.Statuses.Add(new Status { StatusId = Guid.Parse("ff73416a-0631-4C2f-96ef-447dae7ab639"), Name = "Выполнен" });
            context.SaveChanges();

            base.Seed(context);
        }
    }
}
