import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { PersonDetail } from '../../shared/person-detail.model';
import { PersonDetailService } from '../../shared/person-detail.service';

@Component({
  selector: 'app-person-form',
  templateUrl: './person-form.component.html',
  styleUrls: ['./person-form.component.css']
})
export class PersonFormComponent implements OnInit {

  public errorMessage: string = '';

  constructor(public service: PersonDetailService, private router: Router) { }

  ngOnInit(): void {
  }

  gotoAccounts(person_code: number, form: NgForm) {

    this.resetForm(form);
   
    this.router.navigate(['/accounts-list'], {

      queryParams: {
        person_code: person_code
      }
    });

  }

  resetForm(form: NgForm) {
    form.form.reset();
    this.service.formData = new PersonDetail();
    this.errorMessage = '';
  }
  onSubmit(form: NgForm) {
    if (this.service.formData.code == 0)
      this.insertRecord(form);
    else
      this.updateRecord(form);
  }

  insertRecord(form: NgForm) {
    this.service.postPaymentDetail().subscribe(
      res => {
        this.resetForm(form);
        this.service.refreshList();
      },
      err => { console.log(err); this.errorMessage = err.error.Message }
    )
  }

  updateRecord(form: NgForm) {
    this.service.putPaymentDetail().subscribe(
      res => {
        this.resetForm(form);
        this.service.refreshList();
      },
      err => {
        console.log(err);
      }
    )
  }
}
