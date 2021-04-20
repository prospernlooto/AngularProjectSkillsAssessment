import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { PersonDetail } from '../../shared/person-detail.model';
import { PersonDetailService } from '../../shared/person-detail.service';

@Component({
  selector: 'app-person-detail-form',
  templateUrl: './person-detail-form.component.html',
  styles: [
  ]
})
export class PersonDetailFormComponent implements OnInit {

  constructor(public service: PersonDetailService) { }

  ngOnInit(): void {
  }

  resetForm(form: NgForm) {
    form.form.reset();
    this.service.formData = new PersonDetail();
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
      err => { console.log(err); }
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
