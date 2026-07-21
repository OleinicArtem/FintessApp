USE Training;
GO

-- Создание представлений для отображения данных
CREATE VIEW vw_Customers AS
SELECT 
    ROW_NUMBER() OVER (ORDER BY C.Id_customer) AS RowNum,
    C.Id_customer AS 'ID',
    C.C_fullname AS 'Full Name',
    C.Customer_telefon_number AS 'Phone Number',
    C.IDNP AS 'IDNP',
    C.Adress AS 'Address',
    A.abonement_type_name AS 'Abonement Type'
FROM CUSTOMER C
JOIN ABONEMENT AB ON C.Id_abonement = AB.Id_abonement
JOIN Abonement_type A ON AB.Id_abonement_type = A.Id_abonement_type;
GO

CREATE VIEW vw_Trainers AS
SELECT 
    ROW_NUMBER() OVER (ORDER BY T.Id_trainer) AS RowNum,
    T.Id_trainer AS 'ID',
    T.T_fullname AS 'Full Name',
    T.Trainer_telefon_number AS 'Phone Number',
    S.Specialozation_name AS 'Specialization'
FROM TRAINER T
JOIN Specialization S ON T.id_specialization = S.Id_specialization;
GO

CREATE VIEW vw_Abonements AS
SELECT 
    ROW_NUMBER() OVER (ORDER BY A.Id_abonement) AS RowNum,
    A.Id_abonement AS 'ID',
    A.VALIDITY AS 'Validity (Days)',
    AT.abonement_type_name AS 'Abonement Type',
    AT.Abonement_price AS 'Price'
FROM ABONEMENT A
JOIN Abonement_type AT ON A.Id_abonement_type = AT.Id_abonement_type;
GO

CREATE VIEW vw_Trainings AS
SELECT 
    ROW_NUMBER() OVER (ORDER BY T.Id_training_type, T.Training_date) AS RowNum,
    T.Id_training_type AS 'Training Type ID',
    TT.training_type_name AS 'Training Type',
    T.Training_date AS 'Date',
    TR.T_fullname AS 'Trainer',
    C.C_fullname AS 'Customer'
FROM TRAINING T
JOIN Training_type TT ON T.Id_training_type = TT.Id_training_type
JOIN TRAINER TR ON T.Id_trainer = TR.Id_trainer
JOIN CUSTOMER C ON T.Id_customer = C.Id_customer;
GO

-- Хранимая процедура для фильтрации клиентов
CREATE PROCEDURE sp_FilterCustomers
    @FullName NVARCHAR(50) = NULL,
    @PhoneNumber NVARCHAR(9) = NULL,
    @AbonementTypeId SMALLINT = NULL
AS
BEGIN
    SELECT 
        ROW_NUMBER() OVER (ORDER BY C.Id_customer) AS RowNum,
        C.Id_customer AS 'ID',
        C.C_fullname AS 'Full Name',
        C.Customer_telefon_number AS 'Phone Number',
        C.IDNP AS 'IDNP',
        C.Adress AS 'Address',
        A.abonement_type_name AS 'Abonement Type'
    FROM CUSTOMER C
    JOIN ABONEMENT AB ON C.Id_abonement = AB.Id_abonement
    JOIN Abonement_type A ON AB.Id_abonement_type = A.Id_abonement_type
    WHERE 
        (@FullName IS NULL OR C.C_fullname LIKE '%' + @FullName + '%')
        AND (@PhoneNumber IS NULL OR C.Customer_telefon_number LIKE '%' + @PhoneNumber + '%')
        AND (@AbonementTypeId IS NULL OR AB.Id_abonement_type = @AbonementTypeId);
END;
GO

-- Хранимая процедура для статистики
CREATE PROCEDURE sp_GetStatistics
AS
BEGIN
    -- Общее количество клиентов
    SELECT 'Total Customers' AS Statistic, COUNT(*) AS Value FROM CUSTOMER;
    
    -- Средняя стоимость абонемента
    SELECT 'Average Abonement Price' AS Statistic, AVG(Abonement_price) AS Value FROM Abonement_type;
    
    -- Минимальная/максимальная стоимость абонемента
    SELECT 'Min Abonement Price' AS Statistic, MIN(Abonement_price) AS Value FROM Abonement_type
    UNION
    SELECT 'Max Abonement Price', MAX(Abonement_price) FROM Abonement_type;
    
    -- Количество тренировок по типам
    SELECT TT.training_type_name AS Statistic, COUNT(*) AS Value 
    FROM TRAINING T
    JOIN Training_type TT ON T.Id_training_type = TT.Id_training_type
    GROUP BY TT.training_type_name;
END;
GO

-- Хранимая процедура для отчетов
CREATE PROCEDURE sp_GenerateReport_CustomerTrainings
    @StartDate DATE,
    @EndDate DATE
