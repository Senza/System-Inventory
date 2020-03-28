CREATE PROCEDURE [dbo].[spProduct_GetAll]
AS
begin
	set nocount on;

	Select Id, ProductName, [Description], RetailPrice, QuantityInStock
	from [dbo].[Product]
	order by ProductName;
end
