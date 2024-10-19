ALTER TABLE AspNetUsers
ADD Customer_Tbl_ID INT NULL;

ALTER TABLE AspNetUsers
ADD CONSTRAINT FK_AspNetUsers_Customer_CustomerId FOREIGN KEY (Customer_Tbl_ID) REFERENCES Customer(CustomerID);
