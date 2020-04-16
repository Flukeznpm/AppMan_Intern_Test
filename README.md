# API Testing
This API is prepared to test the HTTP Method with ASP.NET
> Start Project at 10 Apr 2020
## Repository Description
```PORT``` https/localhost:5001
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
