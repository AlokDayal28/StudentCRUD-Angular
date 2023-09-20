import { DatePipe } from '@angular/common';
import { Component, OnInit, ViewChild } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { StudentService } from '../shared/student.service';
import { Student } from '../shared/student.model';
@Component({
  selector: 'app-student-details',
  templateUrl: './student-details.component.html',
  styleUrls: ['./student-details.component.css']
})
export class StudentDetailsComponent implements OnInit {
  constructor(public studService:StudentService, public datepipe:DatePipe, public toast:ToastrService) { }
  public show:boolean = false;
  public buttonName:any = 'Add New';
  ngOnInit() {
    this.studService.getStudents().subscribe(data=>{
      this.studService.listStudent=data;
    });
  }

  populateStudent(selectedStudent:Student)
  {
    this.studService.studentData=selectedStudent;
  }

  delete(id:number)
  {
    if(confirm('Do you really want to delete this record?'))
    {
      this.studService.deleteStudent(id).subscribe(data=> {
        this.studService.getStudents().subscribe(data=>{
          this.studService.listStudent=data;
          this.toast.error('Success','Record Deleted');
        });
      },
      err=>{
      });
    }
  }

  toggle() {
    this.show = !this.show;
    if(this.show)
      this.buttonName = "Close";
    else
      this.buttonName = "Add New";
  }

 }
