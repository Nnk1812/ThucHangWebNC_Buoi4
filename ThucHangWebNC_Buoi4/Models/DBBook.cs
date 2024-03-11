using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;


namespace ThucHangWebNC_Buoi4.Models
{
    public class DBBook : DbContext
    {
        public DBBook(DbContextOptions<DBBook> option) : base(option) { }
        public DbSet<Book> Books { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().HasKey(b => b.iBookID);
        }
        public void addbook(string bookName, string Author, int Yearpub, int noOfpage)
        {
                string sql = "EXECUTE addbook @bookname ,@author ,@yearpub ,@NoofPage";
                List<SqlParameter> parameters = new List<SqlParameter>
                {
                 new SqlParameter { ParameterName = "@bookname", Value = bookName },
                 new SqlParameter { ParameterName = "@author", Value = Author},
                 new SqlParameter { ParameterName = "@yearpub", Value = Yearpub},
                 new SqlParameter { ParameterName = "@NoofPage" , Value = noOfpage }
                };
                this.Database.ExecuteSqlRaw(sql, parameters.ToArray());
                this.SaveChanges();
        }
        public IQueryable<Book> view()
        {
            return this.Books.FromSqlRaw("select *from Book");
        }

    }
}
