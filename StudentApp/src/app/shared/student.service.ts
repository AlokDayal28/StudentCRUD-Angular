import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Student,State,City } from './student.model';
@Injectable({
  providedIn: 'root'
})
export class StudentService {

  constructor(private myhttp:HttpClient) { }
  studentUrl:string='https://localhost:7195/api/Student';
  listStudent:Student[]=[]; //For Getting Data EmployeeList
  listState:State[]=[];
  listCity:City[]=[];
  studentData:Student=new Student(); //for post data / Insert data

  getStudents():Observable<Student[]>
  {
    return this.myhttp.get<Student[]>(this.studentUrl);
  }

  getStates():Observable<State[]>
  {
    return this.myhttp.get<State[]>(this.studentUrl + '/States');
  }

  getCities():Observable<City[]>
  {
    return this.myhttp.get<City[]>(this.studentUrl + '/Cities');
  }

getCitiesbyId(id:number):Observable<City[]>
{
  return this.myhttp.get<City[]>((this.studentUrl + '/City/'+id))
}

  saveStudent()
  {
    console.log('Add');
    console.log(this.studentUrl);
    console.log(this.studentData);
    return this.myhttp.post(this.studentUrl,this.studentData);
  }

  updateStudent()
  {
    console.log('Edit');
    console.log(this.studentUrl);
    console.log(this.studentData);
    return this.myhttp.put(`${this.studentUrl}/${this.studentData.id}` ,this.studentData);
  }

  deleteStudent(id:number)
  {
    return this.myhttp.delete(`${this.studentUrl}/${id}`);
  }
}
