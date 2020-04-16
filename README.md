# API Testing
This API is prepared to test the HTTP Method with ASP.NET
> Start Project at 10 Apr 2020
## Repository Description
- Student API
1. **GET** 
  * /students -> return รายชื่อของนักศึกษาทั้งหมด
2. **GET** 
  * /students/:id -> return ข้อมูลของนักศึกษาที่ id ตรงกับใน database + รายชื่อของมหาวิทยาลัยที่นักศึกษาศึกษาอยู่ทั้งหมด
3. **POST** 
  * /students -> เพิ่ม นักศึกษา
4. **PUT** 
  * /students/:id -> แก้ไขข้อมูล นักศึกษา ที่ id ตรงกับใน database
5. **DELETE** 
  * /students/:id -> ลบ นักศึกษา ที่ id ตรงกับใน database
