## Functionality
####    Product List 
To access the list of projects
#### Add Product
To add new Product
#### Add Search
Search Product via Product Name, Size, Category, Price, Manufaturing Date or via combination of all.
    List of All matching Products will appear
## Technical
This project has been configured with SQL Server with KIT database.
Database columns are Id(Auto generated), Product Name, Size, Price, Mfg Date, Category.
Entity Framework has been used to seed and create the SQL Database.
Check Readme File for more details.
#### Appsettings.json
"ConnectionStrings": {
  "ProductConnectionString": "server=ZENO-SAMA\\SQLEXPRESS; database=KIT;TrustServerCertificate=true;Trusted_connection=true"
}
Change the Server with your local Server
