import mysql.connector

def connect_to_db_vulnerable():
    # Hardcoded credentials (Not Recommended)
    username = "dbuser"
    password = "password123"
    database = "my_database"
    
    connection = mysql.connector.connect(
        host="localhost",
        user=username,
        password=password,
        database=database
    )
    
    cursor = connection.cursor()
    cursor.execute("SELECT * FROM Users;")
    connection.close()
