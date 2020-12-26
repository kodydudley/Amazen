-- CREATE TABLE profiles (
--     id VARCHAR(255) NOT NULL,
--     name VARCHAR(255) NOT NULL,
--     email VARCHAR(255) NOT NULL,
--     picture VARCHAR(255) NOT NULL,
--     PRIMARY KEY (id)
-- )

-- CREATE TABLE products (
--     id INT NOT NULL AUTO_INCREMENT,
--     title VARCHAR(255) NOT NULL,
--     description VARCHAR(500) NOT NULL,
--     picture VARCHAR(255) NOT NULL,
--     creatorId VARCHAR(255) NOT NULL,
--     PRIMARY KEY (id),
--     FOREIGN KEY (creatorId)
--         REFERENCES profiles(id)
--         ON DELETE CASCADE
-- )

-- ALTER TABLE products
-- ADD Price INT NOT NULL;

-- ALTER TABLE products 
-- DROP COLUMN Price;

-- ALTER TABLE products
-- ADD price INT NOT NULL;

-- ALTER TABLE products 
-- DROP COLUMN price;

-- ALTER TABLE products
-- ADD price DECIMAL (6, 2) NOT NULL DEFAULT 0;

-- ALTER TABLE products
-- ADD isAvailable TINYINT;

-- ALTER TABLE products
-- DROP COLUMN isAvailable;

-- CREATE TABLE wishlists (
--    id INT NOT NULL AUTO_INCREMENT,
--     PRIMARY KEY (id)
-- )

-- CREATE TABLE wishlistproducts(
--   id INT NOT NULL AUTO_INCREMENT,   
--   wishlistId INT,
--   productId INT,
--   creatorId VARCHAR(255) NOT NULL,

--   PRIMARY KEY (id),

--   FOREIGN KEY (wishlistId)
--   REFERENCES wishlists (id)
--   ON DELETE CASCADE,

--   FOREIGN KEY (productId)
--   REFERENCES products (id)
--   ON DELETE CASCADE,

--    FOREIGN KEY (creatorId)
--         REFERENCES profiles(id)
--         ON DELETE CASCADE
-- )

-- ALTER TABLE wishlists
-- ADD name VARCHAR(255) NOT NULL;
