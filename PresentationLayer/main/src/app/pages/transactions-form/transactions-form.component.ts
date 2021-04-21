import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { TransactionDetail } from '../../shared/transaction-detail.model';
import { TransactionDetailService } from '../../shared/transaction-detail.service';

@Component({
  selector: 'app-transactions-form',
  templateUrl: './transactions-form.component.html',
  styleUrls: ['./transactions-form.component.css']
})
export class TransactionsFormComponent implements OnInit {

  public account_code: number = 0;
  public error_message: string = '';
  private person_code: number = 0;

  constructor(private route: ActivatedRoute, public service: TransactionDetailService, private router: Router) { }

  ngOnInit() {
    const account_code: string = this.route.snapshot.queryParamMap.get('account_code');
    const person_code: string = this.route.snapshot.queryParamMap.get('person_code');

    this.account_code = parseInt(account_code);
    this.person_code = parseInt(person_code);
  }

  resetForm(form: NgForm) {
    form.form.reset();
    this.service.formData = new TransactionDetail();
    this.service.formData.account_code = this.account_code;
    this.error_message = '';
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
        this.service.refreshList(this.account_code);
      },
      err => {
        console.log(err);
        this.error_message = err.error.Message;
      }
    )
  }

  updateRecord(form: NgForm) {
    this.service.putPaymentDetail().subscribe(
      res => {
        this.resetForm(form);
        this.service.refreshList(this.account_code);
      },
      err => {
        console.log(err);
        this.error_message = err.error.Message;
      }
    )
  }

  gotoAccounts() {


    this.router.navigate(['/accounts-list'], {

      queryParams: {
        person_code: this.person_code
      }
    });

  }


}
