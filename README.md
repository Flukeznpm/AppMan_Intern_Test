# API Testing
This API is prepared to test the HTTP Method with ASP.NET
> Start Project at 10 Apr 2020

## Repository Description & API
```Database``` PostgreaSQL

```PORT``` https://localhost:5001
1. Student API
- ```GET``` 
  * /students -> return รายชื่อของนักศึกษาทั้งหมด
  * /students/:id -> return ข้อมูลของนักศึกษาที่ id ตรงกับใน database + รายชื่อของมหาวิทยาลัยที่นักศึกษาศึกษาอยู่ทั้งหมด
- ```POST``` 
  * /students -> เพิ่ม นักศึกษา
- ```PUT```
  * /students/:id -> แก้ไขข้อมูล นักศึกษา ที่ id ตรงกับใน database
- ```DELETE``` 
  * /students/:id -> ลบ นักศึกษา ที่ id ตรงกับใน database

2. University SPI
- ```GET``` 
  * /univercities -> return รายชื่อของมหาวิทยาลัยทั้งหมด
  * /univercities/:id -> return ข้อมูลของมหาวิทยาลัยที่ id ตรงกับใน database + รายชื่อขอนักศึกษาที่ศึกษาอยู่ในมหาวิทยาลัยทั้งหมด
- ```POST``` 
  * /univercities -> เพิ่ม มหาวิทยาลัย
- ```PUT``` 
  * /univercities/:id -> แก้ไขข้อมูล มหาวิทยาลัย ที่ id ตรงกับใน database
- ```DELETE``` 
  * /univercities/:id -> ลบ มหาวิทยาลัย ที่ id ตรงกับใน database

3. Register Student in University
- ```POST``` 
  * /register -> เพิ่ม การศึกษาของนักศึกษา
  
## Guideline
1. Clone this Repository
2. run with ```Ctrl + F5```
3. Test with ```Postman```

## Sample data
1. Add Student
![screen1](https://user-images.githubusercontent.com/35445418/79427860-88f6ac00-7fef-11ea-83ef-3f7d68e57b74.jpg)
2. Add University
![screen2](https://user-images.githubusercontent.com/35445418/79427865-8ac06f80-7fef-11ea-84c4-407cdbd4192e.jpg)
3. Register Student in University
![screen3](https://user-images.githubusercontent.com/35445418/79427869-8b590600-7fef-11ea-8a18-26eedc6c1d0c.jpg)
4. GET Student
![screen4](https://user-images.githubusercontent.com/35445418/79427744-5b116780-7fef-11ea-8993-eddadae3e593.jpg)


