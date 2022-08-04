CREATE proc [dbo].[usp_stockmaster]
@product_id int=null,
@company_id int  =null,
@category_id int  =null,
@product_name nvarchar(50)=null, 
@product_desc nvarchar(50)=null,
@product_mrp decimal(18,2)=null,
@stock int=null,
@fin_yr nvarchar(50)=null,
@flag int 
as
begin

if(@flag=1)
begin
set @product_id=(SELECT isnull(max(product_id),0) FROM t_stock_master)
insert into t_stock_master(product_id,company_id_fk,category_id_fk,product_name,product_desc,
product_mrp,stock,fin_yr,created_date)
values(@product_id+1,@company_id,@category_id,@product_name,@product_desc,@product_mrp,@stock,
@fin_yr,getdate())
end
else if(@flag=2)
begin
update t_stock_master
set
company_id_fk=@company_id,
category_id_fk=@category_id,
product_name=@product_name,
product_desc=@product_desc,
product_mrp=@product_mrp,
stock=@stock,
fin_yr=@fin_yr,
updated_date=getdate()
where product_id=@product_id
end

else if(@flag=3)
begin
delete from t_stock_master where product_id=@product_id
end

else if(@flag=4)
begin
select stock.product_id as 'ProductId',company.company_name as 'CompanyName',
category.category_name as 'CategoryName',stock.product_name as 'ProductName',
stock.product_desc as 'ProductDesc',stock.product_mrp as 'ProductMRP',
stock.stock as 'Stock',stock.fin_yr as 'FinYear'
from t_stock_master as stock
left join t_company_master as company on company.company_id=stock.company_id_fk
left join t_category_master as category on category.category_id=stock.category_id_fk
where product_id=@product_id
end

else if(@flag=5)
begin
select company_id as 'CompanyId',company_name as 'CompanyName' from t_company_master
end
else if(@flag=6)
begin
SELECT isnull(max(product_id),0)+1 FROM t_stock_master
end
else if(@flag=7)
begin
select stock.product_id as 'ProductId',company.company_name as 'CompanyName',
category.category_name as 'CategoryName',stock.product_name as 'ProductName',
stock.product_desc as 'ProductDesc',stock.product_mrp as 'ProductMRP',
stock.stock as 'Stock',stock.fin_yr as 'FinYear'
from t_stock_master as stock
left join t_company_master as company on company.company_id=stock.company_id_fk
left join t_category_master as category on category.category_id=stock.category_id_fk
end
else if(@flag=8)
begin
select category_id as 'CategoryId',category_name as 'CategoryName' from t_category_master where company_id_fk=@company_id
end
else if(@flag=8)
begin
;WITH CTE AS
(
    SELECT YEAR(GETDATE()) - 5 AS d
    UNION ALL
    SELECT d + 1
    FROM CTE
    WHERE d < YEAR(GETDATE()) + 10
)
SELECT CAST(D AS VARCHAR) + '-' + CAST(D+1 AS VARCHAR) as 'FinYear'
FROM CTE
end
end

