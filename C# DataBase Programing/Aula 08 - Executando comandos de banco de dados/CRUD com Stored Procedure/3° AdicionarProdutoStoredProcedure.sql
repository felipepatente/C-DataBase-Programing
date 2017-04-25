/*
Cria um procedimento que adiciona uma linha à tabela Produtos usando valores passados como 
parâmetros para o procedimento. O procedimento retorna o ProductID da nova linha usando uma instrução 
RETURN e retorna um conjunto de resultados que contém a nova linha
*/

CREATE PROCEDURE AddProduct3
	@MyProductName VARCHAR(40),
	@MySupplierID INT,
	@MyCategoryID INT,
	@MyQuantityPerUnit VARCHAR(20),
	@MyUnitPrice DECIMAL(5,2),
	@MyUnitsInStock SMALLINT,
	@MyUnitsOnOrder SMALLINT,
	@MyReorderLevel SMALLINT,
	@MyDiscontinued BIT
AS
	--Declarar a variável @MyProductID
	DECLARE @MyProductID INT
	
	--Inserir uma linha na tabela Produtos
	INSERT INTO Products(
		ProductName, SupplierID, CategoryID, QuantityPerUnit, UnitPrice, UnitsInStock,
		UnitsOnOrder, ReoderLevel, Discontinued
	)
	
	VALUES(
		@MyProductName, @MySupplierID, @MyCategoryID, @MyQuantityPerUnit, @MyUnitPrice,
		@MyUnitsInStock, @MyUnitsOnOrder, MyReorderLevel, @MyDiscontinued
	)
	
	/*
	Use a função SCOPE_IDENTITY para obter o último valor de identidade inserido em uma tabela 
	executada dentro da sessão de banco de dados atual e procedimento armazenado, para SCOPE_IDENTITY 
	retorna o ProductID para a nova linha na tabela de produtos neste caso
	*/
	
	SET @MyProductID = SCOPE_IDENTITY()
	
	
	--Retornar o conjunto de resultados
	SELECT ProductName, UnitPrice
	FROM Products
	WHERE ProductID = @MyProductID
	
	-- Retorna @MyProductID
	RETURN @MyProductID
	
	
	