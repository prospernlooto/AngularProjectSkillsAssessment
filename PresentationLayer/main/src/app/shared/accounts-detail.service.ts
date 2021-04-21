import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { AccountDetail } from './account-detail.model';

@Injectable({
  providedIn: 'root'
})
export class AccountsDetailService {
  formData: AccountDetail = new AccountDetail();
  readonly baseURL = 'https://localhost:44341/api/Accounts/';
  list: AccountDetail[];

  constructor(private http: HttpClient) { }

  refreshList(person_code: number) {
    this.http.get(this.baseURL + `GetAccountsByPersonCode/${person_code}`)
      .toPromise()
      .then(res => this.list = res as AccountDetail[]);
  }

  postPaymentDetail() {
    return this.http.post(this.baseURL + 'AddAccounts', this.formData);
  }


  putPaymentDetail() {
    return this.http.post(this.baseURL + 'UpdateAccounts', this.formData);
  }

  deletePaymentDetail(code: number) {
    return this.http.get(this.baseURL + `DeleteAccount/${code}`)
      .toPromise()
      .then(res => this.list = res as AccountDetail[])
      .catch(err => alert(err.error.Message));
  }
}
