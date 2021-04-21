import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { AccountDetail } from '../../shared/account-detail.model';
import { AccountsDetailService } from '../../shared/accounts-detail.service';

@Component({
  selector: 'app-accounts-form',
  templateUrl: './accounts-form.component.html',
  styleUrls: ['./accounts-form.component.css']
})
export class AccountsFormComponent implements OnInit {

  public person_code: number = 0;

  public errorMessage: string = '';

  constructor(private route: ActivatedRoute,public service: AccountsDetailService, private router: Router) {
   
  }

  ngOnInit() {
    const person_code: string = this.route.snapshot.queryParamMap.get('person_code');

    this.person_code = parseInt(person_code);
  }

  gotoTransactions(account_code: number, form: NgForm) {

    this.resetForm(form);
    this.router.navigate(['/transaction-list'], {

      queryParams: {
        account_code: account_code,
        person_code: this.person_code
      }
    });

  }

  resetForm(form: NgForm) {
    form.form.reset();
    this.service.formData = new AccountDetail();
    this.service.formData.person_code = this.person_code;
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
        this.service.refreshList(this.person_code);
      },
      err => { console.log(err); this.errorMessage = err.error.Message }
    )
  }

  updateRecord(form: NgForm) {
    this.service.putPaymentDetail().subscribe(
      res => {
        this.resetForm(form);
        this.service.refreshList(this.person_code);
      },
      err => {
        console.log(err);
      }
    )
  }

  goBack() {
    this.router.navigate(['/personslist']);
  }

}
