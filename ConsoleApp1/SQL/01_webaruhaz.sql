/*
CREATE TABLE Users (
    UserId INT AUTO_INCREMENT PRIMARY KEY,
    Username VARCHAR(255),
    UserEmail VARCHAR(255),
    UserPassword VARCHAR(255)
);

CREATE TABLE Product (
    ProductId INT AUTO_INCREMENT PRIMARY KEY,
    ProductPrice DECIMAL,
    ProductName VARCHAR(255)
);

CREATE TABLE Service (
    ServiceId INT AUTO_INCREMENT PRIMARY KEY,
    ServicePrice DECIMAL,
    ServiceName VARCHAR(255)
);

CREATE TABLE Address (
    AddressId INT AUTO_INCREMENT PRIMARY KEY,
    UserId INT,
    Address_Type ENUM('billing', 'homeaddress'),
    Country VARCHAR(255),
    City VARCHAR(255),
    PostalCode INT,
    StreetName VARCHAR(255),
    Building VARCHAR(255),
    Floor INT,
    Door INT,
    FOREIGN KEY (UserId) REFERENCES Users(UserId)
);

CREATE TABLE Orders (
    OrderId INT AUTO_INCREMENT PRIMARY KEY,
    UserId INT,
    OrderDate DATE,
    TotalAmount DECIMAL,
    AddressId INT,  
    FOREIGN KEY (UserId) REFERENCES Users(UserId),
    FOREIGN KEY (AddressId) REFERENCES Address(AddressId)
);

CREATE TABLE Delivery (
    DeliveryId INT AUTO_INCREMENT PRIMARY KEY,
    OrderId INT,
    DeliveryStatus VARCHAR(255),
    TrackingNumber VARCHAR(255),
    EstimatedArrival DATE,
    FOREIGN KEY (OrderId) REFERENCES Orders(OrderId)
);

CREATE TABLE Payment (
    PaymentId INT AUTO_INCREMENT PRIMARY KEY,
    OrderId INT,
    PaymentDate DATE,
    PaymentMethod VARCHAR(255),
    PaymentStatus VARCHAR(255),
    Amount DECIMAL,
    FOREIGN KEY (OrderId) REFERENCES Orders(OrderId)
);

CREATE TABLE Cart (
    CartId INT AUTO_INCREMENT PRIMARY KEY,
    UserId INT,
    ProductId INT,
    ServiceId INT,
    Quantity INT,
    AddedDate DATE,
    FOREIGN KEY (UserId) REFERENCES Users(UserId),
    FOREIGN KEY (ProductId) REFERENCES Product(ProductId),
    FOREIGN KEY (ServiceId) REFERENCES Service(ServiceId)
);
*/