AS
BEGIN
    SELECT 
        C.C_fullname AS 'Customer',
        COUNT(T.Id_training_type) AS 'Training Count',
        STRING_AGG(TT.training_type_name, ', ') AS 'Training Types'
    FROM CUSTOMER C
    LEFT JOIN TRAINING T ON C.Id_customer = T.Id_customer
    LEFT JOIN Training_type TT ON T.Id_training_type = TT.Id_training_type
    WHERE T.Training_date BETWEEN @StartDate AND @EndDate
    GROUP BY C.C_fullname;
END;
GO

CREATE PROCEDURE sp_GenerateReport_TrainerWorkload
AS
BEGIN
    SELECT 
        T.T_fullname AS 'Trainer',
        COUNT(TR.Id_training_type) AS 'Training Count',
        S.Specialozation_name AS 'Specialization'
    FROM TRAINER T
    LEFT JOIN TRAINING TR ON T.Id_trainer = TR.Id_trainer
    JOIN Specialization S ON T.id_specialization = S.Id_specialization
    GROUP BY T.T_fullname, S.Specialozation_name;
END;
GO

CREATE PROCEDURE sp_GenerateReport_AbonementPopularity
AS
BEGIN
    SELECT 
        AT.abonement_type_name AS 'Abonement Type',
        COUNT(A.Id_abonement) AS 'Count',
        SUM(AT.Abonement_price) AS 'Total Revenue'
    FROM Abonement_type AT
    LEFT JOIN ABONEMENT A ON AT.Id_abonement_type = A.Id_abonement_type
    GROUP BY AT.abonement_type_name;
END;
GO






-- Хранимая процедура для фильтрации тренеров
CREATE PROCEDURE sp_FilterTrainers
    @FullName NVARCHAR(50) = NULL,
    @PhoneNumber NVARCHAR(9) = NULL,
    @SpecializationId SMALLINT = NULL
AS
BEGIN
    SELECT 
        ROW_NUMBER() OVER (ORDER BY T.Id_trainer) AS RowNum,
        T.Id_trainer AS 'ID',
        T.T_fullname AS 'Full Name',
        T.Trainer_telefon_number AS 'Phone Number',
        S.Specialozation_name AS 'Specialization'
    FROM TRAINER T
    JOIN Specialization S ON T.id_specialization = S.Id_specialization
    WHERE 
        (@FullName IS NULL OR T.T_fullname LIKE '%' + @FullName + '%')
        AND (@PhoneNumber IS NULL OR T.Trainer_telefon_number LIKE '%' + @PhoneNumber + '%')
        AND (@SpecializationId IS NULL OR T.id_specialization = @SpecializationId);
END;
GO

-- Хранимая процедура для фильтрации абонементов
CREATE PROCEDURE sp_FilterAbonements
    @AbonementTypeId SMALLINT = NULL,
    @MinValidity INT = NULL
AS
BEGIN
    SELECT 
        ROW_NUMBER() OVER (ORDER BY A.Id_abonement) AS RowNum,
        A.Id_abonement AS 'ID',
        A.VALIDITY AS 'Validity (Days)',
        AT.abonement_type_name AS 'Abonement Type',
        AT.Abonement_price AS 'Price'
    FROM ABONEMENT A
    JOIN Abonement_type AT ON A.Id_abonement_type = AT.Id_abonement_type
    WHERE 
        (@AbonementTypeId IS NULL OR A.Id_abonement_type = @AbonementTypeId)
        AND (@MinValidity IS NULL OR A.VALIDITY >= @MinValidity);
END;
GO

-- Хранимая процедура для фильтрации тренировок
CREATE PROCEDURE sp_FilterTrainings
    @TrainingTypeId SMALLINT = NULL,
    @StartDate DATE = NULL,
    @EndDate DATE = NULL
AS
BEGIN
    SELECT 
        ROW_NUMBER() OVER (ORDER BY T.Id_training_type, T.Training_date) AS RowNum,
        T.Id_training_type AS 'Training Type ID',
        TT.training_type_name AS 'Training Type',
        T.Training_date AS 'Date',
        TR.T_fullname AS 'Trainer',
        C.C_fullname AS 'Customer'
    FROM TRAINING T
    JOIN Training_type TT ON T.Id_training_type = TT.Id_training_type
    JOIN TRAINER TR ON T.Id_trainer = TR.Id_trainer
    JOIN CUSTOMER C ON T.Id_customer = C.Id_customer
    WHERE 
        (@TrainingTypeId IS NULL OR T.Id_training_type = @TrainingTypeId)
        AND (@StartDate IS NULL OR T.Training_date >= @StartDate)
        AND (@EndDate IS NULL OR T.Training_date <= @EndDate);
END;
GO

