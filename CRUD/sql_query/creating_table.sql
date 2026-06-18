CREATE TABLE student (
	 id INT IDENTITY(1,1) PRIMARY KEY,
	name VARCHAR(255) NOT NULL,
	age INT NOT NULL,
	grade VARCHAR(10) NOT NULL
);	

INSERT INTO student (name, age, grade) VALUES ('Maruf', 20, 'A'), ('Asif', 22, 'B'), ('Sumon', 21, 'A'), ('Diana', 23, 'B'), ('Elena', 22, 'A')
,('Fahim', 20, 'C'), ('Gulshan', 21, 'B'), ('Himel', 22, 'A'), ('Ishrat', 23, 'C'), ('Jahid', 20, 'B'),('Kamal', 21, 'A'), ('Lina', 22, 'B'), ('Mizan', 23, 'C'), ('Nabila', 20, 'A'), ('Omar', 21, 'B');
