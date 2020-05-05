CREATE PROCEDURE [dbo].[spProduct_GetAll]
AS
begin
	set nocount on;

	Select Id, ProductName, [Description], RetailPrice, QuantityInStock, IsTaxable
	from [dbo].[Product]
	order by ProductName;
end
