create proc [dbo].[usp_customermaster]
@customer_id int  =null,
@customer_name nvarchar(50)=null, 
@customer_mobile nvarchar(50)=null,
@customer_email nvarchar(50)=null,
@customer_dob date=null,
@customer_address nvarchar(200)=null,
@customer_occupation nvarchar(50)=null,
@channel nvarchar(50)=null,
@flag int 
as
begin

if(@flag=1)
begin
set @customer_id=(SELECT isnull(max(customer_id),0) FROM t_customer_master)
insert into t_customer_master(customer_id,customer_name,customer_mobile,
customer_email,customer_dob,customer_address,customer_occupation,channel,
created_date)
values(@customer_id+1,@customer_name,@customer_mobile,@customer_email,
@customer_dob,@customer_address,@customer_occupation,@channel,
getdate())
end
else if(@flag=2)
begin
update t_customer_master
set customer_name=@customer_name,
customer_mobile=@customer_mobile,
customer_email=@customer_email,
customer_dob=@customer_dob,
customer_address=@customer_address,
customer_occupation=@customer_occupation,
channel=@channel,
updated_date=getdate()
where customer_id=@customer_id
end

else if(@flag=3)
begin
delete from t_customer_master where customer_id=@customer_id
end

else if(@flag=4)
begin
select customer_id as 'CustomerId',customer_name as 'CustomerName',
customer_mobile as 'CustomerMobile',customer_email as 'CustomerEmail',
customer_dob as 'CustomerDOB',customer_address as 'CustomerAddress',
customer_occupation as 'CustomerOccupation',channel as 'Channel'
from t_customer_master
where customer_id=@customer_id

end

else if(@flag=5)
begin
select customer_id as 'CustomerId',customer_name as 'CustomerName',
customer_mobile as 'CustomerMobile',customer_email as 'CustomerEmail',
customer_dob as 'CustomerDOB',customer_address as 'CustomerAddress',
customer_occupation as 'CustomerOccupation',channel as 'Channel'
from t_customer_master
end
else if(@flag=6)
begin
SELECT isnull(max(customer_id),0)+1 FROM t_customer_master
end
end

