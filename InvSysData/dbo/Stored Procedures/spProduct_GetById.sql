CREATE PROCEDURE [dbo].[spProduct_GetById]
	@Id int
AS
begin
	set nocount on;

	Select Id, ProductName, [Description], RetailPrice, QuantityInStock, IsTaxable
	from [dbo].[Product]
	where Id = @Id;
end
