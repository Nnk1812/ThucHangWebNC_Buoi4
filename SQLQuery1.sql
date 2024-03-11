create database book
use book

CREATE TABLE Book (
    iBookID INT PRIMARY KEY IDENTITY,
    sBookname NVARCHAR(100),
    sAuthor NVARCHAR(100),
    iYearPub INT,
    iNoOfPages INT
);

create proc addbook
@bookname nvarchar(100),
@author nvarchar(100),
@yearpub int,
@NoofPage int
as
begin
insert into Book
values(@bookname, @author, @yearpub, @NoofPage)
end

exec addbook N'Sach', N'Khanh', 1, 2
select *from Book