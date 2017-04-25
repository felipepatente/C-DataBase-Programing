/*
Cria um procedimento que adiciona uma linha à tabela Produtos usando valores passados como parâmetros 
para o procedimento. O procedimento retorna o ProductID da nova linha usando uma instrução RETURN
*/

CREATE PROCEDURE AddProduct2
	@MyProductName VARCHAR(40),
	@MySupplierID INT,
	@MyCategoryID INT,
	@MyQuantityPerUnit VARCHAR(20),
	@MyUnitPrice DECIMAL(5,2),
	@MyUnitsInStock SMALLINT,
	@MyUnitsOnOrder SMALLINT,
	@MyReoderLevel SMALLINT,
	@MyDiscontinued BIT
AS
	-- Declarar a variável @MyProductyID
	DECLARE @MyProductID INT
	
	
	-- Insira uma linha na tabela Produtos
	INSERT INTO Products(
		ProductName, SupplierID, CategoryID, QuantityPerUnit, UnitPrice, UnitsInStock, UnitsOnOrder,
		ReorderLevel, Discontinued
	)
	
	VALUES(
		@MyProductName, @MySupplierID, @MyCategoryID, @MyQuantityPerUnit, @MyUnitPrice, @MyUnitsInStock,
		@MyUnitsOnOrder, @MyReoderLevel, @MyDiscontinued
	)
	
	/*
		Use a função SCOPE_IDENTITY () para obter o último valor de identidade inserido em uma tabela 
		executada dentro da sessão de banco de dados atual e procedimento armazenado, SCOPE_IDENTITY 
		retorna o ProductID para a nova linha na tabela produtos neste caso
	*/
	
	RETURN @MyProductID
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	