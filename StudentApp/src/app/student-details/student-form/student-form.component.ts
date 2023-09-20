import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { StudentService } from 'src/app/shared/student.service';
import { Student,City } from 'src/app/shared/student.model';
import { filter } from 'rxjs';
 @Component({
  selector: 'app-student-form',
  templateUrl: './student-form.component.html',
  styleUrls: ['./student-form.component.css']
 })
export class StudentFormComponent implements OnInit{
  filteredCity:City[]=[];
  stateID:string='';
  constructor(public studService:StudentService, public toast:ToastrService) { }
  isSlide:string='off';
  ngOnInit() {
    this.studService.getStates().subscribe(data=> {
        this.studService.listState=data;
    });

    this.studService.getCities().subscribe(data=> {
      this.studService.listCity=data;
  });
  }
   submit(form:NgForm)
  {
    if(this.studService.studentData.id==0)
      this.insertStudent(form);
     else
     this.updateStudent(form);
  }
  insertStudent(myform:NgForm)
  {
    this.studService.saveStudent().subscribe(d=> {
     this.resetForm(myform);
     this.refereshData();
     this.toast.success('Success','Record Saved');
    });
  }
  updateStudent(myform:NgForm)
  {
    this.studService.updateStudent().subscribe(d=> {
      this.resetForm(myform);
      this.refereshData();
      this.toast.warning('Success','Record Updated');
    });
  }
  resetForm(myform:NgForm)
  {
    myform.form.reset(myform.value);
    this.studService.studentData=new Student();
    this.hideShowSlide();
  }
  refereshData()
  {
    this.studService.getStudents().subscribe(res=>{
      this.studService.listStudent=res;
    });
  }
  hideShowSlide()
  {
    /* if(this.checkBox.nativeElement.checked)
    {
      this.checkBox.nativeElement.checked=false;
      this.isSlide='off';
    }
    else
    {
      this.checkBox.nativeElement.checked=true;
      this.isSlide='on';
    } */
  }

  onStateChange(selectedStateId:string)
  {
      this.studService.getCitiesbyId(parseInt(selectedStateId,10)).subscribe(data=> {
        this.studService.listCity=data;
    });
  }
 }



