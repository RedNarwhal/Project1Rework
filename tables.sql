CREATE TABLE customer (custId int GENERATED ALWAYS AS IDENTITY, firstName varchar(50) NOT NULL, lastName varchar(50) NOT NULL, PRIMARY KEY(custId));

  INSERT INTO customer(firstName, lastName) VALUES ('Josh', 'Bertrand');

CREATE TABLE store (storeId int GENERATED ALWAYS AS IDENTITY, storeName varchar(50), PRIMARY KEY(storeId));

  INSERT INTO store(storeName) VALUES ('Samples Store');

CREATE TABLE product (productId int GENERATED ALWAYS AS IDENTITY, productDescription varchar(50) NOT NULL, productPrice decimal(10, 2), PRIMARY KEY(productId));

  INSERT INTO product(productDescription, productPrice) VALUES ('Sample Battery Pack', 3.99);

CREATE TABLE storeInventory (storeInvId int GENERATED ALWAYS AS IDENTITY, storeId int NOT NULL, productId int NOT NULL, quantity int NOT NULL, PRIMARY KEY(storeInvId), FOREIGN KEY(storeId) REFERENCES store(storeId), FOREIGN KEY(productId) REFERENCES product(productId));

CREATE TABLE orderInst (orderId int GENERATED ALWAYS AS IDENTITY, orderDate date, customerId int NOT NULL, storeId int NOT NULL, PRIMARY KEY(orderId), FOREIGN KEY(customerId) REFERENCES customer(custId), FOREIGN KEY(storeId) REFERENCES store(storeId));

CREATE TABLE orderHistory (orderHistoryId int GENERATED ALWAYS AS IDENTITY, orderId int NOT NULL, productId int NOT NULL, PRIMARY KEY(orderHistoryId), FOREIGN KEY(orderId) REFERENCES orderInst(orderId), FOREIGN KEY(productId) REFERENCES product(productId));

