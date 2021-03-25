using BeautyStore.BeautyStoreModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;


namespace BeautyStoreDL
{
    //By inheriting the DbContext class, I am establishing an is-a relationship between BeautyStoreDBContext 
    //and the dbcontext ==> BeautyStoredbcontext is a dbcontext.
    public class BeautyStoreDBContext : IdentityDbContext
    {
        public BeautyStoreDBContext(DbContextOptions options) : base(options)
        {
        }

        protected BeautyStoreDBContext()
        {
        }
        //To declare to EF Core that these are the models I want to be persisted to my db
        public DbSet<BeautyProduct> BeautyProducts { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Manager> Managers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //To say that I want a self incrementing primary key

            modelBuilder.Entity<Order>()
                .Property(Order => Order.OrderId)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<Location>()
                .Property(Location => Location.LocationId)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<Item>()
                .Property(Item =>Item.ItemsId)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<Inventory>()
                .Property(Inventory => Inventory.InventoriesId)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<Customer>()
                .Property(Customer => Customer.CustomerID)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<BeautyProduct>()
                .Property(BeautyProduct => BeautyProduct.ProductId)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<Manager>()
                .Property(Manager => Manager.ManagerID)
                .ValueGeneratedOnAdd();

            // //I want to say that my customer has 1-m relationship with Shopping Carts
            // //One customer can have many Shopping Carts, but a Shopping Cart can only belong to one customer.
            // modelBuilder.Entity<Customer>()
            //     .HasMany(c => c.ShoppingCarts)
            //     .WithOne(s => s.Customer)
            //     .OnDelete(DeleteBehavior.Cascade); //to delete everything that depends on it.
            // //Customer has a one to many relationship with orders
            // //one customer can have many orders, but an order can only belong to one customer.
            // //if a customer account is deleted, then we will delete everything that belongs to it.
            // modelBuilder.Entity<Customer>()
            //     .HasMany(c => c.Orders)
            //     .WithOne(o => o.Customer)
            //     .OnDelete(DeleteBehavior.SetNull);
           //  //A location can have many carts, but a cart can only belong to one location (1-m)
           //  modelBuilder.Entity<Location>()
           //      .HasMany(l => l.ShoppingCarts)
           //      .WithOne(s => s.Location)
           //      .OnDelete(DeleteBehavior.Cascade);
           //  //A location can have many orders, but an order can only belong to one location (1-m)
           //  modelBuilder.Entity<Location>()
           //      .HasMany(l => l.Orders)
           //      .WithOne(o => o.Location)
           //      .OnDelete(DeleteBehavior.SetNull);
           //  //show that join table reference the other two tables
           //  modelBuilder.Entity<Item>()
           //      .HasKey(i => new { i.ShoppingCartId, i.ProductId });
           //  //relationship b/w products and items 
           //  modelBuilder.Entity<BeautyProduct>()
           //      .HasMany(bp => bp.Items)
           //      .WithOne(i => i.BeautyProducts)
           //      .HasForeignKey(i => i.ProductId);
           //  //Item has one Shopping Cart; cart with many items
           //  modelBuilder.Entity<Item>()
           //      .HasOne(i => i.ShoppingCarts)
           //      .WithMany(s => s.Items)
           //      .HasForeignKey(i => i.ShoppingCartId);
           //  //one manager manages three locations
           //  modelBuilder.Entity<Location>()
           //      .HasOne(l => l.Manager)
           //      .WithMany(m => m.Location);
           //  //modelBuilder.Entity<Inventory>()
           //      //.HasKey(inv => new { inv.LocationId, inv.ProductId });
           //  //one location has many inventories
           //  modelBuilder.Entity<Location>()
           //      .HasMany(l => l.Inventory)
           //      .WithOne(inv => inv.Location)
           //      .HasForeignKey(inv => inv.LocationId);
           // // modelBuilder.Entity<Inventory>()
           //      //.HasMany(inv => inv.BeautyProducts)
           //      //.WithOne(bp => bp.Inventory)
           //      //.HasForeignKey(inv => inv.ProductId);
           //  modelBuilder.Entity<ShoppingCart>()
           //      .HasMany(s => s.BeautyProduct)
           //      .WithOne(bp => bp.ShoppingCart);
           //  modelBuilder.Entity<Order>()
           //      .HasMany(o => o.Items)
           //      .WithOne(i => i.Orders)
           //      .HasForeignKey(i => i.OrderId);
        }
    }
}
