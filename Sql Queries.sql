create table productType (
   id int not null identity(1,1) primary key,
   product_name nvarchar(50) not null
 )

 create table category (
   id int not null identity(1,1) primary key,
   product_name nvarchar(50) not null,
   category_name nvarchar(50) not null
 )

 create table subCategory (
   id int not null identity(1,1) primary key,
   product_name nvarchar(50) not null,
   category_name nvarchar(50) not null,
   subCategory_name nvarchar(50) not null
 )

 create table inventoryMaster (
   id int not null identity(1,1) primary key,
   productType nvarchar(50) not null,
   categoryName nvarchar(50) not null,
   subCategoryName nvarchar(50) not null,
   productName nvarchar(50) not null,
   sellingPrice nvarchar(50) not null,
   stockLimit nvarchar(50) not null,
   stockReorderPoint nvarchar(50) not null,
   stockInHand nvarchar(50) not null,
   taxCategory nvarchar(50),
   createdOn date
 )

 create table customerMaster (
   id int not null identity(1,1) primary key,
   customerName nvarchar(50) not null,
   address nvarchar(100),
   contactNo nvarchar(50),
   alternateContact nvarchar(50),
   age nvarchar(50),
   gender nvarchar(50),
   email nvarchar(50),
   remarks nvarchar(50)
 )

 create table customerPower(
   id int not null identity(1,1) primary key,
   customerId int not null,
   rsph nvarchar(50),
   rcyl nvarchar(50),
   raxis nvarchar(50),
   rvn nvarchar(50),
   lsph nvarchar(50),
   lcyl nvarchar(50),
   laxis nvarchar(50),
   lvn nvarchar(50),
   radd nvarchar(50),
   ladd nvarchar(50),
   pd nvarchar(50),
   refBy nvarchar(50),
   lensType nvarchar(50),
   bookingDate date,
   prgRight nvarchar(50),
   prgLeft nvarchar(50),
   ppRight nvarchar(50),
   ppLeft nvarchar(50),
   ppAdd nvarchar(50),
   remarks nvarchar(50),
   createdOn date
)

  drop table productType
  drop table category
  drop table subCategory
  drop table inventoryMaster
  drop table customerMaster
  drop table customerPower